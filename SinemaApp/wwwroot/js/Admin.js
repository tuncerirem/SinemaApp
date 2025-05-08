//$(document).ready(function () {


//    $("#seansAdet").on("input", function () {
//        const adet = parseInt($(this).val()) || 0;
//        const $seansInputs = $("#seansInputs");
//        $seansInputs.empty();

//        for (let i = 1; i <= adet; i++) {
//            const seansInput = `
//                <p>Seans ${i}</p>
//                <input type="datetime-local" id="seansBaslangic${i}" placeholder="Başlangıç">
//                <input type="datetime-local" id="seansBitis${i}" placeholder="Bitiş">
//                <br/><br/>
//            `;
//            $seansInputs.append(seansInput);
//        }
//    });

//    $("#filmEkleBtn").on("click", function () {
//        const film = getFilmData();

//        if (!isValid(film)) {
//            alert("Lütfen tüm alanları doldurun.");
//            return;
//        }

//        sendFilmToApi(film);
//    });


//    function getFilmData() {
//        const seanslar = [];
//        const adet = parseInt($("#seansAdet").val()) || 0;

//        for (let i = 1; i <= adet; i++) {
//            const baslangic = $(`#seansBaslangic${i}`).val();
//            const bitis = $(`#seansBitis${i}`).val();

//            if (baslangic && bitis) {
//                seanslar.push({ baslangic, bitis });
//            }
//        }

//        return {
//            ad: $("#filmAd").val(),
//            tur: $("#filmTur").val(),
//            zaman: parseInt($("#filmZaman").val()),
//            fotograf: $("#filmFotograf").val(),
//            fragman: $("#filmFragman").val(),
//            seanslar
//        };
//    }


//    function isValid(data) {
//        return data.ad && data.tur && data.zaman && data.fotograf && data.fragman && data.seanslar.length > 0;
//    }


//    function sendFilmToApi(data) {
//        $.ajax({
//            url: "https://localhost:44340/api/Admin/FilmEkle",
//            method: "POST",
//            contentType: "application/json",
//            data: JSON.stringify(data),
//            success: function (response) {
//                alert(response);
//                window.location.href = "/Home/Film";
//            },
//            error: function (xhr) {
//                alert("Hata oluştu: " + xhr.responseText);
//            }
//        });
//    }
//});




//$(document).ready(function () {
//    if (!token || !isAuthorized(token)) {
//        alert("Bu sayfayı görüntüleme yetkiniz yok.");
//        window.location.href = "/Login";
//    }

//    function isAuthorized(token) {
//        try {
//            const decoded = jwt_decode(token);
//            return decoded.role === 'Admin';
//        } catch (e) {
//            console.error("Token doğrulama hatası:", e);
//            return false;
//        }
//    }



//    $("#seansAdet").on("input", function () {
//        const adet = parseInt($(this).val()) || 0;
//        const $seansInputs = $("#seansInputs");
//        $seansInputs.empty();

//        for (let i = 1; i <= adet; i++) {
//            const seansInput = `
//                <div id="seans${i}">
//                    <p>Seans ${i}</p>
//                    <input type="datetime-local" id="seansBaslangic${i}" placeholder="Başlangıç" required>
//                    <input type="datetime-local" id="seansBitis${i}" placeholder="Bitiş" required>
//                    <br/><br/>
//                </div>
//            `;
//            $seansInputs.append(seansInput);
//        }
//    });

//    $("#filmEkleBtn").on("click", function () {
//        const film = getFilmData();

//        if (!isValid(film)) {
//            alert("Lütfen tüm alanları doldurun.");
//            return;
//        }

//        sendFilmToApi(film);
//    });

//    function getFilmData() {
//        const seanslar = [];
//        const adet = parseInt($("#seansAdet").val()) || 0;

//        for (let i = 1; i <= adet; i++) {
//            const baslangic = $(`#seansBaslangic${i}`).val();
//            const bitis = $(`#seansBitis${i}`).val();

//            if (baslangic && bitis) {
//                seanslar.push({ baslangic, bitis });
//            } else {
//                alert(`Seans ${i} için tüm bilgileri doldurduğunuzdan emin olun.`);
//                return null;
//            }
//        }

//        return {
//            ad: $("#filmAd").val(),
//            tur: $("#filmTur").val(),
//            zaman: parseInt($("#filmZaman").val()) || 0,
//            fotograf: $("#filmFotograf").val(),
//            fragman: $("#filmFragman").val(),
//            seanslar
//        };
//    }

//    function isValid(data) {
//        return data && data.ad && data.tur && data.zaman && data.fotograf && data.fragman && data.seanslar.length > 0;
//    }

//    function sendFilmToApi(data) {
//        $.ajax({
//            url: "https://localhost:44340/api/Admin/FilmEkle",
//            method: "POST",
//            contentType: "application/json",
//            data: JSON.stringify(data),
//            success: function (response) {
//                alert("Film ve seanslar başarıyla eklendi.");
//                window.location.href = "/Home/Film";
//            },
//            error: function (xhr) {
//                alert("Hata oluştu: " + xhr.responseText);
//            }
//        });
//    }
//    const token = localStorage.getItem("token");



//});

$(document).ready(function () {
    const token = localStorage.getItem("token");

  
    (async () => {
        if (!token || !(await isAuthorized(token))) {
            alert("Bu sayfayı görüntüleme yetkiniz yok.");
            window.location.href = "/Login";
            return;
        }
    })();

    setInterval(async () => {
        if (!(await isAuthorized(token))) {
            alert("Oturum süresi doldu.");
            localStorage.removeItem("token");
            window.location.href = "/Login";
        }
    }, 5000);

    async function isAuthorized(token) {
        try {
            const decoded = jwt_decode(token);
            const now = Date.now() / 1000;
            return decoded.exp > now && decoded.role === 'Admin';
        } catch (e) {
            console.error("Token doğrulama hatası:", e);
            return false;
        }
    }

    $("#seansAdet").on("input", function () {
        const adet = parseInt($(this).val()) || 0;
        const $seansInputs = $("#seansInputs");
        $seansInputs.empty();

        for (let i = 1; i <= adet; i++) {
            const seansInput = `
                <div id="seans${i}">
                    <p>Seans ${i}</p>
                    <input type="datetime-local" id="seansBaslangic${i}" placeholder="Başlangıç" required>
                    <input type="datetime-local" id="seansBitis${i}" placeholder="Bitiş" required>
                    <br/><br/>
                </div>
            `;
            $seansInputs.append(seansInput);
        }
    });

    $("#filmEkleBtn").on("click", async function () {
        const film = await getFilmData();

        if (!isValid(film)) {
            alert("Lütfen tüm alanları doldurun.");
            return;
        }

        await sendFilmToApi(film);
    });

    async function getFilmData() {
        const seanslar = [];
        const adet = parseInt($("#seansAdet").val()) || 0;

        for (let i = 1; i <= adet; i++) {
            const baslangic = $(`#seansBaslangic${i}`).val();
            const bitis = $(`#seansBitis${i}`).val();

            if (baslangic && bitis) {
                seanslar.push({ baslangic, bitis });
            } else {
                alert(`Seans ${i} için tüm bilgileri doldurduğunuzdan emin olun.`);
                return null;
            }
        }

        return {
            ad: $("#filmAd").val(),
            tur: $("#filmTur").val(),
            zaman: parseInt($("#filmZaman").val()) || 0,
            fotograf: $("#filmFotograf").val(),
            fragman: $("#filmFragman").val(),
            seanslar
        };
    }

    function isValid(data) {
        return data && data.ad && data.tur && data.zaman && data.fotograf && data.fragman && data.seanslar.length > 0;
    }

    async function sendFilmToApi(data) {
        try {
            const response = await $.ajax({
                url: "https://localhost:44340/api/Admin/FilmEkle",
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(data)
            });

            alert("Film ve seanslar başarıyla eklendi.");
            window.location.href = "/Home/Film";
        } catch (xhr) {
            alert("Hata oluştu: " + xhr.responseText);
        }
    }
});



