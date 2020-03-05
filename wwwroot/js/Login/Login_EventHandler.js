// Get the modal
var modal = document.getElementById('employee');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        hideModal();
    }
};

const eme_img = document.getElementById("eme_img");
eme_img.addEventListener("click", () => {
    displayModal();
});

const eme_btn = document.getElementById("eme_btn");
eme_btn.addEventListener("click", () => {
    displayModal();
});

const emr_img = document.getElementById("emr_img");
emr_img.addEventListener("click", () => {
    displayModal();
});

const emr_btn = document.getElementById("emr_btn");
emr_btn.addEventListener("click", () => {
    displayModal();
});