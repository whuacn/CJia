<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckResultAdvice.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Supervise.CheckResultAdvice" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
        <ext:Form ID="Form2" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
            AutoScroll="true" LabelWidth="75px" BodyPadding="25px 15px" runat="server" EnableCollapse="True">
            <Rows>
                <ext:FormRow>
                    <Items>
                        <ext:TextArea ID="txtCheckRusult" runat="server" ShowRedStar="true" Height="168" Label="检查笔录" Required="true"></ext:TextArea>
                    </Items>
                </ext:FormRow>
            </Rows>
            <Rows>
                <ext:FormRow>
                    <Items>
                        <ext:TextArea ID="txtCheckAdvice" runat="server" ShowRedStar="true" Height="168" Label="检查意见" Required="true"></ext:TextArea>
                    </Items>
                </ext:FormRow>
            </Rows>
            <Toolbars>
                    <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                        <Items>
                            <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                            <ext:Button ID="btn_Save" IconUrl="../../Icons/table_column.png"  runat="server" Text="   保存   "  OnClick="btn_Save_Click"></ext:Button>
                        </Items>
                    </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    </form>
</body>
</html>
