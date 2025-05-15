
$(document).ready(function () {
    //localStorage.removeItem("token");
    //localStorage.removeItem("role");
});

$("#loginFormElement").on("submit", function (e) {
    e.preventDefault();

    const email = $("#Email").val();
    const sifre = $("#Sifre").val();

    if (!email || !sifre) {
        alert("Lütfen e-posta ve şifre giriniz.");
        return;
    }

    const loginData = { email, sifre };

    $.ajax({
        url: `https://localhost:44340/api/Hesap/Login`,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(loginData),
        success: function (response) {
            console.log("Login response:", response);

            const token = response.token || response.data?.token;
            const role = response.role || response.data?.role;

            if (token) {
                localStorage.setItem("token", token);
                localStorage.setItem("role", role);
                var rol = localStorage.getItem("role");
                try {
                    //const decoded = jwt_decode(token);
                    //const role = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

                    switch (rol) {
                        case "Admin":
                            window.location.href = "/Home/Admin";
                            break;
                        case "Kullanici":
                            window.location.href = "/Home/Filmler";
                            break;
                        default:
                            alert("Yetkisiz rol.");
                            localStorage.removeItem("token");
                            break;
                    }

                } catch (e) {
                    alert("Token çözümlemesi başarısız.");
                    localStorage.removeItem("token");
                }
            } else {
                alert("Giriş başarısız. Token alınamadı.");
            }
        },
        error: function (xhr) {
            alert("Giriş başarısız: " + (xhr.responseText || "Bilinmeyen hata"));
        }
    });
});
