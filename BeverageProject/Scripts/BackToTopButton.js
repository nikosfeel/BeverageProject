const backToTop = document.getElementById('backToTop');

window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 300 || document.documentElement.scrollTop > 300) {
        backToTop.style.display = "block";
    }
    else {
        backToTop.style.display = "none";
    }
}

backToTop.addEventListener('click', () => {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
})