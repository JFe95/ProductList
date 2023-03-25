// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function incrementViewCount(i) {
    var count = document.getElementById('viewCount ' + i);
    var number = count.innerHTML;
    number++;
    count.innerHTML = number;
}