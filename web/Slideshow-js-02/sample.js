// ------------------------------------------------------------
// ▼設定：スライドショーで見せたい画像ファイルとキャプション群
// ------------------------------------------------------------
var imgset = [
  ["kinme.jpg", "1.キンめ"],
  ["lobster.jpg", "2.雪の山"],
  ["lobsterablone.jpg", "3.水面"],
  ["reasonable.jpg", "4.ビーチ"],
  ["restaurant.jpg", "5.平原"],
  ["slideshow.jpg", "6.海に浮かぶ船"]      /* 最後にはカンマ不要 */
];

// -----------------------------------------------
// ▼関数A：指定画像を順に表示させる
// -----------------------------------------------
var counter = 0;
function slideimage() {
  if (counter >= imgset.length) {
    // カウンタが画像数よりも大きくなったら0番に戻す
    counter = 0;
  }
  document.getElementById('slideshow').src = imgset[counter][0];
  document.getElementById('slidecaption').innerHTML = imgset[counter][1];
  counter++;
}

// -----------------------------------------------
// ▼関数B：スライドショーを制御
// -----------------------------------------------
var slideid = 0;
function startstopshow() {
  if (slideid == 0) {
    // 始まっていなければ始める
    slideid = setInterval(slideimage, 1000);      // 1000は切替秒数(ミリ秒)
  }
  else {
    // IDがあれば止める
    clearInterval(slideid);
    slideid = 0;
  }
}

// ▼ボタンクリックに関数を割り当てる
document.getElementById('startstopbutton').onclick = startstopshow;