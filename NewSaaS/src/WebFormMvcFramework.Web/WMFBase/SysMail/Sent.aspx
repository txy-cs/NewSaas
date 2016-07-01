<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sent.aspx.cs" Inherits="WebFormMvcFramework.Web.WMFBase.SysMail.Sent" %>

<%@ Register Src="~/UserControl/Paging.ascx" TagPrefix="uc2" TagName="Paging" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Themes/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../Themes/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/FunctionJS.js" type="text/javascript"></script>
    <title>已发送</title>
    <script type="text/javascript">
        function GetCheckboxValue() {
            var key = CheckboxValue();
            if (key == "") {
                showWarningMsg('请选择数据！');
                return false;
            }
            else {
                document.getElementById("HF_KEY").value = key;
                return true;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="btnbartitle">
            <div>
                已发送
            </div>
        </div>
        <div style="text-align: right">
            <asp:LinkButton ID="lbut_delete" runat="server" class="button green" OnClick="lbut_delete_Click" OnClientClick="return GetCheckboxValue()" ><span class="icon-botton"
            style="background: url('../../Themes/images/16/email_delete.png') no-repeat scroll 0px 4px;"> </span>删 除</asp:LinkButton>
        </div>
        <table id="table1" class="grid">
            <thead>
                <tr>
                    <td style="width: 5%; text-align: left;">
                        <label id="checkAllOff" onclick="CheckAllLine()" title="全选">
                            &nbsp;</label>
                    </td>
                    <td style="width: 10%; text-align: center;">收件人
                             </td>
                    <td style="width: 65%; text-align:left;">主题
                    </td>
                    <td style="width: 15%; text-align: center;">时间
                    </td>
                    <td style="width: 5%; text-align: center;">大小
                    </td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rp_Item" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="width: 5%; text-align: left;">
                                <input type="checkbox" value="<%#Eval("Mail_Guid")%>" name="checkbox" />
                            </td>
                            <td style="width: 10%; text-align: center;">
                                <%#Eval("Mail_MR_UserAccount")%>
                            </td>
                            <td style="width: 65%; text-align:left;">
                                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl=<%# "~/WMFBase/SysMail/Details.aspx?Mail_Guid="+Eval("Mail_Guid") %>> <%#Eval("Mail_Name")%></asp:LinkButton>
                            </td>
                            <td style="width: 15%; text-align: center;">
                              <%# Convert.ToDateTime( Eval("Mail_CreateTime")).ToString("yyyy年MM月dd日HH时mm分")%>
                            </td>
                            <td style="width: 5%; text-align: left;"></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        <% if (rp_Item != null)
                           {
                               if (rp_Item.Items.Count == 0)
                               {
                                   Response.Write("<tr><td colspan='6' style='color:red;text-align:center'>没有找到您要的相关数据！</td></tr>");
                               }
                           } %>
                    </FooterTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <uc2:Paging runat="server" ID="Paging1" />
        <asp:HiddenField ID="HF_KEY" runat="server" />
    </form>
</body>
</html>
