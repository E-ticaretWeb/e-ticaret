document.querySelectorAll('.nav-link').forEach(tab => {
    tab.addEventListener('click', function () {
        document.querySelector('.nav-link.active').classList.remove('active');
        this.classList.add('active');
        document.querySelector('.tab-pane.show').classList.remove('show', 'active');
        document.querySelector(this.getAttribute('data-bs-target')).classList.add('show', 'active');
    });
});
