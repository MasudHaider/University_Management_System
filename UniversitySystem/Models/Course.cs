using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySystem.Models
{
    public class Course
    {
        private readonly ApplicationDbContext _context;

        public Course()
        {
            _context = new ApplicationDbContext();
        }

        public int Id { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public float CourseCredit { get; set; }

        public string CourseDescription { get; set; }

        public virtual Department Department { get; set; }

        public int DepartmentId { get; set; }

        public Semester SemesterId { get; set; }

        //Methods
        public IEnumerable<SelectListItem> GetSemesterListItems()
        {
            List<SelectListItem> semesterList = Enum.GetValues(typeof(Semester))
                .Cast<Semester>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString()
                }).ToList();

            var semesterTip = new SelectListItem
            {
                Value = "0",
                Text = "--Select Semester--"
            };

            semesterList.Insert(0, semesterTip);

            return new SelectList(semesterList, "Value", "Text");
        }

        public bool CheckCourseCodeAvailability(string courseCode)
        {
            return _context.Courses.Any(c => c.CourseCode == courseCode);
        }

        public bool CheckCourseNameAvailability(string courseName)
        {
            return _context.Courses.Any(c => c.CourseName == courseName);
        }
    }

    public enum Semester
    {
        [Description("1st")]
        First = 1,
        [Description("2nd")]
        Second,
        [Description("3rd")]
        Third,
        [Description("4th")]
        Fourth,
        [Description("5th")]
        Fifth,
        [Description("6th")]
        Sixth,
        [Description("7th")]
        Seventh,
        [Description("8th")]
        Eighth
    }

    /*public class Enum<T> where T : struct, IConvertible
    {
        public static List<SelectListItem> GetSemesterListItems()
        {
            List<SelectListItem> items = new List<SelectListItem>();


            Type type = typeof(T);

            if (type.IsEnum)
            {
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {

                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    SelectListItem item = new SelectListItem
                    {
                        Text = val.ToString(),
                        Value = val.ToString()
                    };
                    if (descriptionAttributes.Length > 0)
                    {

                        item.Text = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                    }
                    items.Add(item);


                }

            }
            return items;
        }*/

    /*private string GetEnumDisplayName<T>(T value) where T : struct
    {
        var memberInfo = value.GetType().GetMember(value.ToString());
        if (memberInfo.Length != 1)
            return null;

        var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

        if (displayAttribute == null || displayAttribute.Length != 1)
            return null;

        return displayAttribute[0].Name;
    }*/
}
