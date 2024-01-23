const buttons = document.querySelectorAll('.portfolio-filter li');
const items = document.querySelectorAll('.portfolio-items .single-item');
buttons.forEach(button => {
    button.addEventListener("click", () => {
        buttons.forEach(elem => {
            elem.classList.remove('active');
        })
        button.classList.add('active');

        items.forEach(item => {
            if (button.textContent.trim().toLowerCase() == 'all') {
                item.classList.remove('d-none');
            } else {
                let modifiedButtonText = button.textContent.trim().split(' ').join('');

                if (item.classList.contains(modifiedButtonText)) {
                    item.classList.remove('d-none');
                } else {
                    item.classList.add('d-none');
                }
            }
        })
    })
});