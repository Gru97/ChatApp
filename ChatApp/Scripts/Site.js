var Globalreceiver_id;
var GlobalType;
      
function ShowModal() {
    $("#myModal").modal("show");
          
    getAllContacts();
}
function hideModal() {
    $("#myModal").modal("hide");
}

function getAllMessages(id, messageType) {

    Globalreceiver_id = id;
    GlobalType = messageType;
    var sr =
        {
            receiver_id: id,
            type: messageType
                  
        };
    $.ajax({

        type: "Get",
        url: 'http://localhost:1612/api/Chat/?receiver_id='+ sr.receiver_id + '&&type=' + sr.type,
        datatype: JSON,
        data: JSON.stringify(sr),// pass json object to web api
        success: function (messages) {

            //alert("successful retreival")
            debugger;

            $('#content').empty()
            $.each(messages, function (index, data) {
                let messageString =
            '<b>' + data.user_name + ':</b> ' + data.message_text + '<br />'
                $('#content').append(messageString)

            });
        }
    })
};

$(function getAllUsers() {

    $.ajax({

        type: "Get",
        url: 'http://localhost:1612/api/User/',
        datatype: JSON,
        success: function (users) {
            //debugger;
            //This each has a callback function that it's first argument is index?????????
            $.each(users, function (index, user) {

                let userInfo =
              '<li class="list-group-item" onClick="getAllMessages(\'' + user.user_id + '\',false)">' + user.username + '-' + user.status + '</li>'

                $('#contacts').append(userInfo)

            });
        }
    })
});

function getAllContacts(RoomID) {

    //for model
    $.ajax({

        type: "Get",
        url: 'http://localhost:1612/api/User/',
        datatype: JSON,
        success: function (users) {
            //debugger;

            $.each(users, function (index, user) {

                let userInfo =
              '<li class="list-group-item" onClick="AddUserToRoom(\'' + user.user_id + '\')">' + user.username + '-' + user.status + '</li>'

                $('#dvContent').append(userInfo)

            });
        }
    });

}

$(function getAllRooms() {
    $.ajax({
        type: "Get",
        url: 'http://localhost:1612/api/Room/',
        datatype: JSON,
        success: function (rooms) {
            $.each(rooms, function (index, room) {
                let roomInfo =
                    '<li class="list-group-item" onClick="getAllMessages(\'' + room.RoomID + '\',true)">' + room.RoomName + '-' + room.Picture + '</li>'

                $('#roomList').append(roomInfo)
            })
        }

    })

});

$(function getAllRooms() {
    $.ajax({
        type: "Get",
        url: 'http://localhost:1612/api/Room/' + $('#username').val(),
        datatype: JSON,
        success: function (rooms) {
            $.each(rooms, function (index, room) {
                let roomInfo =
                    '<li class="list-group-item" onClick="getAllMessages(\'' + room.RoomID + '\',1)">' + room.RoomName + '-' + room.Picture + '</li>'

                $('#myroomList').append(roomInfo)
            })
        }

    })

});

function SendMessage() {
    var message = {

        type:GlobalType,
        message_text: $('#txtMessage').val(),
        receiver_id: Globalreceiver_id
    };
    debugger;
    $.ajax({
        type: "POST",
        url: 'http://localhost:1612/api/Chat/',//change to your url
        data: JSON.stringify(message),// pass json object to web api
        contentType: 'application/json',
        success: function () {
            //alert('success!');
            $("#txtMessage").empty();
            $(function () {
            

                // Declare a proxy to reference the hub.
                let chatHubProxy =
                    $.connection.chatHub

                $.connection.hub.start()

                    .done(function () {

                        console.log($.connection.hub.id)

                        //$('#content').prepend('<br />Connection Started!')

                        let message = $('#txtMessage').val()
                        let userid = $('#username').val()

                        // Call the [SendMessage] method in the [ChatHub] class in server.
                        console.log(message)
                        chatHubProxy.server.sendMessage(userid, message)

                    })

                    .fail(function () {

                        console.log('Could not Connect!')

                    })
            });

        }
    });

}
// Create a javascript (client) function (method) for broadcasting by server.
$(function () {
    let chatHubProxy =
            $.connection.chatHub
    chatHubProxy.client.broadcastMessage = function (name, message) {
        //debugger;               //helps debugging the code
        //alert("This is the message" + message)
        let messageString =
            '<br /><b>' + name + ':</b> ' + message
        $('#content').append(messageString)

    }
});

function AddUserToRoom(id) {
    var rm = {
        RoomID: Globalreceiver_id,
        UserID: id
    };
    debugger;
    $.ajax({

        type: "GET",
        url: 'http://localhost:1612/api/User/AddUserToRoom/?RoomID=' + rm.RoomID + '&&UserID=' + rm.UserID,
        datatype: JSON,
        success: function (data) {
            hideModal();
            if (data !=null) {
                var joinMessage = data.User + " Added " + data.Added;
                $('#content').append(joinMessage);
            }


        }
    });

}

