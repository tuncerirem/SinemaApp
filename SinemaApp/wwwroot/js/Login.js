$(document).ready(function () {
    $('#loginForm').on('submit', function (e) {
        e.preventDefault();

        const username = $('#Email').val();
        const password = $('#Sifre').val();

        const loginBtn = $('button[type="submit"]');
        loginBtn.prop('disabled', true).html('<span class="spinner-border spinner-border-sm"></span> Giriş Yapılıyor...');

        
        $('#loadingPanel').show();

        $.ajax({
            url: 'https://localhost:44340/api/Hesap/Login',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ Email: username, Sifre: password }),
            success: function (response) {
                
                if (response.redirectURL) {
                    window.location.href = response.redirectURL;
                } else {
                    window.location.href = '/home';
                }
            },
            error: function (xhr, status, error) {
                console.error('Hata:', error);

                alert(xhr.responseText || 'Bir hata oluştu. Lütfen tekrar deneyin.');

                loginBtn.prop('disabled', false).html('Giriş Yap');

                
                $('#loadingPanel').hide();
            }
        });
    });
});
