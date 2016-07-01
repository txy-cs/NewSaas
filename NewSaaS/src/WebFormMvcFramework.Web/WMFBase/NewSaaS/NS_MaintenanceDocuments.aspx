<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NS_MaintenanceDocuments.aspx.cs" Inherits="WebFormMvcFramework.Web.WMFBase.NewSaaS.NS_MaintenanceDocuments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Themes/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../Themes/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/jquery.pullbox.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/FunctionJS.js" type="text/javascript"></script>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Themes/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../Themes/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/jquery.pullbox.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/FunctionJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        //新增
        function add() {
            var url = "../WMFBase/NewSaaS/NS_CustomerAdd.aspx";
            top.openDialog(url, 'NS_CustomerAdd', '客户 - 添加', 650, 450, 50, 50);
        }
        function select() {
            var url = "../WMFBase/NewSaaS/NS_CustomerSelect.aspx"
            top.openDialog(url, 'NS_CustomerSelect', '客户 - 选择', 650, 450, 50, 50);
        }
     </script>

    <style type="text/css">
        .auto-style1 {
            width: 99%;
            margin-bottom: 1px;
        }

        .auto-style2 {
            text-align: right;
        }

        .auto-style3 {
            text-align: left;
            width: 217px;
        }

        .auto-style4 {
            text-align: left;
            width: 214px;
        }

        .auto-style7 {
            text-align: right;
            font-weight: normal;
        }

        .auto-style8 {
            text-align: left;
        }

        .auto-style10 {
            border-left: #ccc 1px solid;
            border-right: #ccc 1px solid;
            border-bottom: #ccc 1px solid;
            margin-bottom: 1px;
            padding-top: 2px;
            overflow: auto;
            scrollbar-face-color: #e4e4e4;
            scrollbar-heightlight-color: #f0f0f0;
            scrollbar-3dlight-color: #d6d6d6;
            scrollbar-arrow-color: #240024;
            scrollbar-darkshadow-color: #d6d6d6;
            background: #F7F7F7;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="btnbartitle">
            <div>
                维修单据管理
            </div>
        </div>

        <div class="auto-style10">
            <div style="float: right;">
                <asp:LinkButton ID="Save" runat="server" class="button green" OnClick="Save_Button">保 存</asp:LinkButton>
                <asp:LinkButton ID="lbtUserAdd" runat="server" class="button green">完 工</asp:LinkButton>
                <asp:LinkButton ID="lbtUserEdit" runat="server" class="button green">结 算</asp:LinkButton>
                <asp:LinkButton ID="lbtUserDel" runat="server" class="button green">打 印</asp:LinkButton>
            </div>
        </div>
        
        <asp:LinkButton ID="Create_Customer" runat="server" class="button green" OnClientClick="add()">添加客户</asp:LinkButton>
        <asp:LinkButton ID="Select_Customer" runat="server" class="button green" OnClientClick="select()">选择客户</asp:LinkButton>
        <div class="auto-style2">
            <table id="table1" border="0" cellpadding="0" cellspacing="0" class="auto-style1">
                <tr>
                    <th class="auto-style7">最新里程： </th>
                    <td class="auto-style3">
                        <input id="m_LatestMileage" runat="server" type="text" class="txt" datacol="yes" err="最新里程"
                            checkexpession="NotNull" style="width: 200px" /></td>
                    <th class="auto-style7">上次里程：
                    </th>
                    <td class="auto-style4">
                        <input id="w_CommodityName" runat="server" type="text" class="txt" datacol="yes" err="上次里程"
                            checkexpession="NotNull" style="width: 200px" /></td>
                    <td class="auto-style2">历史消费：</td>
                    <td class="auto-style8">
                        <input id="w_CommodityName0" runat="server" type="text" class="txt" datacol="yes" err="历史消费"
                            checkexpession="NotNull" style="width: 200px" /></td>
                </tr>
                <tr>
                    <th class="auto-style7">接待人员：</th>
                    <td>
                        <asp:DropDownList ID="c_CustomerType" runat="server" class="txt" Style="width: 205px; height: 25px"></asp:DropDownList>

                    </td>
                    <th class="auto-style7">车型：</th>
                    <td class="auto-style4">
                        <input id="w_InitialCostPrice" runat="server" type="text" class="txt" datacol="yes" err="车型"
                            checkexpession="NotNull" style="width: 200px" /></td>
                    <td class="auto-style2">历史单数：</td>
                    <td class="auto-style8">
                        <input id="w_CommodityName1" runat="server" type="text" class="txt" datacol="yes" err="历史单数"
                            checkexpession="NotNull" style="width: 200px" /></td>
                </tr>
                <tr>
                    <th class="auto-style7">业务类型：</th>
                    <td class="auto-style3">
                        <input type="text" id="m_ServiceType" datacol="yes" class="txt" runat="server" style="width: 200px;" /></td>
                    <th class="auto-style7">车身颜色：</th>
                    <td class="auto-style4">
                        <input id="w_brand" runat="server" type="text" class="txt" datacol="yes" err="车身颜色"
                            checkexpession="NotNull" style="width: 200px" /></td>
                    <td class="auto-style2">历史欠数：</td>
                    <td class="auto-style8">
                        <input id="w_CommodityName2" runat="server" type="text" class="txt" datacol="yes" err="历史欠数"
                            checkexpession="NotNull" style="width: 200px" /></td>
                </tr>
                <tr>
                    <th class="auto-style7">送修人：</th>
                    <td class="auto-style3">
                        <input id="m_RepairPerson" runat="server" type="text" class="txt" datacol="yes" err="送修人"
                            checkexpession="NotNull" style="width: 200px" /></td>
                    <th class="auto-style7">故障描述：</th>
                    <td class="auto-style4">
                        <input id="m_FaultDescription" runat="server" type="text" class="txt" datacol="yes" err="故障描述"
                            checkexpession="NotNull" style="width: 200px" /></td>
                    <td class="auto-style2">维修建议：</td>
                    <td class="auto-style8">
                        <input id="m_MaintenanceSuggestion" runat="server" type="text" class="txt" datacol="yes" err="维修建议"
                            checkexpession="NotNull" style="width: 200px" /></td>
                </tr>
                <tr>
                    <th class="auto-style7">备注：</th>
                    <td class="auto-style3">
                        <input id="m_Remarks" runat="server" type="text" class="txt" datacol="yes" err="备注"
                            checkexpession="NotNull" style="width: 200px" /></td>
                    <th class="auto-style7">&nbsp;</th>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                </tr>
            </table>
        </div>
        <div class="auto-style10">
            <div style="float: right;">
                &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" class="button green">选 择</asp:LinkButton>
                <asp:LinkButton ID="LinkButton4" runat="server" class="button green">新 建</asp:LinkButton>
            </div>
            项目明细
        </div>
        <div>
            <table id="table2" class="grid" singleselect="true">
                <thead>
                    <tr>
                        <td style="width: 3%; text-align: left;"></td>
                        <td style="width: 3%; text-align: center;">序号
                        </td>
                        <td style="width: 10%; text-align: center;">项目编码
                        </td>
                        <td style="width: 10%; text-align: center;">项目名称
                        </td>
                        <td style="width: 4%; text-align: center;">单价
                        </td>
                        <td style="width: 5%; text-align: center;">工时
                        </td>
                        <td style="width: 5%; text-align: center;">优惠
                        </td>
                        <td style="width: 10%; text-align: center;">金额
                        </td>
                        <td style="width: 10%; text-align: center;">开始时间
                        </td>
                        <td style="width: 10%; text-align: center;">完工时间
                        </td>
                        <td style="width: 10%; text-align: center;">施工人员
                        </td>
                        <td style="width: 10%; text-align: center;">项目分类
                        </td>
                        <td style="width: 10%; text-align: center;">项目备注
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rp_Item" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 3%; text-align: left;">
                                    <input type="checkbox" value="<%#Eval("w_guid")%>" name="checkbox" id="checkbox" />
                                </td>
                                <td style="width: 3%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("w_EncodingMerchandise")%>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("w_EncodingMerchandise")%>
                                </td>
                                <td style="width: 4%; text-align: center;">
                                    <%#Eval("w_EncodingMerchandise")%>
                                </td>
                                <td style="width: 5%; text-align: center;">
                                    <%#Eval("w_EncodingMerchandise")%>
                                </td>
                                <td style="width: 5%; text-align: center;">
                                    <%#Eval("w_EncodingMerchandise")%>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("w_EncodingMerchandise")%>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("w_EncodingMerchandise")%>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("w_EncodingMerchandise")%>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("w_EncodingMerchandise")%>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("w_EncodingMerchandise")%>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("w_EncodingMerchandise")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <% if (rp_Item != null)
                                {
                                    if (rp_Item.Items.Count == 0)
                                    {
                                        Response.Write("<tr><td colspan='13' style='color:red;text-align:center'>没有找到您要的相关数据！</td></tr>");
                                    }
                                } %>
                        </FooterTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div class="auto-style10">
            <div style="float: right;">
                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" class="button green">选 择</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" class="button green">新 建</asp:LinkButton>
            </div>
            商品明细
        </div>
        <div>
            <table id="table3" class="grid" singleselect="true">
                <thead>
                    <tr>
                        <td style="width: 3%; text-align: left;"></td>
                        <td style="width: 3%; text-align: center;">序号
                        </td>
                        <td style="width: 10%; text-align: center;">商品编码
                        </td>
                        <td style="width: 10%; text-align: center;">商品名称
                        </td>
                        <td style="width: 4%; text-align: center;">品牌
                        </td>
                        <td style="width: 10%; text-align: center;">规格
                        </td>
                        <td style="width: 10%; text-align: center;">适用车型
                        </td>
                        <td style="width: 5%; text-align: center;">单位
                        </td>
                        <td style="width: 5%; text-align: center;">销售单价
                        </td>
                        <td style="width: 5%; text-align: center;">数量
                        </td>
                        <td style="width: 5%; text-align: center;">优惠
                        </td>
                        <td style="width: 10%; text-align: center;">金额
                        </td>
                        <td style="width: 10%; text-align: center;">领料人员
                        </td>
                        <td style="width: 10%; text-align: center;">商品备注
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 3%; text-align: left;">
                                    <input type="checkbox" value="<%#Eval("w_guid")%>" name="checkbox" id="checkbox" />
                                </td>
                                <td style="width: 3%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 4%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 5%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 5%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 5%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 5%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("w_number")%></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <% if (rp_Item != null)
                                {
                                    if (rp_Item.Items.Count == 0)
                                    {
                                        Response.Write("<tr><td colspan='14' style='color:red;text-align:center'>没有找到您要的相关数据！</td></tr>");
                                    }
                                } %>
                        </FooterTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
