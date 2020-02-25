$(document).ready(function () {
    getData();

    $(document).on('click', '.edit', function () {
        $('#publisher-modal').modal().show();
        tr = $(this).closest('tr')
        $('#publisherId').val($(tr).attr('id'));
        $('#publisherName').val($(tr).find('.publisher-name').text());
        $('#address').val($(tr).find('.address').text());
        $('#phone').val($(tr).find('.phone').text());
    });

    $(document).on('click', '.delete', function () {
        $('#publisherIdDel').val($(this).closest('tr').attr('id'));
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
        $('#publisher-modal').modal('show');
    });

    $('#btn-delete-mul').click(function () {
        let multiDel = [...$('.del-publisher:checkbox:checked')].map(elem => $(elem).closest('tr').attr('id'));
        console.log(multiDel);
        alert('Updating...');
    });

    $('#btn-save').click(function () {
        let publisherId = $('#publisherId').val();
        let publisherName = $('#publisherName').val();
        let address = $('#address').val();
        let phone = $('#phone').val();
        let data = {
            publisherId,
            publisherName,
            address,
            phone
        }
        $.ajax({
            url: 'publisher/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        }).done((resp) => {
            $('#publisher-modal').modal('hide');
            if (resp) {
                let publisher = resp.publisher;
                let newRow = `<tr id="${publisher.publisherId}">
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-publisher" name="input[]"></td>
                                    <td>1</td>
                                    <td class="publisher-name">${publisher.publisherName}</td>
                                    <td class="address">${publisher.address}</td>
                                    <td class="phone">${publisher.phone}</td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                                </tr>`;
                if (resp.create) {
                    toastr.success('Thêm mới thành công!');
                    $('#publisher-table tbody').append(newRow);
                    clearForm();
                } else if (resp.update) {
                    $(`#publisher-table #${publisher.publisherId}`).replaceWith(newRow);
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
        let publisherId = $('#publisherIdDel').val();
        $.ajax({
            url: 'publisher/delete',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ publisherId }),
            dataType: "json"
        }).done((resp) => {
            $('#confirm-modal').modal('hide');
            $(`#publisher-table #${publisherId}`).remove();
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
        $('.publisher-name').each((i, v) => {
            if ($(v).text().toUpperCase().includes(key)) {
                $(v).closest('tr').removeClass('hidden');
            } else {
                $(v).closest('tr').addClass('hidden');
            }
        });
    }

    function clearForm() {
        $('#publisherId').val(0);
        $('#publisherName').val('NXB ');
        $('#address').val('');
        $('#phone').val('');
    }

    function getData() {
        $.ajax({
            url: 'publisher/getdata',
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
        $table = $('#publisher-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((publisher, index) => {
                tbody += `<tr id="${publisher.publisherId}">
                                <td style="text-align: center"><input type="checkbox" class="i-checks del-publisher" name="input[]"></td>
                                <td>${index + 1}</td>
                                <td class="publisher-name">${publisher.publisherName}</td>
                                    <td class="address">${publisher.address}</td>
                                    <td class="phone">${publisher.phone}</td>
                                <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                            </tr>`
            });
            $table.append(tbody);
            loadIcheck();
        }
    }
});