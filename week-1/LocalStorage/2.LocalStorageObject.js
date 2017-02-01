// JavaScript Document
"use strict";
(function()
{
	//Add event listeners
	document.getElementById('btnStore').addEventListener("click", storeUserName, false);
	document.getElementById('btnRetrieve').addEventListener("click", getUserName, false);
	document.getElementById('btnClear').addEventListener("click", clearUserName, false);
}());
//More practical example
//1. Click "Store", close browser, open browser, click "Retrieve", then click "Clear" and "retrieve" again.
function storeUserName()
{
	//Create person object
	var person = {};
	person.age = 25;
	person.firstName = 'Joe';
	person.lastName = 'Smith';
	//localStorage - setItem is typically used to store items in name/value
	//pairs up to a maximum of 5MB
	//The key here is 'persondetails' - the value is the person object to 
	//a JSON (JavaScript Object Notation) string
	localStorage.setItem('persondetails', JSON.stringify(person));
}

function getUserName()
{
	//getItem is used to retrieve an item (we must know what the key is as we may have stored more than one key)
	//JSON.parse is used to parse a string to JSON 
	var storedPerson = JSON.parse(localStorage.getItem('persondetails'));
	console.log("afddf");
	console.log(localStorage.getItem('persondetails'));
	storedPerson !== null?document.getElementById('username').innerHTML = storedPerson.age + ' ' + storedPerson.firstName + ' ' + storedPerson.lastName:document.getElementById('username').innerHTML="";
}

function clearUserName()
{
	//Clear 'persondetails' from local storage
	localStorage.removeItem('persondetails');
}

