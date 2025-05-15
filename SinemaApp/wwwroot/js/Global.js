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

    return true;
}

function isValidToken() {



    const token = localStorage.getItem("token");
    try {
        if (token) {
            const decoded = jwt_decode(token);
            const now = Date.now() / 1000;

            if (decoded.exp >= now) {
                return true; // Token geçerli
            } else {
                // Süresi dolmuş token
                localStorage.removeItem("token");
                localStorage.removeItem("role");
                sessionStorage.clear();
                window.location.href = "/Login";
                return false;
            }
        } else {
            return false; // Token yok
        }
    } catch (e) {
        // Token çözümlenemedi (bozuk olabilir)
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
        if (!window.location.href.includes("/Login")) {
            window.location.href = "/Login";
        }
        return false;
        //if (!isValidToken(token)) {
        //    localStorage.removeItem("token");
        //    localStorage.removeItem("role");
        //    window.location.href = "/Login";
        //    return false;
        //}
        //else {
        //    localStorage.setItem("token", token);
        //}
        
    }
    try {
        isValidToken(token);
    } catch {
        localStorage.removeItem(token);
        
        
    }
        //try {
        //    if (token != null) {
        //        const decoded = jwt_decode(token);
        //        /*const role = decoded.role;*/
        //        const role = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];


        //        if (requiredRole && role !== requiredRole) {
        //            alert("Bu sayfayı görüntüleme yetkiniz yok.");
        //            localStorage.removeItem("token");
        //            window.location.href = "/Login";
        //            return false;
        //        }
        //        return true;
        //    }
        //} catch (e) {
        //    alert("Token çözümlenemedi.");
        //    localStorage.removeItem("token");
        //    window.location.href = "/Login";
        //    return false;
        //}
    
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