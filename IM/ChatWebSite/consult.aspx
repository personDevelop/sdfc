<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consult.aspx.cs" Inherits="SignalR.consult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>在线客服</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.6.4.min.js"></script>
    <script src="Scripts/jquery.url.js" type="text/javascript"></script>
    <script src="Scripts/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="Scripts/jquery.signalR-1.1.1.min.js"></script>
    <script src="signalr/hubs"></script>
    <script type="text/javascript">
        function send_message() {
            //alert($(that).attr("refid"));
            var textarea = $("#textarea");
            if (textarea.val() == "") {
                return;
            }
            var to = $("#target").val();
            chat.server.sendMessageSever(to, textarea.val());
            append_clientMessage(textarea.val(), getClientTime());
            textarea.val("");
        }
        // JScript source code
        Date.prototype.format = function (format) {
            var o = {
                "M+": this.getMonth() + 1, //month 
                "d+": this.getDate(), //day 
                "h+": this.getHours(), //hour 
                "m+": this.getMinutes(), //minute 
                "s+": this.getSeconds(), //second 
                "q+": Math.floor((this.getMonth() + 3) / 3), //quarter 
                "S": this.getMilliseconds() //millisecond 
            }

            if (/(y+)/.test(format)) {
                format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
            }

            for (var k in o) {
                if (new RegExp("(" + k + ")").test(format)) {
                    format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
                }
            }
            return format;
        }

        function getClientTime() {
            var now = new Date();
            var nowStr = now.format("yyyy-MM-dd hh:mm:ss");
            return nowStr;
        }

        function append_serverMessage(mes, time) {
            var html = "<div class='server'>" +
                "<h2><span class='header'><b class='nick'>" + $("#uname").val() + "</b> <b class='time'>" + time +
                "</b></span><a class='avatar'><img src='image/server.png'></a></h2>" +
                "<div class='content'>" + mes + "</div></div>";
            $("#dycontent").append(html);
            $("#dycontent").getNiceScroll().resize();
            $('#dycontent').animate({ scrollTop: $('#dycontent')[0].scrollHeight }, 1000);
        }
        function append_clientMessage(mes, time) {
            var html = "<div class='client J-client-chat' style='padding-bottom: 12px'>" +
                "<h2><span class='header'>" + time + " 我</span><a class='avatar'>" +
                "<img src='http://tfsimg.alipay.com/images/partner/T1IVXXXb0bXXXXXXXX'></a></h2>" +
                "<div class='content J-chat-content'>" + mes + "</div></div>";
            $("#dycontent").append(html);
            $("#dycontent").getNiceScroll().resize();
            $('#dycontent').animate({ scrollTop: $('#dycontent')[0].scrollHeight }, 1000);

        }

        function append_message(mes, time) {
            $("#dycontent").append("<div class='item'><div class='title'>" + time + "</div><div class='info'>" + mes + "</div></div>");
        }
        var userID = "";
        var chat = $.connection.codingChatHub;
        $(function () {

            $("#textarea").keyup(function (event) {

                $("#leftvalue").html(200 - $("#textarea").val().length);

            });
            $("#textarea").keydown(function (event) {
                if (event.keyCode == 13) {
                    document.getElementById("btnsend").click();
                    return false;
                }


            });

            if ($.url.param('name') != "" && $.url.param('name') != undefined) {
                $("#uname").val($.url.param('name'));
                $("#userinfo").html($.url.param('name'));
            }
            $("#dycontent").niceScroll({
                touchbehavior: false,
                cursorcolor: "#7C7C7C",
                cursoropacitymax: 0.6,
                cursoropacitymin: 0.3,
                cursorwidth: 5
            });
            while (userID.length == 0) {

                userID = $("#uid").val();
            }
            // $("#userName").append(userID).show();
            chat.client.sendMessage = function (message, time) {
                //time = $("#target").val() + time;
                append_serverMessage(message, time);

                //                $("#dycontent").append("<div class='item'><div class='title'>" + time + "</div><div class='info'>" + message + "</div></div>");
            }
            //建立與Server端的Hub的物件，注意Hub的開頭字母一定要為小寫
            //chat = $.connection.codingChatHub;
            //將連線打開
            $.connection.hub.start().done(function () {
                //當連線完成後，呼叫Server端的userConnected方法，並傳送使用者姓名給Server
                chat.server.userConnected(userID);
                //chat.server.sendMessageConnect($("#target").val(), "您好 有人要有请求是否应答？");
            });
        });

        function requestData(that) {
            var res = $(that).attr("req");
            append_serverMessage(res, getClientTime());

        }
    </script>
</head>
<body>
    <input id='target' runat="server" type="hidden" />
    <input id='uid' runat="server" type="hidden" />
    <input id='uname' runat="server" type="hidden" />
    <div id="dyhead">
        <span id="robotLogo" style="float: left; margin-right: 10px; margin-left: 10px; margin-top: 5px;
            display: inline;">
            <img src="logo.png" width="50" height="45" alt="智能客服">
        </span>
        <ul style='margin-left: 10px;'>
            <li>福彩在线</li>
            <li>在线客服，您全天候的好伙伴^_^</li>
        </ul>
    </div>
    <div id="right">
        <!-- menu_1 -->
        <div id="mjr_menu_1" class="mjr_menu" style="right: 1px; font-family: 微软雅黑; font-size: 14px;
            border-bottom: 1px solid #ddd;">
            对方名片</div>
        <div id="mjr_menu_1_content" class="mjr_menu_content" opened="true" style="display: block;">
            <!-- 展示渠道 -->
            <ul id="firstchannel">
                <li class='sign'>
                    <dl>
                        客服：<span id='userinfo' runat="server"></span>
                    </dl>
                </li>
                <li>
                    <div class='wrap'>
                        <span class='bold'>客服热线：96677</span>
                        <br>
                        <a style="display: block; line-height: 20px; color: black;">自动查询：7×24小时声讯服务</a>
                        <a style="display: block; line-height: 20px; color: black;">人工服务时间：8:30——11:30</a>
                        <a style="display: block; line-height: 20px; color: black;">13:00——17:00</a> <a style="display: block;
                            line-height: 20px; color: black;">网址：www.sdcp.cn</a>
                    </div>
                </li>
                <li>
                    <div class='wrap'>
                        <span class='bold'>常见问题：</span><br>
                        <div id='commonQues' runat="server">
                        </div>
                    </div>
                </li>
                <img src='image/chat_logo2.png' style='position: absolute; top: 5px; right: 5px;
                    height: 45px; width: 100px;' />
            </ul>
        </div>
        <div class="inform">
        </div>
    </div>
    <div id="left">
        <div id="dycontent" style="">
            <div class="server">
                <h2>
                    <span class="header"><b class="nick">在线助手</b> <b class="time">00:56</b></span><a
                        class="avatar"><img src="image/server.png"></a></h2>
                <div class="content">
                    <div class="J-welcome">
                        <div>
                            您好！请问有什么可以帮您？</div>
                        <br>
                        很抱歉，人工客服服务时间：9:00--24:00，您可以通过在线助手或拨打我们的24小时服务热线95188进行咨询。</div>
                    <div class="J-login-trigger-container">
                        为了更好地解决您的问题，建议您<a href="javascript:void(0)" class="J-login-trigger" seed="PCportal_self_login">登录</a></div>
                </div>
            </div>
            <div class="client J-client-chat" style="padding-bottom: 12px">
                <h2>
                    <span class="header">01:18 我</span><a class="avatar"><img src="http://tfsimg.alipay.com/images/partner/T1IVXXXb0bXXXXXXXX"></a></h2>
                <div class="content J-chat-content">
                    124124</div>
            </div>
        </div>
        <div class="menubar">
        </div>
        <div class='inputobx'>
            <div id='input-field'>
                <textarea id='textarea'></textarea></div>
            <p class="tips">
                [发送快捷键:Enter]:您还可以输入 <span class="J-left" id='leftvalue'>200</span>个字</p>
            <input type="button" id='btnsend' onclick='send_message();' class="submit" id="main-submit-btn"
                value="发送信息">
        </div>
    </div>
</body>
</html>
