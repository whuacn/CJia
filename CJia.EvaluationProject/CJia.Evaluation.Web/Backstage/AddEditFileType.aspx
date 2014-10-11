<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditFileType.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.AddFileType" %>


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
                <%--<ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_TypeID" AutoPostBack="true" ShowRedStar="true" runat="server" Label="类型代码" MaxLength="100" Text="" Required="True"></ext:TextBox>
                    </Items>
                </ext:FormRow>--%>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_TypeValue" AutoPostBack="true" ShowRedStar="true" runat="server" Label="类型名称" MaxLength="100" Text="" Required="True"></ext:TextBox>
                    </Items>
                </ext:FormRow>
            </Rows>
            <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btn_Save" ConfirmText="确定保存？" Text="保存" ValidateForms="sf_Edit" runat="server" Icon="Disk" OnClick="btn_Save_Click">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    </form>
</body>
</html>
