window.onload = function(){
    
}

function clickShiftDown(){
    $("#main").animate({
        "margin-top":"0"
    },400);
    $(".break-50").animate({
        "height":"50px"
    },400);
//    $("body").css("overflow", "auto");
}

function togglePlay(){
    var video = document.getElementById("trailer");
    var mask = document.getElementById("videoMask")
    if(video.paused){
        video.play();
    } else {
        video.pause();
    }
}