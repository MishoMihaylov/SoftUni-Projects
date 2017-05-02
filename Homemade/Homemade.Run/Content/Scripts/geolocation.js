var map, infoWindow;
function initMap() {
    var HmLat = 42.697;
    var HmLng = 23.322;

    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: HmLat, lng: HmLng },
        zoom: 18
    });

    infoWindow = new google.maps.InfoWindow;

    var marker = new google.maps.Marker
    ({
        position: new google.maps.LatLng(HmLat, HmLng),
        map: map,
        title: 'Homemade is located here!'
    });
}
