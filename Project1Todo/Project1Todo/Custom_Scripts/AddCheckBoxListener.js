$(document).ready(function () {

    $('.ActiveCheck').change(function () {

        var self = $(this);         //reference self
        var id = self.prop('id');   // get id from html attribute
        var value = self.prop('checked');   //get the property from the checkbox

        //calls function and passes named pair vals once done setd vals in <div id="tableDiv" to result
        $.ajax({
            url: '/Items/AJAXEdit',
            data: {
                id: id,
                value: value
            },
            type: 'Post',
            success: function (data) {
                $('#itemTableDiv').html(data);
            }
        });
    });

});