function HomePageFuntion() {
    //$("#userreports").MultiFile({
    //    max: 10,
    //    accept: 'jpg|jpeg|png|docx|gif|doc|pdf',
    //    maxfile: 10240,
    //    STRING: {
    //        remove: "<i class='glyphicon glyphicon-trash text-danger'></i>",
    //        denied: 'You cannot select a $ext file.\nTry again...',
    //        file: '$file',
    //        selected: 'File selected: $file',
    //        duplicate: 'This file has already been selected:\n$file',
    //        toobig: 'Please upload a smaller file, max size is 10 MB',
    //        preview: true,
    //        onFileAppend: function (element, value, master_element) {
    //            debugger;
    //            $('._fileupload').append('<li>afterFileSelect - ' + value + '</li>')
    //        }
    //    }
    //});
    $("input[name=group1]").first().attr("checked", true);

    $("._digitsOnly").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            (e.keyCode >= 35 && e.keyCode <= 40)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });

    //if ($("#showform").val() == true) {
    //    //debugger;
    //    $("#test1").hide();
    //    $("#test2").hide();
    //}
    if ($("#showmessage").val() != null || $("#showform").val() == "1") {
        //debugger;
        //alert();
        $("._userdetails").hide();
        //$("#test2").hide();
    }

    $("input[name=group1]").on("click", function () {
        //debugger;
        if (this.checked) {
            $("input[name=group1]").removeAttr("disabled");
        } else {
            $("input[name=group1]").attr("disabled", true);
        }

    })

    //$(function () {
    //    enable_cb();
    //    $("input[name=group1]").click(enable_cb);
    //});

    //function enable_cb() {
    //    if (this.checked) {
    //        $("input[name=group1]").removeAttr("disabled");
    //    } else {
    //        $("input[name=group1]").attr("disabled", true);
    //    }
    //}
    var uid = $("#icon_telephone").text();
    var username = $("#icon_prefix").text();
    var usergender = $("#usergender").text();
    var userage = $("#icon_age").text();
    var userreports = $("#userreports");
    var usermobile = $("#icon_telephone");

    $("#uid").off("focusout").on("focusout", function () {
        var xhr = new XMLHttpRequest();
        xhr.uid = uid;
        xhr.file = file;
        var params = { "uid": uid }
        xhr.open('post', "/batch/validateuid", true);
        xhr.setRequestHeader("uid", uid)
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4) {
                var json = JSON.parse(xhr.responseText);
                if (json.status == 0) {
                    return false;
                }
                else if (json.status == 200) {
                    $("#username").val(json.msg.name);
                    $("#usersex").val(json.msg.sex);
                    $("#userage").val(json.msg.age);
                    $("#usermobile").val(json.msg.mobile);
                    return true;
                }
            }
        }
        xhr.send(file);
    });

    $("#loginBtn").off("click").on("click", function () {
        $("div#loading").show();        
    });

    $("#registerBtn").off("click").on("click", function () {
        $("div#loading").show();
    });


    $("#submitBtn").off("click").on("click", function () {
        $("div#loading").show();
    });
}