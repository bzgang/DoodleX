using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoodleX.Models
{
    public class DX_Menus
    {

        /// <summary>
        ///设置或返回值Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///设置或返回值Menuchname
        /// </summary>
        public String MenuChName { get; set; }

        /// <summary>
        ///设置或返回值Menuenname
        /// </summary>
        public String MenuEnName { get; set; }

        /// <summary>
        ///设置或返回值Menuicon
        /// </summary>
        public String MenuIcon { get; set; }

        /// <summary>
        ///设置或返回值Menulevel
        /// </summary>
        public String MenuLevel { get; set; }

        /// <summary>
        ///设置或返回值Menutarget
        /// </summary>
        public String MenuTarget { get; set; }

        /// <summary>
        ///设置或返回值Parentid
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        ///设置或返回值Linkaddress
        /// </summary>
        public String LinkAddress { get; set; }

        /// <summary>
        ///设置或返回值Createdon
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        ///设置或返回值Createdby
        /// </summary>
        public String CreatedBy { get; set; }

        /// <summary>
        ///设置或返回值Updatedon
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        ///设置或返回值Updatedby
        /// </summary>
        public String UpdatedBy { get; set; }

        /// <summary>
        ///设置或返回值Isdeleted
        /// </summary>
        public Boolean IsDeleted { get; set; }

        /// <summary>
        ///设置或返回值Isenable
        /// </summary>
        public Boolean IsEnable { get; set; }

        /// <summary>
        ///设置或返回值Sortby
        /// </summary>
        public int SortBy { get; set; }

    }
}