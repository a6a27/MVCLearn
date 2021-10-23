using MVCLearn.Extensions;
using MVCLearn.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLearn.Controllers
{
    public class LearnController : Controller
    {
        // GET: Learn
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
            ClassViewModel classViewModel = new ClassViewModel();
            classViewModel = GetClass();
            return View(classViewModel);
        }

        /// <summary>
        /// 取得班級清單
        /// </summary>
        /// <returns>清單</returns>
        private ClassViewModel GetClass()
        {
            ClassViewModel classViewModel = new ClassViewModel();
            using (var db = new MVCLearn.Models.LearnEntities())
            {
                #region 教師

                classViewModel.ClassTeacher = db.ClassTeacher
                                                .FirstOrDefault()
                                                .MapperTo<MVCLearn.Models.ClassTeacher,
                                                          MVCLearn.ViewModels.ClassTeacher>();

                #endregion

                #region 學生清單

                classViewModel.ClassStudentList = db.ClassStudent
                                                    .MapperToList<MVCLearn.Models.ClassStudent, 
                                                                  MVCLearn.ViewModels.ClassStudent>()
                                                     .ToList(); 

                #endregion

            }

            return classViewModel;
        }
    }
}