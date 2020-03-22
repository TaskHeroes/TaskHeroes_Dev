function displayStarRating(rating) {
    const star_total = 5;
    const percentage = (rating / star_total) * 100;
    document.querySelector('.card .stars-inner').style.width = percentage + "%";
}

// Show the initial display of the form when first loaded
function initialForm() {
    $('textarea').css('background-color', '#ffffff');
    $('textarea').css('border', 'none');
    $('input').attr('readonly', true);

    // Re enable editable attributes for elements of the modal
    $('.modal textarea').css('border', '1px solid');
    $('.modal input').attr('readonly', false);
}

// Button Contact Clicked - Send email to the person.
function contact() {
    var email = document.getElementById("email").value;
    window.open('mailto:' + email);
}

