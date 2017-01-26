// JavaScript Document
"use strict";

(function () {
    //Add an event listener for the button click
    document.getElementById('btn').addEventListener("click", clearStorage, false);
}());

//localStorage allows us to 
//store data locally via the browser and is an alternative to 
//cookies. It is persistant as closing the browser page
//will not delete the storage
//What happens if you open this page in a new tab?
//What happens if you open this page in a new browser?
function clearStorage() {
    localStorage.clear();
    document.write("Total Hits : 0");
}

//Look for the key "hits" =>if null we have no data to retrieve,
//if not null we have some value there
if (localStorage.getItem("hits") !== null) {
    //The localStorage key "hits" exists so increment it by 1.
    //In this case we are updating the value for the name "hits" with a new value
    localStorage.setItem("hits", Number(localStorage.hits) + 1);
    //setItem stores data in key/value pairs
}
else {
    //The localStorage key does not exist so create it and set it to 1
    localStorage.setItem("hits", 1);
}

//Write out the value for the key "hits"
document.write("Total Hits :" + localStorage.hits);
//The above document.write statement is shorthand for:
//document.write("Total Hits :" + localStorage.getItem("hits"));
