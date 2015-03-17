/*
测试版本，一边学一边写一边抄	
<input type="button" id="lbtnUpload"  div_panel="div_download"  />        <div id="div_download"></div>  
调用方式  $('#lbtnUpload).attachment();

*/
(function ($) {
    $.fn.attachmentInit = function (options) {
        var defaults = {
            //默认设置，如果参数不给，以这个为准，如果给了参数，参数覆盖默认
            RelatedID: 0,
            RelatedType: 0,
            url: '../CommonSvr/AttachmentAPI',
            swfpath: '../Scripts/Third/uploadify/uploadify.swf'
        };
        // This makes it so the users custom options overrides the default ones
        // 合并 defaults 和 options, 不修改 defaults。
    	settings = $.extend({}, defaults, options);

        //button本身,必须用button来调用，button执行了uploadify之后，button自身就没了，插件会弄一个flash object进来
        var button = $(this);
        //对应的div，通过attr获取其id
        var div = $('#' + settings.DivId);

        $(button).uploadify({
            'auto': true,
            'swf': settings.swfpath,
            'uploader': '../CommonSvr/Upload',
            'buttonImg': 'upload.png',//浏览按钮的图片的路径 
            'buttonText': '',
            'height': 25,
            'width': 46,
            'wmode': "transparent",
            'onUploadSuccess': function (file, data, response) {
                if (response == true) {
                    var retObj = $.parseJSON(data);
                    var tmp = GetSpanAttachment(0, retObj.FileName, retObj.SavePath);
                    //alert(tmp);
                    $(div).append(tmp);                    
                }
            }
        });

        //参数判断是读还是写,该好好学学js的面向对象开发啊
        $.ajax({
            type: 'post',
            url: settings.url,//路径为添加方法
            data: 'RelatedID=' + settings.RelatedID + '&RelatedType=' + settings.RelatedType + '&JsonVal=&Action=Read',//参数的个数和名字要和方法的名字保持一致
            success: function (json)//返回的是Json类型的
            {
                if (json.Result == true) {
                    InitView(json.Data,div);
                }
            }
        });     

        //鼠标经过span时显示小x号
        $(div).on("mouseover", ".span-attachment", function () {
            $(this).find("a").show();
        });
        $(div).on("mouseout", ".span-attachment", function () {
            $(this).find("a").hide();
        });
        $(div).on("click", ".selecter_delete", function () {
            $(this).parent().remove();
        });
        return settings;
    };

    $.fn.attachmentSave = function (options) {
        var defaults = {
            //默认设置，如果参数不给，以这个为准，如果给了参数，参数覆盖默认
            RelatedID: 0,
            RelatedType: 0,
            url: '../CommonSvr/AttachmentAPI',
            swfpath: '../Scripts/Third/uploadify/uploadify.swf'
        };
        // This makes it so the users custom options overrides the default ones
        // 合并 defaults 和 options, 不修改 defaults。
        settings = $.extend({}, defaults, options);

        var arr = [];
        var bln = false;
        div = $('#' + settings.DivId);
        $('#' + $(div).attr('id') + " span>a").each(function (idx, obj) {
            var jVal = {};
            jVal['ID'] = $(this).attr('attr_id');
            jVal['FileName'] = $(this).attr('attr_filename');
            jVal['Path'] = $(this).attr('attr_path');
            arr.push(jVal);
        })
        $.ajax({
            type: 'post',
            url: settings.url,//路径为添加方法
            data: 'RelatedID=' + settings.RelatedID + '&RelatedType=' + settings.RelatedType + '&JsonVal=' + JSON.stringify(arr) + '&Action=Save',//参数的个数和名字要和方法的名字保持一致
            success: function (json)//返回的是Json类型的
            {
                if (json.Result == true) {
                    //保存成功了，更新一下界面
                    $.ajax({
                        type: 'post',
                        url: settings.url,//路径为添加方法
                        data: 'RelatedID=' + settings.RelatedID + '&RelatedType=' + settings.RelatedType + '&JsonVal=&Action=Read',//参数的个数和名字要和方法的名字保持一致
                        success: function (json)//返回的是Json类型的
                        {
                            if (json.Result == true) {
                                InitView(json.Data,div);
                            }
                        }
                    });
                }
            }
        });
        return settings;
    };


    //渲染函数
    function InitView(json_data,div) {
        $(div).html("");
        if (json_data == null || json_data.length <= 0)
            return;

        for (var i = 0; i < json_data.length; i++) {
            var strhtml =
                GetSpanAttachment(json_data[i].AttachID, json_data[i].MyName, json_data[i].OrigPath);

            $(div).append(strhtml);
        }//end for
    }//end func

    function GetSpanAttachment(id, filename, path) {
        var strhtml = "<span class='span-attachment' attr_id='" + id + "'>"
                + filename
                + "<a href='javascript:void(0)' class='selecter_delete' style='display:none'  attr_id='" + id + "' attr_filename='" + filename + "' attr_path='" + path + "'></a>"
                + "</span>&nbsp";
        return strhtml;
    }//end of func

})(jQuery);