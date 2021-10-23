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
    public class ClassViewModel
    {
        //導師資訊
        public ClassTeacher ClassTeacher { get; set; } = new ClassTeacher();

        //學生資訊清單
        public List<ClassStudent> ClassStudentList { get; set; } = new List<ClassStudent>();
    }

    /// <summary>
    /// 班級導師
    /// </summary>
    public class ClassTeacher
    {
        [DisplayName("班導編號")]
        public string ClassTeacher_ID { get; set; }
        [DisplayName("班導姓名")]
        public string ClassTeacher_Name { get; set; }
        [DisplayName("班導電話")]
        public string ClassTeacher_Tel { get; set; }
    }

    /// <summary>
    /// 班級學生
    /// </summary>
    public class ClassStudent
    {
        [DisplayName("學生編號")]
        public string ClassStudent_ID { get; set; }
        [DisplayName("學生姓名")]
        public string ClassStudent_Name { get; set; }
        [DisplayName("學生電話")]
        public string ClassStudent_Tel { get; set; }
        [DisplayName("班導編號")]
        public string ClassStudent_ClassTeacher_ID { get; set; }
    }
}