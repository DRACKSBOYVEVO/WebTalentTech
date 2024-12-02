// Ejemplo básico de cómo podrías manejar la rotación de las imágenes
let currentIndex = 0;
const images = document.querySelectorAll('.image-container');
const dots = document.querySelectorAll('.dot');

function showSlide(index) {
    images.forEach((image, i) => {
        image.style.display = i === index ? 'block' : 'none';
    });
    dots.forEach((dot, i) => {
        dot.classList.toggle('active', i === index);
    });
}

function nextSlide() {
    currentIndex = (currentIndex + 1) % images.length;
    showSlide(currentIndex);
}

// Iniciar el carrusel
setInterval(nextSlide, 3000); // Cambiar cada 3 segundos