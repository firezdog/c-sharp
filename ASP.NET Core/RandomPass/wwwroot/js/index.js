$(document).ready(function(){
    $("#generate").click(function(){
        $.get("/ajax", function(data){
            $("p").text(data.random);
            $("span").text(data.visited);
        });
    });
});
