//$(document).ready(function () {

//    $('#loginFormElement').on('submit', function (e) {
//        e.preventDefault();

//        const username = $('#Email').val();
//        const password = $('#Sifre').val();

//        const loginBtn = $('button[type="submit"]');
//        loginBtn.prop('disabled', true).html('<span class="spinner-border spinner-border-sm"></span> Giriş Yapılıyor...');


//        $('#loadingPanel').show();
//        VeriGonder("Hesap", "Login", { Email: username, Sifre: password })
//            .then(function (response) {
//                if (response.redirectURL) {
//                    window.location.href = response.redirectURL;
//                } else {
//                    window.location.href = '/Home/Filmler';
//                }
//            })
//            .catch(function (error) {
//                console.error('Hata:', error);
//                alert(error.responseText || 'Bir hata oluştu. Lütfen tekrar deneyin.');

//                loginBtn.prop('disabled', false).html('Giriş Yap');
//                $('#loadingPanel').hide();
//            });
//    });

//    $('#KaydolBtn').on('click', function () {
//        $('#loginForm').hide();
//        $('#signupForm').show();

//    });


//    $('#registerForm').on('submit', function (e) {
//        e.preventDefault();

//        const email = $('#RegEmail').val();
//        const password = $('#RegSifre').val();
//        const name = $('#RegAd').val();
//        const surname = $('#RegSoyad').val();


//        $.ajax({
//            url: 'https://localhost:44340/api/Hesap/Register',
//            type: 'POST',
//            contentType: 'application/json',
//            data: JSON.stringify({
//                Email: email,
//                Sifre: password,
//                Ad: name,
//                Soyad: surname
//            }),
//            success: function (response) {
//                alert('Başarıyla kaydoldunuz!');
//                $('#signupForm').hide();
//                $('#loginForm').show();
//            },
//            error: function (xhr, status, error) {
//                console.error('Hata:', error);
//                alert(xhr.responseText || 'Bir hata oluştu. Lütfen tekrar deneyin.');
//            }
//        });
//    });
//});





//$(document).ready(function ()
//{
//    axios.interceptors.response.use(
//        response => response,
//        error => {
//            if (error.response && error.response.status === 401) {
//                localStorage.removeItem("token");
//                localStorage.removeItem("user");
//                window.location.href = "/Hesap/Login";
//            }
//            return Promise.reject(error);
//        }
//    );

//    $('#loginFormElement').on('submit', function (e) {
//        e.preventDefault();

//        const username = $('#Email').val();
//        const password = $('#Sifre').val();

//        const loginBtn = $('button[type="submit"]');
//        loginBtn.prop('disabled', true).html('<span class="spinner-border spinner-border-sm"></span> Giriş Yapılıyor...');

//        $('#loadingPanel').show();


//        $.ajax({
//            url: 'https://localhost:44340/api/Hesap/Login',
//            type: 'POST',
//            contentType: 'application/json',
//            data: JSON.stringify({ Email: username, Sifre: password }),
//            success: function (response) {

//                if (response.redirectURL) {
//                    window.location.href = response.redirectURL;
//                }
//            },
//            error: function (xhr, status, error) {
//                console.error('Hata:', error);
//                alert(xhr.responseText || 'Bir hata oluştu. Lütfen tekrar deneyin.');

//                loginBtn.prop('disabled', false).html('Giriş Yap');
//                $('#loadingPanel').hide();
//            }
//        });
//    });


//    $('#KaydolBtn').on('click', function () {
//        $('#loginForm').hide();
//        $('#signupForm').show();
//    });


//    $('#registerForm').on('submit', function (e) {
//        e.preventDefault();

//        const email = $('#RegEmail').val();
//        const password = $('#RegSifre').val();
//        const name = $('#RegAd').val();
//        const surname = $('#RegSoyad').val();


//        $.ajax({
//            url: 'https://localhost:44340/api/Hesap/Register',
//            type: 'POST',
//            contentType: 'application/json',
//            data: JSON.stringify({
//                Email: email,
//                Sifre: password,
//                Ad: name,
//                Soyad: surname
//            }),
//            success: function (response) {
//                alert('Başarıyla kaydoldunuz! Şimdi giriş yapabilirsiniz.');
//                $('#signupForm').hide();
//                $('#loginForm').show();
//            },
//            error: function (xhr, status, error) {
//                console.error('Hata:', error);
//                alert(xhr.responseText || 'Bir hata oluştu. Lütfen tekrar deneyin.');
//            }
//        });
//    });
//});


$(document).ready(function () {
    // Login form submit
    $('#loginFormElement').on('submit', function (e) {
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
                console.log("Gelen response:", response);
                if (response.token) {
                    // Token ve rol bilgisini localStorage'a kaydet
                    localStorage.setItem("token", response.token);
                    localStorage.setItem("role", response.role); // role bilgisini kaydediyoruz
                }

                // Token geçerliliğini kontrol et ve yönlendirme yap
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

    // Kaydol butonu
    $('#KaydolBtn').on('click', function () {
        $('#loginForm').hide();
        $('#signupForm').show();
    });

    // Register form submit
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
            url: 'https://localhost:44340/api/Hesap/Register',
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

    // Kullanıcı rolünü kontrol et ve yönlendirme yap
    function checkUserRole() {
        const token = localStorage.getItem("token");

        if (!token) {
            console.error("Token bulunamadı.");
            return;
        }

        // Token'ı decode et ve role bilgisini al
        const decoded = jwt_decode(token);
        const role = decoded.role; // Buradan role bilgisini alıyoruz

        // Kullanıcının rolüne göre yönlendirme
        if (role === 'Admin') {
            // Admin paneline yönlendir
            window.location.href = "Home/Admin";
        } else if (role === 'Kullanici') {
            // Ana sayfaya yönlendir
            window.location.href = "Home/Filmler";
        } else {
            alert("Geçersiz kullanıcı rolü.");
            window.location.href = "/login"; // Hata durumunda login sayfasına yönlendir
        }
    }
});







