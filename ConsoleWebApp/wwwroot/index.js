const uri = 'http://localhost:61477/api/Account/sendsms';

$(document).ready(function () {
    getData();
});

function getData() {
    var smsData = "shdjhsdjhjhas";
    $.ajax({
        url: uri,
        type: 'POST',
        ContentType: 'application/json',
        data: '='+smsData,
        success: function (response) {
            var todos = response;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        }
    });
}