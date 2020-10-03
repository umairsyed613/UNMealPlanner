
document.addEventListener('contextmenu', event => event.preventDefault());

function goBack() {
    window.history.back();
}

function goForward() {
    window.history.forward();
}


$(document).ready(function() {
    if (!!mybutton) {
        mybutton.style.display = "none";
    }

    if (!!document.getElementById("todayMobile")) {
        document.getElementById("todayMobile").scrollIntoView();
    }
});


//Get the button
var mybutton = document.getElementById("toTopBtn");

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function() {scrollFunction()};

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        mybutton.style.display = "inline-block";
    } else {
        mybutton.style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}