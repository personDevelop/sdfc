<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientnew.aspx.cs" Inherits="SignalR.clientnew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gbk" />
    <title>网页样式</title> <link rel="stylesheet" type="text/css" href="css/chat.css"/>
    <script src="/Scripts/jquery-1.6.4.min.js"></script>
    <script src="/Scripts/jquery.signalR-1.1.1.min.js"></script>
    <script src="/signalr/hubs"></script>

    <script type="text/javascript">

        function send_message() {
            //alert($(that).attr("refid"));
            var textarea = $("#textarea");
            append_message(textarea.val(),  "我:2014-09-04 11:12:00");
            var to = $("#target").val();
            chat.server.sendMessageSever(to, textarea.val());
            textarea.val("");
        }

        function append_message(mes, time) {
            $("#dycontent").append("<div class='item'><div class='title'>" + time + "</div><div class='info'>" + mes + "</div></div>");
        }
        var userID = "";
        var chat = $.connection.codingChatHub;
        $(function () {
            while (userID.length == 0) {

                userID = $("#uid").val();
            }
            // $("#userName").append(userID).show();
            chat.client.sendMessage = function (message, time) {
                time = $("#target").val() + time;
                $("#dycontent").append("<div class='item'><div class='title'>" + time + "</div><div class='info'>" + message + "</div></div>");
            }
            //建立與Server端的Hub的物件，注意Hub的開頭字母一定要為小寫
            //chat = $.connection.codingChatHub;
            //將連線打開
            $.connection.hub.start().done(function () {
                //當連線完成後，呼叫Server端的userConnected方法，並傳送使用者姓名給Server
                chat.server.userConnected(userID);
                chat.server.sendMessageConnect($("#target").val(), "您好 有人要有请求是否应答？");
            });
        });
    </script>
    <style type="text/css">
        body, ul, li, div, span, p, h1, h2, table
        {
            margin: 0;
            padding: 0;
            font-size: 12px;
            font-family: Arial, "宋体";
        }
        div,p,li{margin:0;padding:0;}
.jcTab { width:100%; height:100%;}
.chat_wrap{background:rgb(252, 252, 252);}
.chat_content{
	height: 300px;
	background: rgb(252, 252, 252);
	padding:20px;
	overflow:auto;
}

.chat_seperator{height:1px;background:#eee;}

.content{border:1px solid rgb(219, 219, 219);width:98%;margin-left:5px;margin-top:8px;height:80px;outline:none;}
.btn{float:right;right:6px;position:absolute;bottom:8px;}
.reply{background: #fff;
font-size: 12px;
font-family: 微软雅黑;
padding: 5px;
border: 1px solid #8DB2E3;}
.reject{color:red;margin-left:5px;}
.item{margin: 8px 0px;}
        li
        {
            list-style: none;
        }
        #dyhead
        {
            background: #bf0000;
            height: 54px;
            z-index: 100;
            border: 1px solid #d1d1d1;
        }
        #dyhead ul
        {
            color: #fff;
            margin-left: 55px;
            margin-top: 5px;
        }
        #dyhead li
        {
            line-height: 20px;
        }
        #right
        {
            float: right;
            width: 200px;
            background: #fff;
            border: 1px solid #d1d1d1;
            border-top: 0;
            height: 100%;
            overflow: hidden;
            display: inline;
            margin-top: 0px;
            height: 500px;
        }
        #mjr_suo
        {
            float: right;
            width: 10px;
            overflow: hidden;
            height: 100%;
            padding-top: 2000px;
            margin-right: -1px;
            _margin-left: -2px;
        }
        #left
        {
            margin-right: 212px !important;
            margin-right: 208px;
            height: 100%;
        }
        
        .inputobx
        {
            height: 110px;
            border: 1px solid #d1d1d1;
            border-top: 0;
        }
        .menubar
        {
            height: 32px;
            line-height: 10px;
            position: relative;
            z-index: 66667;
            border: 1px solid #d1d1d1;
            border-top: 0;
        }
        #toolsbar
        {
            position: relative;
            height: 20px;
            top: 7px;
            z-index: 66668;
            margin-left: 20px;
            _margin-left: 10px;
        }
        #toolsbar li
        {
            height: 20px;
            width: 21px;
            background-image: url(http://test.live800.com/test1/chatClient/version5/style/theme/userColor/images/tools1.png);
            float: left;
            background-repeat: no-repeat;
            list-style: none;
            margin-right: 20px;
            cursor: pointer;
            text-align: left;
        }
        #activex
        {
            background-position: 0 -20px;
        }
        #file
        {
            background-position: 0 -148px;
        }
        #emotion
        {
            background-position: 0 -41px;
        }
        #callback
        {
            background-position: 0 -63px;
        }
        #switch
        {
            background-position: 0 -83px;
        }
        #evaluation
        {
            background-position: 0 -105px;
        }
        #msn
        {
            background-position: 0px -212px;
        }
        .mjr_menu_content
        {
            color: #FF6600;
            line-height: 14px;
        }
        #firstchannel li
        {
            background: url(../images/r_ico1.gif) 0 3px no-repeat transparent;
            margin-left: 10px;
            padding-left: 10px;
            margin-top: 10px;
            line-height: 16px;
        }
        .mjr_menu
        {
            color: #006e9c;
            background: url(../images/menu_bg.gif) repeat-x;
            line-height: 28px;
            font-weight: bold;
            background: #eee;
            height: 28px;
            cursor: pointer;
            z-index: 200;
            text-indent: 80px;
        }
        .title,.info
{
    margin-bottom: 7px;
font-size: 14px;
font-family: 微软雅黑;}
    </style>
</head>
<body>
<input id='target' runat=server type=hidden />
<input id='uid' runat=server  type=hidden/>
    <div id="dyhead">
        <span id="robotLogo" style="float: left; margin-left: 10px; margin-top: 5px; display: inline;">
            <img src="logo.png" width="35" height="35" alt="智能客服">
        </span>
        <ul>
            <li>福彩智能客服</li>
            <li>在线智能客服，您全天候的好伙伴^_^</li>
        </ul>
        <img src='logo.gif' style='position: absolute; top: 5px; right: 5px; height: 45px;' />
    </div>
    <div id="right">
        <!-- menu_1 -->
        <div id="mjr_menu_1" class="mjr_menu" style="right: 1px;">
            对方名片</div>
        <div id="mjr_menu_1_content" class="mjr_menu_content" opened="true" style="display: block;">
            <!-- 展示渠道 -->
            <ul id="firstchannel">
                <li>
                    <div>
                        客服热线：96677<br>
                        <a style="display: block; line-height: 20px;" href="#">自动查询：7×24小时声讯服务</a> <a style="display: block;
                            line-height: 20px;" href="#">人工服务时间：8:30——11:30</a> <a style="display: block; line-height: 20px;"
                                href="#">13:00——17:00</a> <a style="display: block; line-height: 20px;" href="#">网址：www.sdcp.cn</a> 
                    </div>
                </li>
                <li>
                    <div>
                        客服工号：<br>
                        <a style="display: block; line-height: 20px;" href="http://www.net.cn/service/faq/huiyuan/hyzc/201409/6495.html?spm=0.0.0.0.FymXuA"
                            target="_blank">威海：小王</a> <a style="display: block; line-height: 20px;" href="http://www.net.cn/service/faq/huiyuan/passwd/201211/5720.html?spm=0.0.0.0.fip5MH"
                                target="_blank">网址:www.sdcp.cn</a> <a style="display: block; line-height: 20px;" href="http://www.net.cn/service/faq/huiyuan/cpgl/201409/6497.html?spm=0.0.0.0.9j4THB">
                                    如何进行在线咨询</a></div>
                </li>
            </ul>
        </div>
        <div class="inform">
            <p>
            </p>
        </div>
    </div>
    <div id="mjr_suo" style="padding-top: 194px;">
        <a href="#" onclick="MJR.togChannel();return false;">&nbsp;</a></div>
    <div id="left">
        <div id="dycontent" class='chat_content'  style="overflow-x: hidden; overflow-y: auto; border-width: 0px 1px 1px;
            border-right-style: solid; border-bottom-style: solid; border-left-style: solid;
            border-right-color: #d1d1d1; border-bottom-color: #d1d1d1; border-left-color: #d1d1d1;
            height: 356px; background-color: rgb(255, 255, 255);">
        </div>
        <div class="menubar">
            <ul id="toolsbar">
                <li id="save" class="" title="保存记录"></li>
                <li id="activex" lim:status="show" class="" title="截 屏"></li>
                <li id="file" lim:status="show" class="" title="传送文件"></li>
                <li id="emotion" class="" onclick="return false;" style="" title="表情"></li>
                <li id="callback" style="display: none" lim:status="disabled" title="免费电话" class="disabled">
                </li>
                <li id="switch" class="open" title="关闭提示音"></li>
                <li id="evaluation" class="" title="客服评分"></li>
                <li id="msn" style="display: none;" account="" title="添加MSN服务号为好友" class=""></li>
                <li id="qq" style="display: none;" account="" title="添加QQ服务号为好友" class=""></li>
                <li id="language" style="" class="" title="语言选择"></li>
                <li id="jumper" style="display: none;" title="人工服务" class="">
                    <label style="width: 120px; white-space: nowrap;">
                        人工服务</label></li>
            </ul>
        </div>
        <div class='inputobx'>
            <textarea id='textarea' style='outline:none;border: 0;width:99%;height:60px;'></textarea>
            <input type=button  onclick='send_message();' style='float:right;border:1px solid #eee;background:#fff;padding:5px 10px;margin-top:5px;margin-right:5px;' value='发送' />
        </div>
        <div>
        </div>
    </div>
</body>
</html>
