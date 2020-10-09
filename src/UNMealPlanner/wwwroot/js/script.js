
document.addEventListener('contextmenu', event => event.preventDefault());

function goBack() {
    window.history.back();
}

function goForward() {
    window.history.forward();
}

$(document).ready(function () {
    if (!!mybutton) {
        mybutton.style.display = "none";
    }
});

function CollapseNavBar() {
    $('.navbar-collapse').collapse('hide');
}

function CheckQuickLinks() {
    var checkExist = setInterval(function () {
        var gallery = document.getElementById("gallery");
        //console.log('checking gallery');

        if (!!gallery) {
            $('#gallery').flickity({
                cellAlign: 'left',
                freeScroll: true,
                contain: true,
                pageDots: false,
                prevNextButtons: false,
                resize: true,
            });
            clearInterval(checkExist);
        }
    }, 100);
}

function CheckCalDays() {
    var checkExist = setInterval(function () {
        var gallery = document.getElementById("CalDays");
        //console.log('checking gallery');

        if (!!gallery) {
            var n = new Date().getDate();
            
            //console.log('Today Day ' + n);

            //if (n - 1 < 0) {
            //    n = 0
            //}

            $('#CalDays').flickity({
                cellAlign: 'left',
                freeScroll: true,
                contain: true,
               // wrapAround: true,
                pageDots: false,
                prevNextButtons: false,
                resize: false,
                initialIndex: n-1,
                friction: 0.08,
            });
            clearInterval(checkExist);
        }
    }, 100);
}

function CheckForToday() {
    var checkExist = setInterval(function () {
        var today = document.getElementById("todayMobile");
        //console.log('checking today');

        if (!!today) {
            //console.log('found today');
            today.scrollIntoView({behavior: "auto", block: "center", inline: "center"});
            clearInterval(checkExist);
        }
    }, 100);
}

//Get the button
var mybutton = document.getElementById("toTopBtn");

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction() };

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
