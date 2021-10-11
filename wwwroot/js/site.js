// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var exchangeRate;
var XSRFToken = $("input[name='__RequestVerificationToken']").val();
$("#currency").on("change", function () {

    var value = $("#currency").val();
 
    $.ajax({
        type: "GET",
        url: 'Home/GetExchangeRate',
        data: { 'currency': value},
        success: function (response) {
            ChangePrice(response);
        }
    })

   
})

function ChangePrice(data) {
    var shoesprice = $("#shoes").text() / data;
    var batprice = $("#bat").text() / data;
    var ballprice = $("#ball").text() / data;


    $("#shoes").text(shoesprice.toFixed(2));
    $("#bat").text(batprice.toFixed(2));
    $("#ball").text(ballprice.toFixed(2));

}

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



