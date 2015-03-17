/*
测试版本，一边学一边写一边抄	
调用方式  $('#txt').xValidate({require:true,type:'int',minValue:4,maxValue:10,minLength:1,maxLength:100});
type的可选项有 cn,int ,float, 参数可以复合的用
现在只返回true，false，调用时，读返回值自己做信息反馈给用户，比如alert
*/
(function ($) {
    $.fn.xValidate = function (options) {
        var defaults = {
            //默认设置，如果参数不给，以这个为准，如果给了参数，参数覆盖默认
            require: true
        },
        // This makes it so the users custom options overrides the default ones
        // 合并 defaults 和 options, 不修改 defaults。
    	settings = $.extend({}, defaults, options);

        //正则表达式
        var ruleRegex = /^(.+?)\[(.+)\]$/,
            numericRegex = /(\-|\+)?[0-9]+(.[0-9]+)?$/, // float + int 兼容
            intRegex = /^[0-9]+$/, //by ckw done
            cnRegex = /^[\u4e00-\u9fa5]+$/, // 中文判断  
            emailRegex = /^[a-zA-Z0-9.!#$%&amp;'*+\-\/=?\^_`{|}~\-]+@[a-zA-Z0-9\-]+(?:\.[a-zA-Z0-9\-]+)*$/,
            alphaRegex = /^[a-z]+$/i,
            alphaNumericRegex = /^[a-z0-9]+$/i,
            alphaDashRegex = /^[a-z0-9_\-]+$/i,
            naturalRegex = /^[0-9]+$/i,
            naturalNoZeroRegex = /^[1-9][0-9]*$/i,
            ipRegex = /^((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){3}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})$/i,
            base64Regex = /[^a-zA-Z0-9\/\+=]/i,
            numericDashRegex = /^[\d\-\s]+$/,
            urlRegex = /^((http|https):\/\/(\w+:{0,1}\w*@)?(\S+)|)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?$/,
            postcode= /^[1-9][0-9]{5}$/,
            mobileRegex = /^1[3,5,7,8]\d{9}$/,
            phoneRegex = /^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$/;
        moneyRegex = /^(([1-9]\d*)|0)(\.\d{1,2})?$/;

        var ErrorWords = ['不能为空！',  //0
        '不是合法的整数', //1
        '不是合法的数字', //2
        '数值不能小于',  //3
        '数值不能大于', //4
        '不是合法数字', //5
        '长度不能小于', //6
        '长度不能大于', //7
        '不是有效的手机号码', //8
        '不是合法'//9
        ];

        //return this.each(function () {
        var obj = $(this);
        var bln = true;
        var base_state = 0;
        var each_state = 1;
        var ErrorWord = "";

        //不能为空如果启用，则判断
        if (settings.require != null && settings.require != undefined && settings.require == true) {
            if ($.trim(obj.val()) == '') {
                //alert(ErrorWords[0]);
                bln = false;
                base_state = base_state + each_state;
                ErrorWord = ErrorWords[0];
            }
        }
        //中文
        if (settings.type != null && settings.type != undefined && settings.type == 'cn') {
            var t_val = $.trim(obj.val());
            if (!cnRegex.test(t_val)) {
                //alert(ErrorWords[1]);
                bln = false;
                base_state = base_state + (each_state << 1);
                ErrorWord = ErrorWords[9];
            }
        }
        //金额
        if (settings.type != null && settings.type != undefined && settings.type == 'money') {
            var t_val = $.trim(obj.val());
            if (!moneyRegex.test(t_val)) {
                //alert(ErrorWords[1]);
                bln = false;
                base_state = base_state + (each_state << 1);
                ErrorWord = ErrorWords[9];
            }
        }
        //邮编
        if (settings.type != null && settings.type != undefined && settings.type == 'postcode') {
            var t_val = $.trim(obj.val());
            if (!postcode.test(t_val)) {
                //alert(ErrorWords[1]);
                bln = false;
                base_state = base_state + (each_state << 1);
                ErrorWord = ErrorWords[9];
            }
        }
        //整数
        if (settings.type != null && settings.type != undefined && settings.type == 'int') {
            var t_val = $.trim(obj.val());
            if (!intRegex.test(t_val)) {
                //alert(ErrorWords[1]);
                bln = false;
                base_state = base_state + (each_state << 1);
                ErrorWord = ErrorWords[9];
            }
        }
        //浮点数
        if (settings.type != null && settings.type != undefined && settings.type == 'float') {
            var t_val = $.trim(obj.val());
            if (!numericRegex.test(t_val)) {
                //alert(ErrorWords[2]);
                bln = false;
                base_state = base_state + (each_state << 1);
                ErrorWord = ErrorWords[9];
            }
        }

        //手机号码验证
        if (settings.type != null && settings.type != undefined && settings.type == 'mobile') {
            var t_val = $.trim(obj.val());
            if (!mobileRegex.test(t_val)) {
                bln = false;
                base_state = base_state + (each_state << 1);
                ErrorWord = ErrorWords[9];
            }
        }
        //email验证
        if (settings.type != null && settings.type != undefined && settings.type == 'email') {
            var t_val = $.trim(obj.val());
            if (!emailRegex.test(t_val)) {
                bln = false;
                base_state = base_state + (each_state << 1);
                ErrorWord = ErrorWords[9];
            }
        }
        //电话号验证
        if (settings.type != null && settings.type != undefined && settings.type == 'phone') {
            var t_val = $.trim(obj.val());
            if (!phoneRegex.test(t_val)) {
                bln = false;
                base_state = base_state + (each_state << 1);
                ErrorWord = ErrorWords[9];
            }
        }
        //数值大小
        if (settings.minValue != null && settings.minValue != undefined && !isNaN(settings.minValue)) {
            var t_val = parseFloat(obj.val());
            var min_val = parseFloat(settings.minValue)
            if (!isNaN(t_val) && !isNaN(min_val) && t_val < min_val) {
                //alert(ErrorWords[3]);
                bln = false;
                base_state = base_state + (each_state << 2);
                ErrorWord = ErrorWords[9];
            }
        }
        //数值大小
        if (settings.maxValue != null && settings.maxValue != undefined && !isNaN(settings.maxValue)) {
            var t_val = parseFloat(obj.val());
            var max_val = parseFloat(settings.maxValue)
            if (!isNaN(t_val) && !isNaN(max_val) && t_val > max_val) {
                //alert(ErrorWords[4]);
                bln = false;
                base_state = base_state + (each_state << 2);
                ErrorWord = ErrorWords[9];
            }
        }

        //字符串长度
        if (settings.minLength != null && settings.minLength != undefined && settings.minLength != '') {
            var t_val = $.trim(obj.val());
            var min_len = parseInt($.trim(settings.minLength));
            if (t_val.length < min_len) {
                //alert(ErrorWords[6]);
                bln = false;
                base_state = base_state + (each_state << 3);
                ErrorWord = ErrorWords[9];
            }
        }
        //字符串长度
        if (settings.maxLength != null && settings.maxLength != undefined && settings.maxLength != '') {
            var t_val = $.trim(obj.val());
            var max_len = parseInt($.trim(settings.maxLength));
            if (t_val.length > max_len) {
                //alert(ErrorWords[7]);
                bln = false;
                base_state = base_state + (each_state << 3);
                ErrorWord = ErrorWords[9];
            }
        }

        return bln;

        //}); // END: return this
    };
    $.fn.xFormValidate = function (options) {
        var defaults = {
            //默认设置，如果参数不给，以这个为准，如果给了参数，参数覆盖默认
            require: true,
            ajaxValid: false//异步验证
        };
        options = $.extend(defaults, options);
        var xOffset = -20; // x distance from mouse
        var yOffset = 20; // y distance from mouse  
        //input action
        var initRequireXValidate = function (obj) {
            obj
            .blur(function () {
                if (options.ajaxValid == true) {
                    //ajax_validate($(this));
                } else {
                    if (obj.val().trim() == "") {
                        changeErrorStyle(obj, "add");
                    } else {
                        changeErrorStyle(obj, "remove");
                    }
                }
            });
        };
        var initDataTypeXValidate = function (obj) {
            obj
            .hover(
            function (e) {
                if ($(this).attr('tip') != undefined) {
                    var top = (e.pageY + yOffset);
                    var left = (e.pageX + xOffset);
                    $('body').append('<p id="vtip"><img id="vtipArrow" src="images/vtip_arrow.png"/>' + $(this).attr('tip') + '</p>');
                    $('p#vtip').css("top", top + "px").css("left", left + "px");
                    $('p#vtip').bgiframe();
                }
            },
            function () {
                if ($(this).attr('tip') != undefined) {
                    $("p#vtip").remove();
                }
            }
            )
            .mousemove(
            function (e) {
                if ($(this).attr('tip') != undefined) {
                    var top = (e.pageY + yOffset);
                    var left = (e.pageX + xOffset);
                    $("p#vtip").css("top", top + "px").css("left", left + "px");
                }
            }
            )
            .blur(function () {
                if (options.ajaxValid == true) {
                    //ajax_validate($(this));
                } else {
                    validateForm(obj, obj.attr("datatype"));
                }
            });

        };
        var validateForm = function (obj, key) {
            if (obj.val().trim() != "" && key != undefined) {
                var myType = key;
                var bln = obj.xValidate({ type: myType });
                if (bln == false) {
                    changeErrorStyle(obj, "add");
                    changeTip(obj, null, "remove");
                    return false;
                } else {
                    if (obj.attr("url") == undefined) {
                        changeErrorStyle(obj, "remove");
                        changeTip(obj, null, "remove");
                        return true;
                    } else {
                        return ajax_validate(obj);
                    }
                }
            }

        };
        var changeErrorStyle = function (obj, operate) {
            if (operate == "add") {
                obj.css("border-color", "red");
            }
            if (operate == "remove") {
                obj.css("border-color", "");
            }

        };

        var changeTip = function (obj, msg, actionType) {
            if (obj.attr("tip") == undefined) { //初始化判断TIP是否为空
                obj.attr("is_tip_null", "yes");
            }
            if (actionType == "add") {
                if (obj.attr("is_tip_null") == "yes") {
                    obj.attr("tip", msg);
                } else {
                    if (msg != null) {
                        if (obj.attr("tip_bak") == undefined) {
                            obj.attr("tip_bak", obj.attr("tip"));
                        }
                        obj.attr("tip", msg);
                    }
                }
            } else {
                if (obj.attr("is_tip_null") == "yes") {
                    obj.removeAttr("tip");
                    obj.removeAttr("tip_bak");
                } else {
                    obj.attr("tip", obj.attr("tip_bak"));
                    obj.removeAttr("tip_bak");
                }
            }
        };

        this.each(function () {
            var thisObj = $(this);
            thisObj.find("[demand='readOnly']").click(function () {
                $(this).attr("readOnly", "true");
            });
            thisObj.find("[datatype='money']").each(function () {
                initDataTypeXValidate($(this));
            });
            thisObj.find("[datatype='mobile']").each(function () {
                initDataTypeXValidate($(this));
            });
            thisObj.find("[require='must']").each(function (e) {
                initRequireXValidate($(this));
            });
            thisObj.find("[datatype='int']").each(function () {
                initDataTypeXValidate($(this));
            });
            thisObj.find("[datatype='phone']").each(function () {
                initDataTypeXValidate($(this));
            });
            thisObj.find("[datatype='mobile']").each(function () {
                initDataTypeXValidate($(this));
            });
            thisObj.find("[datatype='email']").each(function () {
                initDataTypeXValidate($(this));
            });
            thisObj.find("[datatype='float']").each(function () {
                initDataTypeXValidate($(this));
            });
            thisObj.find("[datatype='call']").each(function () {
                initDataTypeXValidate($(this));
            });
        });

    };
})(jQuery);