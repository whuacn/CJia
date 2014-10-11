<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.User.EditUser" %>
<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server"/>
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
             AutoScroll="true" LabelWidth="85px" BodyPadding="25px 15px" runat="server" EnableCollapse="True">
             <Rows>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="txtUserNo" ShowRedStar="true" runat="server" Label="编号" MaxLength="100" Text="" Required="True"></ext:TextBox>
                            <ext:TextBox ID="txtUserName" ShowRedStar="true" runat="server" Label="名称" MaxLength="100" Text="" Required="True"></ext:TextBox>
                        </Items>
                    </ext:FormRow> 
                     <ext:FormRow ColumnWidths="100%">
                        <Items>
                             
                            <ext:GroupPanel ID="grRole" Layout="Form" runat="server" AutoHeight="true" Title="角色设置" EnableCollapse="false">
                                <Items> 
                                    <ext:CheckBox runat="server" ID="chkAll" Label="全部" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="true"></ext:CheckBox>
                                    <ext:CheckBoxList ID="chkListRole" runat="server" AutoPostBack="true">
                                    </ext:CheckBoxList>
                            </Items>  
                            </ext:GroupPanel>
                       </Items>   
                </ext:FormRow> 
                </Rows>
             <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btnSave" Text="保存"  ValidateForms="sf_Edit" runat="server" Icon="TextRuler" OnClick="btnSave_Click">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    </form>
</body>
</html>
