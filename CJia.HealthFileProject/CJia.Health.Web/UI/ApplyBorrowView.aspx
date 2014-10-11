<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ApplyBorrowView.aspx.cs" Inherits="CJia.Health.Web.UI.ApplyBorrowView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%;">
        <table style="margin-left: 232px;">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="性别："></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="126px">
                        <asp:ListItem Value="2">全部</asp:ListItem>
                        <asp:ListItem Value="0">女</asp:ListItem>
                        <asp:ListItem Value="1">男</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="年龄："></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="100px"></asp:DropDownList>~<asp:DropDownList ID="DropDownList3" runat="server" Width="100px"></asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="婚姻状况："></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList4" runat="server" Width="125px">
                        <asp:ListItem Value="2">全部</asp:ListItem>
                        <asp:ListItem Value="0">未婚</asp:ListItem>
                        <asp:ListItem Value="1">已婚</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="地域："></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList5" runat="server" Width="100px"></asp:DropDownList>省
                    <asp:DropDownList ID="DropDownList12" runat="server" Width="100px"></asp:DropDownList>市</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="出院诊断："></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Width="120px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="手术："></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox7" runat="server" Width="210px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="病理诊断："></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox10" runat="server" Width="120px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="Label16" runat="server" Text="院内感染："></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox11" runat="server" Width="210px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="借阅时间："></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList6" runat="server" Width="210px">
                        <asp:ListItem Text="1">1天</asp:ListItem>
                        <asp:ListItem Text="3">3天</asp:ListItem>
                        <asp:ListItem Text="5">5天</asp:ListItem>
                        <asp:ListItem Text="10">10天</asp:ListItem>
                        <asp:ListItem Text="15">15天</asp:ListItem>
                        <asp:ListItem Text="30">30天</asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="数量："></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="120px"></asp:TextBox></td>
                <td></td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="查询" Height="31px" Width="98px" OnClick="Button2_Click" />
                    &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="申请借阅" Height="31px" Width="98px" />
                </td>
            </tr>
        </table>
        <div style="margin-left: 232px;">
            <asp:GridView ID="gvPatient" runat="server" Width="90%" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
                <Columns>
                    <asp:BoundField DataField="PATIENT_NAME" HeaderText="姓名" />
                    <asp:BoundField DataField="GENDER" HeaderText="性别" />
                    <asp:BoundField DataField="BIRTHDAY" HeaderText="年龄" />
                    <asp:BoundField DataField="IS_MARRY" HeaderText="婚姻状况" />
                    <asp:BoundField HeaderText="居住地" />
                    <asp:BoundField DataField="ICD_OUTDIA1" HeaderText="出院诊断" />
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </div>
        <br />
    </div>
</asp:Content>
