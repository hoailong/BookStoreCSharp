$(document).ready(function () {
    let g_book;
    init();

    function getData() {
        $.ajax({
            url: '/report/gettoprent',
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
        $table = $('#top-rent-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((book, index) => {
                tbody += `<tr>
                            <td>${index + 1}</td>
                            <td class="book-id">${book.bookId}</td>
                            <td class="book-name">${showBookName(book.bookId)}</td>
                            <td class="book-quant">${book.count}</td>
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
                    { extend: 'excel', title: 'top_thue_nhieu' },
                    { extend: 'pdf', title: 'top_thue_nhieu' },

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
        }
    }
    function showBookName(bookId) {
        return g_book.find(book => book.bookId == bookId).bookName;
    }

    function init() {
        getData();

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