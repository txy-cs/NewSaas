using System;
using System.Text;
using System.Web;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_WarehouseAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();

            SqlWhere.Append("  INSERT INTO[dbo].[SaaS_Warehouse]  ");
            SqlWhere.Append(" ([w_guid]  ");
            SqlWhere.Append(" ,[w_EncodingMerchandise]  ");
            SqlWhere.Append(" ,[w_CommodityName]  ");
            SqlWhere.Append(" ,[w_Company]  ");
            SqlWhere.Append(" ,[w_InitialCostPrice]  ");
            SqlWhere.Append(" ,[w_InitialInventory]  ");
            SqlWhere.Append(" ,[w_Warehouse]  ");
            SqlWhere.Append(" ,[w_brand]  ");
            SqlWhere.Append(" ,[w_Specifications]  ");
            SqlWhere.Append(" ,[w_ApplicableLicensePlateNumber]  ");
            SqlWhere.Append(" ,[w_PlaceOrigin]  ");
            SqlWhere.Append(" ,[w_SalePrice]  ");
            SqlWhere.Append(" ,[w_safetyStock]  ");
            SqlWhere.Append(" ,[w_Location]  ");
            SqlWhere.Append(" ,[w_CustomType]  ");
            SqlWhere.Append(" ,[w_ApplicableModels]  ");
            SqlWhere.Append(" ,[w_OEM]  ");
            SqlWhere.Append(" ,[w_Remarks]  ");
            SqlWhere.Append(" ,[w_CommodityType]  ");
            SqlWhere.Append(" ,[u_guid]  ");
            SqlWhere.Append(" ,[w_CreationTime]  ");
            SqlWhere.Append(" ,[w_LastPurchasePrice]  ");
            SqlWhere.Append(" ,[w_TotalInventory]  ");
            SqlWhere.Append(" ,[w_SupplierName])  ");
            SqlWhere.Append(" VALUES  ");
            SqlWhere.Append(" ('" + Guid.NewGuid().ToString() + "'  ");
            SqlWhere.Append(" ,'" + w_EncodingMerchandise.Value + "'  ");
            SqlWhere.Append(" ,'" + w_CommodityName.Value + "'  ");
            SqlWhere.Append(" ,'" + w_Company.Value + "'  ");
            SqlWhere.Append(" ,'" + w_InitialCostPrice.Value + "'  ");
            SqlWhere.Append(" ,'" + w_InitialInventory.Value + "'  ");
            SqlWhere.Append(" ,'27A4F127-889C-4D38-9EC6-4F321D3A5E8E'   ");
            SqlWhere.Append(" ,'" + w_brand.Value + "'  ");
            SqlWhere.Append(" ,'" + w_Specifications.Value + "'  ");
            SqlWhere.Append(" ,'" + w_ApplicableLicensePlateNumber.Value + "'  ");
            SqlWhere.Append(" ,'" + w_PlaceOrigin.Value + "'  ");
            SqlWhere.Append(" ,'" + w_SalePrice.Value + "'  ");
            SqlWhere.Append(" ,'" + w_safetyStock.Value + "'  ");
            SqlWhere.Append(" ,'" + w_Location.Value + "'  ");
            SqlWhere.Append(" ,'" + w_CustomType.Value + "'  ");
            SqlWhere.Append(" ,'" + w_ApplicableModels.Value + "'  ");
            SqlWhere.Append(" ,'" + w_OEM.Value + "'  ");
            SqlWhere.Append(" ,'" + w_Remarks.Value + "'  ");
            SqlWhere.Append(" ,'33BD6F5B-1C67-42EC-95C2-AFB3FC12E520'  ");
            SqlWhere.Append(" ,'" + HttpContext.Current.Session["u_UserParent"].ToString() + "'   ");
            SqlWhere.Append(",'" + DateTime.Now.ToString() + "'  ");
            SqlWhere.Append(" ,''  ");
            SqlWhere.Append(" ,''   ");
            SqlWhere.Append(" ,'')   ");


            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("添加成功！");
            }
        }
    }
}