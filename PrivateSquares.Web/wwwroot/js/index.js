// Carousel Auto-Cycle
  $(document).ready(function() {
	// Portfolio Section Here 
	$('.ps-pop').click(function(){
	$('.ps-popclick').addClass('ps-pop-s');
	});
	$('.close').click(function(){
		$('.ps-popclick').removeClass('ps-pop-s');
		});
	// Portfolio Section Ends Here 
    $('.carousel').carousel({
      interval: 6000
    });
	// Scroll Section Here 
	if (!$.browser.webkit) {
      $('.wrapper').html('<p>Sorry! Non webkit users. :(</p>');
     }
	//Scroll Section Ends Here 

  });