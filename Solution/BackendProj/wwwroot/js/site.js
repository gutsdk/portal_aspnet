// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var IsPassVisible = false;
/*
function BodyLoad() {
    alert("Саня! Работай!");
    alert("Сава! Работай!");
    alert("Азат! Работай!");
}
*/
function EyeClick() {
    const InputPassword = document.getElementById("Pass_WORD");
    console.log(IsPassVisible);
    if (IsPassVisible) {
        IsPassVisible = false;
        InputPassword.setAttribute("type", "password");
    }
    else {
        IsPassVisible = true;
        InputPassword.setAttribute("type", "text");
    }
}