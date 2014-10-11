<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpLoadLowFile.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Low.UpLoadLowFile" %>

<%@ Register assembly="ExtAspNet" namespace="ExtAspNet" tagprefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
    <style type="text/css">
        .titleColor {
            color: gray;
        }
    </style>
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server" />
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
            AutoScroll="true" LabelWidth="70px" BodyPadding="25px 15px" runat="server" EnableCollapse="True">
            <Rows>
                <ext:FormRow>
                    <Items>
                        <ext:TextBox ID="txt_LowName" AutoPostBack="true" ShowRedStar="true" runat="server" Label="法律法规名称" MaxLength="100" Text="" Required="True"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow>
                    <Items>
                        <ext:DropDownList ID="ddl_Low" AutoPostBack="true" runat="server" Label="法律法规分类" EnableSimulateTree="false" ShowRedStar="true" Width="200">
                        </ext:DropDownList>
                    </Items>
                </ext:FormRow>
                <ext:FormRow>
                    <Items>
                        <ext:FileUpload ID="LowFile" AutoPostBack="true" runat="server" Label="选择文件"></ext:FileUpload>
                    </Items>
                </ext:FormRow>
            </Rows>
            <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btn_Save" Text="保存" ValidateForms="sf_Edit" runat="server" Icon="TextRuler" OnClick="btn_Save_Click" >
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    <%--<div>
        <asp:Label ID="Label1" runat="server" Text="选择文件"></asp:Label>
        <input id="File1" type="file" runat="server"/> 
    </div>--%>
        
    </form>
</body>
</html>
