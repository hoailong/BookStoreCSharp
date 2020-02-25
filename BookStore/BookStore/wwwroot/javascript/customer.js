$(document).ready(function () {
    getData();

    $(document).on('click', '.edit', function () {
        $('#customer-modal').modal().show();
        tr = $(this).closest('tr')
        $('#customerId').val($(tr).attr('id'));
        $('#customerName').val($(tr).find('.customer-name').text());
        $('#customerPhone').val($(tr).find('.customer-phone').text());
        $('#address').val($(tr).find('.address').text());
        $('#birth').val($(tr).find('.birth').text());
        //let gender = $(tr).find('.gender').text();
        //gender === "Nữ" ? $("#girl").prop('checked', true) : $("#girl").prop('checked', false);
    });

    $(document).on('click', '.delete', function () {
        $('#customerIdDel').val($(this).closest('tr').attr('id'));
        $('#confirm-modal').modal('show');
    });

    $(document).on('click', '#check-all', function (event) {
        alert('done');
    });

    //$(document).on('change', '#check-all', function () {
    //    console.log('check');
    //    if (this.checked) {
    //        console.log('check-all');
    //    } else {
    //        console.log('not-check-all');
    //    }
    //});

    $('#btn-create').click(function () {
        clearForm();
        $('#customer-modal').modal('show');
    });

    $('#btn-delete-mul').click(function () {
        let multiDel = [...$('.del-customer:checkbox:checked')].map(elem => $(elem).closest('tr').attr('id'));
        console.log(multiDel);
        alert('Updating...');
    });

    $('#btn-save').click(function () {
        let customerId = $('#customerId').val();
        let customerName = $('#customerName').val();
        let customerPhone = $('#customerPhone').val();
        let address = $('#address').val();
        let birth = $('#birth').val();
        let gender = $("input[name='gender']:checked").val();
        let data = {
            customerId,
            customerName,
            customerPhone,
            address,
            birth,
            gender
        }
        $.ajax({
            url: 'customer/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        }).done((resp) => {
            if (resp) {
                if (resp.error) {
                    toastr.error(resp.error);
                } else {
                    $('#customer-modal').modal('hide');
                    let customer = resp.customer;
                    let newRow = `<tr id="${customer.customerId}">
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-customer" name="input[]"></td>
                                    <td>1</td>
                                    <td class="customer-name">${customer.customerName}</td>
                                    <td class="customer-phone">${customer.customerPhone}</td>
                                    <td class="birth">${customer.birth}</td>
                                    <td class="gender">${showGender(customer.gender)}</td>
                                    <td class="address">${customer.address}</td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                                </tr>`;
                    if (resp.create) {
                        toastr.success('Thêm mới thành công!');
                        $('#customer-table tbody').append(newRow);
                        clearForm();
                    } else if (resp.update) {
                        $(`#customer-table #${customer.customerId}`).replaceWith(newRow);
                        toastr.success('Cập nhật thành công!');
                        clearForm();
                    }
                    loadIcheck();
                }
            } else {
                toastr.erorr('Lỗi!');
            }
        });
    });

    $('#btn-delete').click(function () {
        let customerId = $('#customerIdDel').val();
        $.ajax({
            url: 'customer/delete',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ customerId }),
            dataType: "json"
        }).done((resp) => {
            $('#confirm-modal').modal('hide');
            $(`#customer-table #${customerId}`).remove();
            if (resp.delete) {
                toastr.success('Xoá thành công!');
            } else {
                toastr.erorr('Lỗi!');
            }
        });
    });


    $('#txtSearch').on('keyup change', filterData);

    $('#btn-search').click(filterData);

    function filterData() {
        let key = $('#txtSearch').val().toUpperCase();
        $('.customer-name').each((i, v) => {
            if ($(v).text().toUpperCase().includes(key)) {
                $(v).closest('tr').removeClass('hidden');
            } else {
                $(v).closest('tr').addClass('hidden');
            }
        });
    }

    function clearForm() {
        $('#customerId').val(0);
        $('#customerName').val('');
        $('#customerPhone').val('');
        $('#birth').val('01/01/1990');
        $("input[name='gender'][value='1']").prop('checked', true);
        $('#address').val('');
    }

    function getData() {
        $.ajax({
            url: 'customer/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading
        }).done((resp) => {
            toggleLoading();
            console.log(resp);
            renderTable(resp);
        });
    }

    function renderTable(data) {
        $table = $('#customer-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((customer, index) => {
                tbody += `<tr id="${customer.customerId}">
                                <td style="text-align: center"><input type="checkbox" class="i-checks del-customer" name="input[]"></td>
                                <td>${index + 1}</td>
                                <td class="customer-name">${customer.customerName}</td>
                                <td class="customer-phone">${customer.customerPhone}</td>
                                <td class="birth">${customer.birth}</td>
                                <td class="gender">${showGender(customer.gender)}</td>
                                <td class="address">${customer.address}</td>
                                <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                            </tr>`
            });
            $table.append(tbody);
            loadIcheck();
        }
    }
});