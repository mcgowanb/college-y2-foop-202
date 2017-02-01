// JavaScript Document
"use strict";
(function () {
    //Add event listeners
    document.getElementById('btnStore').addEventListener("click", storeData, false);
    document.getElementById('btnRetrieveStudents').addEventListener("click", getStudents, false);
    document.getElementById('btnRetrieveClass').addEventListener("click", getClassDetails, false);
    document.getElementById('btnClear').addEventListener("click", clearDetails, false);
}());

function storeData() {
    //Create object classdtls
    var classdtls = {
        "Lecturer": "Joe Smith",
        "Room": "B1041",
        "Day": "Thursday",
        "Time": "14:00 - 16:00",
        "Group": "Software and Web Development",
        "s00001": "Mary Harrison",
        "s00002": "Paul Feeney",
        "s00003": "Sarah McWeeney",
        "s00004": "Joe Bloggs"
    };
    //Store the object to local storage
    localStorage.setItem('classdetails', JSON.stringify(classdtls));
}

function getClassDetails() {
    //Get the details for the class and display
    document.getElementById('classinfo').innerHTML = "";
    var classinf = JSON.parse(localStorage.getItem('classdetails'));
    document.getElementById('classinfo').innerHTML = classinf.Lecturer + ' ' + classinf.Room + ' ' + classinf.Day + ' ' + classinf.Time + ' ' + classinf.Group + ' ' + classinf.s00001 + ' ' + classinf.s00002 + ' ' + classinf.s00003 + ' ' + classinf.s00004;
}

function getStudents() {
    //Display the student details only
    document.getElementById('classinfo').innerHTML = "";
    var classinf = JSON.parse(localStorage.getItem('classdetails'));
    document.getElementById('classinfo').innerHTML = classinf.s00001 + ' ' + classinf.s00002 + ' ' + classinf.s00003 + ' ' + classinf.s00004;
}

function clearDetails() {
    //Clear 'persondetails from local storage
    localStorage.removeItem('classdetails');
}

