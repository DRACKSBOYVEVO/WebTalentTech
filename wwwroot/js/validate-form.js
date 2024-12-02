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

