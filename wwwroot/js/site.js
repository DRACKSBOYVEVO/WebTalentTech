// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const slides = document.querySelectorAll('.slide');
const prevBtn = document.querySelector('.banner-btn.prev');
const nextBtn = document.querySelector('.banner-btn.next');
let currentSlide = 0;
const totalSlides = slides.length;

// Cambiar a la diapositiva anterior
prevBtn.addEventListener('click', () => {
  currentSlide = (currentSlide === 0) ? totalSlides - 1 : currentSlide - 1;
  updateSlides();
});

// Cambiar a la siguiente diapositiva
nextBtn.addEventListener('click', () => {
  currentSlide = (currentSlide === totalSlides - 1) ? 0 : currentSlide + 1;
  updateSlides();
});

// Actualizar las diapositivas
function updateSlides() {
  const offset = -currentSlide * 100;
  document.querySelector('.slides').style.transform = `translateX(${offset}%)`;
}

// Cambio automático cada 15 segundos
setInterval(() => {
  currentSlide = (currentSlide === totalSlides - 1) ? 0 : currentSlide + 1;
  updateSlides();
}, 15000);
// Seleccionamos los botones del formulario
const registerButton = document.querySelector(".btn");
const inputs = document.querySelectorAll("#register-form input, #register-form select");

// Animación al pasar el mouse por el botón
registerButton.addEventListener("mouseenter", () => {
  registerButton.style.background = "linear-gradient(to right, #008c9e, #00bcd4)";
  registerButton.style.boxShadow = "0 4px 15px rgba(0, 188, 212, 0.5)";
  registerButton.style.transform = "scale(1.1)";
});

registerButton.addEventListener("mouseleave", () => {
  registerButton.style.background = "#00bcd4";
  registerButton.style.boxShadow = "none";
  registerButton.style.transform = "scale(1)";
});

// Animación al enfocar campos del formulario
inputs.forEach((input) => {
  input.addEventListener("focus", () => {
    input.style.boxShadow = "0 0 5px #00bcd4";
    input.style.background = "rgba(255, 255, 255, 0.4)";
  });

  input.addEventListener("blur", () => {
    input.style.boxShadow = "none";
    input.style.background = "rgba(255, 255, 255, 0.2)";
  });
});

// Validación rápida del formulario al enviar
const form = document.querySelector("#register-form");

form.addEventListener("submit", (event) => {
  event.preventDefault(); // Evita el envío del formulario para pruebas
  let isValid = true;

  inputs.forEach((input) => {
    if (!input.value.trim()) {
      isValid = false;
      input.style.border = "2px solid red";
      setTimeout(() => (input.style.border = "none"), 2000); // Quita el borde rojo después de 2 segundos
    }
  });

  if (isValid) {
    alert("Formulario enviado con éxito 🎉");
    form.reset(); // Limpia el formulario después del envío
  } else {
    alert("Por favor, completa todos los campos.");
  }
});

