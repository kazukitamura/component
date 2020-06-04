/* 到達したら要素を表示させる */
function showElementAnimation() {
                    
  var element = document.getElementsByClassName('js-fadein');
  if(!element) return; // 要素がなかったら処理をキャンセル
                      
  var showTiming = window.innerHeight > 768 ? 200 : 80; // 要素が出てくるタイミングはここで調整
  var scrollY = window.pageYOffset; //スクロール量を取得
  var windowH = window.innerHeight; //ブラウザウィンドウのビューポート(viewport)の高さを取得
                    
  for(var i=0;i<element.length;i++) { 
    //ウィンドウ座標はウィンドウの左上端から始まります。メソッド elem.getBoundingClientRect() はプロパティを持つオブジェクトとして elem に対するウィンドウ座標を返します。
    var elemClientRect = element[i].getBoundingClientRect();
    var elemY = scrollY + elemClientRect.top; 
    if(scrollY + windowH - showTiming > elemY) {
      //is-showクラスを付与して表示させる。
      element[i].classList.add('is-show');
    } else if(scrollY + windowH < elemY) {
    // 上にスクロールして再度非表示にする場合はこちらを記述
      element[i].classList.remove('is-show');
    }
  }
}
showElementAnimation();
window.addEventListener('scroll', showElementAnimation);