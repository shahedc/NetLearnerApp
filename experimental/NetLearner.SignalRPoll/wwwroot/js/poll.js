"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/pollHub").build();
var chartBlock = '\u25A3'; //(U+25A3) is "▣" 

connection.on("ReceiveMessage", function (user, message, myProjectId, myProjectVal) {
    // alert("myProjectId=" + myProjectId + ",myProjectVal=" + myProjectVal);
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    // var encodedMsg = user + " says " + msg;
    var pollResultMsg = user + " voted for '" + myProjectVal + "'.";

    // var liMessage = document.createElement("li");
    // liMessage.textContent = encodedMsg;
    // document.getElementById("messagesList").appendChild(liMessage);

    var ulPoll = document.getElementById("messagesList");
    var liPollResult = document.createElement("li");
    liPollResult.textContent = pollResultMsg;

    // append to top
    ulPoll.insertBefore(liPollResult, ulPoll.childNodes[0]);

    // append to end
    // document.getElementById("messagesList").appendChild(liPollResult);

    // append to chart block
    document.getElementById(myProjectId + 'Block').innerHTML += chartBlock;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = ""; //document.getElementById("messageInput").value;
    //var myProject = document.getElementById("myProject").value;

    if (!user) {
        user = "[anonymous]";
    }

    if ($('input:radio[name=myProject]').is(':checked')) {
        var myProjectId = $('input[name=myProject]:checked').attr('id');
        var myProjectVal = $('input[name=myProject]:checked').val();
        connection.invoke("SendMessage", user, message, myProjectId, myProjectVal).catch(function (err) {
            return console.error(err.toString());
        });
    } else {
        return console.log("No option selected.");
    }

    event.preventDefault();
});