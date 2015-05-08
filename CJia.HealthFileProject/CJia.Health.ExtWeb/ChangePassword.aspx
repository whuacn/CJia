<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="CJia.Health.ExtWeb.ChangePassword" %>
<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>病案借阅申请系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../Css/main.css" />
</head>
<body>
    <form id="form_Main" runat="server">
    <ext:PageManager ID="pm_Main" AutoSizePanelID="pnl_Main" runat="server" />
    <ext:Panel ID="pnl_Main" runat="server" Layout="Fit" ShowBorder="False"
        ShowHeader="false" BodyPadding="5px" EnableBackgroundColor="true">
        <Items>
            <ext:SimpleForm LabelWidth="75px" ID="sf_Main" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                AutoScroll="true" BodyPadding="10px"  runat="server" EnableCollapse="True">
                <Items>
                    <ext:TextBox ID="txt_OldPasswdD" runat="server" Label="旧的密码"
                        Text="" MaxLength="20" TextMode="Password" NextFocusControl="txt_NewPasswdD" Required="true"></ext:TextBox>
                    <ext:TextBox ID="txt_NewPasswdD" runat="server" Label="新的密码"
                        Text="" MaxLength="20" TextMode="Password" NextFocusControl="txt_ConfirmPasswdD" Required="true"></ext:TextBox>
                    <ext:TextBox ID="txt_ConfirmPasswdD" runat="server" Label="确认密码"
                        Text="" MaxLength="20" TextMode="Password" NextFocusControl="btn_Submit" Required="true" CompareControl="txt_NewPasswdD"
                        CompareOperator="Equal" CompareMessage="新密码必须与确认密码相同！"></ext:TextBox>
                    <ext:Button ID="btn_Submit" ValidateForms="sf_Main" CssClass="btn_center" Text="确定修改" runat="server" OnClick="btn_Submit_Click">
                    </ext:Button>
                </Items>
            </ext:SimpleForm>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
