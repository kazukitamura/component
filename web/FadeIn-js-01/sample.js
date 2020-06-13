function animation() {
  //eachで順番にfadeInUpクラス（li）の要素へ働きかけている
  $('.fadeInUp').each(function () {
    //ターゲットの位置を取得
    var target = $(this).offset().top;
    //スクロール量を取得
    var scroll = $(window).scrollTop();
    //ウィンドウの高さを取得。繰り返し処理内で常に一定の値
    var windowHeight = $(window).height();
    //ターゲットまでスクロールするとフェードインする
    if (scroll > target - windowHeight) {
      $(this).css('opacity', '1');
      $(this).css('transform', 'translateY(0)');
    }
  });
}

//windowオブジェクトを指定
$(window).scroll(
  animation()
);
