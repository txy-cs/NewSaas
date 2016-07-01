<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NS_StoreInformation.aspx.cs" Inherits="WebFormMvcFramework.Web.WMFBase.NewSaaS.NS_StoreInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Themes/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../Themes/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/Validator/JValidator.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/artDialog/artDialog.source.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/artDialog/iframeTools.source.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/TreeTable/jquery.treeTable.js" type="text/javascript"></script>
    <link href="../../Themes/Scripts/TreeTable/css/jquery.treeTable.css" rel="stylesheet" type="text/css" />
    <link href="../../Themes/Scripts/TreeView/treeview.css" rel="stylesheet" type="text/css" />
    <script src="../../Themes/Scripts/TreeView/treeview.pack.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/FunctionJS.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        * {
            font-size: 9pt;
        }

        * {
            font-size: 9pt;
        }

        .frmtop {
            margin-bottom: 1px;
            border-bottom: 1px solid #ccc;
            height: auto;
        }

        .div-frm {
            overflow: auto;
            scrollbar-face-color: #e4e4e4;
            scrollbar-heightlight-color: #f0f0f0;
            scrollbar-3dlight-color: #d6d6d6;
            scrollbar-arrow-color: #240024;
            scrollbar-darkshadow-color: #d6d6d6;
        }

        .frm {
            width: 82%;
            margin-bottom: 1px;
        }

            .frm th {
                width: 80px;
                border-bottom: 1px solid #ccc;
                height: 25px;
                line-height: 25px;
                white-space: nowrap;
                font-weight: normal;
                text-align: right;
                padding-right: 5px;
                padding-left: 20px;
            }

            .frm td {
                height: 25px;
                line-height: 25px;
                border-bottom: 1px solid #ccc;
                padding-left: 10px;
                word-break: break-all;
                padding-right: 2px;
                padding-top: 2px;
                padding-bottom: 2px;
            }

                .frm td .txt {
                    border: 1px solid #A8A8A8;
                    font: Verdana, Geneva, sans-serif,宋体;
                    background-image: url(../../Themes/Images/input_text_bg.gif);
                    padding: 3px 2px 2px 2px;
                    height: 15px;
                    line-height: 15px;
                }

        .txt {
            border: 1px solid #A8A8A8;
            background-image: url(../../Themes/Images/input_text_bg.gif);
            background-position: left top;
            padding: 3px 2px 2px 2px;
            height: 15px;
            line-height: 14px;
        }

        .select {
            border: 1px solid #A8A8A8;
            height: 22px;
            line-height: 20px;
        }

        .txtRemark {
            font: Verdana, Geneva, sans-serif,宋体;
            border: 1px solid #A8A8A8;
        }

        .btnbartitle {
            border-top: #ccc 1px solid;
            border-left: #ccc 1px solid;
            border-right: #ccc 1px solid;
            background-image: url('../../Themes/images/datagrid_header_bg.gif');
            background-repeat: repeat-x;
            height: 27px;
            font-weight: bold;
        }

        .div-body {
            border: #ccc 1px solid;
            border-top: #ccc 0px solid;
            overflow: auto;
            scrollbar-face-color: #e4e4e4;
            scrollbar-heightlight-color: #f0f0f0;
            scrollbar-3dlight-color: #d6d6d6;
            scrollbar-arrow-color: #240024;
            scrollbar-darkshadow-color: #d6d6d6;
        }

        .example {
            margin: 0px;
            border-collapse: collapse;
            width: 100%;
        }

            .example thead tr td {
                border-top: 1px solid #ccc;
                border-bottom: 1px solid #ccc;
                border-right: 1px dotted #ccc;
                background: url(../../Themes/Images/datagrid_header_bg.gif) repeat-x;
                padding: 5px 1px;
                font-weight: normal;
                text-overflow: ellipsis;
                word-break: keep-all;
                overflow: hidden;
            }

        #checkAllOff {
            padding-left: 20px;
            background: url(../../Themes/Images/checkAllOff.gif) no-repeat scroll 4px 2px;
            cursor: pointer;
        }

        .frmbottom {
            text-align: center;
            height: auto;
            margin-top: 10px;
            vertical-align: middle;
        }

        a:link {
            color: #222;
            text-decoration: none;
        }

        .l-btn {
            background: url('../../Themes/images/button_a_bg.gif') no-repeat top right;
            text-decoration: none;
            display: inline-block;
            zoom: 1;
            height: 26px;
            padding-right: 18px;
            cursor: pointer;
            outline: none;
        }

        .l-btn-left {
            display: inline-block;
            background: url('../../Themes/images/button_span_bg.gif') no-repeat top left;
            padding: 4px 0px 4px 18px;
            line-height: 16px;
            height: 18px;
        }

        .auto-style1 {
            font-weight: bold;
            color: white;
            display: inline-block;
            width: 85px;
            line-height: 26px;
            height: 26px;
            vertical-align: bottom;
            float: left;
            cursor: pointer;
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            margin-top: 3px;
            padding-left: 20px;
            background: url('../../Themes/Images/title_over1.png') no-repeat left 50%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="frmtop">
            <table style="padding: 0px; margin: 0px; height: 100%;" cellpadding="0" cellspacing="0">
                <tr>
                    <td id="menutab" style="vertical-align: bottom;">
                        <div id="tab0" class="auto-style1" onclick="GetTabClick(this);panel(1)" style="outline: none;">
                            门店信息
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="div-frm" style="height: 275px;">
            <%--基本信息--%>
            <table id="table1" border="0" cellpadding="0" cellspacing="0" class="frm">
                <tr>
                    <th>门店名称:</th>
                    <td>
                        <input id="s_StoreName" runat="server" type="text" class="txt" err="登录账户"
                            checkexpession="NotNull" style="width: 200px" /></td>
                    <th>&nbsp;公司法人: </th>
                    <td><input id="s_CorporationLegalPerson" runat="server" type="text" class="txt" err="职工姓名"
                        checkexpession="NotNull" style="width: 200px" /></td>
                </tr>
                <tr>
                    <th>省份:
                    </th>
                    <td>
                        <asp:DropDownList ID="s_Province" runat="server" class="txt" style="width: 205px;height:25px" AutoPostBack="True" OnSelectedIndexChanged="s_Province_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <th>&nbsp;城市:
                    </th>
                    <td>
                    <asp:DropDownList ID="s_City" runat="server" class="txt" style="width: 205px;height:25px" ></asp:DropDownList>
                </tr>
                <tr>
                    <th>门店地址:
                    </th>
                    <td>
                        <input id="s_StoreAddress" runat="server" type="text" class="txt" style="width: 200px" />
                    </td>
                    <th>联系人:
                    </th>
                    <td>
                        <input type="text" id="s_contacts" datacol="yes" class="txt" runat="server" style="width: 200px;" />
                    </td>
                </tr>
                <tr>
                    <th>法人手机: </th>
                    <td>
                        <input type="text" id="s_CorporateMobilePhone" datacol="yes" class="txt" runat="server" style="width: 200px;" />
                    </td>
                    <th>联系手机: </th>
                    <td>
                        <input type="text" id="s_phone" datacol="yes" class="txt" runat="server" style="width: 200px;" /></td>
                </tr>
                <tr>
                    <th>服务电话:</th>
                    <td>
                        <input type="text" id="s_ServiceTelephone" datacol="yes" class="txt" runat="server" style="width: 200px;" /></td>
                    <th>救援电话:</th>
                    <td>
                        <input type="text" id="s_RescueTelephone" datacol="yes" class="txt" runat="server" style="width: 200px;" /></td>
                </tr>
                <tr>
                    <th>打印备注:</th>
                    <td>
                        <input type="text" id="s_PrintNotes" datacol="yes" class="txt" runat="server" style="width: 200px;" /></td>
                    <th>&nbsp;</th>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <th>广告语:
                    </th>
                    <td colspan="3">
                        <textarea id="s_AdvertisingLanguage" class="txtRemark" runat="server" style="width: 552px; height: 83px;" cols="20" name="S1" rows="1"></textarea>
                    </td>
                </tr>
            </table>
        </div>
        <div class="frmbottom">
            <asp:LinkButton ID="Save" runat="server" class="l-btn" OnClick="Save_Click"><span class="l-btn-left">
            <img src="../../Themes/Images/disk.png" alt="" />保 存</span></asp:LinkButton>
        </div>
    </form>
</body>
</html>
