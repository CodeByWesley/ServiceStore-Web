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
  carregarPrimeiroServico();
});
async function carregarPrimeiroServico() {
    console.log("Tentando chamar a API..."); 
    try {

        const resposta = await fetch('http://localhost:5000/servicos'); 
        
        if (!resposta.ok) throw new Error("Erro na resposta da rede");
        
        const dados = await resposta.json();
        console.log("Dados recebidos:", dados);

        if (dados.length > 0) {
            const servico = dados[0];
            const card = document.querySelector('.service-card');
            if (card) {
                card.innerHTML = `
                    <div class="service-icon">${servico.icone || '⚙️'}</div>
                    <h3>${servico.nome}</h3>
                    <p>${servico.descricao}</p>
                    <span class="price">A partir de R$ ${servico.precoBase}</span>
                `;
            }
        }
    } catch (erro) {
        console.error("Erro ao conectar com a API:", erro);
    }
}
