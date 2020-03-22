function displayStarRating(rating) {
    const star_total = 5;
    const percentage = (rating / star_total) * 100;
    document.querySelector('.box .stars-inner').style.width = percentage + "%";
}

window.onload = function (event) {
    displayStarRating(document.getElementById('user_review').value);
    $('textarea').css('background-color', '#ffffff');
    $('textarea').css('border', 'none');
};