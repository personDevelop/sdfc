<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="severPage.aspx.cs" Inherits="SignalR.severPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gbk" />
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <%-- 引用 jQuery 的參考--%>
    <script src="/Scripts/jquery-1.6.4.min.js"></script>
    <%--引用 SignalR 的參考--%>
    <script src="/Scripts/jquery.signalR-1.1.1.min.js"></script>
    <%--這邊滿重要的，這個參考是動態產生的，當我們build之後才會動態建立這個資料夾，且需引用在jQuery和signalR之後--%>
    <script src="/signalr/hubs"></script>
    <title>表单测试</title>
    <style>
        body, p, div, td, ul, li
        {
            padding: 0;
            margin: 0;
            font-family: 微软雅黑;
            font-size: 14px;
        }
        a
        {
            color: blue;
            text-decoration: none;
        }
        .head
        {
            background: #F9F9F9;
        }
        .userlst
        {
            border-bottom: 1px solid #eee;
        }
        .userlst td
        {
            border-spacing: 0;
            border-top: 1px solid #eee;
            padding: 5px;
        }
        .userlst
        {
            border-spacing: 0;
        }
        .userlst tr:hover
        {
            background: #eee;
        }
        ul, li
        {
            list-style: none;
        }
        .itab ul li a
        {
            font-size: 14px;
            color: #000;
            padding-left: 15px;
            padding-right: 15px;
        }
        .itab
        {
            height: 36px;
            border-bottom: solid 1px #eee;
            position: relative;
            border-left: solid 1px #eee;
        }
        .itab ul .checked
        {
            border-top: 2px solid rgb(133, 181, 255);
            height: 35px;
            background: #fff;
            font-weight: bold;
        }
        .itab ul li
        {
            float: left;
            height: 35px;
            line-height: 37px;
            border-right: solid 1px #eee;
            border-top: solid 1px #eee;
            background: #FAFAFA;
        }
        .chat_wrap
        {
            border: 1px solid #C8C8C8;
        }
        .content
        {
            height: 200px;
            overflow:auto;
            background: #FAFAFA;
            border-bottom: 1px solid #E4E4E4;
        }
        
        textarea
        {
            border: medium none;
            display: block;
            width: 552px;
            height: 96px;
            overflow-y: auto;
            padding: 5px;
            resize: vertical;
        }
        .buttonbar
        {
            background: #FAFAFA;
            padding: 10px 0;
            overflow: auto;
            border-top: 1px solid #E4E4E4;
        }
        
        .notice
        {
            background: rgb(255, 199, 97);
        }
    </style>
<script type="text/javascript">
    var userID = "";
    var chat = $.connection.codingChatHub;
    $(function () {
        while (userID.length == 0) {
            userID = window.prompt("請輸入使用者名稱");
            if (!userID)
                userID = "";
        }
        // $("#userName").append(userID).show();

        //建立與Server端的Hub的物件，注意Hub的開頭字母一定要為小寫


        //取得所有上線清單
        chat.client.getList = function (userList) {
            var li = "";
            $.each(userList, function (index, data) {

                li += "<li id='" + data.id + "'><label class='online'></label><a href='javascript:;'><img src='img/head/2013.jpg'></a><a href='javascript:;' class='chat03_name'>" + data.name + "</a></li>";
                //li += "<li id='" + data.id + "'>" + data.name + "</li>";
            });
            $("#list").html(li);
        }
        //新增一筆上線人員
        chat.client.addList = function (id, name) {

            var li = "<li id='" + id + "'><label class='online'></label><a href='javascript:;'><img src='img/head/2013.jpg'></a><a href='javascript:;' class='chat03_name'>" + name + "</a></li>";

            //var li = "<li id='" + id + "'>" + name + "</li>";
            $("#list").append(li);
        }
        //移除一筆上線人員
        chat.client.removeList = function (id) {
            $("#" + id).remove();
        }

        //全體聊天
        chat.client.sendAllMessge = function (message) {
            $("#messageList").append("<li>" + message + "</li>");
        }

        //密語聊天
        chat.client.sendMessage = function (message, uid) {
            alert(uid);
            //alert(message);
            $("#messageList").append("<li>" + message + "</li>");
        }

        chat.client.Connect = function (message, fromid) {
            alert(message + "--" + fromid);

            if (confirm(message)) {
                $(document.body).append("<div class='chat_wrap'>" +
                "<div class='content' id='messageList'>" +
               " </div>" +
                "<div class=''>" +
                    "<textarea class='message'></textarea>" +
               " </div>" +
                "<div class='buttonbar'>" +
                    "<input type='button' onclick='sendData(this);' userid='" + fromid + "'  value='发送' style='float: right; margin-right: 10px;' />" +
                "</div>" +
           " </div>");
            }
        }

        //加入聊天室
        chat.client.hello = function (message) {
            //$("#messageList").append("<li>" + message + "</li");
        }

        //將連線打開
        $.connection.hub.start().done(function () {
            //當連線完成後，呼叫Server端的userConnected方法，並傳送使用者姓名給Server
            chat.server.userConnected(userID);
        }); ;

        function InitChat() {

        }

        $("#send").click(function () {
            var to = "all";
            //當to為all代表全體聊天，否則為私密聊天
            if (to == "all") {
                chat.server.sendAllMessage($("#message").val());
            } else {
                chat.server.sendMessage(to, $("#message").val());
            }
            $("#message").val('');
        });

    });

    //每个聊天窗口的聊天方法
    function sendData(that) {
        //alert($(that).attr("userid"));
        var to = $(that).attr("userid");
        var textarea = $(that).parent().parent().find(".message");
        //alert(textarea.val());
        chat.server.sendMessage(to, textarea.val());
        textarea.val('');
    }
    </script>
    
</head>
<body>
    <div style='width: 800px; margin-left: 10px; margin-top: 10px;'>
        <div class="itab" style="margin-bottom: 10px;">
            <ul>
                <li class='checked'><a href="#tab1" class="selected">匿名用户：山东联通</a></li>
                <li><a href="#tab1" class="selected">匿名用户：广西联通</a></li>
            </ul>
        </div>
        <div class='chat_wrap'>
            <div class='content' id='messageList'>
            </div>
            <div class=''>
                <textarea id='message'></textarea>
            </div>
            <div class='buttonbar'>
                <input type="button" id='send'  value='发送' style='float: right; margin-right: 10px;' />
            </div>
        </div>
    </div>
</body>
</html>
