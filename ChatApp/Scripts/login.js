function ShowModal() {
    $("#myModal").modal("show");
}
function hideModal() {
    $("#myModal").modal("hide");
    $("#dvContent").empty();

}
function ShowLoginModal() {
    $("#dvContent").load("http://localhost:1612/home/login");
    ShowModal();

}
function ShowSignUpModal() {
    $("#dvContent").load("http://localhost:1612/home/signup");
    
    ShowModal();

}

function login()
{
    var lg = {
        username:$('#txtUsername').val(),
        password: $('#txtPassword').val(),
        rememberMe: $("#remeberMe").val(),
    };
    $.ajax({
        type: "Post",
        url: 'http://localhost:1612/api/User',
        data: JSON.stringify(lg),
        contentType: "application/json",
        success: function (data) {
            if (data == null)
                $('#error').append("username or password  is NOT correct!!!")
            else
            {
                hideModal();
                location.href = "http://localhost:1612/Home/chat";
            }

        }
        
    })
}
function logout()
{
    $.ajax({
        type: "Get",
        url: 'http://localhost:1612/api/User/logout',
   
        success: function () {
            location.href = "http://localhost:1612/Home/index";


        }

    })
}
function signup() {
    var check=$('#agreement').val();
    var is;
    if(check=='on')
        is=true;
    var u = {
        username: $('#txtUsername').val(),
        password: $('#txtPassword').val(),
        agreement:is 
    };
    debugger;

    $.ajax({
        type: "POST",
        url: "http://localhost:1612/api/user/signup",
        data: JSON.stringify(u),
        contentType: "application/json",
        success: function (result) {
            hideModal();

            if (result) {
                alert("Check you email for signup confirmation!");
            }
            else {
                alert("There was a problem. Try again!");

            }
        }
    });
}