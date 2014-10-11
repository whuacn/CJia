<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="CJia.Evaluation.Web.LoginView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>医院等级评审资料管理系统</title>
    <link href="Css/signin.css" rel="stylesheet" />
    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
        }
    </style>
    <script type="text/javascript">
        function getimgcode() {
            var randomnum = Math.random();
            var getimagecode = document.getElementById("getcode");
            getimagecode.src = "CheckCode.aspx?" + randomnum;
        }
    </script>
</head>
<body style="font-family: 微软雅黑">
    <form id="form1" runat="server">
        <div style="background-color: #007ACC; font-weight: bold; height: 80px; font-size: 30px; color: #ffffff; width: 100%;">
            <table style="height: 100%; width: 100%">
                <tr style="height: 100%; width: 100%">
                    <td style="width: 70px;">
                        <img src="../Images/hsz.png" height="65" width="65" title="" alt="" style="margin-top: 2px;" />
                    </td>
                    <td style="align-content: center; vertical-align: middle; width: 600px;">
                        <label>医院等级评审资料管理系统</label>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div class="signin_box">
            <div class="signin_left">
                <h2 class="signin_title">登录评审系统</h2>
                <div class="signin_in" style="font-size: 12px">
                    <div class="signin_linediv">
                        <label class="userlabel">
                            用户名：</label>
                        <asp:TextBox class="usertext" ID="username" runat="server"></asp:TextBox>
                    </div>
                    <div class="signin_linediv">
                        <label class="userlabel">
                            密&nbsp;&nbsp;码：</label>
                        <asp:TextBox class="usertext" ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="signin_linediv">
                        <label class="userlabel">
                            平&nbsp;&nbsp;台：</label>
                        <asp:DropDownList ID="userType" class="usertext"  runat="server" Font-Names="微软雅黑">
                            <asp:ListItem Value="0">评审资料查阅系统</asp:ListItem>
                             <asp:ListItem Value="1">评审资料管理系统</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="signin_linediv">
                        <label class="userlabel">
                            验证码：</label>
                        <asp:TextBox class="usertext CheckCode" ID="CheckCode" runat="server"></asp:TextBox>
                        <img id="getcode" onclick="getimgcode();" alt="" src="CheckCode.aspx" />
                        <a href="javascript:getimgcode()" style="text-decoration:none">换一张</a>
                    </div>
                    <div class="signin_linediv">
                        <asp:Button ID="login_btn" runat="server" OnClick="login_btn_Click" class="login_btn" /><%--<a
                            href="PasswordRecovery.aspx" class="psdRecovery">忘记密码？</a>--%>
                    </div>
                    <div class="signin_linediv">
                        <asp:Label ID="signin_error" runat="server" class="signin_error"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="signin_right">
                <div class="right_main">
                   <img src='Images/people1.png' id='admin' />
                </div>
            </div>
        </div>
        <div class="C_bottom" style="width: 100%; bottom: 0px; position: fixed;">
            <table style="height: 40px; width: 100%; margin: 0; padding: 0;">
                <tr style="height: 100%; width: 100%; margin: 0; padding: 0;">
                    <td></td>
                    <td style="width: 340px;">
                        <label>Copyright &copy; 2014 All Rights Reserved</label>
                    </td>
                    <td style="width: 260px;">
                        <label>江西慧软医院等级评审资料管理系统</label>
                    </td>
                    <td style="width: 60px;">
                        <label><a href="#">联系我们</a></label>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
