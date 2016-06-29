const kinveyAppId = 'kid_rJG5SsqH';
const kinveyAppSecret = '50154345e5af4d1aabc9210c426e2be3';
const kinveyServiceUrl = 'https://baas.kinvey.com/';

function register(){
    const kinveyRegisterUrl = kinveyServiceUrl + "user/" + kinveyAppId + "/";
    const kinveyAuthHeaders = {'Authorization': "Basic " + btoa(kinveyAppId + ':' + kinveyAppSecret)};
    let userData = {
        username: $('#register-username').val(),
        password: $('#register-password').val()
    };

    $.ajax({
        method: "POST",
        url: kinveyRegisterUrl,
        headers: kinveyAuthHeaders,
        data: userData,
        success: login,
        error: showError
    });
}

function login(parameters) {
    const kinveyLoginUrl = kinveyServiceUrl + "user/" + kinveyAppId + "/login";
    const kinveyAuthHeaders = {'Authorization': "Basic " + btoa(kinveyAppId + ':' + kinveyAppSecret)};
    let userData;

    if(typeof(parameters) === 'undefined'){
        userData = {
            username: $('#login-username').val(),
            password: $('#login-password').val()
        }
    }else {
        userData = {
            username: parameters.username,
            password: parameters.password
        }
    }

    $.ajax({
        method: "POST",
        url: kinveyLoginUrl,
        headers: kinveyAuthHeaders,
        data: userData,
        success: loginSuccess,
        error: showError
    });

    function loginSuccess(response){
        let userAuth = response._kmd.authtoken;
        sessionStorage.setItem('authToken', userAuth);
        showHiddenNavigationLinks();
        showHomeView();
        let username = response.username;
        username = username.substr(0, 1).toUpperCase() + username.substr(1);
        let noteMsg = 'Logged as ' + username;
        showNote(noteMsg);
    }
}

function booksAvailable(){
    const kinveyBooksAvailableUrl = kinveyServiceUrl + "appdata/" + kinveyAppId + "/books";
    const kinveyAuthHeaders = {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')};

    $.ajax({
        method: "GET",
        url: kinveyBooksAvailableUrl,
        headers: kinveyAuthHeaders,
        success: loadBooksSuccess,
        error: showError
    });

    function loadBooksSuccess(books){
        if(books.length == 0){
            $('#current-books').text('No available books at the moment.')
        }else{
            showNote("Books loaded");

            let table = $('<table>')
                .append($('<tr>')
                    .append($('<th>').text('Title'))
                    .append($('<th>').text('Author'))
                    .append($('<th>').text('Description')))

            for(let book of books){
                table.append($('<tr>').append(
                    $('<td>').text(book.Title),
                    $('<td>').text(book.Author),
                    $('<td>').text(book.Description)));
            }
            
            $('#current-books').append(table);
        }
    }
}

function createBook(){
    const kinveyBooksAvailableUrl = kinveyServiceUrl + "appdata/" + kinveyAppId + "/books";
    const kinveyAuthHeaders = {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')};

    let title = $('#insert-book-title').val();
    let author = $('#insert-book-author').val();
    let description = $('#insert-book-description').val();

    let bookInformation = {
        Title : title,
        Author : author,
        Description : description
    }

    $.ajax({
        method: "POST",
        url: kinveyBooksAvailableUrl,
        headers: kinveyAuthHeaders,
        data: bookInformation,
        success: createSuccess,
        error: showError
    });

    function createSuccess(){
        showBooksAvailableView();
        showNote('Book created');
    }    
}

function showError(data){

    let errorMessage
    if(typeof(data.readyState) != 'undefined' && data.readyState == 0){
        errorMessage = 'Network connection problem occured'
    }else if(data.responseJSON && data.responseJSON.description){
        errorMessage = data.responseJSON.description;
    }else{
        errorMessage = 'Error ' + JSON.stringify(data);
    }

    $('#view-error').text(errorMessage).show();
}

function showNote(message){
    $('#view-note').text(message).show();
    setTimeout(function(){
        $('#view-note').fadeOut()
    }, 2000);
}

function showHiddenNavigationLinks(){
    $("#nav-home").show();

    if(sessionStorage.getItem('authToken') != null){
        $("#nav-login").hide();
        $("#nav-register").hide();
        $("#nav-books-available").show();
        $("#nav-insert-book").show();
        $("#nav-logout").show();
    }else{
        $("#nav-home").show();
        $("#nav-login").show();
        $("#nav-register").show();
        $("#nav-books-available").hide();
        $("#nav-insert-book").hide();
        $("#nav-logout").hide();
    }
}

function showView(view){
    $("main > section").hide();
    $("#" + view).show();
}

function showHomeView(){
    $("#view-home > h1").text("Welcome to my bookstore library!")
    showView('view-home');
}

function showLoginView(){
    showView('view-login');
}

function showRegisterView(){
    showView('view-register');
}

function showBooksAvailableView(){
    $('#current-books').text('');
    booksAvailable();
    showView('view-books-available');
}

function showInsertView(){
    $('#insert-book-title').val('');
    $('#insert-book-author').val('');
    $('#insert-book-description').val('');

    showView('view-insert-book');
}

function logout(){
    sessionStorage.clear();
    showHiddenNavigationLinks();
    showHomeView();
}

$(function() {
    $("#nav-home").click(showHomeView);
    $("#nav-login").click(showLoginView);
    $("#nav-register").click(showRegisterView);
    $("#nav-books-available").click(showBooksAvailableView);
    $("#nav-insert-book").click(showInsertView);
    $("#nav-logout").click(logout);

    $("#form-login").submit(function(e){ e.preventDefault(); login();});
    $("#form-register").submit(function(e){ e.preventDefault(); register();});
    $("#form-createBook").submit(function(e){ e.preventDefault(); createBook();});
    
    showHomeView();
    showHiddenNavigationLinks();

    $(document)
        .ajaxStart(function(){
            $('#view-loading').show();
        })
        .ajaxStop(function(){
            $('#view-loading').hide();
        });
})