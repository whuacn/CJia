<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CJia.Evaluation.Web.FrontStage.HomePage" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>医院等级评审资料查阅系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../Css/main.css" />
    <script type="text/javascript" src="../Js/main.js"></script>
    <style type="text/css">
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="rgn_Top" Height="100px" ShowBorder="false" ShowHeader="false" Position="Top"
                    Layout="Fit" runat="server">
                    <Items>
                        <ext:ContentPanel CssClass="topBJ" ShowBorder="false" ShowHeader="false" ID="cpnl_Logo" runat="server" CssStyle="topBJ">                        
                        <div style="background-color:#007ACC; font-weight: bold;height:100px; font-size:30px; color:#ffffff; float:left;width:100%;">
                            <table>
                                <tr  style="height:100%;width:100%">
                                    <td style="width:70px;">
                                        <img src="../Images/hsz.png" height="65" width="65" title="" alt="" style="margin-top:2px;"/>
                                    </td>
                                    <td style="align-content:center;vertical-align:middle;width:600px;">
                                        <label>医院等级评审资料查阅系统</label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                         </div>
                        <div style="float:right;padding:0 5px 0 0;"></div>
                        </ext:ContentPanel>
                    </Items>
                    <Toolbars>
                        <ext:Toolbar ID="tbr_b" Position="Bottom" runat="server">
                            <Items>
                                <ext:ToolbarSeparator ID="tbf_sepll" runat="server">
                                </ext:ToolbarSeparator>
                                <ext:Image ID="img_clock" Icon="Clock" runat="server"></ext:Image>
                                <ext:ToolbarText ID="tbt_Clock" runat="server" Text="2014-2-20 10:47:20"></ext:ToolbarText>
                                <ext:ToolbarSeparator ID="tbf_seplc" runat="server">
                                </ext:ToolbarSeparator>
                                <ext:Image ID="Image1" Icon="User" runat="server"></ext:Image>
                                <ext:ToolbarText ID="tbt_Info" runat="server" Text="欢迎【管理员】"></ext:ToolbarText>
                                <ext:ToolbarFill ID="tbf_c" runat="server">
                                </ext:ToolbarFill>
                                <%--<ext:ToolbarSeparator ID="tbf_seplrl" runat="server">
                                </ext:ToolbarSeparator>
                                <ext:Button ID="btn_UserInfo" Icon="User" Text="个人信息" runat="server">
                                </ext:Button>--%>
                                <ext:ToolbarSeparator ID="tbf_seplrc" runat="server">
                                </ext:ToolbarSeparator>
                                <ext:Button ID="btn_ChangePassword" Icon="LockKey" Text="修改密码" runat="server">
                                </ext:Button>
                                <ext:ToolbarSeparator ID="tbf_seplrr" runat="server">
                                </ext:ToolbarSeparator>
                                <ext:Button ID="btn_EndLogin" IconUrl="../Icons/zhuxiao.png" Text="注销登录" runat="server"
                                    OnClientClick="if(confirm('确认要注销登录吗？')) top.location='../LoginView.aspx';">
                                </ext:Button>
                                <ext:ToolbarSeparator ID="tbf_seplr" runat="server">
                                </ext:ToolbarSeparator>
                            </Items>
                        </ext:Toolbar>
                    </Toolbars>
                </ext:Region>
                <ext:Region ID="ren_Left" Split="false" EnableSplitTip="true" CollapseMode="Mini" EnableCollapse="true" Width="260px" ShowHeader="true"
                    Title="功能菜单" Margins="0 0 5 5" Layout="Fit" Position="Left" runat="server">
                    <%--<Toolbars>
                        <ext:Toolbar ID="tbr_menu" Position="Bottom" runat="server">
                            <Items>
                                <ext:ToolbarFill ID="tf_m" runat="server">
                                </ext:ToolbarFill>
                                <ext:Button ID="btn_ReloadMenu" IconUrl="Images/reload.png" Text="刷新" runat="server">
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </Toolbars>--%>
                    <Items>
                        <ext:Accordion ID="ad_Main" runat="server" ShowHeader="false" ShowBorder="false" BodyPadding="2px">
                            <Panes>
                                <%--<ext:AccordionPane ID="ap_MBasic" AutoScroll="true" Expanded="True" IconUrl="../Icons/book.png" Title="第一章：坚持医院公益性" runat="server" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MBasic" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode Text=" 1.1 医院设置、功能和任务符合区域..." ToolTip="医院设置、功能和任务符合区域卫生规划和医疗机构设置规划的定位和要求" IconUrl="../Icons/database_yellow.png">
                                                    <ext:TreeNode Text=" 1.1.1 医院的功能、任务和定位..." ToolTip="医院的功能、任务和定位明确，规模适宜" NavigateUrl="1_1_1.aspx" NodeID="1.1.1" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.1.2 医院有承担服务区域..." ToolTip="医院有承担服务区域内急危重症和疑难疾病诊疗的设施设备、技术梯队与处置能力，医学影像与介入诊疗部门可提供 24 小时急诊诊疗服务" NavigateUrl="1_1_2.aspx" NodeID="1.1.2" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.1.3 临床科室一、二级诊疗..." ToolTip="临床科室一、二级诊疗科目设置、人员梯队与诊疗技术能力符合省级卫生行政部门规定；重点科室专业技术水平与质量处于本省前列" NavigateUrl="1_1_3.aspx" NodeID="1.1.3" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.1.4 医技科室服务能满足临床..." ToolTip="医技科室服务能满足临床科室需要，项目设置、人员梯队与技术能力符合省级卫生行政部门规定" NavigateUrl="1_1_4.aspx" NodeID="1.1.4" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 1.2 医院内部管理机制科学规范" ToolTip="医院内部管理机制科学规范" IconUrl="../Icons/database_yellow.png">
                                                    <ext:TreeNode Text=" 1.2.1" ToolTip="坚持公立医院公益性，把维护人民群众健康权益放在第一位" NavigateUrl="1_1_1.aspx" NodeID="1.2.1" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.2.2" ToolTip="按照规范开展住院医师规范化培训工作，做到制度、师资与经费落实，做好培训基地建设" NavigateUrl="1_1_2.aspx" NodeID="1.2.2" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.2.3" ToolTip="将推进规范诊疗、临床路径管理和单病种质量控制作为推动医疗质量持续改进的重点项目" NavigateUrl="1_1_3.aspx" NodeID="1.2.3" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.2.4" ToolTip="提高工作绩效，优化医疗服务系统与流程，缩短平均住院日、缩短患者诊疗等候时间" NavigateUrl="1_1_4.aspx" NodeID="1.2.4" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.2.5" ToolTip="按照《国家基本药物临床应用指南》和《国家基本药物处方集》及医疗机构药品使用管理有关规定，规范医师处方行为，确保基本药物的优先合理使用" NavigateUrl="1_1_3.aspx" NodeID="1.2.5" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.2.6" ToolTip="控制公立医院特需服务规模" NavigateUrl="1_1_4.aspx" NodeID="1.2.6" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 1.3 承担公立医院与基层医疗机构..." ToolTip="承担公立医院与基层医疗机构对口协作等政府指令性任务" IconUrl="../Icons/database_yellow.png">
                                                    <ext:TreeNode Text=" 1.3.1" ToolTip="将对口支援县医院和乡镇卫生院（以下简称受援医院）和支援社区卫生服务工作纳入院长目标责任制与医院年度工作计划，有实施方案，专人负责" NavigateUrl="1_1_1.aspx" NodeID="1.3.1" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.3.2" ToolTip="承担政府分配的为社区、农村培养人才的指令性任务，制定相关的制度、培训方案，并有具体措施予以保障" NavigateUrl="1_1_2.aspx" NodeID="1.3.2" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.3.3" ToolTip="根据《中华人民共和国传染病防治法》和《突发公共卫生事件应急条例》等相关法律法规承担传染病的发现、救治、报告、预防等任务" NavigateUrl="1_1_3.aspx" NodeID="1.3.3" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.3.4" ToolTip="建立院前急救与院内急诊“绿色通道”，有效衔接的工作流程" NavigateUrl="1_1_4.aspx" NodeID="1.3.4" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.3.5" ToolTip="开展健康教育与健康促进、健康咨询等多种形式的公益性社会活动" NavigateUrl="1_1_3.aspx" NodeID="1.3.5" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.3.6" ToolTip="在基本医疗保障制度框架内，医院应建立与实施双向转诊制度与相关服务流程" NavigateUrl="1_1_4.aspx" NodeID="1.3.6" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.3.7" ToolTip="根据《统计法》与卫生行政部门规定，完成医院基本运行状况、医疗技术、诊疗信息和临床用药监测信息等相关数据报送工作，数据真实可靠" NavigateUrl="1_1_4.aspx" NodeID="1.3.7" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 1.4 应急管理" ToolTip="应急管理" IconUrl="../Icons/database_yellow.png">
                                                    <ext:TreeNode Text=" 1.4.1" ToolTip="遵守国家法律、法规，严格执行各级政府制定的应急预案。服从指挥，承担突发公共事件的紧急医疗救援任务和配合突发公共卫生事件防控工作" NavigateUrl="1_1_1.aspx" NodeID="1.4.1" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.4.2" ToolTip="加强领导，成立医院应急工作领导小组，建立医院应急指挥系统，落实责任，建立并不断完善医院应急管理的机制" NavigateUrl="1_1_2.aspx" NodeID="1.4.2" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.4.3" ToolTip="明确医院需要应对的主要突发事件策略，制定和完善各类应急预案，提高快速反应能力" NavigateUrl="1_1_3.aspx" NodeID="1.4.3" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.4.4" ToolTip="开展应急培训和演练，提高各级、各类人员的应急素质和医院的整体应急能力" NavigateUrl="1_1_4.aspx" NodeID="1.4.4" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                    <ext:TreeNode Text=" 1.4.5" ToolTip="合理进行应急物资和设备的储备" NavigateUrl="1_1_3.aspx" NodeID="1.4.5" Icon="Book" IconUrl="../Icons/database_yellow.png">
                                                    </ext:TreeNode>
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 1.5 临床医学教育" ToolTip="临床医学教育" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 1.6 科研及其成果推广" ToolTip="科研及其成果推广" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MBusiness" IconUrl="../Icons/book.png" runat="server" Expanded="false" Title="第二章：医院服务" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MBusiness" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode Text=" 2.1" NavigateUrl="FirstOne.aspx" NodeID="2.1" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 2.2" NavigateUrl="FirstOne.aspx" NodeID="2.2" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 2.3" NavigateUrl="FirstOne.aspx" NodeID="2.3" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 2.4" NavigateUrl="FirstOne.aspx" NodeID="2.4" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 2.5" NavigateUrl="FirstOne.aspx" NodeID="2.5" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 2.6" NavigateUrl="FirstOne.aspx" NodeID="2.6" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 2.7" NavigateUrl="FirstOne.aspx" NodeID="2.7" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 2.8" NavigateUrl="FirstOne.aspx" NodeID="2.8" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MArticle" AutoScroll="true" IconUrl="../Icons/book.png" runat="server" Expanded="false" Title="第三章：患者安全" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MArticle" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode Text=" 3.1" NavigateUrl="FirstOne.aspx" NodeID="3.1" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 3.2" NavigateUrl="FirstOne.aspx" NodeID="3.2" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 3.3" NavigateUrl="FirstOne.aspx" NodeID="3.3" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 3.4" NavigateUrl="FirstOne.aspx" NodeID="3.4" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 3.5" NavigateUrl="FirstOne.aspx" NodeID="3.5" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 3.6" NavigateUrl="FirstOne.aspx" NodeID="3.6" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 3.7" NavigateUrl="FirstOne.aspx" NodeID="3.7" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 3.8" NavigateUrl="FirstOne.aspx" NodeID="3.8" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 3.9" NavigateUrl="FirstOne.aspx" NodeID="3.9" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 3.10" NavigateUrl="FirstOne.aspx" NodeID="3.10" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MInfo" AutoScroll="true" IconUrl="../Icons/book.png" runat="server" Expanded="false" Title="第四章：医疗质量安全管理与持续改进" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MInfo" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode Text=" 4.1" NavigateUrl="FirstOne.aspx" NodeID="3.1" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.2" NavigateUrl="FirstOne.aspx" NodeID="4.2" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.3" NavigateUrl="FirstOne.aspx" NodeID="4.3" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.4" NavigateUrl="FirstOne.aspx" NodeID="4.4" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.5" NavigateUrl="FirstOne.aspx" NodeID="4.5" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.6" NavigateUrl="FirstOne.aspx" NodeID="4.6" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.7" NavigateUrl="FirstOne.aspx" NodeID="4.7" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.8" NavigateUrl="FirstOne.aspx" NodeID="4.8" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.9" NavigateUrl="FirstOne.aspx" NodeID="4.9" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.10" NavigateUrl="FirstOne.aspx" NodeID="4.10" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.11" NavigateUrl="FirstOne.aspx" NodeID="4.11" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.12" NavigateUrl="FirstOne.aspx" NodeID="4.12" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.13" NavigateUrl="FirstOne.aspx" NodeID="4.13" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.14" NavigateUrl="FirstOne.aspx" NodeID="4.14" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.15" NavigateUrl="FirstOne.aspx" NodeID="4.15" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.16" NavigateUrl="FirstOne.aspx" NodeID="4.16" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.17" NavigateUrl="FirstOne.aspx" NodeID="4.17" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.18" NavigateUrl="FirstOne.aspx" NodeID="4.18" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.19" NavigateUrl="FirstOne.aspx" NodeID="4.19" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.20" NavigateUrl="FirstOne.aspx" NodeID="4.20" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.21" NavigateUrl="FirstOne.aspx" NodeID="4.21" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.22" NavigateUrl="FirstOne.aspx" NodeID="4.22" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.23" NavigateUrl="FirstOne.aspx" NodeID="4.23" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.24" NavigateUrl="FirstOne.aspx" NodeID="4.24" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.25" NavigateUrl="FirstOne.aspx" NodeID="4.25" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.26" NavigateUrl="FirstOne.aspx" NodeID="4.26" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 4.27" NavigateUrl="FirstOne.aspx" NodeID="4.27" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MGoods" AutoScroll="true" IconUrl="../Icons/book.png" runat="server" Expanded="false" Title="第五章：护理管理与质量持续改进" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MGoods" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode Text=" 5.1" NavigateUrl="FirstOne.aspx" NodeID="5.1" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 5.2" NavigateUrl="FirstOne.aspx" NodeID="5.2" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 5.3" NavigateUrl="FirstOne.aspx" NodeID="5.3" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 5.4" NavigateUrl="FirstOne.aspx" NodeID="5.4" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 5.5" NavigateUrl="FirstOne.aspx" NodeID="5.5" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MDept" AutoScroll="true" IconUrl="../Icons/book.png" runat="server" Expanded="false" Title="第六章：医院管理" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MDept" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode Text=" 6.1" NavigateUrl="FirstOne.aspx" NodeID="6.1" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 6.2" NavigateUrl="FirstOne.aspx" NodeID="6.2" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 6.3" NavigateUrl="FirstOne.aspx" NodeID="6.3" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 6.4" NavigateUrl="FirstOne.aspx" NodeID="6.4" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 6.5" NavigateUrl="FirstOne.aspx" NodeID="6.5" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 6.6" NavigateUrl="FirstOne.aspx" NodeID="6.6" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 6.7" NavigateUrl="FirstOne.aspx" NodeID="6.7" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 6.8" NavigateUrl="FirstOne.aspx" NodeID="6.8" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 6.9" NavigateUrl="FirstOne.aspx" NodeID="6.9" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 6.10" NavigateUrl="FirstOne.aspx" NodeID="6.10" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text=" 6.11" NavigateUrl="FirstOne.aspx" NodeID="6.11" IconUrl="../Icons/database_yellow.png">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MUser" Hidden="true" Icon="FolderUser" runat="server" Expanded="false" Title="法律法规" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MUser" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MSystem" Hidden="true" Icon="FolderDatabase" runat="server" Expanded="false" Title="系统设置" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MSystem" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_Suppter" Hidden="true" Icon="FolderStar" runat="server" Expanded="false" Title="超级设置" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_Suppter" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>--%>
                            </Panes>
                        </ext:Accordion>
                    </Items>
                </ext:Region>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="0 0 5 0"
                    runat="server">
                    <Items>
                        <ext:TabStrip ID="tabs_Main" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                            <Tabs>
                                <ext:Tab ID="tab_Home" Title="管理首页" Layout="Fit" Icon="House" runat="server">
                                    <Toolbars>
                                        <ext:Toolbar ID="tb_Tool" runat="server">
                                            <Items>
                                                <ext:ToolbarFill ID="tbf_htfill" runat="server">
                                                </ext:ToolbarFill>
                                                <ext:Button ID="btn_Reload" Icon="ArrowRefresh" Text="刷新窗口" runat="server">
                                                </ext:Button>
                                                <ext:Button ID="btn_SourceCode" OnClientClick="window.open('../Default.aspx', '_blank');e.stopEvent();"
                                                    Icon="WorldLink" Text="网站首页" EnablePostBack="false" runat="server">
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </Toolbars>
                                    <Items>
                                        <ext:ContentPanel ID="ct_Home" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px" AutoScroll="true">
                                        <%--<%=Caches.Config["Home"][0] %>--%>
                                        </ext:ContentPanel>
                                    </Items>
                                </ext:Tab>
                            </Tabs>
                        </ext:TabStrip>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="win_ChangePassword" Icon="LockKey" Title="修改密码" IFrameUrl="UI/ChangePassword.aspx" Hidden="true" EnableIFrame="true"
            Target="Parent" runat="server" IsModal="true" Width="350px" Height="170px">
        </ext:Window>
    </form>
    <script type="text/javascript">
        var trees=new Array();
        trees=<%= TreeCount %>;
        var IDS=new Array();
        for(var i=0;i<trees.length;i++)
        {
            IDS[i]='rpnl_Main_ren_Left_ad_Main_'+trees[i]+'_'+trees[i];
        }
        IDS[trees.length]='<%= tabs_Main.ClientID %>';
    </script>
</body>
</html>
