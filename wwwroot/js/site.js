// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#currency").on("change", function () {
    

})

$(document).ready(function () {
    GetShoesPrice();
    GetBatPrice();
    GetBallPrice();
});
function GetShoesPrice() {
    var id = "#shoes";
    $.ajax({
        type: "GET",
        url: 'Home/GetProduct/',
        data: { 'productname': "shoes" },
        contentType: "application/text; charset=utf-8",
        success: function (response) {
            AddPrice(response, id);
        }

    });
}

function GetBatPrice() {
    var id = "#bat";
    $.ajax({
        type: "GET",
        url: 'Home/GetProduct/',
        data: { 'productname': "bat" },
        contentType: "application/text; charset=utf-8",
        success: function (response) {
            AddPrice(response,id);
        }

    });
}
function GetBallPrice() {
    var id = "#ball";
    $.ajax({
        type: "GET",
        url: 'Home/GetProduct/',
        data: { 'productname': "ball" },
        contentType: "application/text; charset=utf-8",
        success: function (response) {
            AddPrice(response, id);
        }

    });
}


    
function AddPrice(x, id) {
    
    
        $(id).text(x);
};



