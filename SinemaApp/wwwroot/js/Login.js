
$(document).ready(function () {
    const token = localStorage.getItem("token");
    let decoded;

    try {
        decoded = jwt_decode(token);
    } catch (e) {
        alert("Geçersiz token.");
        localStorage.removeItem("token");
        window.location.href = "/Login";
        return;
    }

    if (decoded.role !== 'Admin') {
        alert("Bu sayfayı görüntüleme yetkiniz yok.");
        localStorage.removeItem("token");
        window.location.href = "/Login";
        return;
    }

    $('#loginFormElement').on('submit', function (e) {
        e.preventDefault();

        const username = $('#Email').val();
        const password = $('#Sifre').val();
        const loginBtn = $('button[type="submit"]');

        loginBtn.prop('disabled', true).html('<span class="spinner-border spinner-border-sm"></span> Giriş Yapılıyor...');
        $('#loadingPanel').show();

        $.ajax({
            url: `${API_URL}Hesap/Login`,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ Email: username, Sifre: password }),
            success: function (response) {
                console.log("Gelen response:", response);
                if (response.token) {
                    localStorage.setItem("token", response.token);
                    localStorage.setItem("role", response.role);
                }
                checkUserRole(); 
            },
            error: function (xhr, status, error) {
                console.error('Hata:', error);
                alert(xhr.responseText || 'Bir hata oluştu. Lütfen tekrar deneyin.');
                loginBtn.prop('disabled', false).html('Giriş Yap');
                $('#loadingPanel').hide();
            }
        });
    });

    $('#KaydolBtn').on('click', function () {
        $('#loginForm').hide();
        $('#signupForm').show();
    });

    $('#registerForm').on('submit', function (e) {
        e.preventDefault();

        const email = $('#RegEmail').val();
        const password = $('#RegSifre').val();
        const name = $('#RegAd').val();
        const surname = $('#RegSoyad').val();

        if (!email || !password || !name || !surname) {
            alert("Lütfen tüm alanları doldurunuz.");
            return;
        }

        $.ajax({
            url: `${API_URL}Hesap/Register`,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                Email: email,
                Sifre: password,
                Ad: name,
                Soyad: surname
            }),
            success: function () {
                alert('Başarıyla kaydoldunuz! Şimdi giriş yapabilirsiniz.');
                $('#signupForm').hide();
                $('#loginForm').show();
            },
            error: function (xhr, status, error) {
                console.error('Hata:', error);
                alert(xhr.responseText || 'Bir hata oluştu. Lütfen tekrar deneyin.');
            }
        });
    });
    function checkUserRole() {
        const token = localStorage.getItem("token");

        if (!token) {
            console.error("Token bulunamadı.");
            return;
        }

        const decoded = jwt_decode(token);
        const role = decoded.role;

        if (role === 'Admin') {
            window.location.href = "Home/Admin";
        } else if (role === 'Kullanici') {
            window.location.href = "Home/Filmler";
        } else {
            alert("Geçersiz kullanıcı rolü.");
            window.location.href = "/login";
        }
    }
});
