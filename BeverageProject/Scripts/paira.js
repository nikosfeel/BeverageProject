/**
 * Author -> ThemeTidy
 * Email -> support@themetidy.com
 * Version -> 1.0
 */

/*******************************************************************************************
 * IIFE - Immediately Invoked Function Expression
 * The global jQuery object (window.jQuery, window, document) is passed as a parameter
 *******************************************************************************************/
(function($, window, document) {
    "use strict";
    /*******************************************************************************
     * Listen For The JQuery Ready Event On The Document
     *******************************************************************************/
    $(function() {
        paira.initDomReady();
    });
    /*******************************************************************************
     * Listen When The Document Full Load
     *******************************************************************************/
    $(window).load(function() {
        paira.initWindowReady();
    });
    var paira = {
        /***************************************************************************************
         * Init Dom Ready Function
         ***************************************************************************************/
        initDomReady: function() {
            this.initMenu();
            this.initPairaAnimation();
            this.initDomLoadClass();
            this.initDialogBox();
        },
        /***************************************************************************************
         * Init Window Ready Function
         ***************************************************************************************/
        initWindowReady: function() {
            this.initToolTip();
            this.initIE10ViewPortHack();
            this.initWindowLoadClass();
            this.initOwlCarousel();
            this.initGoogleMap();
            this.initBxCarousel();
        },
        /*******************************************************************************
         * Scroll Animation Function - Using Animate.css with jQuery Waypoints
         *******************************************************************************/
        pairaAnimation: function( items, trigger ) {
            items.each( function() {
                var osElement = $(this),
                    osAnimationClass = osElement.attr('data-paira-animation'),
                    osAnimationDelay = osElement.attr('data-paira-animation-delay');
                osElement.css({
                    '-webkit-animation-delay':  osAnimationDelay,
                    '-moz-animation-delay':     osAnimationDelay,
                    'animation-delay':          osAnimationDelay
                });
                var osTrigger = ( trigger ) ? trigger : osElement;
                osTrigger.waypoint(function() {
                    osElement.addClass('animated').addClass(osAnimationClass);
                },{
                    triggerOnce: true,
                    offset: '90%'
                });
            });
        },
        /*******************************************************************************
         * Animation Load Function
         *******************************************************************************/
        initPairaAnimation: function() {
            paira.pairaAnimation($('.paira-animation'));
        },
        /*******************************************************************************
         * Tool Tips
         *******************************************************************************/
        initToolTip: function() {
            var $tooltip = $('[data-toggle="tooltip"]');
            if($tooltip.length > 0) {
                $tooltip.tooltip();
            }
        },
        /*******************************************************************************
         * Menu Customize
         *******************************************************************************/
        initMenu: function() {
            /***************************************************************************************
             * Mega Menu
             ***************************************************************************************/
            window.prettyPrint && prettyPrint();
            $(document).on('click', '.paira-mega-menu .paira-dropdown-menu', function(p) {
                p.stopPropagation();
            });
            $('.paira-mega-menu ul .paira-dropdown-menu').parent().hover(function() {
                var menu = $(this).find("ul");
                var menupos = $(menu).offset();
                if (menupos.left + menu.width() > $(window).width()) {
                    var newpos = -$(menu).width();
                    menu.css({ left: newpos });
                }
            });
            $(document).on('click', '.paira-mega-menu .paira-angle-down', function(p) {
                p.preventDefault();
                $(this).parents('.paira-dropdown').find('.paira-dropdown-menu').toggleClass('active');
            });
            $(document).on('click', '.paira-dropdown-menu .dropdown-submenu .fa-angle-right', function(p) {
                p.preventDefault();
                $(this).parents('a').next().toggleClass('active-on');
            });
        },
        /*******************************************************************************
         * Dialog Box
         *******************************************************************************/
        initDialogBox: function() {
            /***************************************************************************************
             * Modal Dialog (Quick View, Success Message, Welcome Newsletter, Error Massage)
             ***************************************************************************************/
            $(document).on('click', '.paira-quick-view', function(p) {
                p.stopPropagation();
                $('#paira-quick-view').modal('show');
                var $quick_bxSlider = $(".paira-quick-product-image-list");
                if($quick_bxSlider.length > 0) {
                    $quick_bxSlider.bxSlider({
                        auto: true,
                        mode: 'vertical',
                        slideWidth: 147,
                        minSlides: 3,
                        pager: false,
                        responsive:true,
                        slideMargin: 20
                    });
                }
            });
            $(document).on('click', '.search-popup', function(p) {
                p.stopPropagation();
                $('#paira-search').modal('show');
            });
            $(document).on('click', '.login-popup', function(p) {
                p.stopPropagation();
                $('#paira-login').modal('show');
            });
            $(document).on('click', '.cart-menu-body', function(p) {
                p.stopPropagation();
                $('#paira-ajax-cart').modal('show');
            });
            $(document).on('click', '.product-cart-con', function(p) {
                p.stopPropagation();
                $('#paira-ajax-success-message').modal('show');
            });
            $('#paira-welcome-newsletter').modal('show');
        },
        /*******************************************************************************
         * Single Product Page Item Carousel With Product Elevate Zoom Effect
         *******************************************************************************/
        initBxCarousel: function() {
            var $single_bxSlider = $(".single-product-image-list"),
                $bxSlider = $('.bxslider');
            if($single_bxSlider.length > 0){
                $single_bxSlider.bxSlider({
                    auto: true,
                    mode: 'vertical',
                    slideWidth: 147,
                    minSlides: 3,
                    pager: false,
                    responsive:true,
                    slideMargin: 20
                });
            }
            if($bxSlider.length > 0){
                $bxSlider.bxSlider({
                    mode: 'horizontal',
                    useCSS: false,
                    infiniteLoop: false,
                    hideControlOnEnd: true,
                    easing: false,
                    speed: 0
                });
            }
        },
        /*******************************************************************************
         * Owl Carousel
         *******************************************************************************/
        initOwlCarousel: function() {
            /*******************************************************************************
             * Brand Logo Carousel
             *******************************************************************************/
            var $brand_owlCarousel = $('.paira-brand');
            if ($brand_owlCarousel.length > 0) {
                var brand = $brand_owlCarousel.owlCarousel({
                    itemsCustom: [
                        [1199, 4],
                        [992, 4],
                        [768, 3],
                        [480, 2],
                        [300, 1],
                        [200, 1]
                    ],
                    autoPlay: !1,
                    slidespeed: 500,
                    autoHeight: !0,
                    transitionStyle: "backSlide"
                });
                $(".paira-brand-left").on("click", function () {
                    brand.trigger("owl.prev")
                });
                $(".paira-brand-right").on("click", function () {
                    brand.trigger("owl.next")
                })
            }
        },
        /*******************************************************************************
         * IE10 viewport hack for Surface/desktop Windows 8 bug
         *******************************************************************************/
        initIE10ViewPortHack: function() {
            'use strict';
            if (navigator.userAgent.match(/IEMobile\/10\.0/)) {
                var msViewportStyle = document.createElement('style');
                msViewportStyle.appendChild(
                    document.createTextNode(
                        '@-ms-viewport{width:auto!important}'
                    )
                );
                document.querySelector('head').appendChild(msViewportStyle)
            }
        },
        /*******************************************************************************
         * Custom Dom Load Class
         *******************************************************************************/
        initDomLoadClass: function() {
            /***************************************************************************************
             * When Document Ready Show This Class "paira-dom-ready"
             ***************************************************************************************/
            var toggle_button = $('.toggle-button .fa'),
                product_dtl = $('.product-dtl');
            $(".paira-dom-ready").show();
            $(document).on('click', '.fa-angle-right', function(p) {
                p.preventDefault();
                toggle_button.removeClass('fa-angle-right').addClass('fa-angle-left');
                product_dtl.toggleClass("single-product-tab");
            });
            $(document).on('click', '.fa-angle-left', function(p) {
                p.preventDefault();
                toggle_button.addClass('fa-angle-right').removeClass('fa-angle-left');
                product_dtl.toggleClass("single-product-tab");
            });
        },
        /***************************************************************************************
         * Ajax Get Data
         ***************************************************************************************/
        ajaxGetData: function(url, dataType) {
            var dataTypeDefault = typeof dataType !== 'undefined' ?  dataType : 'html';
            return $.ajax({
                url: url,
                type: "get",
                dataType: dataTypeDefault,
                beforeSend: function() {
                    paira.showLoading();
                },
                error: function() {
                    paira.hideLoading();
                    var message = '<i class="fa fa-info-circle font-size-16"></i> Something wrong! Try to reload your page OR contact customer support.';
                    paira.showCommonMessage(message);
                }
            });
        },
        /***************************************************************************************
         * Show Loading Animation
         ***************************************************************************************/
        showLoading: function() {
            $(".paira-loading").show()
        },
        /***************************************************************************************
         * Hide Loading Animation
         ***************************************************************************************/
        hideLoading: function() {
            $(".paira-loading").hide()
        },
        showCommonMessage: function(message) {
            var popup = $('#paira-common-message');
            popup.find('.paira-common-message-details').html(message);
            popup.modal('show');
        },
        /*******************************************************************************
         * Custom Window Load Class
         *******************************************************************************/
        initWindowLoadClass: function() {
            var $parallax = $('.parallax');
            /*******************************************************************************
             * Image Parallax
             *******************************************************************************/
            if ($parallax.length > 0) {
                $parallax.parallax("50%", 0.3);
            }
            /***************************************************************************************
             * When Window Ready Show This Class "paira-win-ready"
             ***************************************************************************************/
            $(".paira-win-ready").show();
            /***************************************************************************************
             * For product page
             ***************************************************************************************/
            $(document).on('click', '#paira-single-product-gallery a', function(p) {
                p.preventDefault();
                var imageUrl = $(this).attr('data-image');
                paira.ajaxGetData(imageUrl).done(function() {
                    paira.hideLoading();
                    $('.paira-single-product-image img').attr('src', imageUrl);
                });
            });
            $(document).on('click', '.paira-quick-product-image-list a', function(p) {
                p.preventDefault();
                var imageUrl = $(this).attr('data-image');
                paira.ajaxGetData(imageUrl).done(function() {
                    paira.hideLoading();
                    $('.paira-quick-single-product-image img').attr('src', imageUrl);
                });
            });
        }
    };
}(window.jQuery, window, document));
/**********************************************************************************************
 * The global jQuery object (window.jQuery, window, document) is passed as a parameter
 **********************************************************************************************/
