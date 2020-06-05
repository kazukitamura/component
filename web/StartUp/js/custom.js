
//アンカーリンク

$(function(){
     $(".anchor a").click(function(){
     $('html,body').animate({ scrollTop: $($(this).attr("href")).offset().top }, 'slow','swing');
     return false;
     })
});


//フリック

var slider_cuisine2_flg = false;
$(document).on("pageshow","#index",function(event, ui){
	if(!slider_cuisine2_flg) {
		$('#slider2').slick({
			dots: true,
			speed: 200
		});
	}
	slider_cuisine2_flg = true;
});

var slider_cuisine3_flg = false;
$(document).on("pageshow","#spa2",function(event, ui){
	if(!slider_cuisine3_flg) {
		$('#slider3').slick({
			dots: true,
			speed: 200
		});
	}
	slider_cuisine3_flg = true;
});

