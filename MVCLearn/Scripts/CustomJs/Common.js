//Add by 奇緯 20210630 明細－編輯
function Common_List_Edit(i, type) {
    $("[data-toggle='LIST_LABEL[" + i + "]'").attr("style", "display: none");
    $("[data-toggle='LIST_EDIT[" + i + "]'").attr("style", "display: ");
    $("[name='Confirm_" + type + "']").prop("disabled", true);
    $("a[data-toggle*='LIST_LABEL']").prop('onclick', null);
    $("[name='LIST_ADD']").prop('disabled', true);
    Initial_Select2();
    Initial_InputMask();
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
