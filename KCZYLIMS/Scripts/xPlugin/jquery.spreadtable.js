/*
测试版本，一边学一边写一边抄	
调用方式  $('#sss).spreadtable();
*/
(function ($) {
    $.fn.spreadtable = function (options) {
        var defaults = {
            //默认设置，如果参数不给，以这个为准，如果给了参数，参数覆盖默认
            require: true,
            IsAdd: true
        },
        // This makes it so the users custom options overrides the default ones
        // 合并 defaults 和 options, 不修改 defaults。
    	settings = $.extend({}, defaults, options);

        if (settings.url == null || settings.url == undefined || settings.url == "")
        {
            return $(this);
        }

        //return this.each(function () {
        var tbl = $(this);

        $.ajax({
            type:'post',
            url:settings.url,//路径为添加方法
            data: 'ItemID='+settings.ItemID+'&JsonVal=&Action=Read',//参数的个数和名字要和方法的名字保持一致
            success:function(json)//返回的是Json类型的
            {                                
                if (json.Result == true)
                {
                    InitView(json.Data);
                }                
            }
        });


        jQuery.fn.OnSave = function () {
            var arr = [];
            var bln = false;
            $( '#'+ $(tbl).attr('id')+" tr.row_data").each(function (idx, obj) {
                var jVal = {};
                $(this).find("input[type='text']").each(function (idx, obj) {
                    var property = $(obj).attr('prop_name');
                    if (property != undefined && property != null && property != "") {
                        jVal[property] = $(obj).val();
                    }
                })
                arr.push(jVal);
            })
            $.ajax({
                type: 'post',
                url: settings.url,//路径为添加方法
                data: 'ItemID='+settings.ItemID+'&JsonVal=' + JSON.stringify(arr) + '&Action=Save',//参数的个数和名字要和方法的名字保持一致
                success: function (json)//返回的是Json类型的
                {
                    if (json.Result == true) {
                        bln = json.Result;
                    }
                }
            });
            return bln;
        }


        //var pureTr = tbl.find(".row_tpl:first").clone();
        tbl.find(".row_tpl:first").hide();

        $(tbl).on("click", ".x-spread-add", function (event) {
            var cloneTr = tbl.find(".row_tpl:first").clone();
            //提取cloneTr中每个input的值出来，查找input绑定的属性，生成json string
            //提交到Create服务
            //返回成功之后再执行下面
            ClearVal(tbl.find(".row_tpl:first"));
            $(cloneTr).removeClass("row_tpl").addClass("row_data").show();
            //计算器
            var icnt = tbl.find(".row_tpl:first").attr("icnt");
            icnt = icnt + 1;
            tbl.find(".row_tpl:first").attr("icnt",icnt);

            $(cloneTr).find("input").each(function (idx, obj) {
                var prop_name = $(obj).attr("prop_name");
                $(obj).attr("id", prop_name + icnt);            
            })


            tbl.find(".row_tpl:first").after(cloneTr);            
            event.stopPropagation();
        });

        $(tbl).on("click", ".x-spread-edit", function (event) {
            var trParent = $(this).parentsUntil(".row_data").parent();
            //编辑按钮隐藏
            $(this).hide();
            //显示出保存和删除按钮
            $(trParent).find(".x-spread-save").show();
            $(trParent).find(".x-spread-del").show();
            $(trParent).find("input").show();
            $(trParent).find("span.content-show").hide();
            event.stopPropagation();
        });

        $(tbl).on("click", ".x-spread-save", function (event) {
            var trParent = $(this).parentsUntil(".row_data").parent();
            $(trParent).find("input").each(function (idx, obj) {
                $(obj).siblings().text($(obj).val()).show();
                $(obj).hide();
            });
            //提取cloneTr中每个input的值出来，查找input绑定的属性，生成json string
            //提交到Update服务
            //返回成功之后再执行下面
            $(trParent).find(".x-spread-save").hide();
            $(trParent).find(".x-spread-del").hide();
            $(trParent).find(".x-spread-edit").show();
            
            event.stopPropagation();
        });
        $(tbl).on("click", ".x-spread-del", function (event) {
            var trParent = $(this).parentsUntil(".row_data").parent();
            //提取cloneTr中每个input的值出来，查找input绑定的属性，生成json string
            //提交到Delete服务
            //返回成功之后再执行下面
            var row_cnt = $(".row_data").length;
            if (row_cnt > 1) {
                $(trParent).remove();
            }
            event.stopPropagation();
        });

        function ClearVal(obj){
            $(obj).find("input").val("");
        }

        function InitView(json_data) {
            //啥也没有时，直接增加一行
            if (json_data.length == 0)
            {
                var firstTr = tbl.find(".row_tpl:first").clone();
                $(firstTr).removeClass("row_tpl").addClass("row_data").show();
                $(firstTr).find("input").each(function (idx, obj) {
                    var prop_name = $(obj).attr("prop_name");                    
                    $(obj).attr("id", prop_name + 0);
                })

                tbl.find(".row_tpl:first").after(firstTr);
                tbl.find(".row_tpl:first").attr("icnt", 0);
            }
            for (var i = 0; i < json_data.length; i++) {
                tbl.find(".row_tpl:first").attr("icnt", json_data.length);
                
                var cloneTr = tbl.find(".row_tpl:first").clone();
                $(cloneTr).removeClass("row_tpl").addClass("row_data").show();

                $(cloneTr).find("input").each(function (idx, obj) {
                    var prop_name = $(obj).attr("prop_name");
                    $(obj).val(json_data[i][prop_name]);
                    $(obj).attr("id", prop_name + i);
                })

                tbl.find(".row_tpl:first").after(cloneTr);
            }//end for
        }//end func

        function ToJsonObj(tr_obj)
        {
            var json_obj = {};
            $(cloneTr).find("input").each(function (idx, obj) {
                var prop_name = $(obj).attr("prop_name");
                json_obj[prop_name] = $(obj).val();
            })
            return json_obj;
        }//end of func

        return settings;
        //return $(this);

        //}); // END: return this
    };
})(jQuery);