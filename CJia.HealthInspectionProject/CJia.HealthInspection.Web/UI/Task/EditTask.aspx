<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditTask.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Task.EditTask" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server" />
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
            AutoScroll="true" LabelWidth="85px" BodyPadding="25px 15px" runat="server" EnableCollapse="True">
            <Rows>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txtTaskName" ShowRedStar="true" runat="server" Label="任务名称" MaxLength="100" Text="" Required="True"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="80% 20%">
                    <Items>
                        <ext:TextBox ID="txtTempName" ShowRedStar="true" AutoPostBack="true" runat="server" Label="模板名称" Readonly="true" MaxLength="100" Text="" Required="True"></ext:TextBox>
                        <ext:Button ID="btnSelectTemp" IconUrl="../../Icons/zoom_in.png" runat="server" Text="选择模板" OnClick="btnSelectTemp_Click"></ext:Button>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="50% 50%">
                    <Items>
                        <ext:DropDownList ID="dropTaskType" AutoPostBack="true" runat="server" Label="任务类型" ShowRedStar="true" OnSelectedIndexChanged="dropTaskType_SelectedIndexChanged">
                        </ext:DropDownList>
                        <ext:TextBox ID="txtOrganName" runat="server" Label="下达机构" MaxLength="100" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="50% 50%">
                    <Items>
                        <ext:DatePicker ID="dpkStart" Label="开始时间" Required="true" ShowRedStar="true" runat="server"></ext:DatePicker>
                        <ext:DatePicker ID="dpkEnd" Label="结束时间" Required="true" ShowRedStar="true" runat="server"></ext:DatePicker>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextArea ID="txtCheckScode" runat="server" Label="检查范围" Text="" MaxLength="200" Height="80"></ext:TextArea>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextArea ID="txtRemark" runat="server" Label="备注说明" Text="" MaxLength="200" Height="120"></ext:TextArea>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="35% 20% 45%">
                    <Items>
                        <ext:FileUpload ID="fupFile" runat="server" Label="上传文件"></ext:FileUpload>
                        <ext:Button ID="btnAddFile" Text="添加" runat="server" OnClick="btnAddFile_Click"></ext:Button>
                        <ext:Grid ID="gridFiles" runat="server" Title="文件信息" ShowHeader="False" PageSize="18" ShowBorder="true"
                            IsDatabasePaging="true" AutoHeight="true" DataKeyNames="FILE_NO" AutoScroll="true" OnRowCommand="gridFiles_RowCommand">
                            <Columns>
                                <ext:BoundField DataToolTipField="file_id" Width="120px" HeaderText="文件ID" DataField="file_id"/>
                                <ext:BoundField DataToolTipField="file_no" Width="120px" HeaderText="排序" DataField="file_no" />
                                <ext:BoundField DataToolTipField="file_name" Width="150px" HeaderText="文件名称" DataField="file_name" ExpandUnusedSpace="true" />
                                <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Delete" HeaderText="&nbsp;" Width="35px" CommandName="Delete" Text="" ToolTip="移除" Icon="Delete" />
                            </Columns>
                        </ext:Grid>
                    </Items>
                </ext:FormRow>
            </Rows>
            <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btnSave" Text="保存" ValidateForms="sf_Edit" runat="server" Icon="TextRuler" OnClick="btnSave_Click">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="880px" Height="550px">
        </ext:Window>
    </form>
</body>
</html>
