using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Sheng.SailingEase.Core
{
    # region ϵͳö��

    //TODO:ҲӦ�ö�����࣬�������ṩ��֧�ֵ���������
    /// <summary>
    /// ��ʹ�õ����ݿ�����
    /// </summary>
    public enum EnumDataBase
    {
        [LocalizedDescription("EnumDataBase_SqlServer")]
        SqlServer = 0
    }

    //TODO:Ӧ�ö������
    //�Ѿ�û����
    /// <summary>
    /// ���������ͣ�SQL Server��
    /// </summary>
    public enum EnumDataItemType
    {
        /// <summary>
        /// �����ַ���
        /// </summary>
        [LocalizedDescription("EnumDataItemType_Char")]
        Char = 0,
        /// <summary>
        /// �䳤�ַ���
        /// </summary>
        [LocalizedDescription("EnumDataItemType_Varchar")]
        Varchar = 1,
        /// <summary>
        /// ����ʱ��
        /// </summary>
        [LocalizedDescription("EnumDataItemType_SmallDatetime")]
        SmallDatetime = 2,
        /// <summary>
        /// ˫������
        /// </summary>
        [LocalizedDescription("EnumDataItemType_Decimal")]
        Decimal = 3,
        /// <summary>
        /// ��������
        /// </summary>
        [LocalizedDescription("EnumDataItemType_Float")]
        Float = 4,
        /// <summary>
        /// ����
        /// </summary>
        [LocalizedDescription("EnumDataItemType_Int")]
        Int = 5,
        /// <summary>
        /// ���ı�
        /// </summary>
        [LocalizedDescription("EnumDataItemType_Text")]
        Text = 6,
        /// <summary>
        /// ������
        /// </summary>
        [LocalizedDescription("EnumDataItemType_Image")]
        Image = 7,
        /// <summary>
        /// ������
        /// </summary>
        [LocalizedDescription("EnumDataItemType_Bit")]
        Bit = 8,
        /// <summary>
        /// Ψһ��ʶ
        /// </summary>
        [LocalizedDescription("EnumDataItemType_Uniqueidentifier")]
        Uniqueidentifier = 9
    }

    ///// <summary>
    ///// ����Ԫ�صľ���ؼ����ͣ��������п��ÿؼ�
    ///// Ԫ�رȽ϶࣬��ʹ��Flags����Ҫ��ѡʱ��ʹ��EnumFormElementControlTypeCollection������ʵ��
    ///// //TODO:EnumFormElementControlType ���ǸĽ�����ʹ��ö��
    ///// </summary>
    //public enum EnumFormElementControlType
    //{
    //    Null = 0,
    //    /// <summary>
    //    /// ����,����һЩ�б�,�����б���˿ؼ�
    //    /// </summary>
    //    ANY = 1,
    //    /// <summary>
    //    /// �ı���
    //    /// </summary>
    //    TextBox = 2,
    //    /// <summary>
    //    /// �����ı���
    //    /// </summary>
    //    ComboBox = 3,
    //    /// <summary>
    //    /// �����б�
    //    /// </summary>
    //    DataList = 4,
    //    /// <summary>
    //    /// ��̬�ı�
    //    /// </summary>
    //    Label = 5,
    //    /// <summary>
    //    /// ͼƬ��
    //    /// </summary>
    //    PictureBox = 6,
    //    /// <summary>
    //    /// ��ͨ��ť
    //    /// </summary>
    //    Button = 7,
    //    /// <summary>
    //    /// �����У�������DataList��
    //    /// </summary>
    //    DataColumn = 8,
    //    /// <summary>
    //    /// �ָ��������ڲ˵����򹤾����У�
    //    /// </summary>
    //    Separator = 9,
    //    /// <summary>
    //    /// ��������ť
    //    /// </summary>
    //    ToolStripButton = 10,
    //    /// <summary>
    //    /// �������ı�
    //    /// </summary>
    //    ToolStripLabel = 11,
    //    ///// <summary>
    //    ///// �˵���,�������˵���
    //    ///// [���] ����ΪʲôҪ�������
    //    ///// </summary>
    //    //ToolStripMenuItem = 12,
    //}

    ///// <summary>
    ///// ����ö�٣�����ö���һһ��Ӧ
    ///// </summary>
    //public enum EnumEvent
    //{
    //    //TODO:EnumEvent ��������Ը���Attribute֮��ķ������
    //    ClearFormData = 0,
    //    Exit = 1,
    //    LoadDataToForm = 2,
    //    LockProgram = 3,
    //    NewGuid = 4,
    //    OpenForm = 5,
    //    ReceiveData = 6,
    //    //RefreshList = 7,
    //    ReLogin = 8,
    //    SaveFormData = 9,
    //    StartProcess = 10,
    //    UpdateFormData = 11,
    //    CloseForm = 12,
    //    OpenSystemForm = 13,
    //    ValidateFormData = 14,
    //    CallAddIn = 15,
    //    ReturnDataToCallerForm = 16,
    //    //DataListOperator = 17,
    //    DeleteData = 18,
    //    /// <summary>
    //    /// �����б��ˢ���¼�
    //    /// </summary>
    //    DataListRefresh = 19,
    //    /// <summary>
    //    /// ���ö��󷽷�
    //    /// </summary>
    //    CallEntityMethod = 20,
    //    /// <summary>
    //    /// �����б���������¼�
    //    /// </summary>
    //    DataListAddRow = 21,
    //    /// <summary>
    //    /// �����б�ĸ������¼�
    //    /// </summary>
    //    DataListUpdateRow = 22,
    //    /// <summary>
    //    /// �����б��ɾ�����¼�
    //    /// </summary>
    //    DataListDeleteRow = 23
    //}

    #endregion

    /// <summary>
    /// �Ƿ�
    /// </summary>
    public enum EnumTrueFalse
    {
        /// <summary>
        /// ��
        /// </summary>
        [LocalizedDescription("EnumTrueFalse_False")]
        [DefaultValue(false)]
        False = 0,
        /// <summary>
        /// ��
        /// </summary>
        [LocalizedDescription("EnumTrueFalse_True")]
        [DefaultValue(true)]
        True = 1
    }

    /// <summary>
    /// ѡ����Դʱ���õ�ϵͳ����
    /// </summary>
    public enum EnumSystemDataSource
    {
        /// <summary>
        /// �û�Id
        /// </summary>
        [LocalizedDescription("EnumSystemDataSource_UserId")]
        UserId = 0,
        /// <summary>
        /// �û���
        /// </summary>
        [LocalizedDescription("EnumSystemDataSource_UserName")]
        UserName = 1,
        /// <summary>
        /// �û���¼��
        /// </summary>
        [LocalizedDescription("EnumSystemDataSource_UserLoginName")]
        UserLoginName = 2,
        /// <summary>
        /// �û�������Id
        /// ���û��������κ��飬��Id��ȫ0��ʾ
        /// </summary>
        [LocalizedDescription("EnumSystemDataSource_UserGroupId")]
        UserGroupId = 3,
        /// <summary>
        /// �û���������
        /// </summary>
        [LocalizedDescription("EnumSystemDataSource_UserGroupName")]
        UserGroupName = 4,
        /// <summary>
        /// ��ǰ����
        /// </summary>
        [LocalizedDescription("EnumSystemDataSource_Date")]
        Date = 5,
        /// <summary>
        /// ��ǰ����ʱ��
        /// </summary>
        [LocalizedDescription("EnumSystemDataSource_DateTime")]
        DateTime = 6
    }

    //TODO:�ƶ��� IDataBaseProvide
    /// <summary>
    /// ƥ�䷽ʽ
    /// ������ˢ���б��¼����������ò���
    /// </summary>
    public enum EnumMatchType
    {
        /// <summary>
        /// ����
        /// </summary>
        [LocalizedDescription("EnumMatchType_Equal")]
        Equal = 0,
        /// <summary>
        /// ƥ��
        /// </summary>
        [LocalizedDescription("EnumMatchType_Like")]
        Like = 1,
        /// <summary>
        /// ����
        /// </summary>
        [LocalizedDescription("EnumMatchType_Large")]
        Large = 2,
        /// <summary>
        /// ���ڵ���
        /// </summary>
        [LocalizedDescription("EnumMatchType_LargeEqual")]
        LargeEqual = 3,
        /// <summary>
        /// С��
        /// </summary>
        [LocalizedDescription("EnumMatchType_Less")]
        Less = 4,
        /// <summary>
        /// С�ڵ���
        /// </summary>
        [LocalizedDescription("EnumMatchType_LessEqual")]
        LessEqual = 5,
        /// <summary>
        /// ������
        /// </summary>
        [LocalizedDescription("EnumMatchType_NotEqual")]
        NotEqual = 6
    }

    /// <summary>
    /// ����Դ����
    /// </summary>
    public enum EnumDataSourceType
    {
        //TODO;����ȥ��EditControl��DataList
        EditControl = 0,
        DataList = 1,
        System = 2
    }

    /// <summary>
    /// ���
    /// �¼�����ʹ�õ�����Դ����Դ����
    /// ����Flags
    /// </summary>
    [Flags]
    public enum EnumEventDataSource
    {
        //TODO:���ǸĽ������ǰ�SYSTEM�ĳ�һ�������ڴ���Ԫ��һ������
        //����ע�ᵽһ����������ʹ�� Typeof�����ķ�����ʹ��

        /// <summary>
        /// û��
        /// </summary>
        Null = 0,
        /// <summary>
        /// ȫ��
        /// </summary>
        ANY = 1,
        /// <summary>
        /// ����Ԫ��
        /// </summary>
        FormElement = 2,
        /// <summary>
        /// ϵͳ
        /// </summary>
        System = 4
    }

    /// <summary>
    /// Ŀ�괰��
    /// </summary>
    public enum EnumTargetWindow
    {
        /// <summary>
        /// ��ǰ
        /// </summary>
        [LocalizedDescription("EnumTargetForm_Current")]
        Current = 0,
        /// <summary>
        /// ������
        /// </summary>
        [LocalizedDescription("EnumTargetForm_Caller")]
        Caller = 1
    }
}

