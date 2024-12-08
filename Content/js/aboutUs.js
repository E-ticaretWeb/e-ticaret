const slides = document.querySelectorAll('.slide');
let currentSlide = 0;
const totalSlides = slides.length;
let slideInterval;

// Start automatic slideshow
function startSlideShow() {
    slideInterval = setInterval(() => {
        nextSlide();
    }, 5000); // Change slides every 5 seconds
}

// Stop automatic slideshow
function stopSlideShow() {
    clearInterval(slideInterval);
}

// Show next slide
function nextSlide() {
    slides[currentSlide].classList.remove('active'); // Remove active class from current slide
    currentSlide = (currentSlide + 1) % totalSlides; // Move to the next slide
    slides[currentSlide].classList.add('active'); // Add active class to the new slide
    updateSlidePosition();
}

// Show previous slide
function prevSlide() {
    slides[currentSlide].classList.remove('active');
    currentSlide = (currentSlide - 1 + totalSlides) % totalSlides;
    slides[currentSlide].classList.add('active');
    updateSlidePosition();
}

// Update slide position based on currentSlide
function updateSlidePosition() {
    const slideWidth = slides[0].clientWidth; // Assuming all slides have the same width
    const slider = document.querySelector('.slides');
    slider.style.transform = `translateX(-${currentSlide * slideWidth}px)`;
}

// Click event listeners for navigation
document.querySelector('.next').addEventListener('click', () => {
    stopSlideShow();
    nextSlide();
    startSlideShow(); // Restart after manual control
});

document.querySelector('.prev').addEventListener('click', () => {
    stopSlideShow();
    prevSlide();
    startSlideShow(); // Restart after manual control
});

// Initialize slideshow on page load
window.onload = () => {
    startSlideShow();
};
