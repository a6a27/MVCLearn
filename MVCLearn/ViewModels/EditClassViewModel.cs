using Common;
using MVCLearn.Enum;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCLearn.ViewModels
{
    /// <summary>
    /// 班級ViewModel
    /// </summary>
    public class EditClassViewModel
    {
        /// <summary>
        /// 導師資訊
        /// </summary>
        public ClassTeacher ClassTeacher { get; set; } = new ClassTeacher();

        public ClassStudent_Q ClassStudent_Q { get; set; } = new ClassStudent_Q();

        /// <summary>
        /// 學生資訊 搜尋結果 清單
        /// </summary>
        public IPagedList<ClassStudent> ClassStudentList { get; set; }

        /// <summary>
        /// 頁面Size
        /// </summary>
        public int Pagesize { get; set; } = 5;
        
        /// <summary>
        /// 頁面編號
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// 學生資訊明細
        /// </summary>
        public ClassStudent_D ClassStudent_D { get; set; } = new ClassStudent_D();
    }

    /// <summary>
    /// 班級導師
    /// </summary>
    public class ClassTeacher
    {
        [DisplayName("班導編號")]
        public int ClassTeacher_ID { get; set; }
        [DisplayName("班導姓名")]
        public string ClassTeacher_Name { get; set; }
        [DisplayName("班導電話")]
        public string ClassTeacher_Tel { get; set; }
    }

    /// <summary>
    /// 班級學生搜尋條件
    /// </summary>
    public class ClassStudent_Q
    {
        [DisplayName("學生姓名")]
        public string ClassStudent_Name { get; set; }
    }

    /// <summary>
    /// 班級學生
    /// </summary>
    public class ClassStudent
    {
        [DisplayName("學生編號")]
        public int ClassStudent_ID { get; set; }
        [DisplayName("學生姓名")]
        public string ClassStudent_Name { get; set; }
        [DisplayName("學生電話")]
        public string ClassStudent_Tel { get; set; }
        [DisplayName("班導編號")]
        public int ClassStudent_ClassTeacher_ID { get; set; }
        [DisplayName("學生性別")]
        public string ClassStudent_Sex { get; set; }
        [DisplayName("學生地址")]
        public string ClassStudent_Address { get; set; }
        [DisplayName("學生出生日期")]
        public DateTime ClassStudent_Birth { get; set; } = DateTime.Now;
        [DisplayName("學生專長")]
        public string ClassStudent_Skill { get; set; }

        [DisplayName("學生家庭狀況")]
        public ClassStudent_Money ClassStudent_Money { get; set; }

    }

    /// <summary>
    /// 學生家長
    /// </summary>
    public class ClassStudentParents
    {
        [DisplayName("家長編號")]
        public int ClassStudentParents_ID { get; set; }
        [DisplayName("家長姓名")]
        public string ClassStudentParents_Name { get; set; }
        [DisplayName("家長電話")]
        public string ClassStudentParents_Tel { get; set; }

        [DisplayName("學生編號")]
        public int ClassStudentParents_ClassStudent_ID { get; set; }

        [DisplayName("家長地址")]
        public string ClassStudentParents_Address { get; set; }

        [DisplayName("家長性別")]
        public string ClassStudentParents_Sex { get; set; }

        [DisplayName("家長出生日期")]
        public DateTime ClassStudentParents_Birth { get; set; }

    }


    /// <summary>
    /// 學生資訊明細
    /// </summary>
    public class ClassStudent_D
    {
        /// <summary>
        /// CRUD狀態
        /// </summary>
        public Action_Type Action_Type { get; set; }

        /// <summary>
        /// 班級學生資訊
        /// </summary>
        public ClassStudent ClassStudent { get; set; } = new ClassStudent();

        /// <summary>
        /// 班級學生家長清單
        /// </summary>
        public List<ClassStudentParents> ClassStudentParentsList { get; set; } = new List<ClassStudentParents>();
    }


}