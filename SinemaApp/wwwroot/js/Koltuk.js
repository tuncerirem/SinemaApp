let secilenKoltuklar = [];

$(document).ready(function () {
    Koltuklar();
});


function Koltuklar() {
    VeriList("Koltuk", "GetAllKoltuks")
        .then(function (data) {
            $("#koltuklar").empty();
            data.forEach(function (koltuk) {
                const div = $("<div>")
                    .addClass("koltuk")
                    .text(koltuk.id)
                    .attr("data-id", koltuk.id)
                    .toggleClass("dolu", koltuk.durum === "Dolu")
                    .click(function () {
                        if ($(this).hasClass("dolu")) return;

                        $(this).toggleClass("secili");
                        const id = parseInt($(this).attr("data-id"));
                        if (secilenKoltuklar.includes(id)) {
                            secilenKoltuklar = secilenKoltuklar.filter(x => x !== id);
                        } else {
                            secilenKoltuklar.push(id);
                        }

                        $("#satinAlButton").prop('disabled', secilenKoltuklar.length === 0);
                    });

                $("#koltuklar").append(div);
            });
        })
        .catch(function () {
            alert("Koltuklar yüklenirken hata oluştu.");
        });
}



function satinAl() {
    $.ajax({
        url: 'https://localhost:44340/api/Koltuk/SatinAl',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(secilenKoltuklar),
        success: function (response) {
            alert(response.message || "Satın alma başarılı.");
            secilenKoltuklar = [];
            Koltuklar();
            $("#satinAlButton").prop('disabled', true);
        },
        error: function (xhr) {
            alert("Bir hata oluştu.");
        }
    });
}
