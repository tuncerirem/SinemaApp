$(document).ready(function () {
    $.ajax({
        url: "https://localhost:44340/api/Film/GetAllFilms",  
        type: "GET",
        dataType: "json",
        success: function (data) {
           
            $('#filmTable').DataTable({
                data: data,
                ordering: false, // datatable da otomatik gelen sıralama butonlarını pasif istediğim için
                columns: [
                    {
                        data: 'ad',
                        title: 'Film Adı'
                    },
                    {
                        data: 'tur',
                        title: 'Tür'
                    },
                    {
                        data: 'zaman',
                        title: 'Zaman'
                    },
                    {
                        data: 'fotograf',
                        title: 'Fotoğraf',
                        render: function (data) {
                            return `<img src="${data}" width="100" class="img-thumbnail" />`;
                        }
                    },
                    {
                        data: 'fragman',
                        title: 'Fragman',
                        render: function (data) {
                            return `<a href="${data}" target="_blank" class="btn btn-sm btn-outline-primary">İzle</a>`;
                        }
                    },
                    {
                        data: 'seanslar',
                        title: 'Seanslar',
                        render: function (seanslar) {
                            if (!seanslar || seanslar.length === 0) return 'Seans yok';
                            return seanslar.map((s, index) => {
                                const start = new Date(s.baslangic).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
                                const end = new Date(s.bitis).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
                                return `<button class="btn btn-info btn-sm seans-sec" data-seans-id="${index}" data-baslangic="${s.baslangic}" data-bitis="${s.bitis}">${start} - ${end}</button>`;
                            }).join('<br>');
                        }
                    },
                    {
                        data: 'id',
                        render: function (id) {
                            return `
                                <a href="/Bilet/SatinAl/${id}" class="btn btn-success btn-sm">Bilet Al</a>
                            `;
                        }
                    }
                ]
            });
        },
        error: function (err) {
            console.error("Veri alınamadı", err);
        }
    });
});

