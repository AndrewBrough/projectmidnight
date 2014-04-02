window.onload = function(){
    //animate monster mouth open
    if(window.document.title != "Hyperion Title"){
        $("#monster-top").animate({
            "top":"-120%"
        }, 500);
        $("#monster-bot").animate({
            "bottom":"-120%"
        }, 500);
    }
}

function monsterClose(target){
    //fade out
//    $("#main").animate({
//        "opacity":"0"
//    }, 300, function(){
//        window.location.href = target;
//    })
    //animate monster mouth open
    $("#monster-top").animate({
        "top":"-20%"
    }, 300);
    $("#monster-top-start").animate({
        "top":"-20%"
    }, 300);
    $("#monster-bot").animate({
        "bottom":"-40%"
    }, 300, function(){
        window.location.href = target;
    });
     $("#monster-bot-start").animate({
        "bottom":"-40%"
    }, 300, function(){
        window.location.href = target;
    });
}