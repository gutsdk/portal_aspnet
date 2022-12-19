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
    if (IsPassVisible) {
        IsPassVisible = false;
        InputPassword.setAttribute("type", "password");
    }
    else {
        IsPassVisible = true;
        InputPassword.setAttribute("type", "text");
    }
}

function ChangeAbout() {
    const Change = document.getElementById("Change");
    const Save = document.getElementById("Save");
    const About = document.getElementById("about");
    const Label = document.getElementById("Label");

    Change.setAttribute("style", "visibility:hidden; height:0px; width:0px");
    Save.setAttribute("style", "visibility:visible");
    About.setAttribute("style", "visibility:visible");
    Label.setAttribute("style", "visibility:hidden; height:0px");
}

var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click", function () {
        /* Toggle between adding and removing the "active" class,
        to highlight the button that controls the panel */
        this.classList.toggle("active");

        /* Toggle between hiding and showing the active panel */
        var panel = this.nextElementSibling;
        if (panel.style.display === "block") {
            panel.style.display = "none";
        } else {
            panel.style.display = "block";
        }
    });
} 