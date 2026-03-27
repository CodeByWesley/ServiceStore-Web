/* ===================================================
   Samuel Cell - JavaScript Puro
   Menu mobile + scroll suave + fechar menu ao clicar
   =================================================== */

document.addEventListener('DOMContentLoaded', function () {

  // --- Menu mobile (hamburger) ---
  var toggle = document.getElementById('menuToggle');
  var mobileNav = document.getElementById('navMobile');

  toggle.addEventListener('click', function () {
    toggle.classList.toggle('active');
    mobileNav.classList.toggle('open');
  });

  // Fechar menu ao clicar em um link
  var mobileLinks = mobileNav.querySelectorAll('a');
  mobileLinks.forEach(function (link) {
    link.addEventListener('click', function () {
      toggle.classList.remove('active');
      mobileNav.classList.remove('open');
    });
  });

  // --- Header com sombra ao rolar ---
  var header = document.getElementById('header');
  window.addEventListener('scroll', function () {
    if (window.scrollY > 10) {
      header.style.boxShadow = '0 2px 16px hsla(0,0%,0%,0.4)';
    } else {
      header.style.boxShadow = 'none';
    }
  });
});

