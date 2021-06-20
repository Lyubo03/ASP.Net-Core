function login(){
//post
    let username = $('#username-login').val();
    let password = $('#password-login').val();

    $('#username-login').val('');
    $('#password-login').val('');

    let requestBody = {
        username : username,
        password : password
    };

    console.log(requestBody)

    $.post({
        url: APP_SERVICE_URL + 'user/login',
        headers: {
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(requestBody),
        success: function (data) {
            hideGuestNavbar(),
            $('#caption').text('Welcome to Chat-Inc!');
            let token = data.rawHeader +
                '.' +
                data.rawPayload +
                '.' +
                data.rawSignature;
            saveToken(token);

            $('#username-logged-in').text(getUser());

            hideLoginAndRegisterAndShowLoggedInData();
        },
        error: function(){
            console.error(error);
        }
    });
}

function hideGuestNavbar(){
    $('guest-navbar')
        .removeClass('d-flex')
        .addClass('d-none');
}

function showGuestNavbar(){
        $('guest-navbar')
            .removeClass('d-none')
            .addClass('d-flex');
}

function register(){
//post
    let username = $('#username-register').val();
    let password = $('#password-register').val();

    $('#username-register').val('');
    $('#password-password').val('');

    let requestBody = {
        username: username,
        password: password
    };

    $.post({
        url: APP_SERVICE_URL + 'user/register',
        headers: {
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(requestBody),
        success: function (data) {
            toggleLogin();
        },
        error: function (error) {
            console.error(error);
        }
    });
}

function toggleLogin(){
    $('#login-data').show();
    $('#register-data').hide();

}

function toggleRegister(){
    $('#register-data').show();
    $('#login-data').hide();
}

function hideLoginAndRegisterAndShowLoggedInData(){
    $('#register-data').hide();
    $('#login-data').hide();

    $('#logged-in-data').show();
}

function showLoginAndHideLoggedInData(){
    toggleLogin();

    $('#logged-in-data').hide();
}

function logout() {
    //TODO: Copy Functionality described in the Document
$('#caption').text('Choose your username to begin chatting!')
    showLoginAndHideLoggedInData();

    showGuestNavbar();
}

function isLoggedIn(){
return localStorage.getItem('auth_token') !=null;
}

function saveToken(token){
localStorage.setItem('auth_token', token);

}

function evicToken(){
localStorage.removeItem('auth_token', token);
}

function getUser(){
let token = localStorage.getItem('auth_token');

let claims = token.split('.')[1];
let decodedClaims = atob(claims);
let parsedClaims = JSON.parse(decodedClaims);

return parsedClaims.name;
}

$('#logged-in-data').hide();
toggleLogin();