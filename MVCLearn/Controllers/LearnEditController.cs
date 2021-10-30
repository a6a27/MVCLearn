using Common;
using MVCLearn.Extensions;
using MVCLearn.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLearn.Controllers
{
    public class LearnEditController : Controller
    {
        // GET: LearnEdit
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 班級頁面
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Class()
        {
            EditClassViewModel editClassViewModel = new EditClassViewModel();
            editClassViewModel = GetClass();
            return View(editClassViewModel);
        }

        /// <summary>
        /// 取得班級清單
        /// </summary>
        /// <returns>清單</returns>
        private EditClassViewModel GetClass()
        {
            EditClassViewModel editClassViewModel = new EditClassViewModel();
            using (var db = new MVCLearn.Models.LearnEntities())
            {
                #region 教師

                editClassViewModel.ClassTeacher = db.ClassTeacher
                                                .FirstOrDefault()
                                                .MapperTo<MVCLearn.Models.ClassTeacher,
                                                          MVCLearn.ViewModels.ClassTeacher>();

                #endregion

                #region 學生清單

                editClassViewModel.ClassStudentList = db.ClassStudent
                                                    .MapperToList<MVCLearn.Models.ClassStudent,
                                                                  MVCLearn.ViewModels.ClassStudent>()
                                                     .ToList();

                #endregion

            }

            return editClassViewModel;
        }

        /// <summary>
        /// 取得學生明細
        /// </summary>
        /// <returns>明細資料</returns>
        public ActionResult GetClassStudent_D(int classStudent_ID, Action_Type action_Type)
        {
            EditClassViewModel editClassViewModel = new EditClassViewModel();
            editClassViewModel.ClassStudent_D.ClassStudent.ClassStudent_ID = classStudent_ID;
            editClassViewModel.ClassStudent_D.Action_Type = action_Type;

            //// 取得主表(學生資料)
            using (var db = new MVCLearn.Models.LearnEntities())
            {
                var data = db.ClassStudent.Where(x => x.ClassStudent_ID == classStudent_ID).FirstOrDefault();

                editClassViewModel.ClassStudent_D.ClassStudent = data.MapperTo<MVCLearn.Models.ClassStudent,
                                                          MVCLearn.ViewModels.ClassStudent>();
            }

            //// 取得明細(家長資料)
            using (var db = new MVCLearn.Models.LearnEntities())
            {
                var dataList = db.ClassStudentParents.Where(x => 
                                x.ClassStudentParents_ClassStudent_ID == editClassViewModel.ClassStudent_D.ClassStudent.ClassStudent_ID);

                editClassViewModel.ClassStudent_D.ClassStudentParentsList = dataList.MapperToList<MVCLearn.Models.ClassStudentParents,
                                                          MVCLearn.ViewModels.ClassStudentParents>().ToList();
            }

            return PartialView("_Class_Tab2", editClassViewModel);
        }

    }
}