function hamburger() {
    document.getElementById('line1').classList.toggle('linea');
    document.getElementById('line2').classList.toggle('lineb');
    document.getElementById('line3').classList.toggle('linec');
    document.getElementById('target').classList.toggle('slidex');
    document.getElementById('nav_f').classList.toggle('fadein');
    // toggleは、クリックなどの同じ操作によって、 二つの状態を交互に切り替えられるような仕組み。クリックするたびにクラスが生成されたり、なくなったりする。
}

document.getElementById('target').addEventListener('click', function () {
    hamburger();
});

let list = document.getElementsByClassName('list');

for (let i = 0; i < list.length; i++) {
    list[i].addEventListener('click', function () {
        hamburger();
    });
}