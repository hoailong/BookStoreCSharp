$(document).ready(function () {
    toastr.options = {
        closeButton: true,
        progressBar: true,
        showMethod: 'slideDown',
        timeOut: 2000
    };
    $('#btn-login').click(function () {
        let username = $('#username').val();
        let password = $('#password').val();
        console.log(username, password);
        $.ajax({
            url: 'login',
            type: 'POST',
            contentType: "application/json",
            data: JSON.stringify({ username, password }),
            dataType: "json"
        }).done((resp) => {
            console.log(resp);
            if (resp) {
                location.href = '/RentBook'
            } else {
                toastr.error('Tên tài khoản hoặc mật khẩu không đúng!');
            }
        })
    });
});