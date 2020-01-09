/*=========================================================================================
    File Name: maps.js
    Description: google maps
    ----------------------------------------------------------------------------------------
    Item Name: Apex - Responsive Admin Theme
    Version: 1.0
    Author: PIXINVENT
    Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/

// Gmaps Maps
// ------------------------------

$(window).on("load", function () {

  // Basic Map
  // ------------------------------
  new GMaps({
    div: '#basic-map',
    lat: 19.35888888888889,
      lng: -99.22472222222223,
    height: 400,
    zoom: 25
  });

});
