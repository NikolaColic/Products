// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$('#btnSearchProduct').on('click', function (e) {
    var filter = $('#txtSearchProduct').val();

    SearchProduct(filter);
});
function SearchProduct(vrednost) {


    $.ajax({
        type: 'GET',
        url: '/Product/Search',
        data: { value: vrednost },
        cache: false,
        dataType: "html",
        success: function (result) {

            $('.tableMain').html(result);
        },
       
    })
        .fail(function (xhr) {
            console.log('error : ' + xhr.status + ' - ' + xhr.statusText + ' - ' + xhr.responseText);
        });


}