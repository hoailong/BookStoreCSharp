$(document).ready(function () {
    getData();

    $(document).on('click', '.edit', function () {
        $('#author-modal').modal().show();
        tr = $(this).closest('tr')
        $('#authorId').val($(tr).attr('id'));
        $('#authorName').val($(tr).find('.author-name').text());
        $('#address').val($(tr).find('.address').text());
        $('#birth').val($(tr).find('.birth').text());
        let gender = $(tr).find('.gender').text();
        gender === "Nữ" ? $("#girl").prop('checked', true) : $("#girl").prop('checked', false);
    });

    $(document).on('click', '.delete', function () {
        $('#authorIdDel').val($(this).closest('tr').attr('id'));
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
        $('#author-modal').modal('show');
    });

    $('#btn-delete-mul').click(function () {
        let multiDel = [...$('.del-author:checkbox:checked')].map(elem => $(elem).closest('tr').attr('id'));
        console.log(multiDel);
        alert('Updating...');
    });

    $('#btn-save').click(function () {
        let authorId = $('#authorId').val();
        let authorName = $('#authorName').val();
        let address = $('#address').val();
        let birth = $('#birth').val();
        let gender = $("input[name='gender']:checked").val();
        let data = {
            authorId,
            authorName,
            address,
            birth,
            gender
        }
        $.ajax({
            url: 'author/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        }).done((resp) => {
            $('#author-modal').modal('hide');
            if (resp) {
                let author = resp.author;
                let newRow = `<tr id="${author.authorId}">
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-author" name="input[]"></td>
                                    <td>1</td>
                                    <td class="author-name">${author.authorName}</td>
                                    <td class="birth">${author.birth}</td>
                                    <td class="gender">${showGender(author.gender)}</td>
                                    <td class="address">${author.address}</td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                                </tr>`;
                if (resp.create) {
                    toastr.success('Thêm mới thành công!');
                    $('#author-table tbody').append(newRow);
                    clearForm();
                } else if (resp.update) {
                    $(`#author-table #${author.authorId}`).replaceWith(newRow);
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
        let authorId = $('#authorIdDel').val();
        $.ajax({
            url: 'author/delete',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ authorId }),
            dataType: "json"
        }).done((resp) => {
            $('#confirm-modal').modal('hide');
            $(`#author-table #${authorId}`).remove();
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
        $('.author-name').each((i, v) => {
            if ($(v).text().toUpperCase().includes(key)) {
                $(v).closest('tr').removeClass('hidden');
            } else {
                $(v).closest('tr').addClass('hidden');
            }
        });
    }

    function clearForm() {
        $('#authorId').val(0);
        $('#authorName').val('');
        $('#birth').val('01/01/1990');
        $("input[name='gender'][value='Nam']").prop('checked', true);
        $('#address').val('');
    }

    function getData() {
        $.ajax({
            url: 'author/getdata',
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
        $table = $('#author-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((author, index) => {
                tbody += `<tr id="${author.authorId}">
                                <td style="text-align: center"><input type="checkbox" class="i-checks del-author" name="input[]"></td>
                                <td>${index + 1}</td>
                                <td class="author-name">${author.authorName}</td>
                                    <td class="birth">${author.birth}</td>
                                    <td class="gender">${showGender(author.gender)}</td>
                                    <td class="address">${author.address}</td>
                                <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                            </tr>`
            });
            $table.append(tbody);
            loadIcheck();
        }
    }

    function showGender(gender) {
        return gender ? "Nam" : "Nữ";
    }
});