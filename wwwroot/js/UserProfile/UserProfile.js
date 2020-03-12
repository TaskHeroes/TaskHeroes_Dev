function displayStarRating(rating) {
    const star_total = 5;
    const percentage = (rating / star_total) * 100;
    console.log(rating);
    console.log(percentage);
    document.querySelector('.card .stars-inner').style.width = percentage + "%";
}

// Show the initial display of the form when first loaded

function initialDisplay() {
    $('#user_info_form input').css('border', '0');
    $('#user_info_form input').attr('readonly', true);
    $('#user_info_form input').css('background-color', '#ffffff');

}