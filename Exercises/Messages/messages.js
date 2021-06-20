function renderMessages(data) {
    $('#messages').empty();

    for (let message of data) {
        $('#messages').append('<div class="message d-flex justify-content-start">' +
            '<strong>'
            + message.user
            + '</strong>: '
            + message.content
            + '</div>\n')
    }
}

function loadMessages() {
    $.get(
        {
            url: appUrl + 'message/all',
            success: function success(data){
                renderMessages(data);
            },
            error: function error(error){
                console.log(error);
            }
        })
}

function createMessages() {
    let message = $('#message').val();

    if (username === 0) {
        alert("You cannot enter empty message!");
        return;
    }

    if (username == null){
        alert('You cannot send a message before choosing an username!');
        return;
    }

    let username = getUser();

    $.post({
        url: appUrl + 'message/create',
        headers: {
            'Content-Type': 'application/json'
        },
        data: JSON.stringify({message: message, username: username}),
        success: function success(data){
            loadMessages();
        },
        error: function error(){
            console.log(error)
        }
    })
}
function printMe(){
    console.log('print me!');
}