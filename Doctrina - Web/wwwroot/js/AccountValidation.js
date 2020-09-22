function CheckForValidation() {

    var validationSummary = document.getElementById("validationSummary");
    var validationText = validationSummary.childNodes[0].childNodes[0];
    var errorMessageDiv = document.getElementById("errorMessageDiv");
    console.log(validationText.innerText);
    if (validationText.innerText.length > 0) {
        validationText.style = "display:none;";
        errorMessageDiv.style = "display:block";
    }

}

function CheckTermsAndPrivacyPolicy() {

    var checkBox = document.getElementById("TermsAndPrivacyPolicy");
    var checkBoxLabel = document.getElementById("termsAndPolicyLabel");
    var firstName = document.getElementById("FirstName");
    var lastName = document.getElementById("LastName");
    var userName = document.getElementById("UserName");
    var email = document.getElementById("Email");
    var password = document.getElementById("Password");
    var confirmPassword = document.getElementById("ConfirmPassword");
    var city = document.getElementById("City");
    var country = document.getElementById("Country");

    if (firstName.value == "") {
        firstName.style = "border:1px solid red;";
    }

    if (lastName.value == "") {
        lastName.style = "border:1px solid red;";
    }

    if (userName.value == "") {
        userName.style = "border:1px solid red;";
    }

    if (email.value == "") {
        email.style = "border:1px solid red;";
    }

    if (password.value == "") {
        password.style = "border:1px solid red;";
    }

    if (confirmPassword.value == "") {
        confirmPassword.style = "border:1px solid red;";
    }

    if (city.value == "") {
        city.style = "border:1px solid red;";
    }

    if (country.value == "") {
        country.style = "border:1px solid red;";
    }


    if (checkBox.checked == false)
    {
        event.preventDefault();
        checkBoxLabel.style = "border-bottom:1px solid red;";
        console.log("Nema prolaza");
        return false;
    }

    console.log("Prolaz");
}

function RemoveCheckBoxBorder() {
    var checkBoxLabel = document.getElementById("termsAndPolicyLabel");
    checkBoxLabel.style = "border: 0px solid white;";
}