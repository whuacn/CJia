<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.EditUser" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <style type="text/css">
        .titleColor {
            color: gray;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server" />
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
            AutoScroll="true" LabelWidth="85px" BodyPadding="25px 15px" runat="server" EnableCollapse="True">
            <Rows>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_UserCode" AutoPostBack="true" ShowRedStar="true" runat="server" Label="用户代码" MaxLength="100" Text="" Required="True" Readonly="true"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_UserName" AutoPostBack="true" ShowRedStar="true" runat="server" Label="用户名称" MaxLength="100" Text="" Required="True"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="0% 100%">
                    <Items>
                        <%--<ext:TextBox ID="txt_PWD" AutoPostBack="true" ShowRedStar="true" runat="server" Label="用户密码" MaxLength="100" Text="8888" Required="True" Readonly="true"></ext:TextBox>--%>
                        <ext:Label runat="server" Label="用户密码" ></ext:Label>
                        <%--<ext:Button ID="btn_RePwd" " Text="重置密码"  runat="server" ValidateForms="sf_Edit" Icon="TextRuler" ></ext:Button>--%>
                        <ext:Button ID="btn_RePwd" runat="server" ConfirmText="是否重置密码？" Text="重置密码" OnClick="btn_RePwd_Click"></ext:Button>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:DropDownList ID="ddl_Dept" AutoPostBack="true" runat="server" Label="科室" ShowRedStar="true">
                            </ext:DropDownList>
                    </Items>
                </ext:FormRow>
            </Rows>
            <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btn_Save" ConfirmText="确定保存？" Text="保存" ValidateForms="sf_Edit" runat="server" Icon="TextRuler" OnClick="btn_Save_Click"></ext:Button>
                        <ext:Label ID="Label3" runat="server" Width="5" Text=""></ext:Label>
                        <ext:Button ID="btn_Cancle" Icon="Cancel" runat="server" Text=" 取消 " OnClick="btn_Cancle_Click"></ext:Button>
                        <ext:Label ID="Label4" runat="server" Width="5" Text=""></ext:Label>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    </form>
</body>
</html>
