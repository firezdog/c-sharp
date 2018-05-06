$(document).ready(function(){
    $("button").click(function(){
        var button = $(this).text();
        if (button == "Reset"){
            $.get("reset", function(pet){
                updatePet(pet);
                $("#playing").show();
                $("#loss").attr("hidden",true);
            });        
        } else {
            $.get(`action/${button}`, function(pet){
                updatePet(pet);
                if (pet.fullness == 0 || pet.happiness == 0){
                    gameChange("Your Tomaguch is dead :(");
                } else if (pet.energy > 100 && pet.fullness > 100 && pet.happiness > 100) {
                    gameChange("You won :)");
                }
            });
        }
    });
    function updatePet(pet){
        $("#fullness").html(pet.fullness);
        $("#happiness").html(pet.happiness);
        $("#energy").html(pet.energy);
        $("#meals").html(pet.meals);
        $("#action").html(pet.action);
    }
    function gameChange(message){
        $("#playing").hide();
        $("#loss").attr("hidden",false);
        $("#loss").find("h1").text(message);
    }
});