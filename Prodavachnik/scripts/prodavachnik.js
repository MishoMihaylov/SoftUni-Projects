function startApp() {

}


let AppKey = "kid_rJG5SsqH";
let AppSecret = "50154345e5af4d1aabc9210c426e2be3";
let BaseUrl = "https://baas.kinvey.com/";

function login(username, password){
    let cred = {"username" : username, "password": password}

    let req = {
        url: BaseUrl + "user/" + AppKey + "login",
        method: "POST",
        headers: {
            "Authorization" : "Basic" + btoa(AppKey + ":" + AppSecret)
        },
        data: JSON.stringify(cred),
        success: loginSuccess(data),
        error: loginError()
    };

    function loginSuccess(data){
        let authToken = data._kmd[authtoken];
    }

    function loginError(){

    }

    let result = $.ajax(req);
}

function showView(name){
    $('section').hide();

    switch(name){
        case 'home':
            $('#viewHome').show();
            break;
        case 'login':
            $('#viewLogin').show();
            break;
        case 'register':
            $('#viewRegister').show();
            break;

    }
}