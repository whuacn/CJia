<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditDept.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.EditDept" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Link1" />
    <link rel="stylesheet" type="text/css" href="../../Css/main.css" />
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
                        <ext:TextBox ID="txt_Dept_Name" AutoPostBack="true" ShowRedStar="true" runat="server" Label="科室名称" MaxLength="100" Required="True"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:DropDownList ID="ddl_Parent_Dept" AutoPostBack="true" runat="server" Label="上级科室" ShowRedStar="true"></ext:DropDownList>
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
