<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NS_StaffList.aspx.cs" Inherits="WebFormMvcFramework.Web.WMFBase.NewSaaS.NS_StaffList" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Themes/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../Themes/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/jquery.pullbox.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/FunctionJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        //新增员工
        function add() {
            var url = "../WMFBase/NewSaaS/NS_StaffAdd.aspx";
            top.openDialog(url, 'NS_StaffAdd', '员工信息 - 添加', 700, 350, 50, 50);
        }
        //编辑员工
        function Edit() {
            var key = CheckboxValue();
            if (key != "") {
                var url = "../WMFBase/NewSaaS/NS_StaffEdit.aspx?Key=" + key + "";
                top.openDialog(url, 'NS_StaffEdit', '员工信息 - 编辑', 700, 350, 50, 50);
            }
            else {
                showTipsMsg("编辑失败！", 2000, 4);
            }
        }
        //删除员工
        function Delete() {
            var key = CheckboxValue();
            if (key != "") {
                $("#hf_U_Guid").val(key);
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
                员工信息列表
            </div>
        </div>
        <div class="btnbarcontetn">
            <div style="float: right;">
                  查询条件
                <input id="u_select" runat="server" type="text" class="txt" datacol="yes" err="查询条件"
                    checkexpession="NotNull" style="width: 200px; height: 25px" />
                <asp:LinkButton ID="lbtUserSel" runat="server" class="button green" OnClick="lbtUserSel_Click">查 询</asp:LinkButton>
                <asp:LinkButton ID="lbtUserAdd" runat="server" class="button green" OnClientClick="add()">新增员工</asp:LinkButton>
                <asp:LinkButton ID="lbtUserEdit" runat="server" class="button green" OnClientClick="Edit()">编 辑</asp:LinkButton>
                <asp:LinkButton ID="lbtUserDel" runat="server" class="button green" OnClientClick="return Delete();" OnClick="lbtUserDel_Click">删 除</asp:LinkButton>
            </div>
        </div>
        <div class="div-body">
            <table id="table1" class="grid" singleselect="true">
                <thead>
                    <tr>
                        <td style="width: 20px; text-align: left;"></td>
                        <td style="width: 40px; text-align: center;">名称
                        </td>
                        <td style="width: 100px; text-align: center;">联系手机
                        </td>
                        <td style="width: 100px; text-align: center;">身份证号
                        </td>
                        <td style="width: 80px; text-align: center;">入职日期
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rp_Item" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 20px; text-align: left;">
                                    <input type="checkbox" value="<%#Eval("u_guid")%>" name="checkbox" id="checkbox" />
                                </td>
                                <td style="width: 40px; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("u_Name")%></a>
                                </td>
                                <td style="width: 100px; text-align: center;">
                                    <%#Eval("u_phone")%>
                                </td>
                                <td style="width: 100px; text-align: center;">
                                    <%#Eval("u_IDCardNumber")%>
                                </td>
                                <td style="width: 80px; text-align: center;">
                                    <%#Eval("u_EntryDate")%>
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
        <asp:HiddenField ID="hf_U_Guid" runat="server" />
    </form>
</body>
</html>
