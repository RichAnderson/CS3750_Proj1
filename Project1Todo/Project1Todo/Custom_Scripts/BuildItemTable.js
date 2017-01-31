$(document).ready(function () {

    $.ajax({
        url: '/Items/BuildItemsTable',
        success: function (result) {
            $('#itemTableDiv').html(result);
        }

    });

});