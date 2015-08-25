$(function () {
    $("#listeContinents").change(loadRegions);
    $("#listeRegions").change(loadPays);
    $("#listePays").change(loadVilles);

    // DateTimePicker
    $("#DateDepart").datepicker({
        format: "dd/mm/yyyy",
        todayBtn: "linked",
        language: "fr",
        autoclose: true,
        todayHighlight: true,
        endDate: "-1d"
    });

});


function loadRegions() {
    IdContinent = $("#listeContinents").val();
    var str = "";
    $.getJSON("/Browse/GetJSONRegions/" + IdContinent, function (data) {

        // $.each(data, function (idx, mar) {
        // str += '<optgroup  label="' + mar.Marque + '">'
        $.each(data, function (idx, region) {
            str += '<option value="' + region.Id + '">' + region.Nom + "</option>";

        });
        //    str += '</optgroup>';
        //});
        $("#listeRegions").html(str);
    });
}

function loadPays() {
    IdRegion = $("#listeRegions").val();
    var str = "";
    $.getJSON("/Browse/GetJSONPays/" + IdRegion, function (data) {

        // $.each(data, function (idx, mar) {
        // str += '<optgroup  label="' + mar.Marque + '">'
        $.each(data, function (idx, pays) {
            str += '<option value="' + pays.Id + '">' + pays.Nom + "</option>";

        });
        //    str += '</optgroup>';
        //});
        $("#listePays").html(str);
    });
}


function loadVilles() {
    IdPays = $("#listePays").val();
    var str = "";
    $.getJSON("/Browse/GetJSONVilles/" + IdPays, function (data) {

        // $.each(data, function (idx, mar) {
        // str += '<optgroup  label="' + mar.Marque + '">'
        $.each(data, function (idx, ville) {
            str += '<option value="' + ville.Id + '">' + ville.Nom + "</option>";

        });
        //    str += '</optgroup>';
        //});
        $("#listeVilles").html(str);
    });
}