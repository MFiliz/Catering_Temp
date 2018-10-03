$(function () {

    $(".validation-summary-errors").each(function () {

        $(this).css("display", "none");
        $("#alert-msg-contact").html("Tüm alanları doldurunuz.");
        $("#alert-msg-contact").addClass("uk-alert uk-alert-danger");
        
        return false;
    });

});


    function OnScc(resp) {
        if (resp.resp == 1) {
          
            $("#alert-msg-contact2").addClass("uk-alert uk-alert-success");
            $("#alert-msg-contact2").html("Mesajınız Gönderildi.");
        }
        if (resp.resp == 0) {
            $("#alert-msg-contact").html("Bir hata oluştu.");
            $("#alert-msg-contact").addClass("uk-alert uk-alert-danger");
        }

    };
