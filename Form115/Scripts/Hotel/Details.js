$(function () {
    $("#champDateDepart").datepicker({
        format: "dd/mm/yyyy",
        todayBtn: "linked",
        language: "fr",
        autoclose: true,
        todayHighlight: true,
        endDate: "-1d"
    });
});
