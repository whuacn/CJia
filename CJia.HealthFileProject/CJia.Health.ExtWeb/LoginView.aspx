<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="CJia.Health.ExtWeb.LoginView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>病案借阅系统 用户登录</title>
    <script src="js/jquery-1.8.0.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Css/register.css" />
    <script type="text/ecmascript">
        function getWH() {
            var width = document.body.clientWidth;
            var heigh = document.body.scrollHeight;
            $('#winW').val(width);
            $('#winH').val($(document).height());
        };
    </script>
</head>
<body>
    <div id="Div1" class='signup_container' runat="server">
        <h1 class='signup_title'>病案借阅系统</h1>
        <img src='images/people.png' id='admin' />
        <form class="signup_form_form" id="signup_form" runat="server" method="post" data-secure-action="" data-secure-ajax-action="">
            <input id="winW" type="hidden" name="winW" runat="server" />
            <input id="winH" type="hidden" name="winH" runat="server" />
            <div id="signup_forms" class="signup_forms clearfix">
                <%--<form class="signup_form_form" id="signup_form" method="post" data-secure-action="" data-secure-ajax-action="">--%>
                <div class="form_row first_row">
                    <label for="signup_email">请输入用户名</label><%--<div class='tip ok' ></div>--%>
                    <input runat="server" type="text" name="user[email]" placeholder="请输入用户名" id="signup_name" data-required="required" />
                </div>
                <div class="form_row">
                    <label for="signup_password">请输入密码</label><%--<div  class='tip error'></div>--%>
                    <input runat="server" type="password" name="user[password]" placeholder="请输入密码" id="signup_password" data-required="required" />
                </div>
                <%--</form>--%>
            </div>
            <div class="login-btn-set">
                <center><%--<asp:LinkButton ID="btnLogin" runat="server" class='login-btn' OnClick="Login_Click"></asp:LinkButton>--%><%--</center>--%>
                <asp:Button ID="Button1" OnClientClick="getWH();" class='login-btn' runat="server" OnClick="Login_Click" />
                 </center>
            </div>
        </form>
        <p class='copyright'>版权所有 创佳技术有限公司</p>
    </div>
</body>
<script type="text/javascript">

    $(function () {

        $('.rem').click(function () {
            $(this).toggleClass('selected');
        })

        $('#signup_select').click(function () {
            $('.form_row ul').show();
            event.cancelBubble = true;
        })

        $('#d').click(function () {
            $('.form_row ul').toggle();
            event.cancelBubble = true;
        })

        $('body').click(function () {
            $('.form_row ul').hide();
        })

        $('.form_row li').click(function () {
            var v = $(this).text();
            $('#signup_select').val(v);
            $('.form_row ul').hide();
        })
    })
</script>
</html>
