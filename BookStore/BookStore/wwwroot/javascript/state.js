$(document).ready(function () {
    getData();

    $(document).on('click', '.edit', function () {
        $('#state-modal').modal().show();
        tr = $(this).closest('tr')
        $('#stateId').val($(tr).attr('id'));
        $('#stateName').val($(tr).find('.state-name').text());
    });

    $(document).on('click', '.delete', function () {
        $('#stateIdDel').val($(this).closest('tr').attr('id'));
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
        $('#state-modal').modal('show');
    });

    $('#btn-delete-mul').click(function () {
        let multiDel = [...$('.del-state:checkbox:checked')].map(elem => $(elem).closest('tr').attr('id'));
        console.log(multiDel);
        alert('Updating...');
    });

    $('#btn-save').click(function () {
        let stateId = $('#stateId').val();
        let stateName = $('#stateName').val();
        let data = {
            stateId,
            stateName
        }
        $.ajax({
            url: 'state/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        }).done((resp) => {
            $('#state-modal').modal('hide');
            if (resp) {
                let state = resp.state;
                let newRow = `<tr id="${state.stateId}">
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-state" name="input[]"></td>
                                    <td>1</td>
                                    <td class="state-name">${state.stateName}</td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                                </tr>`;
                if (resp.create) {
                    toastr.success('Thêm mới thành công!');
                    $('#state-table tbody').append(newRow);
                    clearForm();
                } else if (resp.update) {
                    $(`#state-table #${state.stateId}`).replaceWith(newRow);
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
        let stateId = $('#stateIdDel').val();
        $.ajax({
            url: 'state/delete',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ stateId }),
            dataType: "json"
        }).done((resp) => {
            $('#confirm-modal').modal('hide');
            $(`#state-table #${stateId}`).remove();
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
        $('.state-name').each((i, v) => {
            if ($(v).text().toUpperCase().includes(key)) {
                $(v).closest('tr').removeClass('hidden');
            } else {
                $(v).closest('tr').addClass('hidden');
            }
        });
    }

    function clearForm() {
        $('#stateId').val(0);
        $('#stateName').val('');
    }

    function getData() {
        $.ajax({
            url: 'state/getdata',
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
        $table = $('#state-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((state, index) => {
                tbody += `<tr id="${state.stateId}">
                                <td style="text-align: center"><input type="checkbox" class="i-checks del-state" name="input[]"></td>
                                <td>${index + 1}</td>
                                <td class="state-name">${state.stateName}</td>
                                <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                            </tr>`
            });
            $table.append(tbody);
            loadIcheck();
        }
    }
});