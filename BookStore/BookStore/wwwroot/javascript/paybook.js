$(document).ready(function () {
    let g_state;
    let g_penalty;
    let g_book;
    init();
    console.log(g_state);
    console.log(g_penalty);
    console.log(g_book);

    $(document).on('click', '.ui-sortable-handle', function () {
        let $elem = $(this).find('button i');
        if ($elem.hasClass('fa-arrow-down')) {
            $elem.removeClass('fa-arrow-down').addClass('fa-arrow-left');
        } else {
            $elem.removeClass('fa-arrow-left').addClass('fa-arrow-down');
        }
    });

    $(document).on('click', '.pay', function () {
        let tr = $(this).closest('tr');
        let rentId = tr.closest('.panel-collapse').attr('id');
        let bookId = tr.find('.bookId').text();
        let bookName = tr.find('.bookName').text();
        let stateId = tr.find('.state').attr('data-state');
        let rentPrice = tr.find('.rentPrice').text();
        let rentDate = tr.closest('ul').find(`li[href='#${rentId}']`).find('.rent-date').text().trim();
        let table = tr.closest('tbody');
        let newRowPay = `<tr data-rendId="${rentId}" data-state="${stateId}" data-rentPrice="${rentPrice}">
                            <td class="rentId">${rentId}</td>
                            <td class="bookId">${bookId}</td>
                            <td class="bookName">${bookName}</td>
                            <td>
                                <select class="form-control penalty">
                                    <option value="">Không</option>
                                </select>
                            </td>
                            <td class="intoMoney" data-rentMoney="${calIntoMoney(rentDate, rentPrice)}">${calIntoMoney(rentDate, rentPrice)}</td>
                            <td style="text-align: center"><a class="btn btn-sm btn-danger cancer-pay"><i class="fa fa-reply" aria-hidden="true"></i></a></td>
                        </tr>`;
        $('#pay-detail-table tbody').append(newRowPay);
        loadPenaltyOption();
        updateToTalMoney();
        tr.remove();
        checkEmptyRentList(table, rentId)
    });

    $(document).on('click', '.cancer-pay', function () {
        let tr = $(this).closest('tr');
        let rentId = tr.attr('data-rendId');
        let bookId = tr.find('.bookId').text();
        let bookName = tr.find('.bookName').text();
        let stateId = tr.attr('data-state');
        let rentPrice = tr.attr('data-rentPrice');
        let table = $(`.panel-collapse[id='${rentId}']`).find('tbody');
        let newRowPay = `<tr>
                            <td class="bookId">${bookId}</td>
                            <td class="bookName">${bookName}</td>
                            <td class="state" data-state="${stateId}">${showState(stateId)}</td>
                            <td class="rentPrice">${rentPrice}</td>
                            <td style="text-align: center"><a class="btn btn-sm btn-success pay"><i class="fa fa-sign-in" aria-hidden="true"></i></a></td>
                        </tr>`;
        checkCollapedRentList(table, rentId);
        table.append(newRowPay);
        tr.remove();
        updateToTalMoney();
    });

    $(document).on('change', '.penalty', function () {
        let penaltyId = $(this).children("option:selected").val();
        let intoMoney = $(this).closest('tr').find('.intoMoney').attr('data-rentMoney');
        let penaltyPrice = 0;
        if (penaltyId != '') {
            penaltyPrice = getPenaltyPrice(penaltyId);
        }
        let newIntoMoney = parseInt(intoMoney) + penaltyPrice;
        $(this).closest('tr').find('.intoMoney').text(newIntoMoney);
        updateToTalMoney();
    });

    $('#search-rent').click(function () {
        $('.ui-sortable').removeClass('hidden');
        customerId = $('#customerId').val();
        if (customerId !== '') {
            $.ajax({
                url: 'rentbook/GetByCustomer',
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({ customerId }),
                dataType: "json",
                beforeSend: toggleLoading,
            }).done((resp) => {
                console.log(resp);
                showRent(resp);
                toggleLoading();
            });
        } else {
            toastr.error('Khách hàng chưa tồn tại!');
            clearRent();    
        }
    });

    $('#customerPhone').keyup(function (e) {
        if (e.keyCode == 13) {
            let customerPhone = $(this).val().trim();
            if (customerPhone !== '') {
                loadCustomerByPhone(customerPhone);
            }
        }
    });

    $('#customerId').keyup(function (e) {
        if (e.keyCode == 13) {
            let customerId = $(this).val().trim();
            if (customerId !== '') {
                loadCustomerById(customerId);
            }
        }
    });

    $('#customerPhone').change(function () {
        $('#customerId').val('');
        let customerPhone = $(this).val();
        if (customerPhone.length > 8) {
            loadCustomerByPhone(customerPhone);
        }
    });

    function clearRent() {
        $('#rent-list').empty();
        $('#pay-detail-table tbody').empty();
        $('#totalDeposit').text('0');
        $('#totalRentMoney').text('0');
        $('#totalMoney').text('0');
    }

    function showRent(rents) {
        $('#rent-list').empty();
        let length = rents.length;
        if (length > 0) {
            let row = ``;
            rents.forEach(async (rent, i) => {
                let rentDetail = await getRentDetai(rent.rentId)
                if (rentDetail.length > 0 && rentDetail.find(e => !e.payed)) {
                    row += `<li class="success-element ui-sortable-handle collapsed" id="task13" data-toggle="collapse" data-parent="#accordion" href="#${rent.rentId}" aria-expanded="false">
                        <h3>Mã thuê: <strong class="text-danger">#${rent.rentId}</strong>&nbsp;<span class="label label-warning">${rentDetail.length} quyển</span></h3>
                        <button class="pull-right btn btn-xs btn-primary"><i class="fa fa-arrow-down" aria-hidden="true"></i></button>
                        <div class="agile-detail rent-date">
                            <i class="fa fa-clock-o"></i> ${moment(rent.rentDate).format('YYYY/MM/DD HH:mm:ss')}
                        </div>
                        <div class="agile-detail deposit">
                            <i class="fa fa-money" aria-hidden="true"></i> ${rent.deposit}
                        </div>
                    </li>
                    <div id="${rent.rentId}" class="panel-collapse collapse in" aria-expanded="true">
                        <div class="panel-body">
                            <table class="table table-hover table-striped table-bordered rent-list-table">
                                <thead>
                                    <tr>
                                        <th width="15%">Mã sách</th>
                                        <th width="30%">Tên sách</th>
                                        <th width="20%">Tình trạng</th>
                                        <th width="15%">Giá thuê</th>
                                        <th width="10%" style="text-align: center">Trả</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    ${showRentDetail(rentDetail)}
                                </tbody>
                            </table>
                        </div>
                    </div>`;
                }
                length--;
                if (length === 0) {
                    $('#rent-list').append(row);
                }
            });
        }
    }

    function showRentDetail(rents) {
        let row = ``;
        rents.forEach(rent => {
            if (!rent.payed) {
                row += `<tr>
                            <td class="bookId">${rent.bookId}</td>
                            <td class="bookName">${showBookName(rent.bookId)}</td>
                            <td class="state" data-state="${rent.stateId}">${showState(rent.stateId)}</td>
                            <td class="rentPrice">${rent.rentPrice}</td>
                            <td style="text-align: center"><a class="btn btn-sm btn-success pay"><i class="fa fa-sign-in" aria-hidden="true"></i></a></td>
                       </tr>`;
            }
        });
        return row;
    }


    $('#confirm-pay').click(async function () {
        let payId;
        if ($("#pay-detail-table tbody").html().trim() !== '') {
            let new_pay = await savePay();
            payId = new_pay.pay.payId;
        }
        if (payId) {
            console.log(payId);
            let pay_detail = await savePayDetail(payId);
            console.log(pay_detail);
            if (pay_detail.done) {
                swal({ title: "Hoàn tất", text: "Trả sách thành công!", type: "success" },
                    function () {
                        location.reload();
                    }
                );
            } else {
                toastr.error('Lỗi!' + JSON.stringify(pay_detail.error));
            }
        }
    });

    async function savePay() {
        let employeeId = g_user.EmployeeId;
        let customerId = $('#customerId').val();
        let payDate = moment().format('YYYY/MM/DD HH:mm:ss');
        let totalMoney = $('#totalMoney').text();
        let data = { employeeId, customerId, payDate, totalMoney };
        console.log(data);
        const pay = await $.ajax({
            url: 'paybook/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        });
        return pay;

    }

    async function savePayDetail(payId) {
        let pays = [];
        $("#pay-detail-table tbody tr").each(function () {
            let bookId = $(this).find('.bookId').text();
            let rentId = $(this).find('.rentId').text();
            let penaltyId = $(this).find('.penalty').val();
            let intoMoney = $(this).find('.intoMoney').text();
            pays.push({ payId, bookId, rentId, penaltyId, intoMoney });
        });

        const payDetail = await $.ajax({
            url: 'paydetail/save',
            type: "POST",
            data: { 'pays': pays },
            dataType: "json"
        });

        if (payDetail.done) {
            let updated = await updateQuantityBook();
            let updatedPay = await updatedPayed();
            console.log(updated);
            console.log(updatedPay);
        }

        return payDetail;

    }

    async function updateQuantityBook() {
        let books = [];
        $("#pay-detail-table tbody tr").each(function () {
            let bookId = $(this).find('.bookId').text();
            books.push({ bookId });
        });
        const updated = await $.ajax({
            url: 'book/addquantity',
            type: "POST",
            data: { 'books': books },
            dataType: "json"
        });
        return updated;
    }

    async function updatedPayed() {
        let rents = [];
        $("#pay-detail-table tbody tr").each(function () {
            let bookId = $(this).find('.bookId').text();
            let rentId = $(this).find('.rentId').text();
            rents.push({ bookId, rentId });
        });
        const updated = await $.ajax({
            url: 'rentdetail/updatepayed',
            type: "POST",
            data: { 'rents': rents },
            dataType: "json"
        });
        return updated;
    }

    async function getRentDetai(rentId) {
        return await $.ajax({
            url: 'RentDetail/GetByRentId',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ rentId }),
            dataType: "json",
        })
    }

    function loadCustomerByPhone(customerPhone) {
        $.ajax({
            url: 'customer/getbyphone',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ customerPhone }),
            dataType: "json",
        }).done((resp) => {
            if (resp) {
                $('#customerId').val(resp.customerId);
                $('#customerName').val(resp.customerName);
                toastr.success('Khách hàng đã tồn tại!');
            } else {
                toastr.error('Khách hàng chưa tồn tại!');
            }
        });
    }

    function loadCustomerById(customerId) {
        $.ajax({
            url: 'customer/getbyid',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ customerId }),
            dataType: "json",
        }).done((resp) => {
            if (resp) {
                $('#customerPhone').val(resp.customerPhone);
                $('#customerName').val(resp.customerName);
                toastr.success('Khách hàng đã tồn tại!');
            } else {
                toastr.error('Khách hàng chưa tồn tại!');
            }
        });
    }

    function calIntoMoney(dateRent, rentPrice) {
        let curent = moment().format('YYYY/MM/DD');
        dateRent = moment(dateRent).format('YYYY/MM/DD');
        let dayRent = moment(curent).diff(moment(dateRent), 'days') + 1;
        return rentPrice * dayRent;
    }

    function checkEmptyRentList(table, rentId) {
        if (table.html().trim() === '') {
            let deposit = table.closest('ul').find(`li[href='#${rentId}']`).find('.deposit').text().trim();
            uploadDeposit(deposit, 1);
            table.closest('.panel-collapse').removeClass('in').attr('aria-expanded', 'false');
            table.closest('ul').find(`li[href='#${rentId}']`).find('button i').removeClass('fa-arrow-down').addClass('fa-arrow-left');
        }
    }

    function checkCollapedRentList(table, rentId) {
        if (table.html().trim() === '') {
            let deposit = table.closest('ul').find(`li[href='#${rentId}']`).find('.deposit').text().trim();
            uploadDeposit(deposit, -1);
        }
        if (!table.closest('.panel-collapse').hasClass('in')) {
            table.closest('.panel-collapse').addClass('in').attr('aria-expanded', 'true');
            table.closest('ul').find(`li[href='#${rentId}']`).find('button i').removeClass('fa-arrow-left').addClass('fa-arrow-down');
        }
    }

    function uploadDeposit(deposit, type) {
        deposit = parseFloat(deposit);
        let totalDeposit = parseFloat($('#totalDeposit').text());
        totalDeposit = type === 1 ? totalDeposit + deposit : totalDeposit - deposit;
        $('#totalDeposit').text(totalDeposit);
        updateToTalMoney(totalDeposit);
    }

    function updateToTalMoney(totalDeposit = 0) {
        let totalRentMoney = 0;
        let totalMoney = 0;
        $('#pay-detail-table tbody tr').each((i, tr) => {
            totalRentMoney += parseFloat($(tr).find('.intoMoney').text().trim());
        });
        //totalMoney = totalRentMoney - totalDeposit;
        totalMoney = totalRentMoney;
        $('#totalRentMoney').text(totalRentMoney);
        $('#totalMoney').text(totalMoney);
    }

    function loadPenaltyOption() {
        let ops = ``;
        g_penalty.forEach(e => {
            ops += `<option value="${e.penaltyId}">${e.penaltyName}</option>`;
        });
        $('.penalty').last().append(ops);
    }

    function showState(stateId) {
        return g_state.find(state => state.stateId == stateId).stateName;
    }

    function showBookName(bookId) {
        return g_book.find(book => book.bookId == bookId).bookName;
    }

    function getPenaltyPrice(penaltyId) {
        return g_penalty.find(penalty => penalty.penaltyId == penaltyId).price;
    }

    function init() {
        $.ajax({
            url: 'state/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_state = resp;
        });

        $.ajax({
            url: 'penalty/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_penalty = resp;
        });

        $.ajax({
            url: 'book/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_book = resp;
        });
    }
});