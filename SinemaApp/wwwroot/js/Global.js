//const API_URL = "https://localhost:44340/api/";

//function VeriList(controller, method) {
//    const url = `${API_URL}${controller}/${method}`;
//    return $.ajax({
//        url: url,
//        type: "GET",
//        dataType: "json",
//    });
//}

//function VeriGonder(controller, method, data) {
//    const url = `${API_URL}${controller}/${method}`;
//    return $.ajax({
//        url: url,
//        type: "POST",
//        contentType: "application/json",
//        data: JSON.stringify(data),
//        dataType: "json"
//    });
//}
const API_URL = "https://localhost:44340/api/";

// Token'ı header'a ekle
function addAuthorizationHeader(xhr) {
    const token = localStorage.getItem("token");
    if (token) {
        xhr.setRequestHeader("Authorization", `Bearer ${token}`);
       
    }
}

// Token'ı decode edip geçerliliğini kontrol et
function isValidToken(token) {
    try {
        const decoded = jwt_decode(token); // jwt-decode kütüphanesi kullanılmalı
        const now = Date.now() / 1000; // Şu anki zaman (Unix timestamp)
        const tokenExpire = decoded.exp;

        if (tokenExpire < now) {
            console.warn("Token süresi geçmiş.");
            return false;
        }

        return true;
    } catch (e) {
        console.error("Token doğrulama hatası:", e);
        return false;
    }
}

// Kullanıcı token'ını kontrol et ve doğrula
function Token_kontrol() {
    const token = localStorage.getItem("token");

    if (!token || !isValidToken(token)) {
        alert("Token geçersiz veya süresi dolmuş.");
        localStorage.removeItem("token");
        sessionStorage.clear(); // Güvenlik için session temizlenir
        window.location.href = "/Login"; // Giriş sayfasına yönlendirme
        return false;
    }
    
    return true;
}

// API GET isteği (Veri Listeleme)
function VeriList(controller, method) {
    if (!Token_kontrol()) return;

    const url = `${API_URL}${controller}/${method}`; // Template literal düzeltmesi
    return $.ajax({
        url: url,
        type: "GET",
        dataType: "json",
        beforeSend: function (xhr) {
            addAuthorizationHeader(xhr);
        }
    });
}

// API POST isteği (Veri Gönderme)
function VeriGonder(controller, method, data) {
    if (!Token_kontrol()) return;

    const url = `${API_URL}${controller}/${method}`; // Template literal düzeltmesi
    return $.ajax({
        url: url,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        dataType: "json",
        beforeSend: function (xhr) {
            addAuthorizationHeader(xhr);
        }
    });
}

$(document).ready(function () {
    // Sayfa yüklendikten sonra çalışacak kodlar burada olacak
});
