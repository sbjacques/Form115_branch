$("a.pageLink").click(function () {
    $("#idCurrentPage").val($(this).html());
    $("#idFormPagination").submit();
    return false;
});