/*
* Template Name: Unique - Responsive vCard Template
* Author: lmpixels
* Author URL: http://themeforest.net/user/lmpixels
* Version: 2.1.0
*/

(function($) {
"use strict";
    
    // Portfolio subpage filters
    function portfolio_init() {
        var portfolio_grid = $('#portfolio_grid'),
            portfolio_filter = $('#portfolio_filters');
            
        if (portfolio_grid) {

            portfolio_grid.shuffle({
                speed: 450,
                itemSelector: 'figure'
            });

            $('.site-main-menu').on("click", "a", function (e) {
                portfolio_grid.shuffle('update');
            });


            portfolio_filter.on("click", ".filter", function (e) {
                portfolio_grid.shuffle('update');
                e.preventDefault();
                $('#portfolio_filters .filter').parent().removeClass('active');
                $(this).parent().addClass('active');
                portfolio_grid.shuffle('shuffle', $(this).attr('data-group') );
            });

        }
    }
    // /Portfolio subpage filters

    // Hide Mobile menu
    function mobileMenuHide() {
        var windowWidth = $(window).width();
        if (windowWidth < 1024) {
            $('#site_header').addClass('mobile-menu-hide');
        }
    }
    // /Hide Mobile menu

    // Custom scroll
    function customScroll() {
        var windowWidth = $(window).width();
        if (windowWidth > 991) {
            // Custom Subpage Scroll
            $(".pt-page").mCustomScrollbar({
                scrollInertia: 8,
                documentTouchScroll: false
            });

            // Custom Header Scroll
            $("#site_header").mCustomScrollbar({
                scrollInertia: 8,
                documentTouchScroll: false
            });
        } else {
            $(".pt-page").mCustomScrollbar('destroy');

            $("#site_header").mCustomScrollbar('destroy');
        }
    }
    // /Custom scroll

    //On Window load & Resize
    $(window)
        .on('load', function() { //Load
            // Animation on Page Loading
            $(".preloader").fadeOut("slow");

            // initializing page transition.
            var ptPage = $('.subpages');
            if (ptPage[0]) {
                PageTransitions.init({
                    menu: 'ul.site-main-menu',
                });
            }
            customScroll();
        })
        .on('resize', function() { //Resize
            mobileMenuHide();
             customScroll();
        });

    // On Document Load
    $(document).on('ready', function() {
        $('.ajax-page-load-link').magnificPopup({
            type: 'ajax',
            removalDelay: 300,
            mainClass: 'mfp-fade',
            gallery: {
                enabled: true
            },
        });
    });

    // init NavMenu
    window.initNavMenu = function() {
        // Mobile menu
        $('.menu-toggle').on("click", function () {
            $('#site_header').toggleClass('mobile-menu-hide');
        });

        // Mobile menu hide on main menu item click
        $('.site-main-menu').on("click", "a", function (e) {
            mobileMenuHide();
        });

        $('.tilt-effect').tilt({

        });
    }

    // init Index
    window.initIndex = function() {
        customScroll();

        // Text rotation
        $('.text-rotation').owlCarousel({
            loop: true,
            dots: false,
            nav: false,
            margin: 10,
            items: 1,
            autoplay: true,
            autoplayHoverPause: false,
            autoplayTimeout: 3800,
            animateOut: 'zoomOut',
            animateIn: 'zoomIn'
        });
    };

    // init AboutMe
    window.initAboutMe = function() {
        customScroll();

        // Testimonials Slider
        $(".testimonials.owl-carousel").owlCarousel({
            nav: true, // Show next/prev buttons.
            items: 3, // The number of items you want to see on the screen.
            loop: false, // Infinity loop. Duplicate last and first items to get loop illusion.
            navText: false,
            margin: 10,
            responsive : {
                // breakpoint from 0 up
                0 : {
                    items: 1,
                },
                // breakpoint from 480 up
                480 : {
                    items: 1,
                },
                // breakpoint from 768 up
                768 : {
                    items: 2,
                },
                1200 : {
                    items: 3,
                }
            }
        });

        $('.tilt-effect').tilt({

        });
    };

    // init Resume
    window.initResume = function() {
        customScroll();
    };

    // init Portfolio
    window.initPortfolio = function() {
        customScroll();

        // Initialize Portfolio grid
        var $portfolio_container = $("#portfolio-grid");
        $portfolio_container.imagesLoaded(function () {
            setTimeout(function(){
                portfolio_init(this);
            }, 500);
        });

        // Portfolio hover effect init
        $(' #portfolio_grid > figure > a ').each( function() { $(this).hoverdir(); } );

        // Lightbox init
        $('.lightbox').magnificPopup({
            type: 'image',
            removalDelay: 300,

            // Class that is added to popup wrapper and background
            // make it unique to apply your CSS animations just to this exact popup
            mainClass: 'mfp-fade',
            image: {
                // options for image content type
                titleSrc: 'title',
                gallery: {
                    enabled: true
                },
            },

            iframe: {
                markup: '<div class="mfp-iframe-scaler">'+
                        '<div class="mfp-close"></div>'+
                        '<iframe class="mfp-iframe" frameborder="0" allowfullscreen></iframe>'+
                        '<div class="mfp-title mfp-bottom-iframe-title"></div>'+
                      '</div>', // HTML markup of popup, `mfp-close` will be replaced by the close button

                patterns: {
                    youtube: {
                      index: 'youtube.com/', // String that detects type of video (in this case YouTube). Simply via url.indexOf(index).

                      id: 'v=', // String that splits URL in a two parts, second part should be %id%
                      // Or null - full URL will be returned
                      // Or a function that should return %id%, for example:
                      // id: function(url) { return 'parsed id'; }

                      src: '//www.youtube.com/embed/%id%?autoplay=1' // URL that will be set as a source for iframe.
                    },
                    vimeo: {
                      index: 'vimeo.com/',
                      id: '/',
                      src: '//player.vimeo.com/video/%id%?autoplay=1'
                    },
                    gmaps: {
                      index: '//maps.google.',
                      src: '%id%&output=embed'
                    }
                },

                srcAction: 'iframe_src', // Templating object key. First part defines CSS selector, second attribute. "iframe_src" means: find "iframe" and set attribute "src".
            },

            callbacks: {
                markupParse: function(template, values, item) {
                 values.title = item.el.attr('title');
                }
            },
        });
    };

    // init Contact
    window.initContact = function() {
        customScroll();
    };

    window.notify = function() {
        $.notify({
            icon: "fa fa-envelope-o",
            title: "Message",
            message: " successfully send, Thanks!"
        },{
            offset: 20,
            placement: {
                from: "top",
                align: "center"
            },
            animate: {
                enter: 'animated bounceInDown',
                exit: 'animated bounceOutUp'
            },
            icon_type: 'class',
            template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert" style="background-color: #555; border-color: #444;" >' +
                        '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">x</button>' +
                        '<span data-notify="icon" style="color: #fd9129" ></span> ' +
                        '<span data-notify="title" style="color: #ddd" >{1}</span> ' +
                        '<span data-notify="message" style="color: #fff" >{2}</span>' +
                    '</div>' 
        });
    };
    
    window.animatePageRemoval = function animatePageRemoval(selectedAnimNumber) {
        var inClass, outClass;
        switch(selectedAnimNumber) {
                case 1:
                    inClass = 'pt-page-moveFromRight';
                    outClass = 'pt-page-moveToLeft';
                    break;
                case 2:
                    inClass = 'pt-page-moveFromLeft';
                    outClass = 'pt-page-moveToRight';
                    break;
                case 3:
                    inClass = 'pt-page-moveFromBottom';
                    outClass = 'pt-page-moveToTop';
                    break;
                case 4:
                    inClass = 'pt-page-moveFromTop';
                    outClass = 'pt-page-moveToBottom';
                    break;
                case 5:
                    inClass = 'pt-page-moveFromRight pt-page-ontop';
                    outClass = 'pt-page-fade';
                    break;
                case 6:
                    inClass = 'pt-page-moveFromLeft pt-page-ontop';
                    outClass = 'pt-page-fade';
                    break;
                case 7:
                    inClass = 'pt-page-moveFromBottom pt-page-ontop';
                    outClass = 'pt-page-fade';
                    break;
                case 8:
                    inClass = 'pt-page-moveFromTop pt-page-ontop';
                    outClass = 'pt-page-fade';
                    break;
                case 9:
                    inClass = 'pt-page-moveFromRightFade';
                    outClass = 'pt-page-moveToLeftFade';
                    break;
                case 10:
                    inClass = 'pt-page-moveFromLeftFade';
                    outClass = 'pt-page-moveToRightFade';
                    break;
                case 11:
                    inClass = 'pt-page-moveFromBottomFade';
                    outClass = 'pt-page-moveToTopFade';
                    break;
                case 12:
                    inClass = 'pt-page-moveFromTopFade';
                    outClass = 'pt-page-moveToBottomFade';
                    break;
                case 13:
                    inClass = 'pt-page-moveFromRight';
                    outClass = 'pt-page-moveToLeftEasing pt-page-ontop';
                    break;
                case 14:
                    inClass = 'pt-page-moveFromLeft';
                    outClass = 'pt-page-moveToRightEasing pt-page-ontop';
                    break;
                case 15:
                    inClass = 'pt-page-moveFromBottom';
                    outClass = 'pt-page-moveToTopEasing pt-page-ontop';
                    break;
                case 16:
                    inClass = 'pt-page-moveFromTop';
                    outClass = 'pt-page-moveToBottomEasing pt-page-ontop';
                    break;
                case 17:
                    inClass = 'pt-page-moveFromRight pt-page-ontop';
                    outClass = 'pt-page-scaleDown';
                    break;
                case 18:
                    inClass = 'pt-page-moveFromLeft pt-page-ontop';
                    outClass = 'pt-page-scaleDown';
                    break;
                case 19:
                    inClass = 'pt-page-moveFromBottom pt-page-ontop';
                    outClass = 'pt-page-scaleDown';
                    break;
                case 20:
                    inClass = 'pt-page-moveFromTop pt-page-ontop';
                    outClass = 'pt-page-scaleDown';
                    break;
                case 21:
                    inClass = 'pt-page-scaleUpDown pt-page-delay300';
                    outClass = 'pt-page-scaleDown';
                    break;
                case 22:
                    inClass = 'pt-page-scaleUp pt-page-delay300';
                    outClass = 'pt-page-scaleDownUp';
                    break;
                case 23:
                    inClass = 'pt-page-scaleUp';
                    outClass = 'pt-page-moveToLeft pt-page-ontop';
                    break;
                case 24:
                    inClass = 'pt-page-scaleUp';
                    outClass = 'pt-page-moveToRight pt-page-ontop';
                    break;
                case 25:
                    inClass = 'pt-page-scaleUp';
                    outClass = 'pt-page-moveToTop pt-page-ontop';
                    break;
                case 26:
                    inClass = 'pt-page-scaleUp';
                    outClass = 'pt-page-moveToBottom pt-page-ontop';
                    break;
                case 27:
                    inClass = 'pt-page-scaleUpCenter pt-page-delay400';
                    outClass = 'pt-page-scaleDownCenter';
                    break;
                case 28:
                    inClass = 'pt-page-moveFromRight pt-page-delay200 pt-page-ontop';
                    outClass = 'pt-page-rotateRightSideFirst';
                    break;
                case 29:
                    inClass = 'pt-page-moveFromLeft pt-page-delay200 pt-page-ontop';
                    outClass = 'pt-page-rotateLeftSideFirst';
                    break;
                case 30:
                    inClass = 'pt-page-moveFromTop pt-page-delay200 pt-page-ontop';
                    outClass = 'pt-page-rotateTopSideFirst';
                    break;
                case 31:
                    inClass = 'pt-page-moveFromBottom pt-page-delay200 pt-page-ontop';
                    outClass = 'pt-page-rotateBottomSideFirst';
                    break;
                case 32:
                    inClass = 'pt-page-flipInLeft pt-page-delay500';
                    outClass = 'pt-page-flipOutRight';
                    break;
                case 33:
                    inClass = 'pt-page-flipInRight pt-page-delay500';
                    outClass = 'pt-page-flipOutLeft';
                    break;
                case 34:
                    inClass = 'pt-page-flipInBottom pt-page-delay500';
                    outClass = 'pt-page-flipOutTop';
                    break;
                case 35:
                    inClass = 'pt-page-flipInTop pt-page-delay500';
                    outClass = 'pt-page-flipOutBottom';
                    break;
                case 36:
                    inClass = 'pt-page-scaleUp';
                    outClass = 'pt-page-rotateFall pt-page-ontop';
                    break;
                case 37:
                    inClass = 'pt-page-rotateInNewspaper pt-page-delay500';
                    outClass = 'pt-page-rotateOutNewspaper';
                    break;
                case 38:
                    inClass = 'pt-page-moveFromRight';
                    outClass = 'pt-page-rotatePushLeft';
                    break;
                case 39:
                    inClass = 'pt-page-moveFromLeft';
                    outClass = 'pt-page-rotatePushRight';
                    break;
                case 40:
                    inClass = 'pt-page-moveFromBottom';
                    outClass = 'pt-page-rotatePushTop';
                    break;
                case 41:
                    inClass = 'pt-page-moveFromTop';
                    outClass = 'pt-page-rotatePushBottom';
                    break;
                case 42:
                    inClass = 'pt-page-rotatePullRight pt-page-delay180';
                    outClass = 'pt-page-rotatePushLeft';
                    break;
                case 43:
                    inClass = 'pt-page-rotatePullLeft pt-page-delay180';
                    outClass = 'pt-page-rotatePushRight';
                    break;
                case 44:
                    inClass = 'pt-page-rotatePullBottom pt-page-delay180';
                    outClass = 'pt-page-rotatePushTop';
                    break;
                case 45:
                    inClass = 'pt-page-rotatePullTop pt-page-delay180';
                    outClass = 'pt-page-rotatePushBottom';
                    break;
                case 46:
                    inClass = 'pt-page-moveFromRightFade';
                    outClass = 'pt-page-rotateFoldLeft';
                    break;
                case 47:
                    inClass = 'pt-page-moveFromLeftFade';
                    outClass = 'pt-page-rotateFoldRight';
                    break;
                case 48:
                    inClass = 'pt-page-moveFromBottomFade';
                    outClass = 'pt-page-rotateFoldTop';
                    break;
                case 49:
                    inClass = 'pt-page-moveFromTopFade';
                    outClass = 'pt-page-rotateFoldBottom';
                    break;
                case 50:
                    inClass = 'pt-page-rotateUnfoldLeft';
                    outClass = 'pt-page-moveToRightFade';
                    break;
                case 51:
                    inClass = 'pt-page-rotateUnfoldRight';
                    outClass = 'pt-page-moveToLeftFade';
                    break;
                case 52:
                    inClass = 'pt-page-rotateUnfoldTop';
                    outClass = 'pt-page-moveToBottomFade';
                    break;
                case 53:
                    inClass = 'pt-page-rotateUnfoldBottom';
                    outClass = 'pt-page-moveToTopFade';
                    break;
                case 54:
                    inClass = 'pt-page-rotateRoomLeftIn';
                    outClass = 'pt-page-rotateRoomLeftOut pt-page-ontop';
                    break;
                case 55:
                    inClass = 'pt-page-rotateRoomRightIn';
                    outClass = 'pt-page-rotateRoomRightOut pt-page-ontop';
                    break;
                case 56:
                    inClass = 'pt-page-rotateRoomTopIn';
                    outClass = 'pt-page-rotateRoomTopOut pt-page-ontop';
                    break;
                case 57:
                    inClass = 'pt-page-rotateRoomBottomIn';
                    outClass = 'pt-page-rotateRoomBottomOut pt-page-ontop';
                    break;
                case 58:
                    inClass = 'pt-page-rotateCubeLeftIn';
                    outClass = 'pt-page-rotateCubeLeftOut pt-page-ontop';
                    break;
                case 59:
                    inClass = 'pt-page-rotateCubeRightIn';
                    outClass = 'pt-page-rotateCubeRightOut pt-page-ontop';
                    break;
                case 60:
                    inClass = 'pt-page-rotateCubeTopIn';
                    outClass = 'pt-page-rotateCubeTopOut pt-page-ontop';
                    break;
                case 61:
                    inClass = 'pt-page-rotateCubeBottomIn';
                    outClass = 'pt-page-rotateCubeBottomOut pt-page-ontop';
                    break;
                case 62:
                    inClass = 'pt-page-rotateCarouselLeftIn';
                    outClass = 'pt-page-rotateCarouselLeftOut pt-page-ontop';
                    break;
                case 63:
                    inClass = 'pt-page-rotateCarouselRightIn';
                    outClass = 'pt-page-rotateCarouselRightOut pt-page-ontop';
                    break;
                case 64:
                    inClass = 'pt-page-rotateCarouselTopIn';
                    outClass = 'pt-page-rotateCarouselTopOut pt-page-ontop';
                    break;
                case 65:
                    inClass = 'pt-page-rotateCarouselBottomIn';
                    outClass = 'pt-page-rotateCarouselBottomOut pt-page-ontop';
                    break;
                case 66:
                    inClass = 'pt-page-rotateSidesIn pt-page-delay200';
                    outClass = 'pt-page-rotateSidesOut';
                    break;
                case 67:
                    inClass = 'pt-page-rotateSlideIn';
                    outClass = 'pt-page-rotateSlideOut';
                    break;
        }

        $('#animatePageRemoval').removeClass(inClass);
        $('#animatePageRemoval').addClass(outClass);
    }

})(jQuery);
