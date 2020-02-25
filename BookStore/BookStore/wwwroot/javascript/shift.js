$(document).ready(function () {
    getData();

    $(document).on('click', '.edit', function () {
        $('#shift-modal').modal().show();
        tr = $(this).closest('tr')
        $('#shiftId').val($(tr).attr('id'));
        $('#shiftName').val($(tr).find('.shift-name').text());
    });

    $(document).on('click', '.delete', function () {
        $('#shiftIdDel').val($(this).closest('tr').attr('id'));
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
        $('#shift-modal').modal('show');
    });

    $('#btn-delete-mul').click(function () {
        let multiDel = [...$('.del-shift:checkbox:checked')].map(elem => $(elem).closest('tr').attr('id'));
        console.log(multiDel);
        alert('Updating...');
    });

    $('#btn-save').click(function () {
        let shiftId = $('#shiftId').val();
        let shiftName = $('#shiftName').val();
        let data = {
            shiftId,
            shiftName
        }
        $.ajax({
            url: 'shift/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        }).done((resp) => {
            $('#shift-modal').modal('hide');
            if (resp) {
                let shift = resp.shift;
                let newRow = `<tr id="${shift.shiftId}">
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-shift" name="input[]"></td>
                                    <td>1</td>
                                    <td class="shift-name">${shift.shiftName}</td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                                </tr>`;
                if (resp.create) {
                    toastr.success('Thêm mới thành công!');
                    $('#shift-table tbody').append(newRow);
                    clearForm();
                } else if (resp.update) {
                    $(`#shift-table #${shift.shiftId}`).replaceWith(newRow);
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
        let shiftId = $('#shiftIdDel').val();
        $.ajax({
            url: 'shift/delete',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ shiftId }),
            dataType: "json"
        }).done((resp) => {
            $('#confirm-modal').modal('hide');
            $(`#shift-table #${shiftId}`).remove();
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
        $('.shift-name').each((i, v) => {
            if ($(v).text().toUpperCase().includes(key)) {
                $(v).closest('tr').removeClass('hidden');
            } else {
                $(v).closest('tr').addClass('hidden');
            }
        });
    }

    function clearForm() {
        $('#shiftId').val(0);
        $('#shiftName').val('');
    }

    function getData() {
        $.ajax({
            url: 'shift/getdata',
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
        $table = $('#shift-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((shift, index) => {
                tbody += `<tr id="${shift.shiftId}">
                                <td style="text-align: center"><input type="checkbox" class="i-checks del-shift" name="input[]"></td>
                                <td>${index + 1}</td>
                                <td class="shift-name">${shift.shiftName}</td>
                                <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                            </tr>`
            });
            $table.append(tbody);
            loadIcheck();
        }
    }
});