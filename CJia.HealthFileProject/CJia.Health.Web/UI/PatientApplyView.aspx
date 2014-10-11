<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientApplyView.aspx.cs" Inherits="CJia.Health.Web.UI.PatientApplyView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Js/Main.js"></script>
    <script src="Js/TabControl.js"></script>
    <script type="text/javascript">
        //加载页面要使用的CSS
        loadCss(top._skinId, 'Page.css');
    </script>
    <style type="text/css">
        .HeaderStyle {
            color: white;
            /*background-color: #FF6600;FFE4B5 F8D0F8 FFA54F*/
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
    <script type="text/javascript">
        function reasonFocus() {
            var txt = document.getElementById('txtReason');
            if (txt.value.trim() == '最多输入汉字50个！！！') {
                txt.value = "";
            }
        }
        function reasonBlur() {
            var txt = document.getElementById('txtReason');
            if (txt.value.trim() == '') {
                txt.value = "最多输入汉字50个！！！";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%" align="center">
                <tr style="width: 100%;">
                    <td colspan="5"><%--AllowPaging="True" PageSize="5" --%>
                        <asp:GridView ID="PatientGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                            OnRowCommand="gvCity_RowCommand" OnRowDataBound="gvCity_RowDataBound" CssClass="GridViewStyle" BorderStyle="Solid">
                            <HeaderStyle CssClass="HeaderStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="借阅">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckApply" runat="server" Enabled='<%# Eval("ENABLE") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMsg" runat="server" Text='<%# Eval("FLAG") %>' ForeColor="#FF3300"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                <tr style="height: 80px; font-family: 宋体; font-size: 18px;">
                    <td></td>
                    <td style="width: 90px; text-align: right; color: red;">
                        <asp:Label ID="lblMeg" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="width: 90px;">借阅原因：
                    </td>
                    <td style="width: 370px;">
                        <textarea id="txtReason" runat="server" cols="40" rows="4" style="font-size: 14px" onfocus="reasonFocus();" onblur="reasonBlur();">最多输入汉字50个！！！</textarea>
                    </td>
                    <td style="width: 120px;">
                        <asp:Button ID="btnApply" runat="server" Text="提交借阅" Width="80px" OnClick="btnApply_Click" OnClientClick="return confirm('确认提交借阅申请吗?')"/>
                        &nbsp;<a href="QueryPatientView.aspx" style="font-size: 11pt; color: #FF0000;">返回</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
