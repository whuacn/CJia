<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddData.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.AddData" %>

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
             LabelWidth="75px" runat="server" BodyPadding="10px" EnableCollapse="True" Width="850px" Height="40px">
                <Rows>
                    <ext:FormRow ColumnWidths="70% 30%">
                        <Items>
                            <ext:TextBox ID="txt_Data_Name" AutoPostBack="true" ShowRedStar="true" runat="server"  MaxLength="100"  Required="True" Label="资料标题"></ext:TextBox>
                            <ext:DropDownList ID="ddl_Data_Type" AutoPostBack="true" runat="server" Label="资料类别" ShowRedStar="true">
                            </ext:DropDownList>
                     </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        <ext:ContentPanel ID="ContentPanel1" runat="server"  BodyPadding="5px"
            EnableBackgroundColor="true" ShowBorder="true" ShowHeader="false" >
        <Items>
            <CKEditor:CKEditorControl ID="ckedit_add" runat="server" Height="249"></CKEditor:CKEditorControl>
        </Items>
    </ext:ContentPanel>
    <ext:Toolbar ID="Toolbar1" Position="Bottom" runat="server">
        <Items>
        <ext:ToolbarFill ID="ToolbarFill1" runat="server"></ext:ToolbarFill>
            <ext:Button runat="server" ID="btn_Add_Data" Icon="SystemSave" Text="保存" ValidateForms="sf_Edit" OnClick="btn_Add_Data_Click"></ext:Button>
            <ext:Label ID="Label3" runat="server" Width="5" Text=""></ext:Label>
            <ext:Button ID="btn_Cancle" Icon="Cancel" runat="server" Text=" 取消 " OnClick="btn_Cancle_Click"></ext:Button>
            <ext:Label ID="Label4" runat="server" Width="5" Text=""></ext:Label>
        </Items>
    </ext:Toolbar>
    </form>
</body>
</html>
