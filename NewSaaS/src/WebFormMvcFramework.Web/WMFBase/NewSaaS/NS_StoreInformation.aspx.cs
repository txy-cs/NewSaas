using System;
using System.Data;
using System.Web;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_StoreInformation : System.Web.UI.Page
    {
        private string StrSql = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable SaaS_Province = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_Province").Copy();
                s_Province.DataValueField = "ProvinceID";
                s_Province.DataTextField = "ProvinceName";
                s_Province.DataSource = SaaS_Province.Copy();
                s_Province.DataBind();

                DataTable SaaS_StoreInformation = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_StoreInformation where(u_guid='" + HttpContext.Current.Session["u_UserParent"] + "')").Copy();
                if (SaaS_StoreInformation.Rows.Count > 0)
                {
                    s_StoreName.Value = SaaS_StoreInformation.Rows[0]["s_StoreName"].ToString();
                    s_Province.SelectedValue = SaaS_StoreInformation.Rows[0]["s_Province"].ToString();
                    s_Province_SelectedIndexChanged(null, null);
                    s_City.SelectedValue = SaaS_StoreInformation.Rows[0]["s_City"].ToString();
                    s_StoreAddress.Value = SaaS_StoreInformation.Rows[0]["s_StoreAddress"].ToString();
                    s_contacts.Value = SaaS_StoreInformation.Rows[0]["s_contacts"].ToString();
                    s_phone.Value = SaaS_StoreInformation.Rows[0]["s_phone"].ToString();
                    s_CorporationLegalPerson.Value = SaaS_StoreInformation.Rows[0]["s_CorporationLegalPerson"].ToString();
                    s_CorporateMobilePhone.Value = SaaS_StoreInformation.Rows[0]["s_CorporateMobilePhone"].ToString();
                    s_ServiceTelephone.Value = SaaS_StoreInformation.Rows[0]["s_ServiceTelephone"].ToString();
                    s_RescueTelephone.Value = SaaS_StoreInformation.Rows[0]["s_RescueTelephone"].ToString();
                    s_PrintNotes.Value = SaaS_StoreInformation.Rows[0]["s_PrintNotes"].ToString();
                    s_AdvertisingLanguage.Value = SaaS_StoreInformation.Rows[0]["s_AdvertisingLanguage"].ToString();
                }
                else
                {
                    StrSql = " INSERT INTO[dbo].[SaaS_StoreInformation]   ";
                    StrSql += "        ( [u_guid]   ";
                    StrSql += "        ,[s_CreationTime])   ";
                    StrSql += "          VALUES   ";
                    StrSql += "  (  ";
                    StrSql += "  '"+ HttpContext.Current.Session["u_UserParent"] .ToString()+ "', ";
                    StrSql += "  '" +DateTime.Now.ToString() + "' ";
                    StrSql += "  )  ";
                    DataFactory.SqlDataBase().Affected(StrSql.ToString());
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            StrSql = "       UPDATE[dbo].[SaaS_StoreInformation]  ";
            StrSql +=" SET [s_StoreName] = '"+ s_StoreName.Value + "' ";
            StrSql += "   ,[s_Province] = '"+ s_Province .SelectedItem.Value+ "'  ";
            StrSql += "  ,[s_City] = '"+ s_City .SelectedItem.Value+ "'  ";
            StrSql += "     ,[s_StoreAddress] = '"+ s_StoreAddress .Value+ "'   ";
            StrSql += "   ,[s_contacts] = '"+ s_contacts .Value+ "'  ";
            StrSql += "    ,[s_phone] = '"+ s_phone .Value+ "'  ";
            StrSql += "    ,[s_CorporationLegalPerson] = '"+ s_CorporationLegalPerson .Value+ "'   ";
            StrSql += "    ,[s_CorporateMobilePhone] = '"+ s_CorporateMobilePhone.Value + "'  ";
            StrSql += "     ,[s_ServiceTelephone] = '"+ s_ServiceTelephone.Value + "'  ";
            StrSql += "     ,[s_RescueTelephone] = '"+ s_RescueTelephone .Value+ "'   ";
            StrSql += "     ,[s_PrintNotes] = '"+ s_PrintNotes .Value+ "'  ";
            StrSql += "     ,[s_AdvertisingLanguage] = '"+ s_AdvertisingLanguage .Value+ "'  ";
            StrSql += "      WHERE u_guid='"+ HttpContext.Current.Session["u_UserParent"].ToString() + "'  ";
            if (DataFactory.SqlDataBase().Affected(StrSql.ToString()) > 0)
            {
                ShowMsgHelper.showFaceMsg("保存成功！");
            }
        }

        protected void s_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable SssS_City = DataFactory.SqlDataBase().ReturnDataTable("select * from SssS_City where(ProvinceID='"+ s_Province .SelectedValue+ "')").Copy();
            s_City.DataValueField = "CityID";
            s_City.DataTextField = "CityName";
            s_City.DataSource = SssS_City.Copy();
            s_City.DataBind();
        }
    }
}