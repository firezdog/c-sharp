$(document).ready(function(){
    $("form").submit(function(e){
        e.preventDefault();
        let that = this;
        $.post("submit", $(that).serializeObject(), function(res){
            //This is a terrible hack.
            if (res.indexOf("html") > 0) {
                $("body").html(res);
            } else {
                $(".card").attr("hidden",false);
                let errors = "";
                res.forEach(function(error){
                    if(error.errors[0]){
                        let message =error.errors[0].errorMessage;
                        errors += `<li class="list-group-item">${message}</li>`
                    }
                });
                $(".list-group").html(errors);
            }
        });
    });
});

 //The function is based on http://css-tricks.com/snippets/jquery/serialize-form-to-json/

 $.fn.serializeObject = function() {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function() {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};