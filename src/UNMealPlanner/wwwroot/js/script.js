
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

    //var checkExist = setInterval(function () {
    //    var today = document.getElementById("todayMobile");
    //    console.log('checking today');

    //    if (!!today) {
    //        console.log('found today');
    //        today.scrollIntoView();
    //        clearInterval(checkExist);
    //    }
    //}, 100);
});

function CheckForToday() {
    var checkExist = setInterval(function () {
        var today = document.getElementById("todayMobile");
        //console.log('checking today');

        if (!!today) {
            //console.log('found today');
            today.scrollIntoView();
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

//function showCalendarSwitchPopOver() {
//    $('#SwitchView').popover('hide');

//    $('#SwitchView').popover({
//        'placement':'left',
//        'content':'Tap to switch the view!'
//    }).popover('show');

//    setTimeout(function(){ $('#SwitchView').popover('hide'); }, 2000);
//}