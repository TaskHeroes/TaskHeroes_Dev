window.onload = function (event) {
    displayStarRating(document.getElementById('user_review').value);
    initialForm();
};

const contact_btn = document.getElementById("contact_btn");
contact_btn.addEventListener("click", () => {
    contact();
});

const edit_profile_btn = document.getElementById("edit_profile_btn");
edit_profile_btn.addEventListener("click", () => {
    Edit_Profile();
});