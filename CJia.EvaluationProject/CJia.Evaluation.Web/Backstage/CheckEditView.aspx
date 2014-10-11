<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckEditView.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.CheckEditView" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
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
                        <ext:Label runat="server" ID="maosu" Text="" Label=""></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="40% 40% 20%">
                    <Items>
                        <ext:DropDownList ID="ddl_state" ForceSelection="False" OnSelectedIndexChanged="ddl_state_SelectedIndexChanged" AutoPostBack="true" runat="server" Label="评审状态">
                        </ext:DropDownList>
                        <ext:DropDownList ID="ddl_result" runat="server" Label="评审结果" ForceSelection="False">
                        </ext:DropDownList>
                        <ext:Label runat="server" ID="eee" Text="" Label=""></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextArea ID="txt_advice" runat="server" Label="评审意见" Text="" MaxLength="1000" Height="100"></ext:TextArea>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextArea ID="txt_zhenggai" runat="server" Label="整改意见" Text="" MaxLength="1000" Height="100"></ext:TextArea>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="40% 45% 15%">
                    <Items>
                        <ext:TextBox ID="txt_cishu" Readonly="true" runat="server" Label="整改次数" Text=""></ext:TextBox>
                        <ext:DatePicker runat="server" Label="整改截止时间" EmptyText="请选择日期" DateFormatString="yyyy-MM-dd HH:mm:ss"
                            ID="zhenggai_date">
                        </ext:DatePicker>
                        <ext:Label runat="server" ID="Label1" Text="" Label=""></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="40% 45% 15%">
                    <Items>
                        <ext:TextBox ID="txt_zerenren" Readonly="true" runat="server" Label="责任人" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_baoshenriqi" Readonly="true" runat="server" Label="报审日期" Text=""></ext:TextBox>
                        <ext:Label runat="server" ID="Label2" Text="" Label=""></ext:Label>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="40% 45% 15%">
                    <Items>
                        <ext:TextBox ID="txt_pingshenren" Readonly="true" runat="server" Label="评审人" Text=""></ext:TextBox>
                        <ext:DatePicker runat="server" Label="评审日期" Required="true" DateFormatString="yyyy-MM-dd HH:mm:ss"
                            ID="pingshen_date">
                        </ext:DatePicker>
                        <ext:Label runat="server" ID="Label3" Text="" Label=""></ext:Label>
                    </Items>
                </ext:FormRow>
            </Rows>
            <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btn_save" OnClick="btn_save_Click" Text="保存" ValidateForms="sf_Edit" runat="server" Icon="PageSave">
                        </ext:Button>
                        <ext:Button ID="btn_Cancel" OnClick="btn_Cancel_Click" Text="取消" runat="server" Icon="Cancel">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    </form>
</body>
</html>
