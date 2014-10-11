<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyApplyDetailView.aspx.cs" Inherits="CJia.Health.Web.UI.MyApplyDetailView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Js/Main.js"></script>
    <script type="text/javascript">
        //加载页面要使用的CSS
        loadCss(top._skinId, 'Page.css');
    </script>
    <script type="text/javascript">
        function onclose() {
            history.go(-1);
        }
</script>
    <style type="text/css">
        .HeaderStyle {
            color: white;
            background-color: #FFA54F;
            height: 30px;
            line-height: 24px;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            font-size: 18px;
        }

        .GridViewStyle {
            border: 0.5px solid #D7D7D7;
            font-size: 15px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" style="text-align: left; font-family: 宋体; font-size: 18px;">
                <tr style="height: 30px">
                    <td colspan="4" style="text-align: center; font-weight: bold; font-size: 20px; color: #000000;">申请单详情&nbsp;<a href="MyApplyView.aspx" style="font-size: 11pt; color: #FF0000;">返回</a></td>
                </tr>
                <tr style="height: 30px">
                    <td style="width: 250px;">申请人姓名：<asp:Label ID="lblApplyName" runat="server" Text="邓华华化"></asp:Label>
                    </td>
                    <td style="width: 350px;">申请单编号：<asp:Label ID="lblListNO" runat="server" Text="20120716001000000005"></asp:Label>
                    </td>
                    <td style="width: 280px;">申请时间：<asp:Label ID="lblApplyDate" runat="server" Text="2013/7/16 0:26:38"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                <tr style="height: 40px">
                    <td colspan="4">
                        申请理由：<asp:Label ID="lblReason" runat="server" Text="20120716001000000005"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="PatientGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                            OnRowCommand="gvCity_RowCommand" OnRowDataBound="gvCity_RowDataBound" CssClass="GridViewStyle" BorderStyle="Solid">
                            <HeaderStyle CssClass="HeaderStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="病案号">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecordNO" runat="server" Text='<%# Eval("RECORDNO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="病人ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatientID" runat="server" Text='<%# Eval("PATIENT_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="入院次数">
                                    <ItemTemplate>
                                        <asp:Label ID="inhosTIme" runat="server" Text='<%# Eval("IN_HOSPITAL_TIME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="病人姓名">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatientName" runat="server" Text='<%# Eval("PATIENT_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="性别">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGender" runat="server" Text='<%#Eval("GENDER_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="入院日期">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl1" runat="server" Text='<%# DateTime.Parse(Eval("IN_HOSPITAL_DATE").ToString()).ToShortDateString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="入院科室">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl2" runat="server" Text='<%# Eval("IN_HOSPITAL_DEPT_NAME")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="入院医生">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl3" runat="server" Text='<%#Eval("IN_HOSPITAL_DOCTOR_NAME")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="出院日期">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl4" runat="server" Text='<%# DateTime.Parse(Eval("OUT_HOSPITAL_DATE").ToString()).ToShortDateString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="出院科室">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl5" runat="server" Text='<%# Eval("OUT_HOSPITAL_DEPT_NAME")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="出院医生">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl6" runat="server" Text='<%#Eval("OUT_HOSPITAL_DOCTOR_NAME")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="详细信息">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("RECORDNO") %>'
                                            CommandName="MyPatient" Font-Bold="True" ForeColor="Red" Font-Underline="False">
                                            <asp:Label ID="lblFlag" runat="server" Text='详细信息>>'></asp:Label>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BorderColor="#D7D7D7" BorderStyle="Solid" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
