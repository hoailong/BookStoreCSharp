$(document).ready(function () {
    let g_employee;
    init();
    console.log(g_employee);

    $(document).on('click', '.edit', function () {
        $('#account-modal').modal().show();
        tr = $(this).closest('tr')
        $('#accountId').val($(tr).attr('id'));
        $('#username').val($(tr).find('.username').text());
        $('#phone').val($(tr).find('.phone').text());
        $('#password').val($(tr).attr('data-password'));
        $('#role').val($(tr).find('.role').attr('data-value'));
        $('#status').val($(tr).find('.status').attr('data-value'));
        $('#employeeId').val($(tr).find('.employee').attr('data-value'));
    });

    $(document).on('click', '.delete', function () {
        $('#accountIdDel').val($(this).closest('tr').attr('id'));
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
        $('#account-modal').modal('show');
    });

    $('#btn-delete-mul').click(function () {
        let multiDel = [...$('.del-account:checkbox:checked')].map(elem => $(elem).closest('tr').attr('id'));
        console.log(multiDel);
        alert('Updating...');
    });

    $('#btn-save').click(function () {
        let accountId = $('#accountId').val();
        let username = $('#username').val();
        let password = $('#password').val();
        let phone = $('#phone').val();
        let role = $('#role').val();
        let status = $('#status').val();
        let employeeId = $('#employeeId').val();
        let data = {
            accountId,
            username,
            password,
            phone,
            role,
            status,
            employeeId,
        }
        $.ajax({
            url: '/admin/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        }).done((resp) => {
            $('#account-modal').modal('hide');
            if (resp) {
                let account = resp.account;
                let newRow = `<tr id="${account.accountId}" data-password=${account.password}>
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-account" name="input[]"></td>
                                    <td>1</td>
                                    <td class="username">${account.username}</td>
                                    <td class="phone">${account.phone}</td>
                                    <td class="role" data-value="${account.role}">${account.role}</td>
                                    <td class="employee" data-value="${account.employeeId}">${showEmployeeName(account.employeeId)}</td>
                                    <td style="text-align: center" class="status" data-value="${account.status}">${showStatus(account.status)}</td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                    <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                                </tr>`;
                if (resp.create) {
                    toastr.success('Thêm mới thành công!');
                    $('#account-table tbody').append(newRow);
                    clearForm();
                } else if (resp.update) {
                    $(`#account-table #${account.accountId}`).replaceWith(newRow);
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
        let accountId = $('#accountIdDel').val();
        $.ajax({
            url: '/admin/delete',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ accountId }),
            dataType: "json"
        }).done((resp) => {
            $('#confirm-modal').modal('hide');
            $(`#account-table #${accountId}`).remove();
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
        $('.username').each((i, v) => {
            if ($(v).text().toUpperCase().includes(key)) {
                $(v).closest('tr').removeClass('hidden');
            } else {
                $(v).closest('tr').addClass('hidden');
            }
        });
    }

    function clearForm() {
        $('#accountId').val(0);
        $('#username').val('');
        $('#password').val('');
        $('#phone').val('');
        $('#role').val('Employee');
    }

    function getData() {
        $.ajax({
            url: '/admin/getdata',
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
        $table = $('#account-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((account, index) => {
                tbody += `<tr id="${account.accountId}" data-password=${account.password}>
                                <td style="text-align: center"><input type="checkbox" class="i-checks del-account" name="input[]"></td>
                                <td>${index + 1}</td>
                                <td class="username">${account.username}</td>
                                <td class="phone">${account.phone}</td>
                                <td class="role" data-value="${account.role}">${account.role}</td>
                                <td class="employee" data-value="${account.employeeId}">${showEmployeeName(account.employeeId)}</td>
                                <td style="text-align: center" class="status" data-value="${account.status}">${showStatus(account.status)}</td>
                                <td style="text-align: center"><a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Cập nhật</a></td>
                                <td style="text-align: center"><a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a></td>
                            </tr>`;
            });
            $table.append(tbody);
            loadIcheck();
        }
    }

    function init() {
        getData();

        $.ajax({
            url: '/employee/getdata',
            type: "GET",
            dataType: "json",
            beforeSend: toggleLoading,
            async: false
        }).done((resp) => {
            toggleLoading();
            g_employee = resp;
            let ops = ``;
            g_employee.forEach(e => {
                ops += `<option value="${e.employeeId}">${e.fullname}</option>`;
            });
            $('#employeeId').append(ops);
        });
    }

    function showStatus(status) {
        return status ? `<span class="label label-primary">Hoạt động</span>` : `<span class="label label-danger">Khóa</span>`;
    }

    function showEmployeeName(employeeId) {
        return g_employee.find(employee => employee.employeeId == employeeId).fullname;
    }
});