using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoodleX.Models
{
    public class DX_User_Role
    {
        private int m_Id;
        private int m_Roleid;
        private int m_Userid;
        private DateTime m_Createdon;
        private String m_Createdby;
        private DateTime m_Updatedon;
        private String m_Updatedby;
        /// <summary>
        ///设置或返回值Id
        /// </summary>
        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        /// <summary>
        ///设置或返回值Roleid
        /// </summary>
        public int Roleid
        {
            get { return m_Roleid; }
            set { m_Roleid = value; }
        }

        /// <summary>
        ///设置或返回值Userid
        /// </summary>
        public int Userid
        {
            get { return m_Userid; }
            set { m_Userid = value; }
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
        ///设置或返回值Createdby
        /// </summary>
        public String Createdby
        {
            get { return m_Createdby; }
            set { m_Createdby = value; }
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
        ///设置或返回值Updatedby
        /// </summary>
        public String Updatedby
        {
            get { return m_Updatedby; }
            set { m_Updatedby = value; }
        }

    }
}