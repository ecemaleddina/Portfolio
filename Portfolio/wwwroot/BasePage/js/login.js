function inputLabel() {
    var inputs = document.querySelectorAll('input');
    var labels = document.querySelectorAll('label');

    inputs.forEach(input => {
        input.addEventListener('input', () => {
            labels.forEach(label => {
                if (input.value.length == 0 && label.getAttribute('for') == input.getAttribute('id')) {
                    label.classList.remove('label-up');
                }
                else if (input.value.length != 0 && label.getAttribute('for') == input.getAttribute('id')) {
                    label.classList.add('label-up');
                }
            })
        })
    })
};

function showHidePassword() {
    var icon = document.getElementById('eyeIcon');
    var input = document.getElementById('Password');

    icon.addEventListener('click', () => {
        if (input.type === 'text') {
            icon.className = 'fa-solid fa-eye-slash';
            input.type = 'password';
        } else {
            icon.className = 'fa-solid fa-eye';
            input.type = 'text';
        }
    });
    
}


document.addEventListener('DOMContentLoaded', ()=>{
    inputLabel();
    showHidePassword();
})