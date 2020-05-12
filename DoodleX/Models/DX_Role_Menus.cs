using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoodleX.Models
{
    public class DX_Role_Menus
    {
        private int m_Id;
        private int m_Menusid;
        private int m_Roleid;
        private DateTime m_Createdon;
        private String m_Createdby;
        private DateTime m_Updatedon;
        private String m_Updatedby;
        private Boolean m_Isenable;

        /// <summary>
        ///设置或返回值Id
        /// </summary>
        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        /// <summary>
        ///设置或返回值Menusid
        /// </summary>
        public int Menusid
        {
            get { return m_Menusid; }
            set { m_Menusid = value; }
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

        /// <summary>
        ///设置或返回值Isenable
        /// </summary>
        public Boolean Isenable
        {
            get { return m_Isenable; }
            set { m_Isenable = value; }
        }

    }
}