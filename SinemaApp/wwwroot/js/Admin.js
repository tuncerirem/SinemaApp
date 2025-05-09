$(document).ready(function () {
    
    const token = localStorage.getItem("token");
    if (!token || !isValidToken(token)) {
        alert("Giriş yapmalısınız.");
        localStorage.removeItem("token");
        window.location.href = "/Login";
        return;
    }

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

    setInterval(() => {
        const currentToken = localStorage.getItem("token");
        if (!isValidToken(currentToken)) {
            alert("Oturum süresi doldu.");
            localStorage.removeItem("token");
            sessionStorage.clear();
            window.location.href = "/Login";
        }
    }, 5000);

  
    $("#seansAdet").on("input", function () {
        const adet = parseInt($(this).val()) || 0;
        const $seansInputs = $("#seansInputs").empty();

        for (let i = 1; i <= adet; i++) {
            $seansInputs.append(`
                <div id="seans${i}">
                    <p>Seans ${i}</p>
                    <input type="datetime-local" id="seansBaslangic${i}" required>
                    <input type="datetime-local" id="seansBitis${i}" required>
                    <br/><br/>
                </div>
            `);
        }
    });

   
    $("#filmEkleBtn").on("click", async function () {
        const film = await getFilmData();
        if (!film || !isValid(film)) {
            alert("Lütfen tüm alanları doldurun.");
            return;
        }

        try {
            await VeriGonder("Admin", "FilmEkle", film);
            alert("Film ve seanslar başarıyla eklendi.");
            window.location.href = "/Home/Film";
        } catch (xhr) {
            alert("Hata oluştu: " + xhr.responseText);
        }
    });

    
    async function getFilmData() {
        const seanslar = [];
        const adet = parseInt($("#seansAdet").val()) || 0;

        for (let i = 1; i <= adet; i++) {
            const baslangic = $(`#seansBaslangic${i}`).val();
            const bitis = $(`#seansBitis${i}`).val();

            if (!baslangic || !bitis) {
                alert(`Seans ${i} için tüm bilgileri doldurunuz.`);
                return null;
            }

            seanslar.push({ baslangic, bitis });
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
        return data && data.ad && data.tur && data.zaman > 0 && data.fotograf && data.fragman && data.seanslar.length > 0;
    }
});
