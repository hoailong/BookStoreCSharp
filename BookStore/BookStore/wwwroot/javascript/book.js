$(document).ready(function () {
    let g_type;
    let g_publisher;
    let g_language;
    let g_category;
    let g_author;
    init();
    console.log(g_type);
    console.log(g_publisher);
    console.log(g_language);
    console.log(g_category);
    console.log(g_author);

    $(document).on('click', '.edit', function () {
        $('#book-modal').modal().show();
        tr = $(this).closest('tr')
        $('#bookId').val($(tr).attr('id'));
        $('#bookName').val($(tr).find('.book-name').text());
        $('#categoryId').val($(tr).find('.category').attr('data-value'));
        $('#publisherId').val($(tr).find('.publisher').attr('data-value'));
        $('#typeId').val($(tr).find('.type').attr('data-value'));
        $('#langId').val($(tr).find('.lang').attr('data-value'));
        $('#page').val($(tr).find('.page').text());
        $('#total').val($(tr).find('.total').text());
        $('#quantity').val($(tr).find('.quantity').text());
        $('#price').val($(tr).find('.price').text());
        $('#rentPrice').val($(tr).find('.rentPrice').text());
        $('#author').val($(tr).find('.author').text());
        $('#image-book').attr('src', $(tr).find('.image').find('img').attr('src'));
        $('#categoryId, #publisherId, #typeId, #langId').select2().trigger('change');
    });

    $(document).on('click', '.delete', function () {
        $('#bookIdDel').val($(this).closest('tr').attr('id'));
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

    $('#btn-search').click(function () {
        let bookName = $('#bookNameSearch').val().toLowerCase() || '';
        let category = $('#categorySearch').val() || '';
        let author = $('#authorSearch').val() || '';
        let publisher = $('#publisherSearch').val() || '';
        console.log(bookName, category, author, publisher);
        $('#book-table tbody tr').each((i, e) => {
            if ($(e).find('.book-name').text().toLowerCase().includes(bookName)
                && $(e).find('.author').attr('data-value').includes(author)
                && $(e).find('.publisher').attr('data-value').includes(publisher)
                && $(e).find('.category').attr('data-value').includes(category)) {
                $(e).removeClass('hidden');
            } else {
                $(e).addClass('hidden');
            }
        });
    });

    $('#btn-refresh').click(function () {
        $('#bookNameSearch').val('');
        $('#categorySearch').val('');
        $('#authorSearch').val('');
        $('#publisherSearch').val('');
        $('#authorSearch, #publisherSearch, #categorySearch').select2().trigger('change');
        $('#btn-search').trigger('click');
    });

    $('#btn-create').click(function () {
        clearForm();
        $('#book-modal').modal('show');
    });

    $('#btn-delete-mul').click(function () {
        let multiDel = [...$('.del-book:checkbox:checked')].map(elem => $(elem).closest('tr').attr('id'));
        console.log(multiDel);
        alert('Updating...');
    });

    $('#btn-save').click(function () {
        var upload = new FormData();
        var files = $("#upload-image").get(0).files;
        if (files.length > 0) {
            upload.append("files", files[0]);
            $.ajax({
                url: "/fileupload/upload",
                type: 'POST',
                data: upload,
                cache: false,
                processData: false,
                contentType: false,
            }).done(function (resp) {
                if (resp.upload) {
                    saveBook();
                } else {
                    toastr.error('Lỗi Upload!');
                }
            }).fail(function (error) {
                console.log(error);
                console.log('error');
            });
        } else {
            saveBook();
        }
    });

    $('#btn-delete').click(function () {
        let bookId = $('#bookIdDel').val();
        $.ajax({
            url: 'book/delete',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ bookId }),
            dataType: "json"
        }).done((resp) => {
            $('#confirm-modal').modal('hide');
            $(`#book-table #${bookId}`).remove();
            if (resp.delete) {
                toastr.success('Xoá thành công!');
            } else {
                toastr.erorr('Lỗi!');
            }
        });
    });

    $('#upload-image').change(function () {
        var input = this;
        var url = $(this).val();
        var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
        if (input.files && input.files[0] && (ext == "gif" || ext == "png" || ext == "jpeg" || ext == "jpg")) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#image-book').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
        else {
            toastr.error('File ảnh không hợp lệ!');
            $('#image-book').attr('src', '/upload/book/not-found.png');
        }
    });

    //$('#categoryNameSearch').on('keyup change', function () {
    //    let categoryNameSearch = $(this).val();
    //    console.log(categoryNameSearch);
    //});
    function saveBook() {
        let bookId = $('#bookId').val();
        let bookName = $('#bookName').val();
        let categoryId = $('#categoryId').val();
        let publisherId = $('#publisherId').val();
        let typeId = $('#typeId').val();
        let langId = $('#langId').val();
        let authorId = $('#authorId').val();
        let page = $('#page').val();
        let total = $('#total').val();
        let quantity = $('#quantity').val();
        let price = $('#price').val();
        let rentPrice = $('#rentPrice').val();
        let url = $('#upload-image').val();
        let image = '';
        if (url === '') {
            url = $('#image-book').attr('src');
            image = url.substring(url.lastIndexOf('/') + 1);
        } else {
            image = url.substring(url.lastIndexOf('\\') + 1);
        }
        let data = {
            bookId,
            bookName,
            categoryId,
            publisherId,
            typeId,
            langId,
            authorId,
            page,
            image,
            total,
            quantity,
            price,
            rentPrice
        }
        $.ajax({
            url: 'book/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        }).done((resp) => {
            if (resp) {
                if (resp.error) {
                    toastr.error(resp.error);
                } else {
                    $('#book-modal').modal('hide');
                    let book = resp.book;
                    let newRow = `<tr id="${book.bookId}">
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-book" name="input[]"></td>
                                    <td>1</td>
                                    <td class="book-name">${book.bookName}</td>
                                    <td class="image"><img src="/upload/book/${book.image}" class="img-md" alt="Book Image"></td>
                                    <td class="author" data-value="${book.authorId}">${showAuthor(book.authorId)}</td>
                                    <td class="publisher" data-value="${book.publisherId}">${showPublisher(book.publisherId)}</td>
                                    <td class="category" data-value="${book.categoryId}">${showCategory(book.categoryId)}</td>
                                    <td class="lang" data-value="${book.langId}">${showLanguage(book.langId)}</td>
                                    <td class="page">${book.page}</td>
                                    <td class="total">${book.total}</td>
                                    <td class="quantity">${book.quantity}</td>
                                    <td class="type" data-value="${book.typeId}">${showType(book.typeId)}</td>
                                    <td class="price">${book.price}</td>
                                    <td class="rentPrice">${book.rentPrice}</td>
                                    <td style="text-align: center">
                                        <a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Sửa</a>&nbsp;
                                        <a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a>
                                    </td>
                                </tr>`;

                    if (resp.create) {
                        toastr.success('Thêm mới thành công!');
                        $('#book-table tbody').append(newRow);
                        clearForm();
                    } else if (resp.update) {
                        $(`#book-table #${book.bookId}`).replaceWith(newRow);
                        toastr.success('Cập nhật thành công!');
                        clearForm();
                    }
                    loadIcheck();
                }
            } else {
                toastr.erorr('Lỗi!');
            }
        });
    }

    function clearForm() {
        $('#bookId').val(0);
        $('#bookName').val('');
        $('#page').val('');
        $('#total').val('');
        $('#quantity').val('');
        $('#price').val('');
        $('#rentPrice').val('');
        $('#image-book').attr('src', '/upload/book/not-found.png');
        $('#categoryId, #publisherId, #typeId, #langId').select2().trigger('change');
    }

    function getData() {
        $.ajax({
            url: 'book/getdata',
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
        $table = $('#book-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((book, index) => {
                tbody += `<tr id="${book.bookId}">
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-book" name="input[]"></td>
                                    <td>${index+1}</td>
                                    <td class="book-name">${book.bookName}</td>
                                    <td class="image"><img src="/upload/book/${book.image}" class="img-md" alt="Book Image"></td>
                                    <td class="author" data-value="${book.authorId}">${showAuthor(book.authorId)}</td>
                                    <td class="publisher" data-value="${book.publisherId}">${showPublisher(book.publisherId)}</td>
                                    <td class="category" data-value="${book.categoryId}">${showCategory(book.categoryId)}</td>
                                    <td class="lang" data-value="${book.langId}">${showLanguage(book.langId)}</td>
                                    <td class="page">${book.page}</td>
                                    <td class="total">${book.total}</td>
                                    <td class="quantity">${book.quantity}</td>
                                    <td class="type" data-value="${book.typeId}">${showType(book.typeId)}</td>
                                    <td class="price">${book.price}</td>
                                    <td class="rentPrice">${book.rentPrice}</td>
                                    <td style="text-align: center">
                                        <a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Sửa</a>&nbsp;
                                        <a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a>
                                    </td>
                                </tr>`
            });
            $table.append(tbody);
            loadIcheck();
        }
    }


    function showPublisher(publisherId) {
        return publisherId ? g_publisher.find(publisher => publisher.publisherId == publisherId).publisherName : '';
    }
    function showLanguage(langId) {
        return langId ? g_language.find(language => language.langId == langId).langName : '';
    }
    function showCategory(categoryId) {
        return categoryId ? g_category.find(category => category.categoryId == categoryId).categoryName : '';
    }
    function showType(typeId) {
        return typeId ? g_type.find(type => type.typeId == typeId).typeName : '';
    }
    function showAuthor(authorId) {
        return authorId ? g_author.find(author => author.authorId == authorId).authorName : '';
    }

    function init() {
        getData();

        $.ajax({
            url: 'type/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_type = resp;
            let ops = ``;
            g_type.forEach(e => {
                ops += `<option value="${e.typeId}">${e.typeName}</option>`;
            });
            $('#typeId').append(ops);
        });

        $.ajax({
            url: 'publisher/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_publisher = resp;
            let ops = ``;
            g_publisher.forEach(e => {
                ops += `<option value="${e.publisherId}">${e.publisherName}</option>`;
            });
            $('#publisherId').append(ops);
            $('#publisherSearch').append(ops);
        });

        $.ajax({
            url: 'language/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_language = resp;
            let ops = ``;
            g_language.forEach(e => {
                ops += `<option value="${e.langId}">${e.langName}</option>`;
            });
            $('#langId').append(ops);
        });

        $.ajax({
            url: 'category/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_category = resp;
            let ops = ``;
            g_category.forEach(e => {
                ops += `<option value="${e.categoryId}">${e.categoryName}</option>`;
            });
            $('#categoryId').append(ops);
            $('#categorySearch').append(ops);
        });

        $.ajax({
            url: 'author/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_author = resp;
            let ops = ``;
            g_author.forEach(e => {
                ops += `<option value="${e.authorId}">${e.authorName}</option>`;
            });
            $('#authorId').append(ops).select2();
            $('#authorSearch').append(ops).select2();
        });

        $('#categoryId, #publisherId, #typeId, #langId, #authorSearch, #publisherSearch, #categorySearch').select2().trigger('change');
    }
});