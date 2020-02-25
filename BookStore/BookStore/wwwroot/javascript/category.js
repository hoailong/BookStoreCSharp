$(document).ready(function () {
    getData();

    $(document).on('click', '.edit', function () {
        $('#category-modal').modal().show();
        tr = $(this).closest('tr')
        $('#categoryId').val($(tr).attr('id'));
        $('#categoryName').val($(tr).find('.category-name').text());
        $('#categoryCode').val($(tr).find('.category-code').text());
    });

    $(document).on('click', '.delete', function () {
        $('#categoryIdDel').val($(this).closest('tr').attr('id'));
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
        $('#category-modal').modal('show');
    });

    $('#btn-delete-mul').click(function () {
        let multiDel = [...$('.del-category:checkbox:checked')].map(elem => $(elem).closest('tr').attr('id'));
        console.log(multiDel);
        alert('Updating...');
    });

    $('#btn-save').click(function () {
        let categoryId = $('#categoryId').val();
        let categoryName = $('#categoryName').val();
        let categoryCode = $('#categoryCode').val();
        let data = {
            categoryId,
            categoryName,
            categoryCode
        }
        $.ajax({
            url: 'category/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        }).done((resp) => {
            $('#category-modal').modal('hide');
            if (resp) {
                let cate = resp.category;
                let newCategory = `<tr id="${cate.categoryId}">
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-category" name="input[]"></td>
                                    <td>1</td>
                                    <td class="category-name">${cate.categoryName}</td>
                                    <td class="category-code">${cate.categoryCode}</td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                                </tr>`;
                if (resp.create) {
                    toastr.success('Thêm mới thành công!');
                    $('#category-table tbody').append(newCategory);
                    clearForm();
                } else if(resp.update) {
                    $(`#category-table #${cate.categoryId}`).replaceWith(newCategory);
                    toastr.success('Cập nhật thành công!');
                    clearForm();
                }
                loadIcheck();
            } else {
                toastr.erorr('Lỗi!');
            }
        });
    });

    $('#btn-delete').click(function () {
        let categoryId = $('#categoryIdDel').val();
        $.ajax({
            url: 'category/delete',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ categoryId }),
            dataType: "json"
        }).done((resp) => {
            $('#confirm-modal').modal('hide');
            $(`#category-table #${categoryId}`).remove();
            if (resp.delete) {
                toastr.success('Xoá thành công!');
            } else {
                toastr.erorr('Lỗi!');
            }
        });
    });

    $('#category-modal').on('keyup keypress blur change', '#categoryName', function () {
        let name = $(this).val();
        $('#categoryCode').val(getSlug(name));
    });

    $('#txtSearch').on('keyup change', filterData);

    $('#btn-search').click(filterData);

    function filterData() {
        let key = $('#txtSearch').val().toUpperCase();
        $('.category-name').each((i, v) => {
            if ($(v).text().toUpperCase().includes(key)) {
                $(v).closest('tr').removeClass('hidden');
            } else {
                $(v).closest('tr').addClass('hidden');
            }
        });
    }

    function clearForm() {
        $('#categoryId').val(0);
        $('#categoryName').val('');
        $('#categoryCode').val('');
    }

    function getData() {
        $.ajax({
            url: 'category/getdata',
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
        $table = $('#category-table tbody');
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((cate, index) => {
                tbody += `<tr id="${cate.categoryId}">
                                <td style="text-align: center"><input type="checkbox" class="i-checks del-category" name="input[]"></td>
                                <td>${index + 1}</td>
                                <td class="category-name">${cate.categoryName}</td>
                                <td class="category-code">${cate.categoryCode}</td>
                                <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                            </tr>`
            });
            $table.append(tbody);
            loadIcheck();
        }
    }

    //function loadtable() {
    //    $('#category-table').datatable({
    //        pagelength: 10,
    //        responsive: true,
    //        info : false,
    //        dom: '<"html5buttons"b>ltfgitp',
    //        buttons: [
    //            //{ extend: 'copy' },
    //            //{ extend: 'csv' },
    //            //{ extend: 'excel', title: 'category' },
    //            //{ extend: 'pdf', title: 'category' },

    //            //{
    //            //    extend: 'print',
    //            //    customize: function (win) {
    //            //        $(win.document.body).addclass('white-bg');
    //            //        $(win.document.body).css('font-size', '10px');

    //            //        $(win.document.body).find('table')
    //            //            .addclass('compact')
    //            //            .css('font-size', 'inherit');
    //            //    }
    //            //}
    //        ]
    //    });
    //    $('#category-table_filter>label').addclass("btn btn-primary");
    //    $('#category-table_length>label').addclass("btn btn-primary");
    //}
});