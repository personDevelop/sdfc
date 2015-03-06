<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="client.aspx.cs" Inherits="SignalR.client" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网页用户咨询界面</title>
    <!-- link href="css/core.css" rel="stylesheet" type="text/css"/ -->
    <link href="css/TabPanel.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.6.4.min.js"></script>
    <script src="/Scripts/jquery.signalR-1.1.1.min.js"></script>
    <script src="/signalr/hubs"></script>
    <script type="text/javascript" src="src/Plugins/Fader.js"></script>
    <script type="text/javascript" src="src/Plugins/TabPanel.js"></script>
    <script type="text/javascript" src="src/Plugins/Math.uuid.js"></script>
    <script type="text/javascript">
        var tabpanel;
        var jcTabs = "<div class='chat_wrap'><div class='chat_content' id='content_id'></div><div class='chat_seperator'></div><div class='chat_input'><textarea class='content'></textarea><input class='btn' type='button' refid='content_id' value='发送' onclick='send_message(this);'></input></div></div>";
        $(document).ready(function () {
            tabpanel = new TabPanel({
                renderTo: 'tab',
                width: 800,
                height: 500,
                //border:'none',  
                active: 0,
                //maxLength : 10,  
                items: [
                    { id: 'main', title: '首页', html: jcTabs, closable: false }
                ]
            });
        });
        function append_message(mes, id, time) {
            $("#" + id).append("<div class='item'><div class='title'>" + time + "</div><div class='info'>" + mes + "</div></div>");
        }

        function send_message(that) {
            //alert($(that).attr("refid"));
            var textarea = $(that).parent().find("textarea");
            append_message(textarea.val(), $(that).attr("refid"), "我:2014-09-04 11:12:00");
            var to = $("#target").val();
            chat.server.sendMessageSever(to, textarea.val());
            textarea.val("");
        }
    </script>
    <script type="text/javascript">
        var userID = "";
        var chat = $.connection.codingChatHub;
        $(function () {
            while (userID.length == 0) {

                userID = $("#uid").val();
            }
            // $("#userName").append(userID).show();
            chat.client.sendMessage = function (message, time) {
                time = $("#target").val() + time;
                $(".chat_content").append("<div class='item'><div class='title'>" + time + "</div><div class='info'>" + message + "</div></div>");
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
</head>
<body>
    <form id="form1" runat="server">
    <input id='target' type="hidden" runat="server" />
    <input id='uid' type="hidden" runat="server" />
    <div id="tab">
    </div>
    </form>
</body>
</html>
