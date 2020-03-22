function displayModal(type) {
    console.log(type);
    if (type == 0)
        document.getElementById('employee').style.display = 'block';
    else
        document.getElementById('employer').style.display = 'block';
}

function hideModal() {
    var display = document.getElementById('employee').style.display;
    if (display == 'block')
        document.getElementById('employee').style.display = 'none';
    else
        document.getElementById('employer').style.display = 'none';

}