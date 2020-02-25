$(document).ready(function () {
    getData();

    $(document).on('click', '.edit', function () {
        $('#penalty-modal').modal().show();
        tr = $(this).closest('tr')
        $('#penaltyId').val($(tr).attr('id'));
        $('#penaltyName').val($(tr).find('.penalty-name').text());
        $('#price').val($(tr).find('.price').text());
    });

    $(document).on('click', '.delete', function () {
        $('#penaltyIdDel').val($(this).closest('tr').attr('id'));
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
        $('#penalty-modal').modal('show');
    });

    $('#btn-delete-mul').click(function () {
        let multiDel = [...$('.del-penalty:checkbox:checked')].map(elem => $(elem).closest('tr').attr('id'));
        console.log(multiDel);
        alert('Updating...');
    });

    $('#btn-save').click(function () {
        let penaltyId = $('#penaltyId').val();
        let penaltyName = $('#penaltyName').val();
        let price = $('#price').val();
        let data = {
            penaltyId,
            penaltyName,
            price
        }
        $.ajax({
            url: 'penalty/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        }).done((resp) => {
            $('#penalty-modal').modal('hide');
            if (resp) {
                let penalty = resp.penalty;
                let newRow = `<tr id="${penalty.penaltyId}">
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-penalty" name="input[]"></td>
                                    <td>1</td>
                                    <td class="penalty-name">${penalty.penaltyName}</td>
                                    <td class="price">${penalty.price}</td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                                </tr>`;
                if (resp.create) {
                    toastr.success('Thêm mới thành công!');
                    $('#penalty-table tbody').append(newRow);
                    clearForm();
                } else if (resp.update) {
                    $(`#penalty-table #${penalty.penaltyId}`).replaceWith(newRow);
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
        let penaltyId = $('#penaltyIdDel').val();
        $.ajax({
            url: 'penalty/delete',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ penaltyId }),
            dataType: "json"
        }).done((resp) => {
            $('#confirm-modal').modal('hide');
            $(`#penalty-table #${penaltyId}`).remove();
            if (resp.delete) {
                toastr.success('Xoá thành công!');
            } else {
                toastr.erorr('Lỗi!');
            }
        });
    });

    //$('#categoryNameSearch').on('keyup change', function () {
    //    let categoryNameSearch = $(this).val();
    //    console.log(categoryNameSearch);
    //});

    function clearForm() {
        $('#penaltyId').val(0);
        $('#penaltyName').val('');
        $('#price').val('');
    }

    function getData() {
        $.ajax({
            url: 'penalty/getdata',
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
        $table = $('#penalty-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((penalty, index) => {
                tbody += `<tr id="${penalty.penaltyId}">
                                <td style="text-align: center"><input type="checkbox" class="i-checks del-penalty" name="input[]"></td>
                                <td>${index + 1}</td>
                                <td class="penalty-name">${penalty.penaltyName}</td>
                                <td class="price">${penalty.price}</td>
                                <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                            </tr>`
            });
            $table.append(tbody);
            loadIcheck();
        }
    }
});