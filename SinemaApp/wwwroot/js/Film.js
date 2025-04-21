
$(document).ready(function () {
    $.ajax({
        url: "https://localhost:5001/api/Film/List", 
        type: "GET",
        dataType: "json",
        success: function (data) {
            $('#filmTable').DataTable({
                data: data,
                columns: [
                    { data: 'ad' },
                    { data: 'tur' },
                    { data: 'zaman' },
                    {
                        data: 'fotograf',
                        render: function (data) {
                            return `<img src="${data}" width="100" class="img-thumbnail" />`;
                        }
                    },
                    {
                        data: 'fragman',
                        render: function (data) {
                            return `<a href="${data}" target="_blank" class="btn btn-sm btn-outline-primary">İzle</a>`;
                        }
                    },
                    {
                        data: 'seanslar',
                        render: function (seanslar) {
                            if (!seanslar || seanslar.length === 0) return 'Seans yok';
                            return seanslar.map(s => {
                                const start = new Date(s.baslangic).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
                                const end = new Date(s.bitis).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
                                return `${start} - ${end}`;
                            }).join('<br>');
                        }
                    },
                    {
                        data: 'id',
                        render: function (id) {
                            return `
                                <a href="/Film/Details/${id}" class="btn btn-info btn-sm me-1">Detay</a>
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


