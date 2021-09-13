// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.  function changeButtonText3(text) {
function changeButtonText3(text) {
    console.log(text);
    dropdownMenuButton.innerHTML = text;
    region.innerHTML = `<input type="hidden" name="region" value="${text}" />`
}
