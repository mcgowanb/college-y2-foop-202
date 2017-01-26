// JavaScript Document
"use strict";
window.addEventListener("load", function (event) {
    var key = document.getElementById("key");
    var value = document.getElementById("value");
    var add = document.getElementById("add");
    var remove = document.getElementById("remove");
    var clear = document.getElementById("clear");
    var content = document.getElementById("content");

    add.addEventListener("click", function (event) {
        if (key.value !== "") {
            try {
                localStorage.setItem(key.value, value.value);
            }
            catch (e) {
                alert("Exceeded Storage Quota!");
            }
            refreshContents();
        }
    });

    remove.addEventListener("click", function (event) {
        if (key.value !== "") {
            localStorage.removeItem(key.value);
            refreshContents();
        }
    });

    clear.addEventListener("click", function (event) {
        localStorage.clear();
        refreshContents();
    });

    function refreshContents() {
        var str = "";

        for (var i = 0, len = localStorage.length; i < len; i++) {
            var k = localStorage.key(i);
            var v = localStorage.getItem(k);
            str += "'" + k + "' = '" + v + "'<br />";
        }

        key.value = "";
        value.value = "";
        content.innerHTML = str;
    }

    refreshContents();
});
