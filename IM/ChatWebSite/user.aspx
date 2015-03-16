<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="SignalR.user" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <script src="Scripts/jquery-1.6.4.min.js"></script>
    <style>
        *
        {
            margin: 0;
            padding: 0;
            font-family: 微软雅黑;
        }
        #chatTitle
        {
            height: 60px;
            width: 100%;
            overflow: hidden;
            position: relative;
        }
        #chatTitle .picbg
        {
            height: 100%;
            width: 100%;
            overflow: hidden;
            clear: none;
            float: left;
            position: relative;
        }
        
        
        #chatTitle .picbg div span
        {
            display: block;
            float: left;
            height: 60px;
            line-height: 60px;
            margin-left: 10px;
            color: #ffffff;
            padding-top: 0px;
            margin-top: 0px;
            overflow: hidden;
            font-size: 22px;
        }
        
        #chatTitle .picbg div span.img
        {
            background: url(image/chat_logo2.png) scroll 50% 50% no-repeat;
        }
        #chatTitle .picbg div span.img
        {
            width: 60px;
            height: 60px;
        }
        .navBar
        {
            height: 51px;
            padding: 9px 20px 20px 20px;
            right: 0;
            top: 0;
            position: absolute;
        }
        .navBar .consultation, .navBar .leavingMessage, .navBar .robot
        {
            width: 146px;
            height: 51px;
            cursor: pointer;
            float: right;
        }
        .navBar .consultation .icon, .navBar .leavingMessage .icon, .navBar .robot .icon
        {
            float: left;
            width: 45px;
            height: 51px;
            background-repeat: no-repeat;
            background-position: 100% 50%;
        }
        .navBar .consultation .word, .navBar .leavingMessage .word, .navBar .robot .word
        {
            float: left;
            width: 96px;
            text-align: center;
            font-size: 18px;
            line-height: 51px;
            font-family: arial, "微软雅黑" , "宋体";
        }
        .navBar .consultation *, .navBar .leavingMessage *, .navBar .robot *
        {
            cursor: pointer;
        }
        .navBar span.word
        {
            color: white;
        }
        .navBar .consultation .icon
        {
            background-image: url(image/zx_b.png);
            _background-image: url(image/lt.gif);
        }
        .navBar .leavingMessage .icon
        {
            background-image: url(image/ly_b.png);
            _background-image: url(image/ly.gif);
        }
        .navBar .robot .icon
        {
            background-image: url(image/zd_b.png);
            _background-image: url(image/yw.gif);
        }
        .navBar .index
        {
            background: url(image/db_bj.gif);
        }
        
        
        .navBar span.index
        {
            color: black;
        }
        .navBar .leavingMessage div.index
        {
            background-image: url(image/ly_h.png);
        }
        .navBar .consultation div.index
        {
            background-image: url(image/zx_h.png);
        }
        .navBar .robot div.index
        {
            background-image: url(image/zd_h.png);
        }
        .main_right
        {
            float: right;
            width: 253px;
            border-left: 1px solid #dadada;
            border-top: none;
            background: #FFF;
            height: 407px;
            position: relative;
            overflow: hidden;
        }
        .cardwrap
        {
            line-height: 32px;
            background: #eee;
            height: 32px;
            cursor: pointer;
            z-index: 200;
            text-align: center;
            font-size: 14px;
            border-bottom: 1px solid #ddd;
        }
        
        .bold
        {
            font-weight: bold;
            color: #FF6600;
        }
        .wrap
        {
            font-size: 12px;
            padding-left: 20px;
        }
        .wrap a
        {
            padding-top: 8px;
        }
        .main_left
        {
            width: 100%;
            margin-left: -254px;
            float: left;
        }
        .free_main p
        {
            line-height: 35px;
        }
        .onlinelist td
        {
            padding: 8px;
        }
        .tabcontent
        {
            margin-left: 254px;
            font-size: 12px;
        }
    </style>
    <script>
        $(function () {
            $(".nav").click(function () {
                if ($(this).hasClass("index")) {
                    return;
                }
                else {
                    $(".nav").removeClass("index");
                    $(".nav").children().removeClass("index");
                    $(this).addClass("index");
                    $(this).children().addClass("index");
                    $(".tabcontent").hide();
                    var id = $(this).attr("id");
                    $("#" + id + "_wrap").show();
                }
            });
        });
    </script>
</head>
<body>
    <div id="chatTitle" style="height: 60px; background: rgb(218, 67, 78);">
        <div class="picbg">
            <div>
                <img src='image/chat_logo2.png' style='float: left; height: 50px; margin: 5px;' /><span>
                    <b id="statusBarPanel">福彩在线</b></span></div>
        </div>
        &nbsp;
        <div class="navBar" style="background: #da434e;">
            <div class="nav robot" id="robot">
                <div class="icon">
                </div>
                <span class="word">
                    <label interpret="自助答疑" complete="n">
                        自助答疑</label></span>
            </div>
            <div class="nav leavingMessage" id="leavingMessage">
                <div class="icon">
                </div>
                <span class="word">
                    <label interpret="我要留言" complete="n">
                        我要留言</label></span>
            </div>
            <div class="nav consultation index" id="consultation" style="display: block;">
                <div class="icon index">
                </div>
                <span class="word index">
                    <label interpret="在线咨询" complete="n">
                        在线咨询</label></span>
            </div>
        </div>
        <div id="ccVersion" style="left: 862px;">
            2.5.0.6331</div>
    </div>
    <div style='zoom: 1;'>
        <div class="main_left" id="main_left" style="overflow: hidden; margin-top: 0px; width: 100%;
            height: 449px;">
            <div class='tabcontent' style='display: none;' id='robot_wrap'>
                <div class="free_explain" style='margin: 20px; color: #989898;'>
                    提示：如需号码查询、福利彩票积分卡积分查询服务，可拨打96677选择1号键，进行自助查询；如需人工服务可拨打96677选择0号键。<br>
                </div>
                <div class="free_main" style='background: #FAFAFA; padding: 25px; border: 1px solid #eee;
                    margin-right: 10px; margin-left: 10px; margin: 10px;'>
                    <p>
                        1、根据您的业务需求，双击选择相应目录下的客服人员。</p>
                    <p>
                        2、如果没有相关客服人员在线，可选择“在线留言”，将您的问题和联系方式留给我们，相关人员会与您取得联系。</p>
                    <p>
                        3、在弹出的聊天窗口的文字输入栏内，输入内容，与客服人员进行业务交流。</p>
                    <p>
                        4、交流完毕后，点击“结束”按钮，结束本次服务，并在弹出的满意度调查窗口中，选择相应的等级，点击“提交”按钮提交。</p>
                </div>
            </div>
            <div class='tabcontent'  id='consultation_wrap'>
                <div class="free_explain" style='line-height: 32px; background: #eee; height: 32px;
                    cursor: pointer; z-index: 200; text-align: center; font-size: 14px; border-bottom: 1px solid #ddd;'>
                    在线客服列表
                </div>
                <div style='margin: 10px; margin: 10px; background: #FCFCFC; border: 1px solid #eee;
                    padding: 10px;' id='userinfo' runat=server>
                    <table class='onlinelist' width="100%">
                        <tr>
                            <td width="55">
                                【德州】
                            </td>
                            <td width="35">
                                <img src='image/chatlist_head_01.png' />
                            </td>
                            <td>
                                <a href='#'>【德州】8765</a>
                            </td>
                        </tr>
                        <tr>
                            <td width="55">
                                【德州】
                            </td>
                            <td width="35">
                                <img src='image/chatlist_head_01.png' />
                            </td>
                            <td>
                                <a href='#'>【德州】8765</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class='tabcontent' style='display: none;' id='leavingMessage_wrap'>
                <div class="free_explain" style='line-height: 32px; background: #eee; height: 32px;
                    cursor: pointer; z-index: 200; text-align: center; font-size: 14px; border-bottom: 1px solid #ddd;'>
                    给我留言
                </div>
                <div style='padding: 10px;'>
                    <table class='onlinelist' style='border: 1px solid #eee; background: #F7F7F7; padding: 10px;'
                        width="100%;">
                        <tr>
                            <td colspan='6'>
                                <textarea rows="10" style='padding: 4px; width: 100%; border: 1px solid #BBB; outline: none;'></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td width="35" align="right">
                                姓名
                            </td>
                            <td>
                                <input type='text' style='padding: 4px; width: 100%; border: 1px solid #BBB; outline: none;' />
                            </td>
                            <td width="35" align="right">
                                电话
                            </td>
                            <td>
                                <input type='text' style='padding: 4px; width: 100%; border: 1px solid #BBB; outline: none;' />
                            </td>
                            <td width="35" align="right">
                                邮箱
                            </td>
                            <td>
                                <input type='text' style='padding: 4px; width: 100%; border: 1px solid #BBB; outline: none;' />
                            </td>
                        </tr>
                        <tr>
                            <td width="35" align="right">
                                地址
                            </td>
                            <td colspan="4">
                                <input type='text' style='padding: 4px; width: 100%; border: 1px solid #BBB; outline: none;' /></textarea>
                            </td>
                            <td>
                                <input type="button" value='提交留言' style='padding: 5px;' />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="main_right" id="main_right" style="">
            <div class='cardwrap'>
                公司名片</div>
            <div style='padding: 18px;'>
                <img src='image/logoin.gif' />
            </div>
            <div class="wrap">
                <span class="bold">客服热线：96677</span>
                <br>
                <a style="display: block; line-height: 20px; color: black;">自动查询：7×24小时声讯服务</a>
                <a style="display: block; line-height: 20px; color: black;">人工服务时间：8:30——11:30</a>
                <a style="display: block; line-height: 20px; color: black;">13:00——17:00</a> <a style="display: block;
                    line-height: 20px; color: black;">网址：www.sdcp.cn</a>
            </div>
        </div>
    </div>
</body>
</html>
