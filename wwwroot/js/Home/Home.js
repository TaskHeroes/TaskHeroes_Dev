// Convert rating - point - to star display
function displayStarRating(rating, user) {
    const star_total = 5;
    const percentage = (rating / star_total) * 100;
    document.querySelector("#star" + user).style.width = percentage + "%";
}

// Handle when homepage finished loading
window.onload = function (event) {
    var user = 1;
    // Get each user rating then call the function above to convert it to star
    while ($("#user_rating" + user).length > 0) {
        var rating = document.getElementById("user_rating" + user).value;
        console.log(rating);
        displayStarRating(rating, user);
        user++
    }
    // Remove unwanted effects on textarea
    $('textarea').css('background-color', '#ffffff');
    $('textarea').css('border', 'none');
};