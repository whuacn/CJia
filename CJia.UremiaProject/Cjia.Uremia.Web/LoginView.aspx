<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="CJia.Uremia.Web.LoginView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>卫生监督系统 用户登录</title>
    <script src="Js/jquery-1.8.0.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Css/register.css" />
    <script type="text/javascript">
        function getimgcode() {
            var randomnum = Math.random();
            var getimagecode = document.getElementById("getcode");
            getimagecode.src = "CheckCode.aspx?" + randomnum;
        }
    </script>
</head>
<body>
    <form class="signup_form_form" runat="server" id="signup_form" method="post" action="" data-secure-action="" data-secure-ajax-action="">
        <div class='signup_container'>
            <h1 class='signup_title'>卫生监督系统</h1>
            <img src='images/people.png' id='admin' />
            <div id="signup_forms" class="signup_forms clearfix">
                <div class="form_row first_row">
                    <label for="signup_email">请输入用户名</label>
                    <input runat="server" type="text" name="user[email]" placeholder="请输入用户名" id="signup_name" data-required="required" />
                </div>
                <div class="form_row">
                    <label for="signup_password">请输入密码</label>
                    <asp:TextBox ID="signup_password" placeholder="请输入密码" runat="server" TextMode="Password" Text="1234"></asp:TextBox>
                </div>
               <%-- <div class="form_row">
                    <label for="signup_code">请输入验证码</label>
                    <input runat="server" type="text" name="user[password]" placeholder="请输入验证码" id="signup_code" data-required="required" />
                    <img id="getcode" title="点击更换" alt="" src="CheckCode.aspx" onclick="getimgcode();" />
                    <span runat="server" id="esg">验证码错误</span>
                </div>--%>
            </div>
            <div class="login-btn-set">
                <div class='rem' runat="server" id="rembMe">记住我</div>
                <input id="yijizhu" type="hidden" runat="server" />
                <asp:Button ID="btnLogin1" class='login-btn' OnClick="Login_Click" runat="server" Text="" />
            </div>
            <p class='copyright'>版权所有 江西电信</p>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
<script type="text/javascript">

    $(function () {
        $('#signup_name').focus();

        $('.rem').click(function () {
            var v = $('#yijizhu').val();
            $(this).toggleClass('selected');
            if (v == '') {
                $('#yijizhu').val('HaveRemberMe');
            }
            else {
                $('#yijizhu').val('');
            }
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
