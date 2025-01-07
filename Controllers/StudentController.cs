using ajax.pratice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ajax.pratice.Controllers
{
    public class StudentController : Controller
    {
        // 模擬資料庫
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Email = "john@example.com", Course = "Math" },
            new Student { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Course = "Science" },
            new Student { Id = 3, Name = "Tom Brown", Email = "tom@example.com", Course = "History" }
        };

        // 顯示學生資料頁面
        public ActionResult Index()
        {
            return View(students);
        }

        // 取得所有學生資料
        [HttpGet]
        public JsonResult GetStudents()
        {
            return Json(students, JsonRequestBehavior.AllowGet);
        }

        // 根據 ID 取得學生資料
        [HttpGet]
        public JsonResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        // 創建新學生
        [HttpPost]
        public JsonResult CreateStudent(Student student)
        {
            student.Id = students.Max(s => s.Id) + 1;  // 模擬自增 ID
            students.Add(student);
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        // 更新學生資料
        [HttpPost]
        public JsonResult UpdateStudent(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Email = student.Email;
                existingStudent.Course = student.Course;
            }
            return Json(existingStudent, JsonRequestBehavior.AllowGet);
        }

        // 刪除學生資料
        [HttpPost]
        public JsonResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
