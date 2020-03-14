function displayStarRating(rating) {
    const star_total = 5;
    const percentage = (rating / star_total) * 100;
    document.querySelector('.card .stars-inner').style.width = percentage + "%";
}

// Show the initial display of the form when first loaded
function initialForm() {
    $('textarea').css('background-color', '#ffffff');
    $('textarea').css('border', 'none');
    $('#save_btn').css('display', 'none');
    $('#save_edit_btn').css('display', 'none');
    $('input').attr('readonly', true);
}

// Button Contact Clicked - Send email to the person.
function contact() {
    var email = document.getElementById("email").value;
    window.open('mailto:' + email);
}

// Button Edit Profile Clicked - make the fields editable and show the submit button
function Edit_Profile() {
    //$('textarea').attr('readonly', false);
    //$('#edit_profile_button').css('display', 'none');
    //$('#save_edit_btn').css('display', 'block');

    console.log("click");

    document.getElementById("email").readOnly = false;
    document.getElementById("email").style.border = "1px solid";
}