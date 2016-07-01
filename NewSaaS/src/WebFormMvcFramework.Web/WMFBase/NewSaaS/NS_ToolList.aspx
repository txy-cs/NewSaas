<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NS_ToolList.aspx.cs" Inherits="WebFormMvcFramework.Web.WMFBase.NewSaaS.NS_ToolList" %>

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
            var url = "../WMFBase/NewSaaS/NS_ToolAdd.aspx";
            top.openDialog(url, 'NS_ToolAdd', '工具 - 添加', 650, 150, 50, 50);
        }
        //删除
        function Delete() {
            var key = CheckboxValue();
            if (key != "") {
                $("#hf_c_guid").val(key);
                return true;
            }
            else {
                showTipsMsg("删除失败！", 2000, 4);
                return false;
            }
        }
        function USE() {
            var key = CheckboxValue();
            if (key != "") {
                var url = "../WMFBase/NewSaaS/NS_ToolUse.aspx?Key=" + key + "";
                top.openDialog(url, 'NS_ToolUse', '工具 - 领用', 650, 150, 50, 50);
            }
            else {
                showTipsMsg("领用失败！", 2000, 4);
            }
        }
        function Return() {
            var key = CheckboxValue();
            if (key != "") {
                $("#hf_c_guid").val(key);
                return true;
            }
            else {
                showTipsMsg("归还失败！", 2000, 4);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" onload="Page_Load">
        <div class="btnbartitle">
            <div>
                工具列表
            </div>
        </div>
        <div class="btnbarcontetn">
            <div style="float: right;">
                查询条件
                <input id="u_select" runat="server" type="text" class="txt" datacol="yes" err="查询条件"
                    checkexpession="NotNull" style="width: 200px; height: 25px" />
                <asp:LinkButton ID="lbtUserSel" runat="server" class="button green" OnClick="lbtUserSel_Click">查 询</asp:LinkButton>
                <asp:LinkButton ID="lbtUserAdd" runat="server" class="button green" OnClientClick="add()">新增工具</asp:LinkButton>
                <asp:LinkButton ID="lbtUserDel" runat="server" class="button green" OnClientClick="return Delete();" OnClick="lbtUserDel_Click">删除工具</asp:LinkButton>
                    <asp:LinkButton ID="lbtUserUse" runat="server" class="button green" OnClientClick="USE()">领用工具</asp:LinkButton>
                   <asp:LinkButton ID="lbtReturn" runat="server" class="button green" OnClientClick="Return()" OnClick="lbtReturn_Click">归还工具</asp:LinkButton>
            </div>
        </div>
        <div class="div-body">
            <table id="table1" class="grid" singleselect="true">
                <thead>
                    <tr>
                        <td style="width: 5%; text-align: left;"></td>
                        <td style="width: 5%; text-align: center;">序号
                        </td>
                        <td style="width: 10%; text-align: center;">名称
                        </td>
                        <td style="width: 10%; text-align: center;">状态
                        </td>
                        <td style="width: 10%; text-align: center;">领用人
                        </td>
                        <td style="width: 20%; text-align: center;">领用时间
                        </td>
                        <td style="width: 40%; text-align: center;">备注
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rp_Item" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 5%; text-align: left;">
                                    <input type="checkbox" value="<%#Eval("c_guid")%>" name="checkbox" id="checkbox" />
                                </td>
                                <td style="width: 5%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("c_number")%></a>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("c_name")%>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("c_StateName")%>
                                </td>
                                <td style="width: 10%; text-align: center;">
                                    <%#Eval("u_name")%>
                                </td>
                                <td style="width: 20%; text-align: center;">
                                    <%#Eval("c_LeadTime")%>
                                </td>
                                <td style="width: 40%; text-align: center;">
                                    <%#Eval("c_Remarks")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <% if (rp_Item != null)
                                {
                                    if (rp_Item.Items.Count == 0)
                                    {
                                        Response.Write("<tr><td colspan='8' style='color:red;text-align:center'>没有找到您要的相关数据！</td></tr>");
                                    }
                                } %>
                        </FooterTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <asp:HiddenField ID="hf_c_guid" runat="server" />
    </form>
</body>
</html>
