$(document).ready(function () {
    let g_employee;
    let g_customer;
    init();

    var last_month = moment().subtract(29, 'days').format('DD/MM/YYYY');
    var now = moment().format('DD/MM/YYYY');
    $('#date-ranger').val(last_month + ' - ' + now);
    $('input[name="daterange"]').daterangepicker({
        format: 'DD/MM/YYYY',
        startDate: moment().subtract(29, 'days'),
        endDate: moment(), });

    $('#btn-search').click(() => {
        let ranger_date = $('#date-ranger').val();
        let from = ranger_date.split(' - ')[0] || '';
        let to = ranger_date.split(' - ')[1] || '';
        filter(from, to);
    });

    $('.search_revenue a').click(function () {
        let key = $(this).attr('id');
        let from = moment().startOf(key).format('DD/MM/YYYY');
        let to = moment().endOf(key).format('DD/MM/YYYY');
        $('#date-ranger').val(from + ' - ' + to);
        filter(from, to);
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
        $table = $('#rentting-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((pay, index) => {
                tbody += `<tr>
                            <td>${index + 1}</td>
                            <td>${showCustomerName(pay.customerId)}</td>
                            <td>${showEmployeeName(pay.employeeId)}</td>
                            <td class="pay-date" style="text-align:center">${moment(pay.payDate).format('DD/MM/YYYY hh:mm:ss')}</td>
                            <td class="total-money" style="text-align:center">${pay.totalMoney} VNĐ</td>
                        </tr>`;
            });
            $table.append(tbody);
            $table.parent().DataTable({
                pageLength: 25,
                responsive: true,
                info: false,
                searching: false,
                paging: false,
                dom: '<"html5buttons"B>lTfgitp',
                buttons: [
                        { extend: 'copy' },
                        { extend: 'csv' },
                        { extend: 'excel', title: 'doanh_thu' },
                    { extend: 'pdf', title: 'doanh_thu' },

                        {
                            extend: 'print',
                            customize: function (win) {
                                $(win.document.body)
                                    .addClass('white-bg')
                                    .css('font-size', '10pt')

                                $(win.document.body).find('table')
                                    .addClass('compact')
                                    .css('font-size', 'inherit');
                            }
                        }
                ]
            });
            getTotalMoney();
        }
    }
    function showCustomerName(customerId) {
        return g_customer.find(customer => customer.customerId == customerId).customerName;
    }
    function showEmployeeName(employeeId) {
        return g_employee.find(employee => employee.employeeId == employeeId).fullname;
    }

    function filter(from, to) {
        $('.pay-date').each((i, e) => {
            let date = $(e).text().split(' ')[0];
            let inRange = moment(date, "DD/MM/YYYY").isBetween(moment(from, "DD/MM/YYYY"), moment(to, "DD/MM/YYYY"), 'days', true)
            if (inRange) {
                $(e).closest('tr').removeClass('hidden');
            } else {
                $(e).closest('tr').addClass('hidden');
            }
        });
        getTotalMoney();
    }

    function getTotalMoney() {
        let total = 0;
        $('.total-money').each((i, e) => {
            if (!$(e).closest('tr').hasClass('hidden')) {
                total += parseInt($(e).text().trim().split(' ')[0]);
            }
        });
        $('#total_money').text(total);
    }

    function init() {
        getData();

        $.ajax({
            url: '/employee/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_employee = resp;
        });

        $.ajax({
            url: '/customer/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_customer = resp;
        });
    }
});