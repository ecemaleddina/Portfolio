const buttons = document.querySelectorAll('.portfolio-filter li');
const items = document.querySelectorAll('.portfolio-items .single-item');
buttons.forEach(button => {
    button.addEventListener("click", ()=>{
        buttons.forEach(elem =>{
            elem.classList.remove('active');
        })
        button.classList.add('active');
        items.forEach(item =>{
            if(item.classList.contains(button.textContent)){
                item.classList.remove('d-none');
            }
            else{
                item.classList.add('d-none');
            }
        })
    })
});