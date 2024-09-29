$(document).ready(function () {
    $('input[type="file"]').change(function (e) {
        $(".custom-file-label").text(e.target.files[0].name);
    });
    //toastr.options = {
    //    //"closeButton": false,
    //    //"debug": false,
    //    //"newestOnTop": false,
    //    //"progressBar": false,
    //    "positionClass": "toast-bottom-left"
    //    //"preventDuplicates": false,
    //    //"onclick": null,
    //    //"showDuration": "300",
    //    //"hideDuration": "1000",
    //    //"timeOut": "5000",
    //    //"extendedTimeOut": "1000",
    //    //"showEasing": "swing",
    //    //"hideEasing": "linear",
    //    //"showMethod": "fadeIn",
    //    //"hideMethod": "fadeOut"
    //}
    var transMessage = $("#transMessage").val();

    if (transMessage) {
        toastr.options.positionClass = "toast-top-center";
        toastr.success(transMessage);

    }
});
function toastrSuccess(msg) {
    toastr.options.positionClass = "toast-top-center";
    toastr.success(msg);
}
function toastrError(msg) {
    toastr.options.positionClass = "toast-top-center";
    toastr.error(msg);
}
$(function () {
    $('.simple_select2').select2({
        dir: "rtl",
        theme: 'bootstrap4',
        //placeholder: function () {
        //    $(this).data('placeholder');
        //},
        placeholder: "---------------",
        allowClear: true
    });
    $(".preloader").fadeOut()

});

function getSelect(ObjectId, datasource, selectedId) {
    var pageSize = 5;
    var control = "#" + ObjectId;
    if (ObjectId !== null || datasource !== null) {
        $(control).select2({
            dir: "rtl",
            theme: 'bootstrap4',
            placeholder: '---------------',
            minimumInputLength: 0,
            allowClear: true,
            ajax: {
                delay: 250,
                cache: false,
                dataType: 'json',
                type: "GET",
                url: datasource,
                data: function (params) {
                    params.page = params.page || 1;
                    return {
                        searchTerm: params.term,
                        pageSize: pageSize,
                        pageNumber: params.page,
                        whareId: selectedId
                    };
                },
                processResults: function (data, params) {
                    params.page = params.page || 1;
                    return {
                        results: data.results,
                        pagination: {
                            more: (params.page * pageSize) < data.total
                        }
                    };
                }
            }
        });
    }
    else {
        toastr.error("Object or datasource can't be  null.");
    }
}
function changeChar(input, e) {
    var ctrlKey = 67, vKey = 86;
    if (e.keyCode != ctrlKey && e.keyCode != vKey) {
        $(input).val(persianToEnglish($(input).val()));
    }
}
function persianToEnglish(input) {
    var inputstring = input;
    var persian = ["۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹"]
    var english = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"]
    for (var i = 0; i < 10; i++) {
        inputstring = inputstring.toString().replace(persian[i], english[i]);
    }

    return inputstring;
}
