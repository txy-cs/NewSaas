<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NS_WarehouseList.aspx.cs" Inherits="WebFormMvcFramework.Web.WMFBase.NewSaaS.NS_WarehouseList" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Themes/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../Themes/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/jquery.pullbox.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/FunctionJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        //新增
        function add() {
            var url = "../WMFBase/NewSaaS/NS_WarehouseAdd.aspx";
            top.openDialog(url, 'NS_WarehouseAdd', '商品 - 添加', 650, 350, 50, 50);
        }
        //编辑
        function Edit() {
            var key = CheckboxValue();
            if (key != "") {
                var url = "../WMFBase/NewSaaS/NS_WarehouseEdit.aspx?Key=" + key + "";
                top.openDialog(url, 'NS_WarehouseEdit', '商品 - 编辑', 650, 350, 50, 50);
            }
            else {
                showTipsMsg("编辑失败！", 2000, 4);
            }
        }
        //删除
        function Delete() {
            var key = CheckboxValue();
            if (key != "") {
                $("#hf_w_guid").val(key);
                return true;
            }
            else {
                showTipsMsg("删除失败！", 2000, 4);
                return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" onload="Page_Load">
        <div class="btnbartitle">
            <div>
                商品列表
            </div>
        </div>
        <div class="btnbarcontetn">
            <div style="float: right;">
                查询条件
                <input id="u_select" runat="server" type="text" class="txt" datacol="yes" err="查询条件"
                    checkexpession="NotNull" style="width: 200px; height: 25px" />
                <asp:LinkButton ID="lbtUserSel" runat="server" class="button green" OnClick="lbtUserSel_Click">查 询</asp:LinkButton>
                <asp:LinkButton ID="lbtUserAdd" runat="server" class="button green" OnClientClick="add()">新增商品</asp:LinkButton>
                <asp:LinkButton ID="lbtUserEdit" runat="server" class="button green" OnClientClick="Edit()">编 辑</asp:LinkButton>
                <asp:LinkButton ID="lbtUserDel" runat="server" class="button green" OnClientClick="return Delete();" OnClick="lbtUserDel_Click">删 除</asp:LinkButton>
                <asp:LinkButton ID="lbtExport" runat="server" class="button green" OnClientClick="getHtmltoValue()" OnClick="lbtExport_Click">导 出</asp:LinkButton>
            </div>
        </div>
        <div class="div-body" id="printDiv">
            <table id="table1" class="grid" singleselect="true">
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
                        <td style="width: 5%; text-align: center;">规格
                        </td>
                        <td style="width: 5%; text-align: center;">单位
                        </td>
                        <td style="width: 10%; text-align: center;">适用车牌号
                        </td>
                        <td style="width: 10%; text-align: center;">适用车型
                        </td>
                          <td style="width: 5%; text-align: center;">库存
                        </td>
                          <td style="width: 5%; text-align: center;">成本价
                        </td>
                          <td style="width: 5%; text-align: center;">销售价
                        </td>
                          <td style="width: 10%; text-align: center;">上次采购价
                        </td>
                          <td style="width: 5%; text-align: center;">库存总额
                        </td>
                          <td style="width: 10%; text-align: center;">供应商名称
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
                                    <%#Eval("w_CommodityName")%>
                                </td>
                                <td style="width: 4%; text-align: center;">
                                    <%#Eval("w_brand")%>
                                </td>
                                <td style="width: 5%; text-align: center;">
                                    <%#Eval("w_Specifications")%>
                                </td>
                                <td style="width: 5%; text-align: center;">
                                    <%#Eval("w_Company")%>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("w_ApplicableLicensePlateNumber")%>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("w_ApplicableModels")%>
                                </td>
                                   <td style="width: 5%; text-align: center;">
                                    <%#Eval("w_InitialInventory")%>
                                </td>
                                  <td style="width: 5%; text-align: center;">
                                    <%#Eval("w_InitialCostPrice")%>
                                </td>
                                   <td style="width: 5%; text-align: center;">
                                    <%#Eval("w_SalePrice")%>
                                </td>
                                    <td style="width: 10%; text-align: center;">
                                    <%#Eval("w_LastPurchasePrice")%>
                                </td>
                                      <td style="width: 5%; text-align: center;">
                                    <%#Eval("w_TotalInventory")%>
                                </td>
                                     <td style="width: 10%; text-align: center;">
                                    <%#Eval("w_SupplierName")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <% if (rp_Item != null)
                                {
                                    if (rp_Item.Items.Count == 0)
                                    {
                                        Response.Write("<tr><td colspan='15' style='color:red;text-align:center'>没有找到您要的相关数据！</td></tr>");
                                    }
                                } %>
                        </FooterTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <asp:HiddenField ID="hf_w_guid" runat="server" />
        <asp:HiddenField ID="printHid" runat="server" />
        <script type="text/javascript">
            function getHtmltoValue() {
                document.getElementById("<%=printHid.ClientID%>").value = document.getElementById("printDiv").innerHTML;
         }
        </script>
    </form>
</body>
</html>