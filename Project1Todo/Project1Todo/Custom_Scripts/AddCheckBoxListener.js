﻿$(document).ready(function () {

    $('.ActiveCheck').change(function () {
       
        var self = $(this);         //reference self
        var id = self.attr('id');   // get id from html attribute
        var value = self.prop('checked');   //get the property from the checkbock

        //calls function and passes named pair vals once done setd vals in <div id="tableDiv" to result
        $.ajax({
            url: '/Items/AJAXEdit',   
            data: {
                id: id,
                value: value
            },
            type: 'Post',
            success: function (result) {
                $('#tableDiv').html(result);
            }
        })
    })

})