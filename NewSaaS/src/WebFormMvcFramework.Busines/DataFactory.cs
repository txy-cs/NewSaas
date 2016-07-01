using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Universal_ClassLibrary.DataBase;
using WebFormMvcFramework.Common.DotNetConfig;

namespace WebFormMvcFramework.Busines
{
    public class DataFactory
    {
        private static SqlParameter SP;
        private static List<SqlParameter> SPList;
        private static SqlServer _SqlDataBase { set; get; }
        /// <summary>
        /// 得到实例
        /// </summary>
        /// <returns></returns>
        public static SqlServer SqlDataBase()
        {
            if (_SqlDataBase == null)
            {
                _SqlDataBase = new Universal_ClassLibrary.DataBase.SqlServer(ConfigHelper.GetAppSettings("SqlServer_NewSaaS"));
            }
            return _SqlDataBase;
        }
        public static DbHelperSQLP DBSQL()
        {
            DbHelperSQLP TmpDbHelperSQLP = new DbHelperSQLP(ConfigHelper.GetAppSettings("SqlServer_WMF_DB"));
            return TmpDbHelperSQLP;
        }
        public static DataSet SqlPager(string sqlstr, int currentpage, int pagesize)
        {
            SPList = new List<SqlParameter>();
            SP = new SqlParameter();
            SP.DbType = DbType.String;
            SP.ParameterName = "@sqlstr";
            SP.Value = sqlstr;
            SPList.Add(SP);

            SP = new SqlParameter();
            SP.DbType = DbType.Int32;
            SP.ParameterName = "@currentpage";
            SP.Value = currentpage;
            SPList.Add(SP);

            SP = new SqlParameter();
            SP.DbType = DbType.Int32;
            SP.ParameterName = "@pagesize";
            SP.Value = pagesize;
            SPList.Add(SP);

            return DataFactory.DBSQL().RunProcedure("[SqlPager]", SPList.ToArray(), "数据集").Copy();
        }
    }
}