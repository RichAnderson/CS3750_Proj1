$(document).ready(function () {
    var listId = $("#ListID").val();

    $.ajax({
        url: '/Items/BuildItemsTable',
        data: { id: listId },
        success: function (data) {
            $('#itemTableDiv').html(data);
        }

    });

});