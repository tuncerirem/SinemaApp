var API_URL = "https://localhost:44340/api/";
const token = localStorage.getItem("token");

$(document).ready(function () {
    checkUserRole();

});

function addAuthorizationHeader(xhr) {
    const token = localStorage.getItem("token");
    if (token) {
        xhr.setRequestHeader("Authorization", `Bearer ${token}`);
    }
}
function Token_kontrol() {
    const token = localStorage.getItem("token");

    if (!token || !isValidToken(token)) {
        alert("Token geçersiz veya süresi dolmuş.");
        localStorage.removeItem("token");
        localStorage.removeItem("role");
        sessionStorage.clear();
        window.location.href = "/Login";
        return false;
    }
    if (!token) {
        window.location.href = "/Login";
    }

    return true;
}

function isValidToken() {



    const token = localStorage.getItem("token");
    try {
        if (token) {
            const decoded = jwt_decode(token);
            const now = Date.now() / 1000;

            if (decoded.exp >= now) {
                return true;
            } else {

                localStorage.removeItem("token");
                localStorage.removeItem("role");
                sessionStorage.clear();
                window.location.href = "/Login";
                return false;
            }
        } else {
            return false;
        }
    } catch (e) {

        localStorage.removeItem("token");
        localStorage.removeItem("role");
        sessionStorage.clear();
        window.location.href = "/Login";
        return false;
    }

}



function checkUserRole() {

    const token = localStorage.getItem("token")
    if (!token) {
        if (!window.location.href.includes("/")) {
            window.location.href = "/Login";
        }
        return false;
    }
    try {
        Token_kontrol(token);
    } catch {
        localStorage.removeItem(token);

    }
}

function VeriList(controller, method) {
    if (!Token_kontrol()) return;

    return $.ajax({
        url: `${API_URL}${controller}/${method}`,
        type: "GET",
        dataType: "json",
        beforeSend: addAuthorizationHeader
    });
}

function VeriGonder(controller, method, data) {
    if (!Token_kontrol()) return;

    return $.ajax({
        url: `${API_URL}${controller}/${method}`,
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        dataType: "json",
        beforeSend: addAuthorizationHeader
    });
}

function Clear_LocalStorage() {
    localStorage.clear()
}