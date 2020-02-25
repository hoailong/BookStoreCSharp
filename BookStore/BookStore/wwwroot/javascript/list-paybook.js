$(document).ready(function () {
    let g_penalty;
    let g_book;
    init();

    $(document).on('click', '.view', async function () {
        modal = $('#view-detail-modal');
        modal.modal('show');
        let payId = $(this).closest('tr').attr('id');
        let payDetail = await getPayDetai(payId);
        $('#detail-payId').text('#' + payId);
        console.log(payDetail);
        renderDetailTable(payDetail);
    });

    $(document).on('click', '.edit', async function () {
        alert('Update...');
    });

    function getData() {
        $.ajax({
            url: '/paybook/getdata',
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
        $table = $('#list-pay-table tbody');
        $table.empty();
        let length = 1;
        if (length > 0) {
            let tbody = ``;
            if (data.length > 0) {
                data.forEach(async pay => {
                    let payDetail = await getPayDetai(pay.payId);
                    tbody += `<tr id="${pay.payId}">
                                <td>${length}</td>
                                <td class="payId">${pay.payId}</td>
                                <td class="payDate">${moment(pay.payDate).format('DD/MM/YYYY HH:mm:ss')}</td>
                                <td class="customerId">${pay.customerId}</td>
                                <td class="employeeId">${pay.employeeId}</td>
                                <td class="totalBook">${payDetail.length}</td>
                                <td class="totalMoney">${pay.totalMoney}</td>
                                <td style="text-align: center"><a class="btn btn-sm btn-info view"><i class="fa fa-eye" aria-hidden="true"></i> Xem</a></td>
                                <td style="text-align: center"><a class="btn btn-sm btn-success edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Sửa</a></td>
                            </tr>`;
                    length++;
                    if (length === data.length + 1) {
                        $table.append(tbody);
                        $table.parent().DataTable({
                            pageLength: 25,
                            responsive: true,
                            info: false,
                            searching: false,
                            dom: '<"html5buttons"B>lTfgitp',
                            buttons: []
                        });
                    }
                });
            }
        }
    }


    function renderDetailTable(data) {
        $table = $('#pay-detail-table tbody');
        $table.empty();
        if (data) {
            let tbody = ``;
            data.forEach(async (pay, index) => {
                tbody += `<tr>
                            <td>${index + 1}</td>
                            <td class="rentId">${pay.rentId}</td>
                            <td class="bookId">${pay.bookId}</td>
                            <td class="bookName">${showBookName(pay.bookId)}</td>
                            <td class="penalty" >${showPenalty(pay.penaltyId)}</td>
                            <td class="intoMoney">${pay.intoMoney}</td>
                        </tr>`;
            });
            $table.append(tbody);
        }
    }

    async function getPayDetai(payId) {
        return await $.ajax({
            url: '/paydetail/getbypayId',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ payId }),
            dataType: "json",
        })
    }

    function showPenalty(penaltyId) {
        if(!penaltyId) {
            return 'Không';
        };
        return g_penalty.find(penalty => penalty.penaltyId == penaltyId).penaltyName;
    }

    function showBookName(bookId) {
        return g_book.find(book => book.bookId == bookId).bookName;
    }

    function init() {
        getData();

        $.ajax({
            url: '/penalty/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_penalty = resp;
        });

        $.ajax({
            url: '/book/getdata',
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