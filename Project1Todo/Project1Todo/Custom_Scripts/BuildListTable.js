$(document).ready(function () {

    $.ajax({
        url: '/Lists/BuildListsTable',
        success: function (result) {
            $('#listTableDiv').html(result);
        }

    });

});