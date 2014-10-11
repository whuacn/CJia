<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckTitleEdit.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.CheckTitle.CheckTitleEdit" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server" />
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
            AutoScroll="true" BodyPadding="25px 15px" runat="server" EnableCollapse="True" LabelWidth="70px">
            <Rows>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_TitleName" ShowRedStar="true" Required="true" runat="server" Label="题目名称" MaxLength="100" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_Type" ShowRedStar="true" Required="true" runat="server" Label="题目分类" MaxLength="200" Text="" Readonly="true"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextArea ID="txt_title_content" Required="True" runat="server" Label="题目内容" Text="" ShowRedStar="true" MaxLength="200" Height="140px"></ext:TextArea>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:CheckBox ID="cb_IsChoice" Label="选择题" Checked="true" runat="server"></ext:CheckBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="30% 70%">
                    <Items>
                        <ext:TextBox ID="txt_answer1" AutoPostBack="true" runat="server" Label="答案一" MaxLength="100" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_result1" AutoPostBack="true" runat="server" Label="检查笔录" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_advice1" AutoPostBack="true" runat="server" Label="生成意见" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="30% 70%">
                    <Items>
                        <ext:TextBox ID="txt_answer2" AutoPostBack="true" runat="server" Label="答案二" MaxLength="100" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_result2" AutoPostBack="true" runat="server" Label="检查笔录" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_advice2" AutoPostBack="true" runat="server" Label="生成意见" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="30% 70%">
                    <Items>
                        <ext:TextBox ID="txt_answer3" AutoPostBack="true" runat="server" Label="答案三" MaxLength="100" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_result3" AutoPostBack="true" runat="server" Label="检查笔录" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_advice3" AutoPostBack="true" runat="server" Label="生成意见" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="30% 70%">
                    <Items>
                        <ext:TextBox ID="txt_answer4" AutoPostBack="true" runat="server" Label="答案四" MaxLength="100" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_result4" AutoPostBack="true" runat="server" Label="检查笔录" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_advice4" AutoPostBack="true" runat="server" Label="生成意见" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="30% 70%">
                    <Items>
                        <ext:TextBox ID="txt_answer5" AutoPostBack="true" runat="server" Label="答案五" MaxLength="100" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_result5" AutoPostBack="true" runat="server" Label="检查笔录" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_advice5" AutoPostBack="true" runat="server" Label="生成意见" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="30% 70%">
                    <Items>
                        <ext:TextBox ID="txt_answer6" AutoPostBack="true" runat="server" Label="答案六" MaxLength="100" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_result6" AutoPostBack="true" runat="server" Label="检查笔录" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_advice6" AutoPostBack="true" runat="server" Label="生成意见" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
            </Rows>
            <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btn_Save" Text="保存" ValidateForms="sf_Edit" runat="server" Icon="TextRuler" OnClick="btn_Save_Click">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    </form>
</body>
</html>
