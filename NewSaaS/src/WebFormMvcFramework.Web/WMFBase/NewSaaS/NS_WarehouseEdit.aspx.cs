using System;
using System.Data;
using System.Text;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_WarehouseEdit : System.Web.UI.Page
    {
        private string Str_w_guid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Str_w_guid = Request.QueryString["Key"].ToString();

                DataTable SaaS_Warehouse = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_Warehouse where(w_guid='" + Str_w_guid + "')").Copy();
                w_EncodingMerchandise.Value = SaaS_Warehouse.Rows[0]["w_EncodingMerchandise"].ToString();
                w_CommodityName.Value = SaaS_Warehouse.Rows[0]["w_CommodityName"].ToString();
                w_Company.Value = SaaS_Warehouse.Rows[0]["w_Company"].ToString();
                w_InitialCostPrice.Value = SaaS_Warehouse.Rows[0]["w_InitialCostPrice"].ToString();
                w_InitialInventory.Value = SaaS_Warehouse.Rows[0]["w_InitialInventory"].ToString();
                w_brand.Value = SaaS_Warehouse.Rows[0]["w_brand"].ToString();
                w_Specifications.Value = SaaS_Warehouse.Rows[0]["w_Specifications"].ToString();
                w_ApplicableLicensePlateNumber.Value = SaaS_Warehouse.Rows[0]["w_ApplicableLicensePlateNumber"].ToString();
                w_PlaceOrigin.Value = SaaS_Warehouse.Rows[0]["w_PlaceOrigin"].ToString();
                w_SalePrice.Value = SaaS_Warehouse.Rows[0]["w_SalePrice"].ToString();
                w_safetyStock.Value = SaaS_Warehouse.Rows[0]["w_safetyStock"].ToString();
                w_Location.Value = SaaS_Warehouse.Rows[0]["w_Location"].ToString();
                w_CustomType.Value = SaaS_Warehouse.Rows[0]["w_CustomType"].ToString();
                w_ApplicableModels.Value = SaaS_Warehouse.Rows[0]["w_ApplicableModels"].ToString();
                w_OEM.Value = SaaS_Warehouse.Rows[0]["w_OEM"].ToString();
                w_Remarks.Value = SaaS_Warehouse.Rows[0]["w_Remarks"].ToString();
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("        UPDATE[dbo].[SaaS_Warehouse]   ");
            SqlWhere.Append("         SET   ");
            SqlWhere.Append("     [w_EncodingMerchandise] = '" + w_EncodingMerchandise.Value + "'   ");
            SqlWhere.Append("     ,[w_CommodityName] = '" + w_CommodityName.Value + "'  ");
            SqlWhere.Append("    ,[w_Company] = '" + w_Company.Value + "'  ");
            SqlWhere.Append("     ,[w_InitialCostPrice] = '" + w_InitialCostPrice.Value + "'  ");
            SqlWhere.Append("     ,[w_InitialInventory] = '" + w_InitialInventory.Value + "'  ");
            SqlWhere.Append("     ,[w_brand] = '" + w_brand.Value + "'  ");
            SqlWhere.Append("      ,[w_Specifications] = '" + w_Specifications.Value + "'  ");
            SqlWhere.Append("     ,[w_ApplicableLicensePlateNumber] = '" + w_ApplicableLicensePlateNumber.Value + "'   ");
            SqlWhere.Append("      ,[w_PlaceOrigin] = '" + w_PlaceOrigin.Value + "'   ");
            SqlWhere.Append("     ,[w_SalePrice] = '" + w_SalePrice.Value + "'   ");
            SqlWhere.Append("      ,[w_safetyStock] ='" + w_safetyStock.Value + "'  ");
            SqlWhere.Append("      ,[w_Location] = '" + w_Location.Value + "'  ");
            SqlWhere.Append("     ,[w_CustomType] = '" + w_CustomType.Value + "'  ");
            SqlWhere.Append("      ,[w_ApplicableModels] ='" + w_ApplicableModels.Value + "'   ");
            SqlWhere.Append("      ,[w_OEM] = '" + w_OEM.Value + "'  ");
            SqlWhere.Append("      ,[w_Remarks] = '" + w_Remarks.Value + "'   ");
            SqlWhere.Append("   WHERE w_guid='" + Request.QueryString["Key"].ToString() + "'  ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("编辑成功！");
            }
        }
    }
}