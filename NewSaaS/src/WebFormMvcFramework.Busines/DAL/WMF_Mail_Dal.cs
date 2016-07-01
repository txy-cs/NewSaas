using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebFormMvcFramework.Busines.IDAO;

namespace WebFormMvcFramework.Busines.DAL
{
    public class WMF_Mail_Dal : WMF_Mail_IDAO
    {
        private string SqlStr = string.Empty;
        private SqlParameter SP;
        private List<SqlParameter> SPList;
        public int DeleteMail(string Mail_Guid)
        {
            SPList = new List<SqlParameter>();
            SqlStr = " UPDATE [Base_Mail] SET [Mail_DeleteMark]=0 where(Mail_Guid=@Mail_Guid) ";
            SP = new SqlParameter();
            SP.DbType = DbType.String;
            SP.ParameterName = "@Mail_Guid";
            SP.Value = Mail_Guid;
            SPList.Add(SP);
            return DataFactory.DBSQL().ExecuteSql(SqlStr, SPList.ToArray());
        }

        public int CompletelyDeleteMail(string Mail_Guid)
        {
            SPList = new List<SqlParameter>();
            SqlStr = " delete from [Base_Mail] where(Mail_Guid=@Mail_Guid) ";
            SP = new SqlParameter();
            SP.DbType = DbType.String;
            SP.ParameterName = "@Mail_Guid";
            SP.Value = Mail_Guid;
            SPList.Add(SP);
            return DataFactory.DBSQL().ExecuteSql(SqlStr, SPList.ToArray());
        }

        public void SendOutMail(string Mail_Guid, string Mail_User_ID, string Mail_User_Account, string Mail_Name, string Mail_Text, string Mail_MR_UserAccount)
        {
            #region 写入发件箱
            SPList = new List<SqlParameter>();
            SqlStr = " INSERT INTO [dbo].[Base_Mail] ";
            SqlStr += " ([Mail_Guid] ";
            SqlStr += " ,[Mail_User_Account] ";
            SqlStr += " ,[Mail_CreateTime] ";
            SqlStr += " ,[Mail_CreateUserID] ";
            SqlStr += " ,[Mail_Type] ";
            SqlStr += " ,[Mail_Name] ";
            SqlStr += " ,[Mail_Text] ";
            SqlStr += " ,[Mail_MR_UserAccount] ";
            SqlStr += " ,[Mail_DeleteMark] ";
            SqlStr += " ,[Mail_ReadState]) ";
            SqlStr += " VALUES ";
            SqlStr += " ( ";
            SqlStr += " @Mail_Guid ";
            SqlStr += " ,@Mail_User_Account ";
            SqlStr += " ,@Mail_CreateTime ";
            SqlStr += " ,@Mail_CreateUserID ";
            SqlStr += " ,@Mail_Type ";
            SqlStr += " ,@Mail_Name ";
            SqlStr += " ,@Mail_Text ";
            SqlStr += " ,@Mail_MR_UserAccount ";
            SqlStr += " ,@Mail_DeleteMark ";
            SqlStr += " ,@Mail_ReadState ";
            SqlStr += " ) ";

            SP = new SqlParameter();
            SP.ParameterName = "@Mail_Guid";
            SP.DbType = DbType.String;
            SP.Value = Mail_Guid;
            SPList.Add(SP);

            SP = new SqlParameter();
            SP.ParameterName = "@Mail_User_Account";
            SP.DbType = DbType.String;
            SP.Value = Mail_User_Account;
            SPList.Add(SP);


            SP = new SqlParameter();
            SP.ParameterName = "@Mail_CreateTime";
            SP.DbType = DbType.DateTime;
            SP.Value = DateTime.Now.ToString();
            SPList.Add(SP);


            SP = new SqlParameter();
            SP.ParameterName = "@Mail_CreateUserID";
            SP.DbType = DbType.String;
            SP.Value = Mail_User_ID;
            SPList.Add(SP);


            SP = new SqlParameter();
            SP.ParameterName = "@Mail_Type";
            SP.DbType = DbType.Int32;
            SP.Value = 0;
            SPList.Add(SP);


            SP = new SqlParameter();
            SP.ParameterName = "@Mail_Name";
            SP.DbType = DbType.String;
            SP.Value = Mail_Name;
            SPList.Add(SP);


            SP = new SqlParameter();
            SP.ParameterName = "@Mail_Text";
            SP.DbType = DbType.String;
            SP.Value = Mail_Text;
            SPList.Add(SP);


            SP = new SqlParameter();
            SP.ParameterName = "@Mail_DeleteMark";
            SP.DbType = DbType.Int32;
            SP.Value = 1;
            SPList.Add(SP);


            SP = new SqlParameter();
            SP.ParameterName = "@Mail_ReadState";
            SP.DbType = DbType.Int32;
            SP.Value = 0;
            SPList.Add(SP);


            SP = new SqlParameter();
            SP.ParameterName = "@Mail_MR_UserAccount";
            SP.DbType = DbType.String;
            SP.Value = Mail_MR_UserAccount;
            SPList.Add(SP);
            DataFactory.DBSQL().ExecuteSql(SqlStr, SPList.ToArray());
            #endregion
            #region 写入收件箱
            for (int i = 0; i < Mail_MR_UserAccount.Split(';').Length - 1; i++)
            {

                SPList = new List<SqlParameter>();
                SqlStr = " INSERT INTO [dbo].[Base_Mail] ";
                SqlStr += " ([Mail_Guid] ";
                SqlStr += " ,[Mail_User_Account] ";
                SqlStr += " ,[Mail_CreateTime] ";
                SqlStr += " ,[Mail_CreateUserID] ";
                SqlStr += " ,[Mail_Type] ";
                SqlStr += " ,[Mail_Name] ";
                SqlStr += " ,[Mail_Text] ";
                SqlStr += " ,[Mail_MR_UserAccount] ";
                SqlStr += " ,[Mail_DeleteMark] ";
                SqlStr += " ,[Mail_ReadState]) ";
                SqlStr += " VALUES ";
                SqlStr += " ( ";
                SqlStr += " @Mail_Guid ";
                SqlStr += " ,@Mail_User_Account ";
                SqlStr += " ,@Mail_CreateTime ";
                SqlStr += " ,@Mail_CreateUserID ";
                SqlStr += " ,@Mail_Type ";
                SqlStr += " ,@Mail_Name ";
                SqlStr += " ,@Mail_Text ";
                SqlStr += " ,@Mail_MR_UserAccount ";
                SqlStr += " ,@Mail_DeleteMark ";
                SqlStr += " ,@Mail_ReadState ";
                SqlStr += " ) ";

                SP = new SqlParameter();
                SP.ParameterName = "@Mail_Guid";
                SP.DbType = DbType.String;
                SP.Value = Guid.NewGuid().ToString();
                SPList.Add(SP);


                SP = new SqlParameter();
                SP.ParameterName = "@Mail_User_Account";
                SP.DbType = DbType.String;
                SP.Value = Mail_MR_UserAccount.Split(';')[i];
                SPList.Add(SP);


                SP = new SqlParameter();
                SP.ParameterName = "@Mail_CreateTime";
                SP.DbType = DbType.DateTime;
                SP.Value = DateTime.Now.ToString();
                SPList.Add(SP);


                SP = new SqlParameter();
                SP.ParameterName = "@Mail_CreateUserID";
                SP.DbType = DbType.String;
                SP.Value = Mail_User_ID;
                SPList.Add(SP);


                SP = new SqlParameter();
                SP.ParameterName = "@Mail_Type";
                SP.DbType = DbType.Int32;
                SP.Value = 1;
                SPList.Add(SP);


                SP = new SqlParameter();
                SP.ParameterName = "@Mail_Name";
                SP.DbType = DbType.String;
                SP.Value = Mail_Name;
                SPList.Add(SP);


                SP = new SqlParameter();
                SP.ParameterName = "@Mail_Text";
                SP.DbType = DbType.String;
                SP.Value = Mail_Text;
                SPList.Add(SP);


                SP = new SqlParameter();
                SP.ParameterName = "@Mail_DeleteMark";
                SP.DbType = DbType.Int32;
                SP.Value = 1;
                SPList.Add(SP);


                SP = new SqlParameter();
                SP.ParameterName = "@Mail_ReadState";
                SP.DbType = DbType.Int32;
                SP.Value = 1;
                SPList.Add(SP);


                SP = new SqlParameter();
                SP.ParameterName = "@Mail_MR_UserAccount";
                SP.DbType = DbType.String;
                SP.Value = Mail_User_Account;
                SPList.Add(SP);

                DataFactory.DBSQL().ExecuteSql(SqlStr, SPList.ToArray());
            }
            #endregion
        }

        public int ModifyReadingStatus(string Mail_Guid, int Mail_ReadState)
        {
            SPList = new List<SqlParameter>();
            SqlStr = " UPDATE [Base_Mail] SET [Mail_ReadState]=@Mail_ReadState where(Mail_Guid=@Mail_Guid) ";
            SP = new SqlParameter();
            SP.DbType = DbType.Guid;
            SP.Value = Mail_Guid;
            SP.ParameterName = "@Mail_Guid";
            SPList.Add(SP);
            SP = new SqlParameter();
            SP.DbType = DbType.Int32;
            SP.ParameterName = "@Mail_ReadState";
            SP.Value = Mail_ReadState;
            SPList.Add(SP);
            return DataFactory.DBSQL().ExecuteSql(SqlStr, SPList.ToArray());
        }

        public System.Data.DataSet Hairpieceslist(string Mail_User_ID)
        {
            SPList = new List<SqlParameter>();
            SqlStr = " select * from Base_Mail where(Mail_User_ID=@Mail_User_ID and Mail_DeleteMark=1 and Mail_Type=0) ";
            SP = new SqlParameter();
            SP.DbType = DbType.Guid;
            SP.Value = Mail_User_ID;
            SP.ParameterName = "@Mail_User_ID";
            SPList.Add(SP);
            return DataFactory.DBSQL().Query(SqlStr, SPList.ToArray());
        }

        public System.Data.DataSet CollectionList(string Mail_User_ID)
        {
            SPList = new List<SqlParameter>();
            SqlStr = " select * from Base_Mail where(Mail_User_ID=@Mail_User_ID and Mail_DeleteMark=1 and Mail_Type=1) ";
            SP = new SqlParameter();
            SP.DbType = DbType.Guid;
            SP.Value = Mail_User_ID;
            SP.ParameterName = "@Mail_User_ID";
            SPList.Add(SP);
            return DataFactory.DBSQL().Query(SqlStr, SPList.ToArray());
        }

        public System.Data.DataSet DeletedList(string Mail_User_ID)
        {
            SPList = new List<SqlParameter>();
            SqlStr = " select * from Base_Mail where(Mail_User_ID=@Mail_User_ID and Mail_DeleteMark=0) ";
            SP = new SqlParameter();
            SP.DbType = DbType.Guid;
            SP.Value = Mail_User_ID;
            SP.ParameterName = "@Mail_User_ID";
            SPList.Add(SP);
            return DataFactory.DBSQL().Query(SqlStr, SPList.ToArray());
        }

        public int RecoveryMail(string Mail_Guid)
        {
            SPList = new List<SqlParameter>();
            SqlStr = " UPDATE [Base_Mail] SET [Mail_DeleteMark]=1 where(Mail_Guid=@Mail_Guid) ";
            SP = new SqlParameter();
            SP.DbType = DbType.String;
            SP.ParameterName = "@Mail_Guid";
            SP.Value = Mail_Guid;
            SPList.Add(SP);
            return DataFactory.DBSQL().ExecuteSql(SqlStr, SPList.ToArray());

        }
    }
}