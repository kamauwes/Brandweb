let signup_btn = document.querySelector(".Signup-btn"); 
let login_btn = document.querySelector(".Login-btn");
let form =document.querySelector(".form_box");
signup_btn.addEventListener('click', () => {
    form.classList.add('change-form');
});
login_btn.addEventListener('click', () => {
    form.classList.remove('change-form');
});

