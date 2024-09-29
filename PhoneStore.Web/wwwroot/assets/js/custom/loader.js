(function ($) {

    // show page loader
    function showLoader() {
        $('.my-page-loader-container').show();
    }

    // hide page loader
    function hideLoader() {
        $('.my-page-loader-container').hide();
    }

    // show page loader on button click
    $('button.print').on('click', function () {

        // You can add your print logic here

        // Hide the loader after the print operation is complete
        hideLoader();
    });

    // hide page loader on page ready
    $(document).ready(function () {
        hideLoader();
    });

})(jQuery);
//(function ($) {

//    // show page loader
//    function showLoader() {
//     //   $('.my-page-loader-container').addClass('show');
//        $('.my-page-loader-container').show();
//    }

//    // hide page loader
//    function hideLoader() {
//        //   $('.my-page-loader-container').removeClass('show');
//        $('.my-page-loader-container').hide();
//    }

//    // show page loader on link click
//    $('a').on('click', function () {

//        showLoader();
//    });

//    // hide page loader on page ready
//    $(document).ready(function () {
//        hideLoader();
//    });

//})(jQuery);
