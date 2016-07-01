<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NS_ProjectTypeList.aspx.cs" Inherits="WebFormMvcFramework.Web.WMFBase.NewSaaS.NS_ProjectTypeList" %>

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
            var url = "../WMFBase/NewSaaS/NS_ProjectTypeAdd.aspx";
            top.openDialog(url, 'NS_ProjectTypeAdd', '项目分类 - 添加', 650, 150, 50, 50);
        }
        //编辑
        function Edit() {
            var key = CheckboxValue();
            if (key != "") {
                var url = "../WMFBase/NewSaaS/NS_ProjectTypeEdit.aspx?Key=" + key + "";
                top.openDialog(url, 'NS_ProjectTypeEdit', '项目分类 - 编辑', 650, 150, 50, 50);
            }
            else {
                showTipsMsg("编辑失败！", 2000, 4);
            }
        }
        //删除
        function Delete() {
            var key = CheckboxValue();
            if (key != "") {
                $("#hf_p_guid").val(key);
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
                项目分类列表
            </div>
        </div>
        <div class="btnbarcontetn">
            <div style="float: right;">
                  查询条件
                <input id="u_select" runat="server" type="text" class="txt" datacol="yes" err="查询条件"
                    checkexpession="NotNull" style="width: 200px; height: 25px" />
                <asp:LinkButton ID="lbtUserSel" runat="server" class="button green" OnClick="lbtUserSel_Click">查 询</asp:LinkButton>
                <asp:LinkButton ID="lbtUserAdd" runat="server" class="button green" OnClientClick="add()" >添 加</asp:LinkButton>
                <asp:LinkButton ID="lbtUserEdit" runat="server" class="button green" OnClientClick="Edit()" >编 辑</asp:LinkButton>
                <asp:LinkButton ID="lbtUserDel" runat="server" class="button green" OnClientClick="return Delete();" OnClick="lbtUserDel_Click">删 除</asp:LinkButton>
            </div>
        </div>
        <div class="div-body">
            <table id="table1" class="grid" singleselect="true">
                <thead>
                    <tr>
                        <td style="width: 10%; text-align: left;"></td>
                        <td style="width: 20%; text-align: center;">序号
                        </td>
                        <td style="width: 70%; text-align: center;">名称
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rp_Item" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="width: 10%; text-align: left;">
                                    <input type="checkbox" value="<%#Eval("p_guid")%>" name="checkbox" id="checkbox" />
                                </td>
                                <td style="width: 20%; text-align: center;">
                                    <a href="javascript:void()">
                                        <%#Eval("p_number")%></a>
                                </td>
                                <td style="width: 70%; text-align: center;">
                                    <%#Eval("p_name")%>
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
        <asp:HiddenField ID="hf_p_guid" runat="server" />
    </form>
</body>
</html>
