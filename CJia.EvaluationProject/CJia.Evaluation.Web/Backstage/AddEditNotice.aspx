<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditNotice.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.AddNotice" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../../Css/main.css" />
    <script type="text/javascript" src="../ckeditor/ckeditor.js" charset="utf-8"></script>
    <script type="text/javascript" src="../ckfinder/ckfinder.js" charset="utf-8"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
             LabelWidth="100px" runat="server" BodyPadding="10px" EnableCollapse="True" Width="850px" Height="70px">
                <Rows>
                    <ext:FormRow ColumnWidths="70% 30%">
                        <Items>
                            <ext:TextBox ID="txt_Notice_Subject" AutoPostBack="true" ShowRedStar="true" runat="server"  MaxLength="100"  Required="True" Label="公告标题"></ext:TextBox>
                             <ext:DatePicker ID="dt_Notice_Date" ShowRedStar="true" runat="server"  Required="True" Label="截至有效期"></ext:DatePicker>
                     </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="70% 30%">
                        <Items>
                            <ext:TextBox ID="txt_Notice_User" AutoPostBack="true" ShowRedStar="true" runat="server"  MaxLength="100"  Required="True" Label="发布人" Readonly="true"></ext:TextBox>
                            <ext:TextBox ID="txt_Notice_Dept" AutoPostBack="true" ShowRedStar="true" runat="server"  MaxLength="100"  Required="True" Label="发布科室" Readonly="true"></ext:TextBox>
                     </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        <ext:ContentPanel ID="ContentPanel1" runat="server"  BodyPadding="5px"
            EnableBackgroundColor="true" ShowBorder="true" ShowHeader="false" >
        <Items>
            <CKEditor:CKEditorControl ID="ckedit_add" runat="server" Height="210"></CKEditor:CKEditorControl>
        </Items>
    </ext:ContentPanel>
    <ext:Toolbar ID="Toolbar1" Position="Bottom" runat="server">
        <Items>
        <ext:ToolbarFill ID="ToolbarFill1" runat="server"></ext:ToolbarFill>
            <ext:Button runat="server" ID="btn_Add_Data" Icon="SystemSave" Text="保存" ValidateForms="sf_Edit" OnClick="btn_Add_Data_Click" ConfirmText="是否保存？"></ext:Button>
            <ext:Label ID="Label3" runat="server" Width="5" Text=""></ext:Label>
            <ext:Button ID="btn_Cancle" Icon="Cancel" runat="server" Text=" 取消 " OnClick="btn_Cancle_Click"></ext:Button>
            <ext:Label ID="Label4" runat="server" Width="5" Text=""></ext:Label>
        </Items>
    </ext:Toolbar>
    </form>
</body>
</html>
