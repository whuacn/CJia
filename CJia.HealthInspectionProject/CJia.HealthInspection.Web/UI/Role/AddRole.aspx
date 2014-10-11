<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Role.AddRole" %>
<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server" />
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
            AutoScroll="true" BodyPadding="25px 15px" runat="server" EnableCollapse="True">
            <Rows>
            <ext:FormRow ColumnWidths="50% 50%">
                <Items>
                    <ext:TextBox ID="txtRoleName" ShowRedStar="true" Required="true" runat="server" Label="名称" MaxLength="100" Text=""></ext:TextBox>
                    <%--<ext:TextBox ID="txtPicture" runat="server" ShowRedStar="true" Required="true" Label="图标" MaxLength="100" Text=""></ext:TextBox>--%>
                </Items>
            </ext:FormRow>
            <ext:FormRow ColumnWidths="100%">
                <Items>
                <ext:GroupPanel ID="gr_Power" Layout="Form" runat="server" AutoHeight="true" Title="权限设置" EnableCollapse="false">
                    <Items> 
                       <ext:Tree ID="treePower" OnNodeCheck="treePower_NodeCheck" ShowHeader="false"
                            Title="权限设置" runat="server">
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
                        <ext:Button ID="btnSave" Text="保存" ValidateForms="sf_Edit" runat="server" Icon="TextRuler" OnClick="btnSave_Click">
                        </ext:Button>
                        <ext:Button ID="btnReturn" Text="返回" runat="server" Hidden="true" Icon="BulletGo" OnClick="btnReturn_Click">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>      
    </form>
</body>
</html>
