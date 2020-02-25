$(document).ready(function () {
    let g_state;
    let g_book;
    init();

    $(document).on('click', '.view', async function () {
        modal = $('#view-detail-modal');
        modal.modal('show');
        let rentId = $(this).closest('tr').attr('id');
        let rentDetail = await getRentDetai(rentId);
        $('#detail-rentId').text('#' + rentId);
        console.log(rentDetail);
        renderDetailTable(rentDetail);
    });

    $(document).on('click', '.edit', async function () {
        alert('Update...');
    });

    function getData() {
        $.ajax({
            url: '/rentbook/getdata',
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
        $table = $('#list-rent-table tbody');
        $table.empty();
        let length = 1;
        if (length > 0) {
            let tbody = ``;
            if (data.length > 0) {
                data.forEach(async rent => {
                    let rentDetail = await getRentDetai(rent.rentId);
                    tbody += `<tr id="${rent.rentId}">
                                <td>${length}</td>
                                <td class="rentId">${rent.rentId}</td>
                                <td class="rentDate">${moment(rent.rentDate).format('DD/MM/YYYY HH:mm:ss')}</td>
                                <td class="customerId">${rent.customerId}</td>
                                <td class="employeeId">${rent.employeeId}</td>
                                <td class="totalBook">${rentDetail.length}</td>
                                <td class="deposit">${rent.deposit}</td>
                                <td class="status">
                                    ${showRentState(rentDetail)}
                                </td>
                                <td style="text-align: center"><a class="btn btn-sm btn-info view"><i class="fa fa-eye" aria-hidden="true"></i> Xem</a></td>
                                <td style="text-align: center"><a class="btn btn-sm btn-success edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Sửa</a></td>
                            </tr>`;
                    length++;
                    if (length === data.length+1) {
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
        $table = $('#rent-detail-table tbody');
        $table.empty();
        if (data) {
            let tbody = ``;
            data.forEach(async (rent, index) => {
                tbody += `<tr>
                            <td>${index + 1}</td>
                            <td class="bookId">${rent.bookId}</td>
                            <td class="bookName">${showBookName(rent.bookId)}</td>
                            <td class="state" data-state="${rent.stateId}">${showState(rent.stateId)}</td>
                            <td class="rentPrice">${rent.rentPrice}</td>
                            <td class="status">
                                ${showStatus(rent.payed)}
                            </td>
                        </tr>`;
            });
            $table.append(tbody);
        }
    }

    async function getRentDetai(rentId) {
        return await $.ajax({
            url: '/RentDetail/GetByRentId',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ rentId }),
            dataType: "json",
        })
    }

    function showRentState(rentDetail) {
        return rentDetail.find(e => !e.payed) ? `<span class="label label-danger">Chưa trả hết</span>` : `<span class="label label-primary">Đã trả hết</span>`;
    }

    function showStatus(payed) {
        return payed ? `<span class="label label-primary">Đã trả</span>` : `<span class="label label-danger">Chưa trả</span>`;
    }

    function showState(stateId) {
        return g_state.find(state => state.stateId == stateId).stateName;
    }

    function showBookName(bookId) {
        return g_book.find(book => book.bookId == bookId).bookName;
    }

    function init() {
        getData();

        $.ajax({
            url: '/state/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_state = resp;
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