using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_MaintenanceDocuments : System.Web.UI.Page
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
            }
        }

        public void Save_Button(object sender, EventArgs e)
        {
            /*
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("         INSERT INTO[dbo].[SaaS_MaintenanceDocuments]   ");
            SqlWhere.Append("                  ([m_guid]  ");
            SqlWhere.Append("        ,[m_OddNumbers]   ");
            SqlWhere.Append("         ,[m_BillingData]  ");
            SqlWhere.Append("         ,[m_LatestMileage]  ");
            SqlWhere.Append("        ,[m_ReceptionStaff]   ");
            SqlWhere.Append("        ,[m_ServiceType]   ");
            SqlWhere.Append("       ,[m_RepairPerson]  ");
            SqlWhere.Append("         ,[m_FaultDescription]  ");
            SqlWhere.Append("         ,[m_MaintenanceSuggestion]  ");
            SqlWhere.Append("         ,[m_Remarks]  ");
            SqlWhere.Append("         ,[c_guid]   ");
            SqlWhere.Append("         ,[m_state]   ");
            SqlWhere.Append("         ,[m_TotalConsumption]  ");
            SqlWhere.Append("         ,[m_ReceivedAmount]   ");
            SqlWhere.Append("         ,[m_AmountStillOwed]  ");
            SqlWhere.Append("         ,[m_SettlementMethod]   ");
            SqlWhere.Append("         ,[m_SettlementDate]   ");
            SqlWhere.Append("          ,[u_guid]  ");
            SqlWhere.Append("         ,[m_CreationTime]  ");
            SqlWhere.Append("     VALUES  ");
            SqlWhere.Append("          ('" + Guid.NewGuid().ToString() + "'  ");
            SqlWhere.Append("          ,'" + c_ContactPhone.Value + "'  ");
            SqlWhere.Append("          ,'" + c_ContacTelephone.Value + "'  ");
            SqlWhere.Append("          ,'" + m_LatestMileage.Value + "'  ");
            SqlWhere.Append("          ,'" + w_Company.Value + "'  ");
            SqlWhere.Append("          ,'" + m_ServiceType.Value + "'  ");
            SqlWhere.Append("          ,'" + m_RepairPerson.Value + "'  ");
            SqlWhere.Append("          ,'" + m_FaultDescription.Value + "'  ");
            SqlWhere.Append("          ,'" + m_MaintenanceSuggestion.Value + "'  ");
            SqlWhere.Append("          ,'" + m_Remarks.Value + "' ");
            SqlWhere.Append("          ,'" + c_guid.Value + "'  ");
            SqlWhere.Append("          ,'" + m_state.Value + "'  ");
            SqlWhere.Append("          ,'" + m_TotalConsumption.Value + "'  ");
            SqlWhere.Append("          ,'" + c_EngineModel.Value + "'   ");
            SqlWhere.Append("          ,'" + c_EngineNumber.Value + "'   ");
            SqlWhere.Append("          ,'" + c_NextMaintenance.Value + "'  ");
            SqlWhere.Append("          ,'" + c_NextTimeMaintenance.Value + "'  ");
            SqlWhere.Append("          ,'" + c_NextTime.Value + "'  ");
            SqlWhere.Append("          ,'" + c_nextAnnualTime.Value + "'  ");
            SqlWhere.Append("          ,'" + c_NextTimeInsurance.Value + "'  ");
            SqlWhere.Append("          ,'" + c_insuranceCompany.Value + "'  ");
            SqlWhere.Append("          ,'" + c_InsuranceNotes.Value + "'  ");
            SqlWhere.Append("        ,'" + c_VehicleNotes.Value + "' ");
            SqlWhere.Append("        , '" + HttpContext.Current.Session["u_UserParent"].ToString() + "' ");
            SqlWhere.Append("        ,'" + DateTime.Now.ToString() + "'   ");
            SqlWhere.Append("        ,'" + c_number.Value + "')  ");
             * */
            ShowMsgHelper.AlertMsg("添加成功！");
        }
    }
}