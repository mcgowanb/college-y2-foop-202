// JavaScript Document
"use strict";

//Use an Immediately Invoked Function Expression to 
//add our event handlers
(function () {
    document.getElementById('file').addEventListener("change", processFile, false);
    document.getElementById('fileToRetrieve').addEventListener("click", retrieveFile, false);
    document.getElementById('clear').addEventListener("click", clearStorage, false);
})();

//This function will be called after the user has selected a file
function processFile() {
    //Only dealing with one file
    var file = document.getElementById('file').files[0];
    //Pass the file for writing to local storage
    writeFileToStorage(file);
}

function writeFileToStorage(file) {
    var reader = new FileReader(); //1.
    reader.onload = function () //3.
    {
        //Callback for when the loading is complete
        localStorage.setItem("myFile", reader.result);
        document.getElementById('output').innerHTML = reader.result;
    };
    reader.onerror = function () {
        //onerror is an event handler for FileReader
        alert("There was an error reading the file");
    };
    reader.readAsText(file); //2.
    console.log('Code still executing');
}

function retrieveFile() {
    var file = localStorage.getItem("myFile");
    if (file !== null) {
        var p = document.createElement("pre");
        p.innerHTML = file;
        document.getElementById('retrieve').appendChild(p);
    }
    else {
        document.getElementById('retrieve').innerText = "";
    }
}

function clearStorage() {
    localStorage.clear();
}