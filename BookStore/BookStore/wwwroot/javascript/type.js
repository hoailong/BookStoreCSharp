$(document).ready(function () {
    getData();

    $(document).on('click', '.edit', function () {
        $('#type-modal').modal().show();
        tr = $(this).closest('tr')
        $('#typeId').val($(tr).attr('id'));
        $('#typeName').val($(tr).find('.type-name').text());
    });

    $(document).on('click', '.delete', function () {
        $('#typeIdDel').val($(this).closest('tr').attr('id'));
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
        $('#type-modal').modal('show');
    });

    $('#btn-delete-mul').click(function () {
        let multiDel = [...$('.del-type:checkbox:checked')].map(elem => $(elem).closest('tr').attr('id'));
        console.log(multiDel);
        alert('Updating...');
    });

    $('#btn-save').click(function () {
        let typeId = $('#typeId').val();
        let typeName = $('#typeName').val();
        let data = {
            typeId,
            typeName
        }
        $.ajax({
            url: 'type/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        }).done((resp) => {
            $('#type-modal').modal('hide');
            if (resp) {
                let type = resp.type;
                let newRow = `<tr id="${type.typeId}">
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-type" name="input[]"></td>
                                    <td>1</td>
                                    <td class="type-name">${type.typeName}</td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                                </tr>`;
                if (resp.create) {
                    toastr.success('Thêm mới thành công!');
                    $('#type-table tbody').append(newRow);
                    clearForm();
                } else if (resp.update) {
                    $(`#type-table #${type.typeId}`).replaceWith(newRow);
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
        let typeId = $('#typeIdDel').val();
        $.ajax({
            url: 'type/delete',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ typeId }),
            dataType: "json"
        }).done((resp) => {
            $('#confirm-modal').modal('hide');
            $(`#type-table #${typeId}`).remove();
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
        $('.type-name').each((i, v) => {
            if ($(v).text().toUpperCase().includes(key)) {
                $(v).closest('tr').removeClass('hidden');
            } else {
                $(v).closest('tr').addClass('hidden');
            }
        });
    }

    function clearForm() {
        $('#typeId').val(0);
        $('#typeName').val('');
    }

    function getData() {
        $.ajax({
            url: 'type/getdata',
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
        $table = $('#type-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((type, index) => {
                tbody += `<tr id="${type.typeId}">
                                <td style="text-align: center"><input type="checkbox" class="i-checks del-type" name="input[]"></td>
                                <td>${index + 1}</td>
                                <td class="type-name">${type.typeName}</td>
                                <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                            </tr>`
            });
            $table.append(tbody);
            loadIcheck();
        }
    }
});