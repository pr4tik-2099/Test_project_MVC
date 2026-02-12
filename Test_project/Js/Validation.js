//function validateEmailOnServer() {
//    var email = document.getElementById('email');
//    var email_validate = document.getElementById('email_validate');
//    var regexPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
//    if (!regexPattern.test(email)) {
//        email_validate.innerHTML = "Invalid email format.";
//        return;
//    }
//}

//$(document).ready(function () {
//    $("#email").on("change", function () {
//        var email = document.getElementById('email');
//        var email_validate = document.getElementById('email_validate');
//        var regexPattern = "^ [a - zA - Z0 - 9.!#$ %&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
//        if (!regexPattern.match(email)) {
//         email_validate.innerHTML = "Invalid email format.";
//             return;
//           }
//    });
//});
<partial name="_ValidationScriptsPartial" />
$(document).ready(function () {
    function validateEmailOnServer() {
        var email = document.getElementById('email');
        var email_validate = document.getElementById('email_validate');
        //if (email != "") {
        //    email_validate.innerHTML = "";
        //}
        settings.onkeyup = function (email) {
            email_validate.innerHTML = "";
        }
    }
    })

