$(function () {
    $("a.Continents").click(function () {

        //switch ($("#texteChoix").html()) {
           // case "Choix du continent":
                //break;
            //case "Choix de la région":
            //    break;
            //case "Choix du pays":
            //    break;
            //case "Choix de la ville":
            //    loadHotels($(this).prop("id"));
            //    $("#texteChoix").html("Choix de l'hôtel");
            //    break;
            //default:
            //    console.log('hello');
            //    };

        loadRegions($(this).prop("id"));
        $("#texteChoix").html("Choix de la région");
        //$("#BreadCrumb").html('Parcourir le catalogue >> <a href="Browse" id="Continents">Continents</a> >> Régions');
        $("#BreadCrumb").html('Parcourir le catalogue >> <a href="Browse" id="Continents">Continents</a> >> <span href="#" id="Continent">' + $(this).html() + '</span> ');
        
        return false;
    });
});

function loadRegions(IdContinent) {
    var str = '';
    if (IdContinent != 0) {
        $.getJSON("/Browse/GetJSONRegions/" + IdContinent, function (data) {

            $.each(data, function (idx, region) {
                str += '<li><a class="Regions" href="#" id="' + region.Id + '">' + region.Nom + '</a></li>';
            });

            $("#listeChoix").html(str);

            
            $("a.Regions").click(function () {
                loadPays($(this).prop("id"));
                $("#texteChoix").html("Choix du pays");
                $("#BreadCrumb").html('Parcourir le catalogue >> <a href="Browse" id="Continents">Continents</a> >> <a href="#" id="Continent">' + $("#Continent").html() + '</a> >> <span href="#" id="Region">' + $(this).html() + '</span> ');
                $("#Continent").click(function () {

                    loadRegions(IdContinent);
                    $("#texteChoix").html("Choix de la région");

                    $("#BreadCrumb").html('Parcourir le catalogue >> <a href="Browse" id="Continents">Continents</a> >> <span href="#" id="Continent">' + $("#Continent").html() + '</span> ');
                    $('#Continent').data('id', IdContinent);
                });
            });
            //$("#Regions").click(function () {
            //    loadRegions(IdContinent);
            //    $("#texteChoix").html("Choix du pays");
            //});
        });
        
        
    }
}

function loadPays(IdRegion) {
    var str = '';
    if (IdRegion != 0) {
        $.getJSON("/Browse/GetJSONPays/" + IdRegion, function (data) {

            $.each(data, function (idx, pays) {
                str += '<li><a class="Pays" href="#" id="' + pays.Id + '">' + pays.Nom + '</a></li>';
            });

            $("#listeChoix").html(str);
            $("a.Pays").click(function () {

                loadVilles($(this).prop("id"));
                $("#texteChoix").html("Choix de la ville");

                IdContinent = $('#Continent').data('id');
                $("#BreadCrumb").html('Parcourir le catalogue >> <a href="Browse" id="Continents">Continents</a> >> <a href="#" id="Continent">' + $("#Continent").html() + '</a> >> <a href="#" id="Region">' + $("#Region").html() + '</a> >> <span href="#" id="Pays">' + $(this).html() + '</span> ');
                $('#Continent').data('id', IdContinent);
                $("#Continent").click(function () {
                    loadRegions(IdContinent);
                    $("#texteChoix").html("Choix de la région");

                    $("#BreadCrumb").html('Parcourir le catalogue >> <a href="Browse" id="Continents">Continents</a> >> <span href="#" id="Continent">' + $("#Continent").html() + '</span> ');
                });
                $("#Region").click(function () {

                    loadPays(IdRegion);
                    $("#texteChoix").html("Choix du pays");

                    $("#BreadCrumb").html('Parcourir le catalogue >> <a href="Browse" id="Continents">Continents</a> >> <a href="#" id="Continent">' + $("#Continent").html() + '</a> >> <span href="#" id="Region">' + $(this).html() + '</span> ');
                    $('#Continent').data('id', IdContinent);
                    $("#Continent").click(function () {
                        loadRegions(IdContinent);
                        $("#BreadCrumb").html('Parcourir le catalogue >> <a href="Browse" id="Continents">Continents</a> >> <span href="#" id="Continent">' + $("#Continent").html() + '</span> ');
                        $("#texteChoix").html("Choix de la région");
                    });
                });
            });
            });
    }
}


function loadVilles(IdPays) {
    var str = '';
    if (IdPays != 0) {
        $.getJSON("/Browse/GetJSONVilles/" + IdPays, function (data) {

            $.each(data, function (idx, ville) {
                str += '<li><a class="Villes" href="Search/Result/' + ville.Id + '">' + ville.Nom + '</a></li>';
            });

            $("#listeChoix").html(str);
        });
    }
}
