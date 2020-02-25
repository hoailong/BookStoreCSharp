$(document).ready(function () {
    getData();

    $(document).on('click', '.edit', function () {
        $('#language-modal').modal().show();
        tr = $(this).closest('tr')
        $('#langId').val($(tr).attr('id'));
        $('#langName').val($(tr).find('.language-name').text());
    });

    $(document).on('click', '.delete', function () {
        $('#langIdDel').val($(this).closest('tr').attr('id'));
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
        $('#language-modal').modal('show');
    });

    $('#btn-delete-mul').click(function () {
        let multiDel = [...$('.del-language:checkbox:checked')].map(elem => $(elem).closest('tr').attr('id'));
        console.log(multiDel);
        alert('Updating...');
    });

    $('#btn-save').click(function () {
        let langId = $('#langId').val();
        let langName = $('#langName').val();
        let data = {
            langId,
            langName
        }
        $.ajax({
            url: 'language/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        }).done((resp) => {
            $('#language-modal').modal('hide');
            if (resp) {
                let language = resp.language;
                let newRow = `<tr id="${language.langId}">
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-language" name="input[]"></td>
                                    <td>1</td>
                                    <td class="language-name">${language.langName}</td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                                </tr>`;
                if (resp.create) {
                    toastr.success('Thêm mới thành công!');
                    $('#language-table tbody').append(newRow);
                    clearForm();
                } else if (resp.update) {
                    $(`#language-table #${language.langId}`).replaceWith(newRow);
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
        let langId = $('#langIdDel').val();
        $.ajax({
            url: 'language/delete',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ langId }),
            dataType: "json"
        }).done((resp) => {
            $('#confirm-modal').modal('hide');
            $(`#language-table #${langId}`).remove();
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
        $('.language-name').each((i, v) => {
            if ($(v).text().toUpperCase().includes(key)) {
                $(v).closest('tr').removeClass('hidden');
            } else {
                $(v).closest('tr').addClass('hidden');
            }
        });
    }

    function clearForm() {
        $('#langId').val(0);
        $('#langName').val('');
    }

    function getData() {
        $.ajax({
            url: 'language/getdata',
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
        $table = $('#language-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((language, index) => {
                tbody += `<tr id="${language.langId}">
                                <td style="text-align: center"><input type="checkbox" class="i-checks del-language" name="input[]"></td>
                                <td>${index + 1}</td>
                                <td class="language-name">${language.langName}</td>
                                <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                            </tr>`
            });
            $table.append(tbody);
            loadIcheck();
        }
    }
});