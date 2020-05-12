using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoodleX.Models
{
    public class DX_Role
    {
        private int m_Id;
        private String m_Name;
        private String m_Descr;
        private Boolean m_Isenable;
        private Boolean m_Isdelete;
        private String m_Updatedby;
        private DateTime m_Updatedon;
        private String m_Createdby;
        private DateTime m_Createdon;

        /// <summary>
        ///设置或返回值Id
        /// </summary>
        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        /// <summary>
        ///设置或返回值Name
        /// </summary>
        public String Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        /// <summary>
        ///设置或返回值Descr
        /// </summary>
        public String Descr
        {
            get { return m_Descr; }
            set { m_Descr = value; }
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

    }
}