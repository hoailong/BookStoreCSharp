$(document).ready(function () {
    let g_book;
    let g_state;
    init();
    console.log(g_book);
    console.log(g_state);

    $(document).on('click', '.btn-delete-row', function () {
        $(this).closest('.book-row').remove();
        $('#sumBook').text($('.book-row').length);
    });

    $(document).on('change', '.bookName', function () {
        $(this).closest('.book-row').find('.rentPrice').val(getRentPriceById($(this).val()));
    });

    $('.btn-add-row').click(function () {
        $('#row-book').find("select").each(function (index) {
            $(this).select2('destroy');
        });
        $("#row-book").clone().appendTo(".book-area");
        $('.rentPrice').last().val('');
        setSelect2();
        $('#sumBook').text($('.book-row').length);
    });

    $('#customerPhone').keyup(function (e) {
        if (e.keyCode == 13) {
            let customerPhone = $(this).val().trim(); 
            if (customerPhone !== '') {
                loadCustomer(customerPhone);
            }
        }
    });

    $('#customerPhone').change(function () {
        $('#customerId').val('0');
        let customerPhone = $(this).val();
        if (customerPhone.length > 8) {
            loadCustomer(customerPhone);
        }
        $('#customer-phone').text(customerPhone);
    });

    $('#customerName').change(function () {
        $('#customer-name').text($(this).val());
    });


    function setSelect2() {
        $(".bookName").select2({
            placeholder: "Chọn tên sách",
            allowClear: true
        });

        $(".stateId").select2({
            placeholder: "Chọn trạng thái",
            allowClear: true
        });
    }

    function getRentPriceById(bookId) {
        return g_book.find(book => book.bookId == bookId).rentPrice;
    }

    function loadCustomer(customerPhone) {
        $.ajax({
            url: 'customer/getbyphone',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ customerPhone }),
            dataType: "json",
        }).done((resp) => {
            if (resp) {
                $('#customerId').val(resp.customerId);
                $('#customerName').val(resp.customerName).trigger('change');
                $('#address').val(resp.address);
                $('#birth').val(resp.birth);
                toastr.success('Khách hàng đã tồn tại!');
            } else {
                $('#customerId').val('0');
                toastr.error('Khách hàng chưa tồn tại!');
            }
        });
    }

    async function submitForm() {
        let customerId = $('#customerId').val();

        if (customerId === '0') {
            let new_customer = await saveCustormer();
            if (new_customer.customer) {
                customerId = new_customer.customer.customerId;
            } else {
                toastr.error(new_customer.error + ' - Nhập lại thông tin khách hàng!');
            }
        }

        let rentId;
        if (customerId !== '0') {
            //customerId = (customerId);
            let new_rent = await saveRent(customerId);
            rentId = new_rent.rent.rentId;

        }
        if (rentId) {
            let rent_detail = await saveRentDetail(rentId);
            console.log(rent_detail);
            if (rent_detail.done) {
                swal({ title: "Hoàn tất", text: "Thuê sách thành công!", type: "success" },
                    function () {
                        location.reload();
                    }
                );
            } else {
                toastr.error('Lỗi!' + JSON.stringify(rent_detail.error));
            }
        }
    }

    async function saveCustormer() {
        let customerId = $('#customerId').val()
        let customerPhone = $('#customerPhone').val();
        let customerName = $('#customerName').val();
        let birth = $('#birth').val();
        let address = $('#address').val();
        let gender = $("input[name='gender']:checked").val();
        let data = { customerId, customerPhone, customerName, birth, gender, address }

        const custormer = await $.ajax({
            url: 'customer/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        });
        return custormer;
    }

    async function saveRent(customerId) {
        customerId = parseInt(customerId)
        let employeeId = g_user.EmployeeId;
        let rentDate = moment().format('YYYY/MM/DD HH:mm:ss');
        let deposit = $('#deposit').val();
        let data = { rentDate, deposit, customerId, employeeId };

        const rent = await $.ajax({
            url: 'rentbook/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        });
        return rent;

    }

    async function saveRentDetail(rentId) {
        let payed = false;

        let rents = [];
        $(".book-row").each(function () {
            let bookId = $(this).find('.bookName').val();
            let stateId = $(this).find('.stateId').val();
            let rentPrice = $(this).find('.rentPrice').val();
            rents.push({ rentId, bookId, stateId, rentPrice, payed });
        });

        const rentDetail = await $.ajax({
            url: 'rentdetail/save',
            type: "POST",
            data: { 'rents': rents },
            dataType: "json"
        });

        if (rentDetail.done) {
            let updated = await updateQuantityBook();
            console.log(updated);
        }

        return rentDetail;

    }

    async function updateQuantityBook() {
        let books = [];
        $(".book-row").each(function () {
            let bookId = $(this).find('.bookName').val();
            books.push({ bookId });
        });
        const updated = await $.ajax({
            url: 'book/subquantity',
            type: "POST",
            data: { 'books': books },
            dataType: "json"
        });
        return updated;
    }

    function setValidatesStep() {
        $("#form").steps({
            bodyTag: "fieldset",
            onStepChanging: function (event, currentIndex, newIndex) {
                // Always allow going backward even if the current step contains invalid fields!
                if (currentIndex > newIndex) {
                    return true;
                }

                // Forbid suppressing "Warning" step if the user is to young
                if (newIndex === 3 && Number($("#age").val()) < 18) {
                    return false;
                }

                var form = $(this);

                // Clean up if user went backward before
                if (currentIndex < newIndex) {
                    // To remove error styles
                    $(".body:eq(" + newIndex + ") label.error", form).remove();
                    $(".body:eq(" + newIndex + ") .error", form).removeClass("error");
                }

                // Disable validation on fields that are disabled or hidden.
                form.validate().settings.ignore = ":disabled,:hidden";

                // Start validation; Prevent going forward if false
                return form.valid();
            },
            onStepChanged: function (event, currentIndex, priorIndex) {
                // Suppress (skip) "Warning" step if the user is old enough.
                if (currentIndex === 2 && Number($("#age").val()) >= 18) {
                    $(this).steps("next");
                }

                // Suppress (skip) "Warning" step if the user is old enough and wants to the previous step.
                if (currentIndex === 2 && priorIndex === 3) {
                    $(this).steps("previous");
                }
            },
            onFinishing: function (event, currentIndex) {
                var form = $(this);

                // Disable validation on fields that are disabled.
                // At this point it's recommended to do an overall check (mean ignoring only disabled fields)
                form.validate().settings.ignore = ":disabled";

                // Start validation; Prevent form submission if false
                return form.valid();
            },
            onFinished: function (event, currentIndex) {
                submitForm();
            }
        }).validate({
            errorPlacement: function (error, element) {
                element.before(error);
            },
            rules: {
                confirm: {
                    equalTo: "#password"
                }
            }
        });
    }

    function init() {
        setValidatesStep();
        let today = moment().format('YYYY/MM/DD');
        $('#rentDate').text(today);
        $('#employee-name').text(g_user.EmployeeName);
        $.ajax({
            url: 'book/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_book = resp;
            let opts = ``;
            g_book.forEach(e => {
                opts += `<option value="${e.bookId}">${e.bookName}</option>`;
            });
            $('.bookName').append(opts);
        });
        $.ajax({
            url: 'state/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_state = resp;
            let ops = ``;
            g_state.forEach(e => {
                ops += `<option value="${e.stateId}">${e.stateName}</option>`;
            });
            $('.stateId').append(ops);
        });
        $('#birth').datepicker({
            todayBtn: "linked",
            keyboardNavigation: false,
            forceParse: false,
            calendarWeeks: true,
            autoclose: true,
            format: 'dd/mm/yyyy'
        });
        setSelect2();

        //$('#categoryId, #publisherId, #typeId, #langId').select2().trigger('change');
    }
});