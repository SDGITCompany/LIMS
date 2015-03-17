/*
*	功能：给文档对象添加事件操作
*  参数:
*  1. target		需添加事件操作的文档对象
*  2. eventName	添加事件名
*  3. handler      事件处理函数
*  4. argsObject	事件处理函数的参数
*/
function AttachEvent(target, eventName, handler, argsObject) {
    var eventHandler = handler;
    if (argsObject) {
        eventHandler = function (e) {
            handler.apply(e, argsObject);
        }
    } else {
        eventHandler = handler;
    }
    if (window.attachEvent) {
        target.attachEvent("on" + eventName, eventHandler);
    } else {
        target.addEventListener(eventName, eventHandler, false);
    }
}

function createAjaxObject() {
    var xmlHttp;
    try {
        xmlHttp = new XMLHttpRequest();
    } catch (e) {
        try {
            xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) {
                alert(td_lang.crm.inc.msg_31);
                return false;
            }
        }
    }
    return xmlHttp;
}


function getObj(theObj, theDoc) {//获取对象
    var p, i, getObj;
    if (!theDoc) theDoc = document;
    if ((p = theObj.indexOf("?")) > 0 && parent.frames.length) {
        theDoc = parent.frames[theObj.substring(p + 1)].document;
        theObj = theObj.substring(0, p);
    }
    if (!(getObj = theDoc[theObj]) && theDoc.all) {
        getObj = theDoc.all[theObj];
    }
    for (i = 0; !getObj && i < theDoc.forms.length; i++) {
        getObj = theDoc.forms[i][theObj];
    }
    for (i = 0; !getObj && theDoc.layers && i < theDoc.layers.length; i++) {
        getObj = findObj(theObj, theDoc.layers[i].document);
    }
    if (!getObj && document.getElementById) {
        getObj = document.getElementById(theObj);
    }
    return getObj;
}

/*
*	功能：获得当前文档查询串中某个参数的值
*  参数:
*  1. name		参数名称
*/
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) {
        return r[2];
    }
    return null;
}

/*
*	功能：获得当前文档查询串中某个参数的值
*  参数:
*  
*   name		参数名称
*/
function getUrlQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) {
        return r[2];
    }
    return null;
}

/*
*	功能：设置参数值
*  参数:
*  1. field        参数名称
*  2. value	    参数值
*  3. splitChar    分割符号(?号或者&号)
*/
function setQueryString(field, value, splitChar) {
    return splitChar + field + "=" + value;
}

/*
*	功能：根据保持原参数的值不变，返回相应的参数串
*  参数:
*  1. field        参数名称
*  2. splitChar    分割符号(?号或者&号)
*/
function keepQueryString(field, splitChar) {
    var value = getQueryString(field);
    return ((value == null) ? "" : (splitChar + field + "=" + value))
}


function getTextObj(obj) {
    if (obj.nodeType == 3) {
        return obj;
    }
    if (obj.childNodes.length == 0) {
        return false;
    }

    return getTextObj(obj.childNodes[0]);
}

function getScrollTop(container) {
    return container.scrollTop;
}

function openWindow(url, width, height, params, target) {

    var left = (screen.availWidth - width) / 2;
    var top = (screen.availHeight - height) / 2;


    var paramStr = "";
    if (typeof params == "undefined" || params == null) {
        paramStr = "toolbar=" + "no,"
                 + "location=" + "no,"
                 + "status=" + "no,"
                 + "directories=" + "no,"
                 + "menubar=" + "no,"
                 + "scrollbars=" + "yes,"
                 + "resizable=" + "yes,"
                 + "left=" + left + ", "
                 + "top=" + top + ", "
                 + "width=" + width + ", "
                 + "height=" + height;
    } else {
        paramStr = "toolbar=" + ((typeof params['toolbar'] == "undefined" || params['toolbar'] == "") ? "no" : params['toolbar']) + ","
                 + "location=" + ((typeof params['location'] == "undefined" || params['location'] == "") ? "no" : params['location']) + ","
                 + "status=" + ((typeof params['status'] == "undefined" || params['status'] == "") ? "no" : params['status']) + ","
                 + "directories=" + ((typeof params['directories'] == "undefined" || params['directories'] == "") ? "no" : params['directories']) + ","
                 + "menubar=" + ((typeof params['menubar'] == "undefined" || params['menubar'] == "") ? "no" : params['menubar']) + ","
                 + "scrollbars=" + ((typeof params['scrollbars'] == "undefined" || params['scrollbars'] == "") ? "yes" : params['scrollbars']) + ","
                 + "resizable=" + ((typeof params['resizable'] == "undefined" || params['resizable'] == "") ? "yes" : params['resizable']) + ","
                 + "left=" + left + ", "
                 + "top=" + top + ", "
                 + "width=" + width + ", "
                 + "height=" + height;
    }

    if (typeof target != 'undefined') {
        winObj = window.open(url, target, paramStr);
    } else {
        winObj = window.open(url, "", paramStr);
    }
    winObj.focus();
    return winObj;
}

/*function openDialogWindow(url, dialogWidth, dialogHeight, params, target) {
    var dialogLeft = (screen.availWidth - dialogWidth) / 2;
    var dialogTop = (screen.availHeight - dialogHeight) / 2;


    var paramStr = "";
    if (typeof params == "undefined") {
        paramStr = "center=" + "yes;"
                 + "help=" + "no;"
                 + "resizable=" + "no;"
                 + "status=" + "yes;"
                 + "scroll=" + "yes;"
                 + "dialogHide=" + "no;"
                 + "edge=" + "raised;"
				 + "unadorned=" + "no;"
                 + "dialogLeft=" + dialogLeft + "; "
                 + "dialogTop=" + dialogTop + "; "
                 + "dialogWidth=" + dialogWidth + "; "
                 + "dialogHeight=" + dialogHeight;
    } else {

        paramStr = "center=" + ((typeof params['center'] == "undefined" || params['center'] == "") ? "no" : params['center']) + ";"
                 + "help=" + ((typeof params['help'] == "undefined" || params['help'] == "") ? "no" : params['help']) + ";"
                 + "resizable=" + ((typeof params['resizable'] == "undefined" || params['resizable'] == "") ? "no" : params['resizable']) + ";"
                 + "status=" + ((typeof params['status'] == "undefined" || params['status'] == "") ? "yes" : params['status']) + ";"
                 + "scroll=" + ((typeof params['scroll'] == "undefined" || params['scroll'] == "") ? "yes" : params['scroll']) + ";"
                 + "dialogHide=" + ((typeof params['dialogHide'] == "undefined" || params['dialogHide'] == "") ? "no" : params['dialogHide']) + ";"
                 + "edge=" + ((typeof params['edge'] == "undefined" || params['edge'] == "") ? "raised" : params['edge']) + ";"
				 + "unadorned=" + ((typeof params['unadorned'] == "undefined" || params['unadorned'] == "") ? "no" : params['unadorned']) + ";"
                 + "dialogLeft=" + dialogLeft + "; "
                 + "dialogTop=" + dialogTop + "; "
                 + "dialogWidth=" + dialogWidth + "; "
                 + "dialogHeight=" + dialogHeight;

    }

    if (typeof target != 'undefined') {
        window.showModalDialog(url, target, paramStr);
    } else {
        window.showModalDialog(url, "", paramStr);
    }

}*/
function openDialogWindow(url, derw, derh,isRefresh) {
    
    var dialogWidth = $(document).width() * 0.8;
    var dialogHeight = $(document).height() * 0.8;
    var obj = $(".xubox_layer:last", parent.parent.document);   //获取最上面的弹窗层
    if ( obj.length!=0) {
        dialogWidth = obj.width() * 0.9;
        dialogHeight = obj.height() * 0.9;
    }
    if (derw != "") {
        dialogWidth = derw;
    }
    if (derh != "") {
        dialogHeight = derh;
    }
    parent.parent.$.layer({
        type: 2,
        fix: false,
        shadeClose: false,
        offset: [($(parent.parent.document).height() - dialogHeight) / 2 + 'px', ''],
        maxmin: false,
        iframe: { src: url },
        area: [dialogWidth, dialogHeight],
        title: false,
        close: function () {
            if (isRefresh == undefined) {
                parent.parent.location.href = parent.parent.location.href;
            }
           else if (isRefresh == "Parent") {
                parent.location.href = parent.location.href;
           }
           
            
        }
    });

}
//四舍五入
function roundValue(val) {
    val = parseFloat(val);
    val = Math.round(val * 100) / 100;
    val = val.toString();

    if (val.indexOf(".") < 0) {
        val += ".00";
    } else {
        var dec = val.substring(val.indexOf(".") + 1, val.length);
        if (dec.length > 2)
            val = val.substring(0, val.indexOf(".")) + "." + dec.substring(0, 2);
        else if (dec.length == 1)
            val = val + "0";
    }

    return val;
}

/*
*  功能：关闭弹窗
*  参数:
*  1. args		刷新函数对应的参数
*/
function CloseAndRebind(args) {
    if (args) {
        GetRadWindow().BrowserWindow.refreshGrid(args);
        GetRadWindow().close();
    } else {
        var opener = window.opener;
        opener.Refresh();
        //终于实现了
        setTimeout("window.close()", 500);

    }

}
function Refresh() {
    location.href = location.href;
}
/*
*  功能：获取当前弹窗的Handle
*  参数:
*  
*/
function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow)
        oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog                
    else if (window.frameElement.radWindow)
        oWindow = window.frameElement.radWindow; //IE (and Moz as well)                
    return oWindow;
}
/*
*  功能：取消编辑
*  参数:
*/
function CancelEdit() { GetRadWindow().close(); }
/*
*  功能：检查提交数据
*  参数:
*  1. 目前仅支持must
*/
function checkForm() {
    var rst = true;
    $("[require='must']").each(function () {
        if ($(this).val().trim() == "") {
            rst = false;
            $(this).css("border-color", "red");
        } else {
            $(this).css("border-color", "");
        }
    });
    $("[datatype='mobile']").each(function () {
        if ($(this).val().trim() != "") {
            if ($(this).xValidate({ type: 'mobile' })==false) {
                rst = false;
                $(this).css("border-color", "red");
            } else {
                $(this).css("border-color", "");
            }
        }
    });
    $("[datatype='email']").each(function () {
        if ($(this).val().trim() != "") {
            if ($(this).xValidate({ type: 'email' }) == false) {
                rst = false;
                $(this).css("border-color", "red");
            } else {
                $(this).css("border-color", "");
            }
        }
    }); 
    $("[datatype='phone']").each(function () {
        if ($(this).val().trim() != "") {
            if ($(this).xValidate({ type: 'phone' }) == false) {
                rst = false;
                $(this).css("border-color", "red");
            } else {
                $(this).css("border-color", "");
            }
        }
    });
    $("[datatype='postcode']").each(function () {
        if ($(this).val().trim() != "") {
            if ($(this).xValidate({ type: 'postcode' }) == false) {
                rst = false;
                $(this).css("border-color", "red");
            } else {
                $(this).css("border-color", "");
            }
        }
    });
    $("[datatype='money']").each(function () {
        if ($(this).val().trim() != "") {
            if ($(this).xValidate({ type: 'money' }) == false) {
                rst = false;
                $(this).css("border-color", "red");
            } else {
                $(this).css("border-color", "");
            }
        }
    });
    $("[datatype='int']").each(function () {
        if ($(this).val().trim() != "") {
            if ($(this).xValidate({ type: 'int' }) == false) {
                rst = false;
                $(this).css("border-color", "red");
            } else {
                $(this).css("border-color", "");
            }
        }
    });
    return rst;
}
function initSearch() {
    //搜索框的回车事件
    $('#keyword').keyup(function (event) {
        if (this.value != "" && $('#search_clear:visible').length <= 0) {
            $('#search_clear').show();
            initAutoComplete();
        } else if (this.value == "")
            $('#search_clear').hide();
            initAutoComplete();
        });
    initHideSearchBar();
}
function initHideSearchBar() {
    //隐藏searchBar事件
    $('#highSearch').bind('click', function () {
        $('#highSearchContent').slideToggle(500, function () {  });
        $(this).toggleClass('searchUp');
        var hidden = $(this).attr('class').indexOf('searchUp') >= 0;
        $.cookie(location.href+'highSearch', (hidden ? '1' : null), { expires: 1000, path: '/' });
    });
    if ($.cookie(location.href+'highSearch') == '1')
        $('#highSearch').triggerHandler('click');
} 
function initAutoComplete() {
    var searchSource = [];
    $("#tableTr a").each(function () {
        if ($(this).attr("index") > 0 && $(this).text().trim() != "") {
            searchSource.push($(this).text() + ":" + $("#keyword").val());
        }
    });
    $("#keyword").autocomplete({
        source: searchSource,
        select: function (event, ui) {

        }
    });
}
//时间控件，只读属性
$(function () {
    $("input[datatype='money'],input[require='must'],input[datatype='mobile'],input[datatype='email'],input[datatype='phone'],input[datatype='int'],input[datatype='postcode']").bind("blur", checkForm);

    $("a[class='ref-delete-handle inline-block']").click(function () {
        $(this).prev().val('');
    });
});
//矿产资源所专用
function InitButtonInfo(savePath,editPath) {
    var itemID = getUrlQueryString('ItemID');
    var status = getUrlQueryString('Status');
    if (itemID == "0") {
        $("#approvelTable").hide();
        $("#approvelTable_cont").hide();
        $("#approvelTable_Pageing").hide();
    } else {
        if (status == "EditStatus") {
            $("#tdCteat").hide();
            $("#tdEdit").show();
           $("#appInfo").show();
            RenderTpl(itemID);
            RenderApproveTpl(itemID);
        } else if (status == "Approval") {
            $("#tdCteat").hide();
            $("#tdEdit").hide();
            $("#tdApprove").show();
            $("#appInfo").show();
            RenderTpl(itemID);
            RenderApproveTpl(itemID);
           // $("select,input,textarea").attr("disabled", "disabled");
        } else if (status == "CompletedStatus") {
            $("#tdCteat").hide();
            RenderApproveTpl(itemID);
            $("select,input,textarea").attr("disabled", "disabled");
        }

    }

    $("#btnSave").click(function () {
        if (checkForm()) {
            $.ajax({
                type: 'post',
                url: savePath, //路径为添加方法
                data: $('#MainFrm').serialize(), //参数的个数和名字要和方法的名字保持一致
                success: function(json) //返回的是Json类型的
                {
                    if (json.Result == true) {
                        parent.parent.layer.msg('保存成功', 2, 1);
                        var search = parent.window.location.search;
                        if (search == "") { //新建
                            parent.window.location.href = parent.window.location.href + "?ItemID=" + json.Data.OrigID;
                        } else {//编辑
                            parent.window.location.href = parent.window.location.href.replace(search, "?ItemID=" + json.Data.OrigID);
                        }
                        //parent.window.location.href = window.location.origin + parent.window.location.pathname + "?ItemID=" + json.Data.OrigID;
                    }
                }
            });
        }
    });
    $("#btnEdit").click(function () {
        if (checkForm()) {
            $.ajax({
                type: 'post',
                url: editPath, //路径为添加方法
                data: $('#MainFrm').serialize(), //参数的个数和名字要和方法的名字保持一致
                success: function(json) //返回的是Json类型的
                {
                    if (json.Result == true) {
                        console.log(json.Result);
                        parent.parent.layer.msg('保存成功', 2, 1);
                    }
                }
            });
        }
    });
    $("#submit").click(function () {
        if (checkForm()) {
            $.ajax({
                type: 'post',
                async: false, //同步
                url: editPath, //路径为添加方法
                data: $('#MainFrm').serialize(), //参数的个数和名字要和方法的名字保持一致
            });
        }
        var userLists = "";
        $("input[type=checkbox]:checked").each(function () {
            userLists += $(this).val() + ";";
            $("#ApproveMyNote").val();
        });
            if (userLists != "") {
                $.ajax({
                    type: "POST", //默认是GET
                    url: "../CommonSvr/Submit", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
                    data: { "ItemID": getUrlQueryString('ItemID'), "Notes": $("#ApproveMyNote").val(), "NextUsers": userLists },
                    async: false, //异步
                    cache: false, //不加载缓存
                    success: function(result) {
                        //返回的result就是json格式的
                        //var tmp = "";
                        parent.parent.layer.msg('提交成功', 2, 6);
                        var index = parent.window.location.href.indexOf('#');
                        if (index == -1) {
                            parent.window.location.href = parent.window.location.href;
                        } else {
                            parent.window.location.href = parent.window.location.href.substr(0, index);
                        }
                    },
                    error: function() {
                        parent.parent.layer.msg("提交失败", 2, 8);
                    }
                });
            } else {
                parent.parent.layer.msg('请您选择下一步审批人！', 2, 15);
            }
       
    });
    $("#btnApprove").click(function () {
        var userLists = "";
        $("input[type=checkbox]:checked").each(function () {
            userLists += $(this).val() + ";";
            $("#ApproveMyNote").val();
        });
        //console.log(userLists);
        if ($("#hfLast").val() == "LastStep") { //流程最后一步时，可以不用选择下一步审批人
            $.ajax({
                type: "POST", //默认是GET
                url: "../CommonSvr/Approval", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
                data: { "ItemID": getUrlQueryString('ItemID'), "Notes": $("#ApproveMyNote").val(), "NextUsers": userLists },
                async: true, //异步
                cache: false, //不加载缓存
                success: function(result) {
                    //返回的result就是json格式的
                    parent.parent.layer.msg('审批成功', 2, 6);
                    var index = parent.window.location.href.indexOf('#');
                    if (index == -1) {
                        parent.window.location.href = parent.window.location.href;
                    } else {
                        parent.window.location.href = parent.window.location.href.substr(0, index);
                    }
                    //alert($("#product_template").render(result));
                    //$("#submit").after($("#submit_Lists").render(result.NextUsers));
                },
                error: function() {
                    alert("同意--请求失败");
                }
            });
        } else {
            if (userLists != "") {
                $.ajax({
                    type: "POST", //默认是GET
                    url: "../CommonSvr/Approval", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
                    data: { "ItemID": getUrlQueryString('ItemID'), "Notes": $("#ApproveMyNote").val(), "NextUsers": userLists },
                    async: true, //异步
                    cache: false, //不加载缓存
                    success: function (result) {
                        //返回的result就是json格式的
                        parent.parent.layer.msg('审批成功', 2, 6);
                        var index = parent.window.location.href.indexOf('#');
                        if (index == -1) {
                            parent.window.location.href = parent.window.location.href;
                        } else {
                            parent.window.location.href = parent.window.location.href.substr(0, index);
                        }
                    },
                    error: function () {
                        alert("同意--请求失败");
                    }
                });
            } else {
                parent.parent.layer.msg('请您选择下一步审批人！', 2, 15);
            }
        }
    });
    $("#btnReject").click(function () {
        var userLists = "";
        $("input[type=checkbox]:checked").each(function () {
            userLists += $(this).val() + ";";
            $("#ApproveMyNote").val();
        });
        //console.log(userLists);
        $.ajax({
            type: "POST", //默认是GET
            url: "../CommonSvr/Reject", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
            data: { "ItemID": getUrlQueryString('ItemID'), "Notes": $("#ApproveMyNote").val(), "NextUsers": userLists },
            async: true, //异步
            cache: false, //不加载缓存
            success: function (result) {
                //返回的result就是json格式的
                //var tmp = "";
                //alert(result);
                parent.window.location.href = parent.window.location.href;
            },
            error: function () {
                alert("请求失败");
            }
        });

    });
}
//异步加载和渲染函数-------下一级审批人
function RenderTpl(tree_id) {
    $.ajax({
        type: "POST", //默认是GET
        url: "../CommonSvr/NextStepUserRoles", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
        data: "ItemID=" + tree_id,
        async: true, //异步
        cache: false, //不加载缓存
        success: function (json) {
            //返回的result就是json格式的
            //var tmp = "";
            //alert(result);
            //alert($("#product_template").render(result));
            if (json.Result) {
                $("#approveUsers").after($("#submit_Lists").render(json.NextUsers));
            } else {
                $("#approveUsers").hide();
                $("#hfLast").val("LastStep");
            }
        },
        error: function () {
            //alert("请求失败");
            $("#approveUsers").hide();
            console.log("下一步审批人请求失败");
            $("#hfLast").val("LastStep");
        }
    });
}
//审批列表
function RenderApproveTpl(tree_id) {
    $.ajax({
        type: "POST", //默认是GET
        url: "../CommonSvr/ApprovalHistory", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
        data: "ItemID=" + tree_id,
        async: true, //异步
        cache: false, //不加载缓存
        success: function (result) {
            //返回的result就是json格式的
            //var tmp = "";
            //alert(result);
            //alert($("#product_template").render(result));
            $("#approvelTable > tbody > tr:gt(0)").remove();
            $("#approvelTable > tbody > tr:first").after($("#approve_Lists").render(result.History));
        },
        error: function () {
            alert("审批列表请求失败");
        }
    });
}




