/// <reference path="jquery-3.4.1.min.js" />
function getAccessToken()
{
    if (location.hash)
    {
        if (location.hash.split('access_token='))
        {
            var accessToken = location.hash.split('access_token=')[1].splite('&')[0];
            if (accessToken)
            {
                isUserRegistered(accessToken);
            }
        }
    }

}

function isUserRegistered(accessToken) {
    $.ajax({
        url: 'api/Account/Userinfo',
        methode: 'GET',
        headers: {
            'content-type': 'application/JSON',
            'Authorization': 'Bearer' + accessToken

        },
        success: function (response) {
            if (response.HasRegistered) {
                localStorage.setItem('accessToken', accessToken);
                localStorage.setItem('userName', response.Email);
                window.location.href = "Data.html";
            }
            else {
                signupExternalUser(accessToken response.LoginProvider);
            }
        }

    });

function signupExternalUser(accessToken , provider) {
    $.ajax({
        url: 'api/Account/RegisterExternal',
        methode: 'POST',
        headers: {
            'content-type': 'application/JSON',
            'Authorization': 'Bearer' + accessToken

        },
        success: function (response) {    
            if (response.HasRegistered) {
                localStorage.setItem('accessToken', accessToken);
                localStorage.setItem('userName', response.Email);
                window.location.href = "Data.html";
            }
            else {
                signupExternalUser(accessToken);
            }
        }

    });

}