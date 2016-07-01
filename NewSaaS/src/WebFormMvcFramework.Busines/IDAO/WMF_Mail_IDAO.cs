using System.Data;

namespace WebFormMvcFramework.Busines.IDAO
{
    public interface WMF_Mail_IDAO
    {
        /// <summary>
        /// 删除邮件
        /// </summary>
        /// <param name="Mail_Guid">邮件GUID</param>
        /// <returns></returns>
        int DeleteMail(string Mail_Guid);
        /// <summary>
        /// 彻底删除邮件
        /// </summary>
        /// <param name="Mail_Guid">邮件GUID</param>
        /// <returns></returns>
        int CompletelyDeleteMail(string Mail_Guid);
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="Mail_Guid">邮件GUID</param>
        /// <param name="Mail_User_ID">邮件归属人GUID</param>
        /// <param name="Mail_User_Account">邮件归属人帐号</param>
        /// <param name="Mail_Name">邮件标题</param>
        /// <param name="Mail_Text">邮件内容</param>
        /// <param name="Mail_MR_UserAccount">邮件收件人GUID列表</param>
        /// <returns></returns>
        void SendOutMail(string Mail_Guid, string Mail_User_ID, string Mail_User_Account, string Mail_Name, string Mail_Text, string Mail_MR_UserAccount);
        /// <summary>
        /// 修改阅读状态
        /// </summary>
        /// <param name="Mail_Guid">邮件GUID</param>
        /// <param name="Mail_ReadState">阅读状态0已读 1未读</param>
        /// <returns></returns>
        int ModifyReadingStatus(string Mail_Guid, int Mail_ReadState);
        /// <summary>
        /// 查询发件列表
        /// </summary>
        /// <param name="Mail_User_ID">用户GUID</param>
        /// <returns></returns>
        DataSet Hairpieceslist(string Mail_User_ID);
        /// <summary>
        /// 查询收件列表
        /// </summary>
        /// <param name="Mail_User_ID">用户GUID</param>
        /// <returns></returns>
        DataSet CollectionList(string Mail_User_ID);
        /// <summary>
        /// 查询已删列表
        /// </summary>
        /// <param name="Mail_User_ID">用户GUID</param>
        /// <returns></returns>
        DataSet DeletedList(string Mail_User_ID);
        /// <summary>
        /// 恢复邮件
        /// </summary>
        /// <param name="Mail_Guid">邮件GUID</param>
        /// <returns></returns>
        int RecoveryMail(string Mail_Guid);
    }
}