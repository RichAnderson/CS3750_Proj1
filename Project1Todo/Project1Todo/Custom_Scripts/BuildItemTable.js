$(document).ready(function () {

    $.ajax({
        url: '/Items/BuildItemsTable',
        success: function (result) {
            $('#tableDiv').html(result);
        }

    });

});