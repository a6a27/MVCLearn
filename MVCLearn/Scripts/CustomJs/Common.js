//Add by 奇緯 20210630 明細－編輯
function Common_List_Edit(i, type) {
    $("[data-toggle='LIST_LABEL[" + i + "]'").attr("style", "display: none");
    $("[data-toggle='LIST_EDIT[" + i + "]'").attr("style", "display: ");
    $("[name='Confirm_" + type + "']").prop("disabled", true);
    $("a[data-toggle*='LIST_LABEL']").prop('onclick', null);
    $("[name='LIST_ADD']").prop('disabled', true);
    //Initial_Select2();
    //Initial_InputMask();
}

//Add by 奇緯 20210630 明細－新增
function Common_List_Add(TABLE_ID) {
    var Temp = $("#Template_D_LIST").text();
    var Append_ID = $("#" + TABLE_ID);
    var i = 0;
    var iArray = [];
    $("#" + TABLE_ID + " tbody").find("tr").each(function () {
        iArray.push(parseInt($(this).attr('data-no')));
    });
    if (iArray.length > 0) {
        i = Math.max.apply(Math, iArray) + 1;
    }
    var NewTemp = Temp.replaceAll("999999", i);
    Append_ID.prepend("<tr data-no='" + i + "'></tr>");
    Append_ID.find("tr").eq(1).prepend(NewTemp);
    LIST_EDIT(i);
    $("a#LIST_CANCEL_" + i).attr("data-add", true);
    $("[name$='LIST_ADD']").prop('disabled', true);
    return i;
}

//Add by 奇緯 20210630 明細－刪除
function Common_List_Del(i, callback) {
    swal({
        title: "確定要刪除資料？",
        text: "",
        type: "info",
        showCancelButton: true,
        confirmButtonText: "是",
        cancelButtonText: "否"
    },
        function (isConfirm) {
            if (isConfirm) {
                $("[data-toggle='LIST_LABEL[" + i + "]'").parent().parent().remove();
                if (callback) {
                    callback();
                }
            }
            else {
                return;
            }
        });
}

//Add by 奇緯 20210630 明細－更新
function Common_List_Upd(LIST_NAME, i, type) {
    $("span[name*='" + LIST_NAME + "[" + i + "]']").each(function () {
        //Mod by 奇緯 20210705 使New_Val預設為空值，且將type為radio的欄位與其他欄位分開給值
        var New_Val = "";
        $(this).find("select,input[type=text],input[type=number]").each(function () {
            New_Val = $(this).val();
            if ($(this).is("select")) {
                New_Val = $(this).find("option[value='" + New_Val + "']").text();
            }
        });
        $(this).find("input[type=radio]").each(function () {
            if ($(this).is(":checked")) {
                var id = $(this).attr("id");
                New_Val = $(this).parent().find("label[for=" + id + "]").text();
            }
        });
        $("[data-label='" + $(this).attr("name") + "']").text(New_Val);
    });
    $("a#LIST_CANCEL_" + i).attr("data-add", false);
    $("[data-toggle='LIST_LABEL[" + i + "]'").attr("style", "display: ");
    $("[data-toggle='LIST_EDIT[" + i + "]'").attr("style", "display: none");
    //復原按鈕click事件
    $("[name='Confirm_" + type + "']").prop("disabled", false);
    $("[name='LIST_ADD']").prop('disabled', false);
    $("a[data-toggle*='LIST_LABEL']").each(function () {
        var ClickEvent = $(this).attr('onclick');
        $(this).attr('onclick', ClickEvent);
    });
}

//Add by 奇緯 20210630 明細－取消
function Common_List_Cancel(LIST_NAME, i, type) {
    if ($("a#LIST_CANCEL_" + i).attr("data-add") == "true") {
        //明細取消－新增
        $("[data-toggle='LIST_LABEL[" + i + "]'").parent().parent().remove();
    }
    else {
        $("span[data-label*='" + LIST_NAME + "[" + i + "]']").each(function () {
            //#region 明細取消－編輯(把span label上面的"原始資料值"塞回edit欄位，這樣點"取消"之後再次"編輯"的edit項目才會正確)
            var Org_Val = $.trim($(this).text()); //修改前的值
            var Org_Col = $("[name='" + $(this).attr("data-label") + "']").find("select,input[type=text],input[type=number],input[type=radio]");

            Org_Col.each(function () {
                //如果是select
                if ($(this).is("select")) {
                    var SelectedVal = $(this).find("option").filter(function () { return $(this).html() == Org_Val; }).val();
                    $(this).val(SelectedVal);
                }
                //如果是radio
                else if ($(this).is("[type=radio]")) {
                    var RadioCheckItem = $(this).next("label").filter(function () { return $(this).text() == Org_Val; }).prev();
                    RadioCheckItem.attr({ "checked": true }).prop({ "checked": true });
                }
                else {
                    $(this).val(Org_Val);
                }
            });
            //#endregion
        });
        $("[data-toggle='LIST_LABEL[" + i + "]'").attr("style", "display: ");
        $("[data-toggle='LIST_EDIT[" + i + "]'").attr("style", "display: none");
    }
    //復原按鈕click事件
    $("[name='LIST_ADD']").prop('disabled', false);
    $("[name='Confirm_" + type + "']").prop("disabled", false);
    $("a[data-toggle*='LIST_LABEL']").each(function () {
        var ClickEvent = $(this).attr('onclick');
        $(this).attr('onclick', ClickEvent);
    });
}

//阻止a裡面的input觸發事件
function AccordionEvt(FORMID) {
    $("#" + FORMID).on("click", "a.accordion-toggle", function (evt) {
        if ($(evt.originalEvent.srcElement).is("input, textarea")) {
            evt.stopPropagation();//阻止事件擴散
            evt.preventDefault();//停止自己的行為
            return false;
        }
    });
}

//Add by 妤瑄 20210530 因為disabled時後端收不到disabled的值，所以這邊在送出前把被disabled的物件長出一個分身(hidden)這樣後端就可以取得到分身的值
function BeforeSubmit_BuildHidden(form) {
    $(form).find('*:disabled').each(function (i, item) {
        var Obj_Name = $(this).attr("name");
        var Obj_Hidden = $("input:hidden[name='" + Obj_Name + "']");
        var SelectedVal = "";
        if ($(this).attr("type") == "radio") {
            SelectedVal = $("[name='" + Obj_Name + "']:checked").val();
        }
        else {
            SelectedVal = $(this).val();
        }

        //找不到hidden時，就產生一個hidden
        if (Obj_Hidden.length > 0) {
            $(Obj_Hidden).remove();
        }
        $("<input/>").attr("name", Obj_Name).attr("type", "hidden").val(SelectedVal).appendTo($(form));
    });
}

//Mod by 奇緯 20210608 將Table的List逐一產生hidden
function BeforeSubmit_BuildHidden_List(table_Id, form) {
    $("#" + table_Id + " tbody").find("tr").each(function (i) {
        var $obj = $(this);
        $obj.find("td[data-type='content']").each(function () {
            var New_Num = "[" + i + "]";
            //Mod by 奇緯 20210806 如果一個td裡面有複數欄位 例如：幣別+金額 也會一起處理成hidden
            var list = $(this).find("select,input,radio,label").parent();
            list.each(function () {
                var Parent_Name = $(this).attr("name");
                var Obj_Name = Parent_Name.replace(/\[[0-9]+\]/, New_Num);
                var Obj_Val = $(this).find("select,input[type=text],input[type=number],input[type=radio]:checked").val();
                Get_Each_Val(Obj_Name, Obj_Val, form);
            });
        });
    });
}

//逐項取值
function Get_Each_Val(Obj_Name, Obj_Val, form) {
    var Obj_Hidden = $("input:hidden[name='" + Obj_Name + "']");
    //若畫面上已有hidden則先清除，以確保建出來的hidden是最新的
    if (Obj_Hidden.length > 0) {
        Obj_Hidden.remove();
    }
    $("<input/>").attr("name", Obj_Name).attr("type", "hidden").val(Obj_Val).appendTo($(form));
}

//<!--- 當動作成功時，顯示成功動作內容 --->
//mod by 志豪 20200121 加上內容 如果有內容則跳出確認框等對方確認
function SuccessAlert(message, desc) {
    $.unblockUI();
    //Mod By 妤瑄 20170417 修改Client_Potential_XSS
    var regex = /(<([^>]+)>)/ig
        , body = message
        , message = body.replace(regex, "");
    if (desc != null || desc != "") {
        swal({
            title: message,
            text: desc,
            type: "success",
            confirmButtonText: "確定",
        });
    }
    else {
        swal({
            title: message,
            type: "success",
            timer: 2000,
            showConfirmButton: false
        });
    }
}

//顯是錯誤訊息 Create By John
function ShowErrorMessage(error) {
    $.unblockUI();
    $.each(error, function (keys, value) {
        var span = 'span[data-valmsg-for="' + keys + '"]';
        if (keys == "") {
            span = 'span[data-valmsg-for="errorMessage"]';
            value.forEach(function (item) {
                $(span).append(item + "</br>");
            });

        } else {
            $(span).html(value);
        }
    })
}

//<!--- 顯示警示視窗 --->
function InfoAlert(message) {
    $.unblockUI();

    //Mod By 妤瑄 20170417 修改Client_Potential_XSS
    var regex = /(<([^>]+)>)/ig
        , body = message
        , message = body.replace(regex, "");

    if (message.indexOf("查無資料") > -1) {
        swal({
            title: "",
            text: message,
            type: "info",
            confirmButtonText: "確定",
        });
    }
    else {
        swal({
            title: "請確認以下內容：",
            text: message + "\n請重新調整資料內容。",
            type: "info",
            confirmButtonText: "確定",
        });
    }
}
