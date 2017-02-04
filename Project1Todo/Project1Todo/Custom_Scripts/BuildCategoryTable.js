$(document).ready(function () {
    var listId = $("#ListID").val();

    $.ajax({
        url: '/Categories/BuildCategoriesTable',
        data: { id: listId },
        success: function (data) {
            $('#itemTableDiv').html(data);
        }

    });

});