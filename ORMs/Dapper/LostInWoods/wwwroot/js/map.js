$(document).ready(function(){
    let lat = $("#map").attr("lat");
    let long = $("#map").attr("long");
    var mymap = L.map('map').setView([lat, long], 13);
    L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', 
        {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            maxZoom: 18,
            id: 'mapbox.streets',
            accessToken: 'pk.eyJ1IjoiZmlyZXpkb2ciLCJhIjoiY2poMmZvM3Q0MDFoOTJxb2F6OWE3ZGFsYyJ9.07sqkwD4WXNIjSYetyHUZQ'
        }
    ).addTo(mymap);
});