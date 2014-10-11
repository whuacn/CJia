<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckResultDetial.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.CheckResultDetial" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../Css/main.css" />
    <title></title>
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server" />
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
            AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True" LabelWidth="85px">
            <Rows>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:Label runat="server" ID="treeName" Text="" Label="评审条款"></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:Label runat="server" ID="maosu" Text="" Label="条款内容"></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="45% 55%">
                    <Items>
                        <ext:Label runat="server" ID="zerenren" Text="" Label="责任人"></ext:Label>
                        <ext:Label runat="server" ID="baoshensj" Text="" Label="报审时间"></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="45% 55%">
                    <Items>
                        <ext:Label runat="server" ID="pingshenren" Text="" Label="评审人"></ext:Label>
                        <ext:Label runat="server" ID="pingshensj" Text="" Label="评审时间"></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="45% 55%">
                    <Items>
                        <ext:Label runat="server" ID="pingshenzhuangt" Text="" Label="评审状态"></ext:Label>
                        <ext:Label runat="server" ID="pingshenjieguo" Text="" Label="评审结果"></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="45% 55%">
                    <Items>
                        <ext:Label runat="server" ID="cishu" Text="" Label="整改次数"></ext:Label>
                        <ext:Label runat="server" ID="jiezhisj" Text="" Label="整改截止时间"></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:Label runat="server" ID="psyijian" Text="" Label="评审意见"></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:Label runat="server" ID="zgyijian" Text="" Label="整改意见"></ext:Label>
                    </Items>
                </ext:FormRow>
            </Rows>
            <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btn_Cancel" Text="关闭" ValidateForms="sf_Edit" runat="server" Icon="Cancel" OnClick="btn_Cancel_Click">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    </form>
</body>
</html>
