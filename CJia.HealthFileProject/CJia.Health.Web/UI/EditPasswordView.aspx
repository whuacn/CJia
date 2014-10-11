<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPasswordView.aspx.cs" Inherits="CJia.Health.Web.UI.EditPasswordView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Js/Main.js"></script>
    <script type="text/javascript">
        //加载页面要使用的CSS
        loadCss(top._skinId, 'Page.css');
    </script>
    <script type="text/javascript">
        function ClientValidate(source, arguments) {
            if (arguments.Value.length < 4)
                arguments.IsValid = false;
            else
                arguments.IsValid = true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" style="text-align: left; font-family: 宋体; font-size: 18px;">
                <tr style="height: 30px">
                    <td colspan="5"></td>
                </tr>
                <tr style="height: 40px">
                    <td></td>
                    <td style="width: 100px; text-align: right;">原密码:</td>
                    <td style="width: 180px;">
                        <asp:TextBox ID="txtOldPassword" runat="server" Width="180px" TextMode="Password"></asp:TextBox></td>
                    <td style="width: 250px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="输入不能为空"
                            ForeColor="Red" ControlToValidate="txtOldPassword" Display="Dynamic"></asp:RequiredFieldValidator>&nbsp;
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
                    <td></td>
                </tr>
                <tr style="height: 40px">
                    <td></td>
                    <td style="width: 100px; text-align: right;">新密码:</td>
                    <td style="width: 180px;">
                        <asp:TextBox ID="txtPassword" runat="server" Width="180px" TextMode="Password"></asp:TextBox></td>
                    <td style="width: 250px;">
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ClientValidate"
                            ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="密码必须不小于4位" ForeColor="Red"
                            OnServerValidate="Server_Validate"></asp:CustomValidator></td>
                    <td></td>
                </tr>
                <tr style="height: 40px">
                    <td></td>
                    <td style="width: 100px; text-align: right;">确认密码:</td>
                    <td style="width: 180px;">
                        <asp:TextBox ID="txtTrePassword" runat="server" Width="180px" TextMode="Password"></asp:TextBox></td>
                    <td style="width: 250px;">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="输入不一致"
                            ControlToCompare="txtPassword" ControlToValidate="txtTrePassword" ForeColor="Red"></asp:CompareValidator></td>
                    <td></td>
                </tr>
                <tr style="height: 40px">
                    <td></td>
                    <td style="width: 100px; text-align: right;"></td>
                    <td colspan="2">
                        <asp:Button ID="btnResert" runat="server" Text="重置" Width="70px" CausesValidation="False" OnClick="btnResert_Click" />&nbsp;
                        <asp:Button ID="btnSave" runat="server" Text="保存" Width="70px" OnClick="btnSave_Click" />
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
