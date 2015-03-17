function deleteItem(pageName,myId) {

    if (confirm("确定要删除选中的记录吗?")) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "../../Service/CRMWebService.asmx/DeleteItem",
            data: "{'pageName':'" + pageName + "','myId':'" + myId + "'}",
            dataType: "json",
            async: true,
            success: function (data) {
                alert("删除成功！");
                refresh();
            },
            error: function (result) {
                alert("删除失败！");
                //alert("Due to unexpected errors at BindCat "+result.d);
            }
        });
    }
}

function deleteItems(pageName,obj) {
    var table = $(obj).parent().parent();
    var selectedIDs =[];
    $("#" + table.attr("id") + " input@[name='selRecord'][checked='checked']").each(function() {
         selectedIDs.push($(this).val());
    });
    //alert(selectedIDs);
        var myIds = selectedIDs.toString();
     
     if (confirm("确定要删除选中的记录吗?")) {
         $.ajax({
             type: "POST",
             contentType: "application/json; charset=utf-8",
             url: "../../Service/CRMWebService.asmx/DeleteItems",
             data: "{'pageName':'" + pageName + "','myIds':'" + myIds + "'}",
             dataType: "json",
             async: true,
             success: function (data) {
                 alert("删除成功！");
                 refresh();
             },
             error: function (result) {
                 //    alert("删除失败！");
                 alert("Due to unexpected errors at DeleteItems "+result);
             }
         });
         return false;
         /*$.ajax({
             type: "POST",
             contentType: "application/json; charset=utf-8",
             url: "../../Service/CRMWebService.asmx/DeleteItems",
             data: "{'pageName':'" + pageName + "','selectedIDs':'" + selectedIDs.toString() + "'}",
             dataType: "json",
             async: true,
             success: function (data) {
                 alert("删除成功！");
                 refresh();
             },
             error: function (result) {
                 alert("删除失败！");
                 //alert("Due to unexpected errors at BindCat"+result.d);
             }
         });*/
     }

}

function refresh() {
    location.href = location.href;
}
function loadModuleJsOp(op_priv, opNum, f, args, op_id, o) {
    var ownerDoc = window;
    var oSelectIds = jQuery("#selectIds"), oMselectIds = jQuery("#MselectIds");
    if (op_id == "008") {
        alert(td_lang.crm.apps.msg_53 + "...");
        return false;
    }
    if (op_id == "000" || op_id == "002" || op_id == "009" || (arguments.length == "6" && op_id == "010")) {
        var selectId = jQuery(o).parents("td").first().attr("id");
        var thisTable = jQuery(o).parents(".Reference_Table").first();
        if (thisTable.length) {
            ownerDoc = thisTable.siblings('input');
            ownerDoc.each(function () {
                if (this.id == "selectIds") oSelectIds = jQuery(this);
                if (this.id == "MselectIds") oMselectIds = jQuery(this);
            });
        } else {
            oSelectIds = jQuery("#selectIds");
            oMselectIds = jQuery("#MselectIds");
        }
        oSelectIds.val(selectId);
        oMselectIds.val(selectId);
        args.push(selectId);
    }
    else {
        getSelData();
    }
    var share_op = "";
    if (opNum == 0) {
        f.apply(f, args);
    } else if (opNum == 1) {
        var id = oSelectIds.val();
        if (id == "") {
            alert(td_lang.crm.apps.msg_54); //操作权限不允许!');
            return false;
        }
        if (id != "") {
            var rowObj = document.getElementById("tr_" + id);
            if (typeof rowObj != 'undefined' && rowObj != null) {
                var key_priv = rowObj.getAttribute("key_priv");
                var share_op = rowObj.getAttribute("share_op");
                var other_op = rowObj.getAttribute('other_op');
                var key_create_dept = rowObj.getAttribute('key_create_dept');
                var key_owner_dept = rowObj.getAttribute('key_owner_dept');
                var key_owner = rowObj.getAttribute('key_owner');
                if (!isMatchBasePriv(op_priv, key_priv, key_owner_dept, key_owner)
						&& !isMatchSharePriv(share_op, op_id)
						&& !isMatchOtherPriv(other_op, op_id, 1)) {
                    alert(td_lang.crm.apps.msg_55);
                    return false;
                }
                if (isMatchOtherPriv(other_op, op_id, 0)
					&& !isMatchSharePriv(share_op, op_id)) {
                    alert(td_lang.crm.apps.msg_55);
                    return false;
                }
            }
        }
        f.apply(f, args);
        return true;
    } else if (opNum == 2) {
        var id = oSelectIds.val();
        if (id == "") {
            alert(td_lang.crm.apps.msg_56); //操作权限不允许!');
            return false;
        }
        if (id != "") {
            var id_array = id.split(",");
            for (i = 0; i < id_array.length; i++) {
                var rowObj = document.getElementById("tr_" + id_array[i]);
                if (typeof rowObj != 'undefined' && rowObj != null) {
                    var key_priv = rowObj.getAttribute("key_priv");
                    var share_op = rowObj.getAttribute("share_op");
                    var other_op = rowObj.getAttribute('other_op');
                    var key_create_dept = rowObj.getAttribute('key_create_dept');
                    var key_owner_dept = rowObj.getAttribute('key_owner_dept');
                    var key_owner = rowObj.getAttribute('key_owner');
                    if (!isMatchBasePriv(op_priv, key_priv, key_owner_dept, key_owner)
							&& !isMatchSharePriv(share_op, op_id)
							&& !isMatchOtherPriv(other_op, op_id, 1)) {
                        alert(td_lang.crm.apps.msg_57);
                        return false;
                    }
                    if (isMatchOtherPriv(other_op, op_id, 0)
						&& !isMatchSharePriv(share_op, op_id)) {
                        alert(td_lang.crm.apps.msg_57);
                        return false;
                    }
                }
            }
        }
        f.apply(f, args);
        return true;
    }
}
function isMatchBasePriv(op_priv, key_priv, key_owner_dept, key_owner) {

    var tmp_key_priv = (key_priv.substr(key_priv.length - 1, 1) == "!") ? key_priv.substring(0, key_priv.length - 1) : key_priv;
    var tmp_op_priv = (op_priv.substr(op_priv.length - 1, 1) == "!") ? op_priv.substring(0, op_priv.length - 1) : op_priv;
    var tmp_priv_arr = tmp_op_priv.split("!");
    var tmp_priv_arr_len = tmp_priv_arr.length;

    for (var i = 0; i < tmp_priv_arr_len; i++) {
        var full_priv_arr = tmp_priv_arr[i].split("|");
        var final_priv = full_priv_arr[0];
        var other_dept = full_priv_arr[1];
        if (final_priv == "4") {
            return true;
        }
        if (final_priv == "0") {
            return false;
        }

        //权限扩充，解决高级权限没有将低级权限包含在内的问题。
        if (final_priv == "2" || final_priv == "3") {
            var tmp_key_priv_arr = tmp_key_priv.split("!");
            for (i = 0; i < tmp_key_priv_arr.length; i++) {
                if (final_priv > tmp_key_priv_arr[i] && tmp_key_priv_arr[i] != "") {
                    return true;
                }
            }
        }

        if (final_priv != "5" && key_priv != "") {
            var reg = new RegExp("!", "g");
            var reg_key_priv = new RegExp("!(" + tmp_key_priv.replace(reg, "|") + ")!");
            if (reg_key_priv.test("!" + tmp_op_priv + "!")) {
                return true;
            }
        }
        if (final_priv == "5") {
            var tmp_other_dept = (other_dept.substr(other_dept.length - 1, 1) == ",") ? other_dept.substring(0, other_dept.length - 1) : other_dept;
            var tmp_key_owner_dept = (key_owner_dept.substr(key_owner_dept.length - 1, 1) == ",") ? key_owner_dept.substring(0, key_owner_dept.length - 1) : key_owner_dept;
            var reg = new RegExp(",", "g");
            var reg_dept_priv = new RegExp(",(" + tmp_other_dept.replace(reg, "|") + "),");
            if (reg_dept_priv.test("," + tmp_key_owner_dept + ",")) {
                return true;
            }
        }
        continue;
    }
    return false;
}

function isMatchSharePriv(share_op, op_id) {
    var op_flag = "";
    var temp_share_op_arr = share_op.split(":");
    var temp_op_str = temp_share_op_arr[1];
    if (temp_op_str == "" || typeof temp_op_str == "undefined") {
        return false;
    }
    var reg = new RegExp("" + op_id + "(.*?)\#");
    var result = temp_op_str.match(reg);
    if (result != null) {
        var temp_op_flag = result[1].split("|");
        op_flag = temp_op_flag[1];
    }
    if (op_flag == "1") {
        return true;
    }
    return false;
}

function isMatchOtherPriv(other_op, op_id, plus_or_minus) {
    var op_flag = "";
    var temp_other_op_arr = other_op.split(":");
    var temp_op_str = temp_other_op_arr[1];
    if (temp_op_str == "" || typeof temp_op_str == "undefined") {
        return false;
    }
    var reg = new RegExp("" + op_id + "(.*?)\#");
    var result = temp_op_str.match(reg);
    if (result != null) {
        var temp_op_flag = result[1].split("|");
        op_flag = temp_op_flag[1];
        if (plus_or_minus == 1) {
            if (op_flag == "1") {
                return true
            }
        } else if (plus_or_minus == 0) {
            if (op_flag == "0") {
                return true
            }
        }
    }
    return false;
}

function ShareRecord(op_id, entity_name, selectId) {
    var selectId = selectId || jQuery("#MselectIds").val();
    var entity = entity_name || jQuery("#entity").val();
    if (selectId == "") {
        alert(td_lang.crm.apps.msg_58);
        return false;
    } else {
        url = g_CRM_PATH + "/include/Share/?entity=" + entity + "&id=" + selectId + '&op_id=' + op_id;
        openWindow(url, 650, 600, { 'scrollbars': 'no', 'resizable': 'no' });
        return false;
    }
}

function RefDetailRecord(entity, id, op_id) {
    jQuery.ajax({
        url: g_CRM_PATH + "/include/entityPath.php",
        data: "entity_name=" + entity,
        type: "POST",
        async: false,
        success: function (msg) {
            var msgArr = msg.split("|");
            if (msgArr.length == 2) {
                var entity_path = msgArr[0];
                var entity_label = msgArr[1];
                var url = "/general/" + entity_path + "/DetailView/DetailView.php?op_id=000&id=" + id;
                openWindow(url, 1200, 570, null, entity + id);
                return false;
            } else {
                alert(td_lang.crm.apps.msg_59);
                return false;
            }
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
}

function DetailRecord(op_id, entity_name, selectId) {
    var selectId = selectId || jQuery("#selectIds").val();
    RefDetailRecord(entity_name, selectId, op_id);
}

function InsertRecord(op_id) {
    newRecord("", "", op_id, "", "");
}

function InsertRecord_ref(entity_name, base_entity, base_id, op_id) {
    newRecord(entity_name, "", op_id, base_entity, base_id);
}

function EditRecord(op_id, entity_name, selectId) {
    var selectId = selectId || jQuery("#selectIds").val();
    newRecord(entity_name, selectId, op_id, "", "");
}
function toEditView(id, entity_name, op_id) {

    location = '../EditView/EditView.php?entity=' + entity_name + '&id=' + id + '&op_id=' + op_id;
}

function DeleteRecord(op_id, entity_name, selectId, url) {
    var selectId = selectId || jQuery("#MselectIds").val();
    var entity = entity_name || jQuery("#entity").val();
    if (selectId == "") {
        alert(td_lang.crm.apps.msg_58); //请选择一条记录！
        return false;
    } else {
        if (url) {
            var msg = td_lang.crm.apps.msg_71; //确定要删除当前记录吗？
            url = "../DeleteView/?entity=" + entity + "&ids=" + selectId + '&op_id=' + op_id + '&url=1';
        }
        else {
            var msg = td_lang.crm.apps.msg_60; //确定要删除选中的记录吗？
            url = "DeleteView/?entity=" + entity + "&ids=" + selectId + '&op_id=' + op_id;
        }
        if (!confirm(msg)) {
            return false;
        }


        openWindow(url, 500, 333, { 'scrollbars': 'no', 'resizable': 'no' }, "HiddenIframe");
        return false;
    }
}

function TrackRecord(op_id, entity_name, selectId) {
    var selectId = selectId || jQuery("#selectIds").val();
    if (selectId == "") {
        alert(td_lang.crm.apps.msg_58); //请选择一条记录！
        return false;
    } else if (selectId.indexOf(",") >= 0) {
        alert(td_lang.crm.apps.msg_61); //该动作只支持单条记录！
        return false;
    } else {
        //url = g_CRM_PATH + "/include/history.php?entity_name="+entity+"&id="+selectId+'&op_id='+op_id;
        url = g_CRM_PATH + "/include/historyframe.php?entity_name=" + entity_name + "&id=" + selectId + '&op_id=' + op_id;
        params = "";
        var historyWin = window.showModalDialog(url, window, "dialogWidth=712px;dialogHeight=570px", params);
        //historyWin.focus();
        return false;
    }

}

function Import(op_id, entity_name) {
    var entity = jQuery("#entity").val();
    var obj = (window.name == "product_main") ? parent.window : window;
    goToUrl(g_CRM_PATH + "/include/import/index.php?entity=" + entity + "&op_id=" + op_id, null, obj);
}

function Export(op_id, entity_name) {
    var entity_name = jQuery("#entity").val();
    var selectId = jQuery("#selectIds").val();
    //alert(selectId);
    window.showModalDialog(g_CRM_PATH + "/include/export/index.php?entity_name=" + entity_name + '&op_id=' + op_id + '&ids=' + selectId, window, "dialogWidth=700px;dialogHeight=570px");
}

function copyRecord(op_id, entity_name) {
    var selectId = jQuery("#selectIds").val();
    if (selectId == "") {
        alert(td_lang.crm.apps.msg_58);
        return false;
    } else if (selectId.indexOf(",") >= 0) {
        alert(td_lang.crm.apps.msg_61);
        return false;
    } else {
        //if(parent.window.name == "table_index") {
        goToUrl('EditView/EditView.php?id=' + selectId + "&op=copy" + "&op_id=" + op_id);
        //		}else {
        //			openWindow('EditView/EditView.php?id='+selectId+"&op=copy"+"&op_id="+op_id,800,600);	
        //		}
        return false;
    }
}


function DeleteConfirm() {
    getSelData();
    var selectId = jQuery("#selectIds").val();
    var entity_name = jQuery("#entity").val();
    if (selectId == "") {
        alert(td_lang.crm.apps.msg_58);
        return false;
    }
    var url = g_CRM_PATH + "/include/delete_confirm.php?entityname=" + entity_name + "&ids=" + selectId;
    window.open(url, "", "width=800px,height=600px");
}

function ReferDetail() {
    getSelData();
    var selectId = jQuery("#selectIds").val();
    var entity_name = jQuery("#entity").val();
    if (selectId == "") {
        alert(td_lang.crm.apps.msg_58);
        return false;
    }
    var url = g_CRM_PATH + "/include/refer_detail.php?entityname=" + entity_name + "&ids=" + selectId;
    openWindow(url, 800, 600);
}

function Resume() {
    getSelData();
    var selectId = jQuery("#selectIds").val();
    var entity_name = jQuery("#entity").val();
    if (selectId == "") {
        alert(td_lang.crm.apps.msg_58);
        return false;
    }

    var msg = td_lang.crm.apps.msg_62;
    if (!confirm(msg)) {
        return false;
    }

    var url = g_CRM_PATH + "/include/resume.php";
    var data = "entityname=" + entity_name + "&ids=" + selectId;
    jQuery.ajax({
        type: "GET",
        async: false,
        url: url,
        data: data,
        success: function (msg) {
            if (msg == "+ok") {
                alert(td_lang.crm.apps.msg_63);
                window.location.reload();
            }
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
}

function newRecord(entity, id, op_id, base_entity, base_id) {
    if (entity == "") {
        entity = jQuery("#entity").val();
    }
    jQuery.ajax({
        url: g_CRM_PATH + "/include/entityPath.php",
        data: "entity_name=" + entity,
        type: "POST",
        async: false,
        success: function (msg) {
            var msgArr = msg.split("|");
            if (msgArr.length == 2) {
                var entity_path = msgArr[0];
                var entity_label = msgArr[1];
                var url = "/general/" + entity_path;
                if (id != "") {
                    url += "/EditView/EditView.php?op_id=" + op_id + "&id=" + id;
                }
                else {
                    if (base_entity != "" && base_id != "")
                        url += "/EditView/EditView.php?op_id=" + op_id + "&base_entity=" + base_entity + "&base_id=" + base_id;
                    else
                        url += "/EditView/EditView.php?op_id=" + op_id;
                }
                openWindow(url, 1200, 600, null, entity + id);
                return false;
            } else {
                alert(td_lang.crm.apps.msg_59);
                return false;
            }
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
}

function RevisionHistory(id) {//最近修改记录
    //if(parent.window.name == "table_index") {
    openWindow("DetailView/DetailView.php?id=" + id + "&op_id=000", 1100, 600, { resizable: 'no' });
    //	}else {
    //		openWindow("EditView/EditView.php?id="+id+"&op_id=002",800,600);	
    //	}
    return false;
}

function changeView(viewId) {
    if (typeof indexInfo == 'undefined' || typeof getListInfo == 'undefined') {
        var url = window.location.pathname;
        url += "?USER_VIEW=" + viewId;
        var param = getUrlQueryString(window.location.search, "param");
        if (param != null && trim(param) != "") {
            var params = param.split(",");
            url += keepQueryString("param", "&");
            for (var i = 0; i < params.length; i++) {
                url += keepQueryString(params[i], "&");
            }
        }
        goToUrl(url);
    } else {
        indexInfo.USER_VIEW = viewId;
        indexInfo.ORDERFIELD = '';
        indexInfo.ORDERTYPE = '';
        indexInfo.CUR_PAGE = '';
        getListInfo(indexInfo);
    }
}

function orderView(entity) {
    var page = openWindow(g_STUDIO_PATH + '/modules/ViewDefine/order.php?entity_name=' + entity, 700, 500, "", "_blank");
    page.focus();
}

function createUView(entity, selObj) {
    if (typeof selObj == 'undefined' || selObj == null) {
        selObj = getObj('view_sel');
    }
    var view_id = selObj.value;
    var obj = (window.name == "product_main") ? parent.window : window;
    goToUrl(g_STUDIO_PATH + '/modules/ViewDefine/index.php?entity_name=' + entity + "&view_id_old=" + view_id, null, obj);
    //goToUrl(g_STUDIO_PATH+'/modules/ViewDefine/index.php?entity_name=' + entity);
}

function updateUView(entity, selObj, actionType) {
    if (typeof selObj == 'undefined' || selObj == null) {
        selObj = getObj('view_sel');
    }
    if (typeof selObj == 'undefined' || selObj == null) {
        actionType = "";
    }
    var view_id = selObj.value;
    var obj = (window.name == "product_main") ? parent.window : window;
    goToUrl(g_STUDIO_PATH + '/modules/ViewDefine/index.php?entity_name=' + entity + "&view_id=" + view_id + "&actionType=" + actionType, null, obj);
    //goToUrl(g_STUDIO_PATH+'/modules/ViewDefine/index.php?entity_name=' + entity + "&view_id=" + view_id+"&actionType="+actionType);
}

function delUView(entity, selObj) {
    var msg = td_lang.crm.apps.msg_64;
    if (!confirm(msg)) {
        return false;
    }
    if (typeof selObj == 'undefined' || selObj == null) {
        selObj = getObj('view_sel');
    }
    var view_id = selObj.value;
    goToUrl(g_STUDIO_PATH + '/modules/ViewDefine/delete.php?entity_name=' + entity + "&view_id=" + view_id);
}

function setDefaultView(entity, selObj) {
    if (typeof selObj == 'undefined' || selObj == null) {
        selObj = getObj('view_sel');
    }
    var view_id = selObj.value;
    goToUrl(g_STUDIO_PATH + '/modules/ViewDefine/setDefault.php?entity_name=' + entity + "&view_id=" + view_id);
}

function SendEmail() {
    var selectId = jQuery("#MselectIds").val();
    var entity_name = jQuery("#entity").val();
    if (selectId == "") {
        alert(td_lang.crm.apps.msg_58);
        return false;
    }
    url = "index.php?TO_ID=" + selectId + "&ENTITY=" + entity_name;
    openWindow(g_CRM_PATH + '/modules/SendEmail/' + url, 900, 550, { 'scrollbars': 'no', 'resizable': 'no' }, "_blank");
    return false;
}

function SendEmailCell(email_addr, o) {
    var rowObj = jQuery(o).parents("td").parents("tr")[0];
    var entity_name = jQuery("#entity").val();
    var email_addr = email_addr;
    jQuery.ajax({
        url: g_CRM_PATH + "/include/getUserOpPriv.php",
        data: "entity_name=" + entity_name + "&OP_ID=011",
        type: "POST",
        async: false,
        success: function (msg) {
            op_priv = msg;
        },
        error: function (msg) {
            alert(msg.responseText);
        }
    });
    if (typeof rowObj != 'undefined' && rowObj != null) {
        var key_priv = rowObj.getAttribute("key_priv");
        var share_op = rowObj.getAttribute("share_op");
        var other_op = rowObj.getAttribute('other_op');
        var key_create_dept = rowObj.getAttribute('key_create_dept');
        var key_owner_dept = rowObj.getAttribute('key_owner_dept');
        var key_owner = rowObj.getAttribute('key_owner');
        if (!isMatchBasePriv(op_priv, key_priv, key_owner_dept, key_owner) && !isMatchSharePriv(share_op, "011") && !isMatchOtherPriv(other_op, "011", 1)) {
            alert(td_lang.crm.apps.msg_55);
            return false;
        }
        if (isMatchOtherPriv(other_op, "011", 0)
			&& !isMatchSharePriv(share_op, op_id)) {
            alert(td_lang.crm.apps.msg_55);
            return false;
        }
    }

    url = "index.php?email_addr=" + email_addr + "&ENTITY=" + entity_name;
    openWindow(g_CRM_PATH + '/modules/SendEmail/' + url, 900, 550, { 'scrollbars': 'no', 'resizable': 'no' }, "_blank");
    return false;
}

function crm_diary() {
    URL = "/modules/crm_diary/?MAIN_URL=new";
    goToUrl(g_STUDIO_PATH + URL);
}

function createOrder(op_id, entity_name) {
    var selectId = jQuery("#selectIds").val();
    if (selectId == "") {
        alert(td_lang.crm.apps.msg_58);
        return false;
    } else if (selectId.indexOf(",") >= 0) {
        alert(td_lang.crm.apps.msg_61);
        return false;
    } else {
        var obj = (window.name == "product_main") ? parent.window : window;
        var entity_name = jQuery("#entity").val();
        goToUrl('createOrder/EditView.php?id=' + selectId + '&op_id=' + op_id + '&from_entity=' + entity_name + '&to_entity=crm_order', null, obj);
        return false;
    }
}

function createQuotation(op_id, entity_name) {
    var selectId = jQuery("#selectIds").val();
    if (selectId == "") {
        alert(td_lang.crm.apps.msg_58);
        return false;
    } else if (selectId.indexOf(",") >= 0) {
        alert(td_lang.crm.apps.msg_61);
        return false;
    } else {
        var obj = (window.name == "product_main") ? parent.window : window;
        var entity_name = jQuery("#entity").val();
        goToUrl('createQuotation/EditView.php?id=' + selectId + '&op_id=' + op_id + '&from_entity=' + entity_name + '&to_entity=crm_order', null, obj);
        return false;
    }
}

function createStockout(op_id, entity_name) {
    var selectId = jQuery("#selectIds").val();
    if (selectId == "") {
        alert(td_lang.crm.apps.msg_58);
        return false;
    } else if (selectId.indexOf(",") >= 0) {
        alert(td_lang.crm.apps.msg_61);
        return false;
    } else {
        var obj = (window.name == "product_main") ? parent.window : window;
        var entity_name = jQuery("#entity").val();
        goToUrl('createStockout/EditView.php?id=' + selectId + '&op_id=' + op_id + '&from_entity=' + entity_name + '&to_entity=crm_order', null, obj);
        return false;
    }
}

function createStorage(op_id, entity_name) {
    var selectId = jQuery("#selectIds").val();
    if (selectId == "") {
        alert(td_lang.crm.apps.msg_58);
        return false;
    } else if (selectId.indexOf(",") >= 0) {
        alert(td_lang.crm.apps.msg_61);
        return false;
    } else {
        var obj = (window.name == "product_main") ? parent.window : window;
        var entity_name = jQuery("#entity").val();
        goToUrl('createStorage/EditView.php?id=' + selectId + '&op_id=' + op_id + '&from_entity=' + entity_name + '&to_entity=crm_order', null, obj);
        return false;
    }
}
function getSelData() {
    var sel_str = "";
    jQuery("input[name='selRecord']").each(function () {
        if (jQuery(this).attr("checked")) {
            sel_str += jQuery(this).val() + ",";
        }
    });
    jQuery("#selectIds").val(sel_str.substring(0, sel_str.length - 1));
    jQuery("#MselectIds").val(sel_str);
}