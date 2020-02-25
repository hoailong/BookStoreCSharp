$(document).ready(function () {
    getData();
    let g_shift;
    loadShift();

    $(document).on('click', '.edit', function () {
        $('#employee-modal').modal().show();
        tr = $(this).closest('tr')
        $('#employeeId').val($(tr).attr('id'));
        $('#fullname').val($(tr).find('.employee-name').text());
        $('#phone').val($(tr).find('.employee-phone').text());
        $('#address').val($(tr).find('.address').text());
        $('#birth').val($(tr).find('.birth').text());
        $('#salary').val($(tr).find('.salary').text());
        $('#status').val($(tr).find('.status').attr('data-value'));
        $('#shiftId').val($(tr).find('.shiftId').attr('data-value'));
        //let gender = $(tr).find('.gender').text();
        //gender === "Nữ" ? $("#girl").prop('checked', true) : $("#girl").prop('checked', false);
    });

    $(document).on('click', '.delete', function () {
        $('#employeeIdDel').val($(this).closest('tr').attr('id'));
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
        $('#employee-modal').modal('show');
    });

    $('#btn-delete-mul').click(function () {
        let multiDel = [...$('.del-employee:checkbox:checked')].map(elem => $(elem).closest('tr').attr('id'));
        console.log(multiDel);
        alert('Updating...');
    });

    $('#btn-save').click(function () {
        let employeeId = $('#employeeId').val();
        let fullname = $('#fullname').val();
        let phone = $('#phone').val();
        let address = $('#address').val();
        let birth = $('#birth').val();
        let salary = $('#salary').val();
        let status = $('#status').val();
        let shiftId = $('#shiftId').val();
        let gender = $("input[name='gender']:checked").val();
        let data = {
            employeeId,
            fullname,
            phone,
            address,
            birth,
            gender,
            salary,
            status,
            shiftId
        }
        $.ajax({
            url: 'employee/save',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            dataType: "json"
        }).done((resp) => {
            if (resp) {
                if (resp.error) {
                    toastr.error(resp.error);
                } else {
                    $('#employee-modal').modal('hide');
                    let employee = resp.employee;
                    let newRow = `<tr id="${employee.employeeId}">
                                    <td style="text-align: center"><input type="checkbox" class="i-checks del-employee" name="input[]"></td>
                                    <td>1</td>
                                    <td class="employee-name">${employee.fullname}</td>
                                    <td class="employee-phone">${employee.phone}</td>
                                    <td class="birth">${employee.birth}</td>
                                    <td class="gender">${showGender(employee.gender)}</td>
                                    <td class="address">${employee.address}</td>
                                    <td class="status" data-value="${employee.status}">${showStatus(employee.status)}</td>
                                    <td class="shiftId" data-value="${employee.shiftId}">${showShift(employee.shiftId)}</td>
                                    <td class="salary">${employee.salary}</td>
                                    <td style="text-align: center">
                                        <a class="btn btn-sm btn-info edit"><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Sửa</a>&nbsp;
                                        <a class="btn btn-sm btn-danger delete"><i class="fa fa-trash-o" aria-hidden="true"></i> Xóa</a>
                                    </td>
                                </tr>`;
                    if (resp.create) {
                        toastr.success('Thêm mới thành công!');
                        $('#employee-table tbody').append(newRow);
                        clearForm();
                    } else if (resp.update) {
                        $(`#employee-table #${employee.employeeId}`).replaceWith(newRow);
                        toastr.success('Sửa thành công!');
                        clearForm();
                    }
                    loadIcheck();
                }
            } else {
                toastr.erorr('Lỗi!');
            }
        });
    });

    $('#btn-delete').click(function () {
        let employeeId = $('#employeeIdDel').val();
        $.ajax({
            url: 'employee/delete',
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ employeeId }),
            dataType: "json"
        }).done((resp) => {
            $('#confirm-modal').modal('hide');
            $(`#employee-table #${employeeId}`).remove();
            if (resp.delete) {
                toastr.success('Xoá thành công!');
            } else {
                toastr.erorr('Lỗi!');
            }
        });
    });

    //filter data
    $('#txtSearch').on('keyup change', filterData);
    $('#btn-search').click(filterData);

    $('#shiftSearch').change(filterByShift);
    $('#btn-search-shift').click(filterByShift);

    $('#genderSearch').change(filterByGender);
    $('#btn-search-gender').click(filterByGender);

    function filterData() {
        let key = $('#txtSearch').val().toUpperCase();
        $('.employee-name').each((i, v) => {
            if ($(v).text().toUpperCase().includes(key)) {
                $(v).closest('tr').removeClass('hidden');
            } else {
                $(v).closest('tr').addClass('hidden');
            }
        });
    }

    function filterByShift() {
        let key = $('#shiftSearch').val();
        $('.shiftId').each((i, v) => {
            if (key === "") {
                $(v).closest('tr').removeClass('hidden');
            } else if ($(v).attr('data-value') === key) {
                $(v).closest('tr').removeClass('hidden');
            } else {
                $(v).closest('tr').addClass('hidden');
            }
        });
    }

    function filterByGender() {
        let key = $('#genderSearch').val();
        $('.gender').each((i, v) => {
            if (key === "") {
                $(v).closest('tr').removeClass('hidden');
            } else if ($(v).text() === key) {
                $(v).closest('tr').removeClass('hidden');
            } else {
                $(v).closest('tr').addClass('hidden');
            }
        });
    }

    function clearForm() {
        $('#employeeId').val(0);
        $('#fullname').val('');
        $('#phone').val('');
        $('#birth').val('01/01/1990');
        $("input[name='gender'][value='1']").prop('checked', true);
        $('#address').val('');
        $('#salary').val('');
        $('#status').val('true');
    }

    function getData() {
        $.ajax({
            url: 'employee/getdata',
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
        $table = $('#employee-table tbody');
        $table.empty();
        let tbody = ``;
        if (data.length > 0) {
            data.forEach((employee, index) => {
                tbody += `<tr id="${employee.employeeId}">
                                <td style="text-align: center"><input type="checkbox" class="i-checks del-employee" name="input[]"></td>
                                <td>${index + 1}</td>
                                <td class="employee-name">${employee.fullname}</td>
                                <td class="employee-phone">${employee.phone}</td>
                                <td class="birth">${employee.birth}</td>
                                <td class="gender">${showGender(employee.gender)}</td>
                                <td class="address">${employee.address}</td>
                                <td class="status" data-value="${employee.status}">${showStatus(employee.status)}</td>
                                <td class="shiftId" data-value="${employee.shiftId}">${showShift(employee.shiftId)}</td>
                                <td class="salary">${employee.salary}</td>
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

    function loadShift() {
        $.ajax({
            url: 'shift/getdata',
            type: "GET",
            dataType: "json",
            async: false,
            beforeSend: toggleLoading
        }).done((resp) => {
            toggleLoading();
            console.log(resp);
            g_shift = resp;
            let opts = ``;
            if (resp.length > 0) {
                resp.forEach((e, i) => {
                    opts += `<option value="${e.shiftId}">${e.shiftName}</option>`
                });
                $('#shiftId').append(opts);
                $('#shiftSearch').append(opts);
            }
        });
    }

    function showStatus(status) {
        return status ? `<span class="label label-primary">Đang làm</span>` : `<span class="label label-danger">Nghỉ việc</span>`;
    }
    function showShift(shiftId) {
        return g_shift.find(shift => shift.shiftId == shiftId).shiftName;
    }
});