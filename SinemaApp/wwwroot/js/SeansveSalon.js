$(document).ready(function () {
    VeriList("Salon", "GetAllSalons")
        .then(function (data) {
            $('#salonSeansTable').DataTable({
                data: data, 
                columns: [
                    {
                        data: 'ad',
                        title: 'Salon Adý'
                    },
                    {
                        data: 'seanslar',
                        title: 'Seanslar',
                        render: function (seanslar) {
                            if (!seanslar || seanslar.length === 0) return 'Seans yok';
                            return seanslar.map((seans) => {
                                const start = new Date(seans.baslangic).toLocaleTimeString([], {
                                    hour: '2-digit', minute: '2-digit'
                                });
                                const end = new Date(seans.bitis).toLocaleTimeString([], {
                                    hour: '2-digit', minute: '2-digit'
                                });
                                return `
                                    <button 
                                        id="seans-${seans.seansId}" 
                                        class="btn btn-info btn-sm seans-sec" 
                                        data-salon-id="${seans.salonId}" 
                                        data-seans-id="${seans.seansId}" 
                                        data-baslangic="${seans.baslangic}" 
                                        data-bitis="${seans.bitis}">
                                        ${start} - ${end}
                                    </button>`;
                            }).join('<br>');
                        }
                    }
                ]
            });

            
            $(document).on('click', '.seans-sec', function () {
                var salonId = $(this).data('salon-id');
                var seansId = $(this).data('seans-id');

                window.location.href = `/Home/Koltuklar?seansId=${seansId}&salonId=${salonId}`;
            });
        })
        .catch(function (err) {
            console.error("Salon verisi alýnamadý", err);
        });
});
