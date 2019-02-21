                    
    $('button[name="Igrac"]').click(function () {
        var Igrac = $(this).attr("data-igracNaziv");
        var IdIgraca = $(this).attr("data-IgracId");
        var IdUtakmice = $(this).attr("data-UtakmicaId");
        //console.log(IdIgraca, IdUtakmice);
        $('#ImePrezimeIgraca').html(Igrac);
        $('#IdUtakmice').val(IdUtakmice);
        $('#IdIgraca').val(IdIgraca);

    $("#modalPrikaz").modal('show');                     
});


    $("#btnSacuvaj").click(function () {

        var data = {
            UtakmicaId: Number($('#IdUtakmice').val()),
            IgracId: Number($('#IdIgraca').val()),
            BrojOdigranihMinuta: $('#MinuteIgre').val(),
            BrojPostignutihGolova: $('#PostignutiGolovi').val(),
            BrojZutihKartona: $('#ZutiKartoni').val(),
            CrveniKarton: false
        };
        if (data.BrojZutihKartona === 2) { data.CrveniKarton = true; } else { data.CrveniKarton = false; }

        $.post("/RasporedUtakmica/UnosUcinka", data, function (success) {
            console.log(success);
            if (success) {

                console.log(success);
                $.get("/RasporedUtakmica/Details", { id: data.UtakmicaId }, function (podaci) {
                    $(".mica").html(podaci);
                });

                $('#ImePrezimeIgraca').html('');
                $("#txtMessage").html("");
                $("#txtNaziv").val("");
                $("#modalPrikaz").modal('hide');
                             
                       
            } else {
                $("#txtMessage").html("Doslo je do greske pri upisu u bazu");
            }
    });
});





