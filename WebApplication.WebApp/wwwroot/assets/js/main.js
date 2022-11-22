/* multi language*/






/**
 * 
 */
var $ = jQuery.noConflict();

$(document).ready(function($) {
    "use strict";

    /* global google: false */

    /* ==============================================
        Full height home-section
    =============================================== */
    
	var windowHeight = $(window).height(),
		topSection = $('#hero-section');
	topSection.css('height', windowHeight);

	$(window).resize(function(){
		var windowHeight = $(window).height();
		topSection.css('height', windowHeight);       
	});

    /* ==============================================
        Collapse menu on click
    =============================================== */

        $('.navbar-collapse a:not(.dropdown-toggle)').click(function(){
            if($(window).width() < 768 )
                $('.navbar-collapse').collapse('hide');
        });

    /* ==============================================
        Scrollspy
    =============================================== */

        $('body').scrollspy({
           target: '#navigation-nav',
           offset: 140      //px/
        });

    /* ==============================================
        Parallax
    =============================================== */
    
    $.stellar({
        responsive: true,
        horizontalScrolling: false,
        verticalOffset: 0
    });

    /* ==============================================
        Hero slider
    =============================================== */

    $('.caption-slides').bxSlider({
      pager: false,
      mode: 'fade',
      adaptiveHeight: true,
      controls: false,
      auto: true
    });

    /* ==============================================
        Smooth Scroll on anchors
    =============================================== */  

    $('a[href*=#]:not([href=#])').click(function() {
        if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
          var target = $(this.hash);
          target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
          if (target.length) {
            $('html,body').animate({
                  scrollTop: target.offset().top -66
            }, 1000);
            return false;
          }
        }
    });

    /* ==============================================
     Bootstrap Tooltip
    =============================================== */

    $(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });

    /* ==============================================
    Placeholder
    =============================================== */ 

    $('input, textarea').placeholder();

    /* ==============================================
        Animated content
    =============================================== */

    $('.animated').appear(function(){
        var el = $(this);
        var anim = el.data('animation');
        var animDelay = el.data('delay');
        if (animDelay) {

            setTimeout(function(){
                el.addClass( anim + " in" );
                el.removeClass('out');
            }, animDelay);

        }

        else {
            el.addClass( anim + " in" );
            el.removeClass('out');
        }    
    },{accY: -150});  
    

    /* ==============================================
        MailChip
    =============================================== */

    $('.mailchimp').ajaxChimp({
        callback: mailchimpCallback,
        url: "http://clas-design.us10.list-manage.com/subscribe/post?u=5ca5eb87ff7cef4f18d05e127&amp;id=9c23c46672" //Replace this with your own mailchimp post URL. Don't remove the "". Just paste the url inside "".  
    });

    function mailchimpCallback(resp) {
         if (resp.result === 'success') {
            $('.subscription-success').html('<span class="icon-happy"></span><br/>' + resp.msg).fadeIn(1000);
            $('.subscription-error').fadeOut(500);
        
        } else if(resp.result === 'error') {
            $('.subscription-error').html('<span class="icon-sad"></span><br/>' + resp.msg).fadeIn(1000);
            $('.subscription-success').fadeOut(500);
        }  
    }


    // Countdown
    // To change date, simply edit: var endDate = "June 26, 2015 20:39:00";
    $(function() {
      var endDate = "June 26, 2016 20:39:00";
      $('.soon-countdown .row').countdown({
        date: endDate,
        render: function(data) {
          $(this.el).html('<div><div><span>' + (parseInt(this.leadingZeros(data.years, 2)*365) + parseInt(this.leadingZeros(data.days, 2))) + '</span><span>days</span></div><div><span>' + this.leadingZeros(data.hours, 2) + '</span><span>hours</span></div></div><div class="lj-countdown-ms"><div><span>' + this.leadingZeros(data.min, 2) + '</span><span>minutes</span></div><div><span>' + this.leadingZeros(data.sec, 2) + '</span><span>seconds</span></div></div>');
        }
      });
    });


    /* ==============================================
    Fade In .back-to-top
    =============================================== */

    $(window).scroll(function () {
        if ($(this).scrollTop() > 500) {
            $('.back-to-top').fadeIn();
        } else {
            $('.back-to-top').fadeOut();
        }
    });

    // scroll body to 0px on click
    $('.back-to-top').click(function () {
        $('html, body').animate({
            scrollTop: 0,
            easing: 'swing'
        }, 750);
        return false;
    });

    


    

    
    /* ==============================================
    Isotope
    =============================================== */

        // FIlter
        if( $("#filter").length>0 ) {
            var container = $('#filter');
            container.isotope({
                itemSelector: '.gallery-item',
                transitionDuration: '0.8s'
            });
            $(".filter").click(function(){
                $(".filter.active").removeClass("active");
                $(this).addClass("active");
                var selector = $(this).attr('data-filter');
                container.isotope({ 
                    filter: selector
                });
                return false;
            });

            $(window).resize(function(){
                setTimeout(function(){
                    container.isotope();
                },1000);
            }).trigger('resize');
        }


            if ( $('#type-masory').length ) {

            var $container = $('#type-masory');

            $container.imagesLoaded( function(){
              $container.fadeIn(1000).isotope({
                itemSelector : '.masonry-item'
              });
            });
        }

    /* ==============================================
    Preloader
    =============================================== */

    // will first fade out the loading animation
    $("#loading-animation").fadeOut();
    // will fade out the whole DIV that covers the website.
    $("#preloader").delay(600).fadeOut("slow");

});