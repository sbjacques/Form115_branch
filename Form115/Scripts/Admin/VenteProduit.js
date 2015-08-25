$(function () {
    
    $("#IdSejour").change(loadHotel);


    $('#DateDepart').datepicker({
        format: "dd/mm/yyyy",
        todayBtn: "linked",
        language: "fr",
        autoclose: true,
        todayHighlight: true,
        endDate: "-1d"
    });

});

function loadHotel() {
    var s = "";
    var mq = $("#IdSejour").val();

    $.getJSON("/Admin/Produits/GetJSONHotel/" + mq, function (data) {

        $.each(data, function (idx, item) {

            s += '<option value ="' + item.Hotel + '">' + item.NomHotel+" - "+ item.Ville +'('+ item.Pays +')' + "</option>";

        });
        $("#IdHotel").html(s);

    });
}