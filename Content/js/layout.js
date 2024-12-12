document.addEventListener('DOMContentLoaded', function () {
    const dropdownToggles = document.querySelectorAll('.dropdown-toggle');
    const dropdownMenus = document.querySelectorAll('.dropdown-menu');

    // Dropdown açma ve kapama işlemi
    dropdownToggles.forEach(function (toggle) {
        toggle.addEventListener('click', function (e) {
            e.stopPropagation(); // Olayın dışarı taşmasını engelle
            const parentDropdown = this.closest('.dropdown');
            const menu = parentDropdown.querySelector('.dropdown-menu');

            // Tüm açık menüleri kapat
            dropdownMenus.forEach(function (otherMenu) {
                if (otherMenu !== menu) {
                    otherMenu.classList.remove('show');
                }
            });

            // Şu anki menüyü aç/kapat
            menu.classList.toggle('show');
        });
    });

    // Submenu hover eventleri
    document.querySelectorAll('.dropdown-submenu').forEach(function (submenu) {
        submenu.addEventListener('mouseenter', function () {
            const submenuDropdown = this.querySelector('.dropdown-menu');
            if (submenuDropdown) {
                submenuDropdown.classList.add('show');
            }
        });

        submenu.addEventListener('mouseleave', function () {
            const submenuDropdown = this.querySelector('.dropdown-menu');
            if (submenuDropdown) {
                submenuDropdown.classList.remove('show');
            }
        });
    });

    // Sayfada herhangi bir yere tıklanınca tüm dropdown'ları kapat
    document.addEventListener('click', function () {
        dropdownMenus.forEach(function (menu) {
            menu.classList.remove('show');
        });
    });
});
