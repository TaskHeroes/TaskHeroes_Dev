function displayStarRating(rating) {
    const star_total = 5;
    const percentage = (rating / star_total) * 100;
    console.log(rating);
    console.log(percentage);
    document.querySelector('.card .stars-inner').style.width = percentage + "%";
}