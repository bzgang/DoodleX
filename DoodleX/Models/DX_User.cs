using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoodleX.Models
{
    public class DX_User
    {
        private int m_Id;
        private String m_Ad;
        private String m_Namecn;
        private String m_Nameen;
        private String m_Email;
        private String m_Telphone;
        private String m_Password;
        private Boolean m_Isenable;
        private Boolean m_Isdelete;
        private String m_Updatedby;
        private DateTime m_Updatedon;
        private String m_Createdby;
        private DateTime m_Createdon;
        private DateTime m_Starttime;
        private DateTime m_Endtime;

        /// <summary>
        ///设置或返回值Id
        /// </summary>
        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        /// <summary>
        ///设置或返回值Ad
        /// </summary>
        public String Ad
        {
            get { return m_Ad; }
            set { m_Ad = value; }
        }

        /// <summary>
        ///设置或返回值Namecn
        /// </summary>
        public String Namecn
        {
            get { return m_Namecn; }
            set { m_Namecn = value; }
        }

        /// <summary>
        ///设置或返回值Nameen
        /// </summary>
        public String Nameen
        {
            get { return m_Nameen; }
            set { m_Nameen = value; }
        }

        /// <summary>
        ///设置或返回值Email
        /// </summary>
        public String Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        /// <summary>
        ///设置或返回值Telphone
        /// </summary>
        public String Telphone
        {
            get { return m_Telphone; }
            set { m_Telphone = value; }
        }

        /// <summary>
        ///设置或返回值Password
        /// </summary>
        public String Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }

        /// <summary>
        ///设置或返回值Isenable
        /// </summary>
        public Boolean Isenable
        {
            get { return m_Isenable; }
            set { m_Isenable = value; }
        }

        /// <summary>
        ///设置或返回值Isdelete
        /// </summary>
        public Boolean Isdelete
        {
            get { return m_Isdelete; }
            set { m_Isdelete = value; }
        }

        /// <summary>
        ///设置或返回值Updatedby
        /// </summary>
        public String Updatedby
        {
            get { return m_Updatedby; }
            set { m_Updatedby = value; }
        }

        /// <summary>
        ///设置或返回值Updatedon
        /// </summary>
        public DateTime Updatedon
        {
            get { return m_Updatedon; }
            set { m_Updatedon = value; }
        }

        /// <summary>
        ///设置或返回值Createdby
        /// </summary>
        public String Createdby
        {
            get { return m_Createdby; }
            set { m_Createdby = value; }
        }

        /// <summary>
        ///设置或返回值Createdon
        /// </summary>
        public DateTime Createdon
        {
            get { return m_Createdon; }
            set { m_Createdon = value; }
        }

        /// <summary>
        ///设置或返回值Starttime
        /// </summary>
        public DateTime Starttime
        {
            get { return m_Starttime; }
            set { m_Starttime = value; }
        }

        /// <summary>
        ///设置或返回值Endtime
        /// </summary>
        public DateTime Endtime
        {
            get { return m_Endtime; }
            set { m_Endtime = value; }
        }


    }
}