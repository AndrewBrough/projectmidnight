window.onload = function(){
    $(".section").css("height", window.innerHeight);
}

function clickShift(){
    console.log($("#main").css("margin-top"));
    if($("#main").css("margin-top") != 0){
        $("#main").animate({
            "margin-top":"0",
        },500);
        $(".break-50").animate({
            "height":"0px"
        },500);
    }
    if($("#main").css("margin-top") == "0px"){
        $("#main").animate({
            "margin-top":"22%",
        },500);
        $(".break-50").animate({
            "height":"525px"
        },500);
    }
}