const API_URL = "https://localhost:44340/api/";
const kulData = {}


function addAuthorizationHeader(xhr) {
    const token = localStorage.getItem("token");
    if (token) {
        xhr.setRequestHeader("Authorization", `Bearer ${token}`);

    }
}


function isValidToken(token) {
    try {
        const decoded = jwt_decode(token);
        const now = Date.now() / 1000;
        const tokenExpire = decoded.exp;

        return tokenExpire >= now;
    } catch (e) {
        console.error("Token doğrulama hatası:", e);
        return false;
    }
}
function Token_kontrol() {
    const token = localStorage.getItem("token");

    if (!token || !isValidToken(token)) {
        alert("Token geçersiz veya süresi dolmuş.");
        localStorage.removeItem("token");
        sessionStorage.clear();
        window.location.href = "/Login";
        return false;
    }

    return true;
}


function VeriList(controller, method) {
    if (!Token_kontrol()) return;

    const url = `${API_URL}${controller}/${method}`;
    return $.ajax({
        url: url,
        type: "GET",
        dataType: "json",
        beforeSend: function (xhr) {
            addAuthorizationHeader(xhr);
        }
    });
}


function VeriGonder(controller, method, data) {
    if (!Token_kontrol()) return;

    const url = `${API_URL}${controller}/${method}`;
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

});