using System;
using System.Data;
using System.Text;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_CustomerEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable SaaS_CustomerType = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_CustomerType").Copy();
                c_CustomerType.DataValueField = "c_guid";
                c_CustomerType.DataTextField = "c_name";
                c_CustomerType.DataSource = SaaS_CustomerType.Copy();
                c_CustomerType.DataBind();


                DataTable SaaS_Customer = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_Customer where(c_guid='" + Request.QueryString["Key"].ToString() + "')").Copy();
                c_ContactPhone.Value = SaaS_Customer.Rows[0]["c_ContactPhone"].ToString();
                c_ContacTelephone.Value = SaaS_Customer.Rows[0]["c_ContacTelephone"].ToString();
                c_CustomerName.Value = SaaS_Customer.Rows[0]["c_CustomerName"].ToString();
                c_CustomerNotes.Value = SaaS_Customer.Rows[0]["c_CustomerNotes"].ToString();
                c_ClientUnit.Value = SaaS_Customer.Rows[0]["c_ClientUnit"].ToString();
                c_LicensePlateNumber.Value = SaaS_Customer.Rows[0]["c_LicensePlateNumber"].ToString();
                c_CustomerType.SelectedValue = SaaS_Customer.Rows[0]["c_CustomerType"].ToString();
                c_BodyColor.Value = SaaS_Customer.Rows[0]["c_BodyColor"].ToString();
                c_LatestMileage.Value = SaaS_Customer.Rows[0]["c_LatestMileage"].ToString();
                c_BuyingTime.Value = SaaS_Customer.Rows[0]["c_BuyingTime"].ToString();
                c_FrameNumberVINCode.Value = SaaS_Customer.Rows[0]["c_FrameNumberVINCode"].ToString();
                c_Models.Value = SaaS_Customer.Rows[0]["c_Models"].ToString();
                c_EngineModel.Value = SaaS_Customer.Rows[0]["c_EngineModel"].ToString();
                c_NextMaintenance.Value = SaaS_Customer.Rows[0]["c_NextMaintenance"].ToString();
                c_NextTimeMaintenance.Value = SaaS_Customer.Rows[0]["c_NextTimeMaintenance"].ToString();
                c_NextTime.Value = SaaS_Customer.Rows[0]["c_NextTime"].ToString();
                c_nextAnnualTime.Value = SaaS_Customer.Rows[0]["c_nextAnnualTime"].ToString();
                c_NextTimeInsurance.Value = SaaS_Customer.Rows[0]["c_NextTimeInsurance"].ToString();
                c_insuranceCompany.Value = SaaS_Customer.Rows[0]["c_insuranceCompany"].ToString();
                c_InsuranceNotes.Value = SaaS_Customer.Rows[0]["c_InsuranceNotes"].ToString();
                c_VehicleNotes.Value = SaaS_Customer.Rows[0]["c_VehicleNotes"].ToString();
                c_number.Value = SaaS_Customer.Rows[0]["c_number"].ToString();
                c_EngineNumber.Value = SaaS_Customer.Rows[0]["c_EngineNumber"].ToString();
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("           UPDATE[dbo].[SaaS_Customer]   ");
            SqlWhere.Append("           SET [c_ContactPhone] = '" + c_ContactPhone.Value + "'   ");
            SqlWhere.Append("      ,[c_ContacTelephone] = '" + c_ContacTelephone.Value + "'   ");
            SqlWhere.Append("      ,[c_CustomerName] = '" + c_CustomerName.Value + "'   ");
            SqlWhere.Append("      ,[c_CustomerType] = '" + c_CustomerType.SelectedItem.Value + "'   ");
            SqlWhere.Append("      ,[c_CustomerNotes] = '" + c_CustomerNotes.Value + "'   ");
            SqlWhere.Append("       ,[c_ClientUnit] = '" + c_ClientUnit.Value + "'   ");
            SqlWhere.Append("      ,[c_LicensePlateNumber] = '" + c_LicensePlateNumber.Value + "'   ");
            SqlWhere.Append("     ,[c_BodyColor] = '" + c_BodyColor.Value + "'   ");
            SqlWhere.Append("      ,[c_LatestMileage] = '" + c_LatestMileage.Value + "'   ");
            SqlWhere.Append("       ,[c_BuyingTime] = '" + c_BuyingTime.Value + "'   ");
            SqlWhere.Append("      ,[c_FrameNumberVINCode] = '" + c_FrameNumberVINCode.Value + "'  ");
            SqlWhere.Append("      ,[c_Models] = '" + c_Models.Value + "'   ");
            SqlWhere.Append("     ,[c_EngineModel] = '" + c_EngineModel.Value + "'  ");
            SqlWhere.Append("     ,[c_EngineNumber] = '" + c_EngineNumber.Value + "'   ");
            SqlWhere.Append("      ,[c_NextMaintenance] = '" + c_NextMaintenance.Value + "'   ");
            SqlWhere.Append("     ,[c_NextTimeMaintenance] = '" + c_NextTimeMaintenance.Value + "'   ");
            SqlWhere.Append("     ,[c_NextTime] = '" + c_NextTime.Value + "'   ");
            SqlWhere.Append("      ,[c_nextAnnualTime] = '" + c_nextAnnualTime.Value + "'   ");
            SqlWhere.Append("     ,[c_NextTimeInsurance] = '" + c_NextTimeInsurance.Value + "'    ");
            SqlWhere.Append("     ,[c_insuranceCompany] ='" + c_insuranceCompany.Value + "'    ");
            SqlWhere.Append("     ,[c_InsuranceNotes] = '" + c_InsuranceNotes.Value + "'   ");
            SqlWhere.Append("    ,[c_VehicleNotes] ='" + c_VehicleNotes.Value + "'   ");
            SqlWhere.Append("    ,[c_number] = '" + c_number.Value + "'    ");
            SqlWhere.Append("    WHERE c_guid='" + Request.QueryString["Key"].ToString() + "'   ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("编辑成功！");
            }
        }
    }
}