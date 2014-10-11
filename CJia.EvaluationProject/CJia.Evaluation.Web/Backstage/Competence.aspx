<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Competence.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.Competence" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../../Css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server"/>
    <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
             AutoScroll="true" LabelWidth="85px" BodyPadding="25px 15px" runat="server" EnableCollapse="True">
             <Rows>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:GroupPanel ID="grMenu" Layout="Form" runat="server" AutoHeight="true" Title="菜单设置" EnableCollapse="false">
                            <Items> 
                                <ext:Tree ID="treeMenu"  ShowHeader="false" runat="server" OnNodeCheck="treeMenu_NodeCheck">
                                </ext:Tree>
                        </Items>  
                        </ext:GroupPanel>
                    </Items>   
                </ext:FormRow> 
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:GroupPanel ID="grColumn" Layout="Form" runat="server" AutoHeight="true" Title="栏目设置" EnableCollapse="false">
                            <Items> 
                                <ext:Tree ID="treeColumn" ShowHeader="false" runat="server" OnNodeCheck="treeColumn_NodeCheck">
                                </ext:Tree>
                        </Items>  
                        </ext:GroupPanel>
                    </Items>   
                </ext:FormRow> 
            </Rows>
             <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btnSave" Text="保存"  ValidateForms="sf_Edit" runat="server" Icon="SystemSaveClose" OnClick="btnSave_Click"></ext:Button>
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
