// Get the modal
var modal = document.getElementById('employee');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
};

const login_eme = document.getElementById("login_employee");
login_eme.addEventListener("click", () => {
    displayModal();
});

const login_emr = document.getElementById("login_employer");
login_emr.addEventListener("click", () => {
    displayModal();
});