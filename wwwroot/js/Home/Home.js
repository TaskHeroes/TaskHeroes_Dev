function displayStarRating(rating, user) {
    const star_total = 5;
    const percentage = (rating / star_total) * 100;
    document.querySelector("#star" + user).style.width = percentage + "%";
}

window.onload = function (event) {
    var user = 1;

    while ($("#user_rating" + user).length > 0) {
        var rating = document.getElementById("user_rating" + user).value;
        console.log(rating);
        displayStarRating(rating, user);
        user++
    }
    $('textarea').css('background-color', '#ffffff');
    $('textarea').css('border', 'none');
};