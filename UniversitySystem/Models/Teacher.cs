using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace UniversitySystem.Models
{
    public class Teacher
    {
        private readonly ApplicationDbContext _context;

        public Teacher()
        {
            _context = new ApplicationDbContext();
        }

        public int Id { get; set; }

        public string TeacherName { get; set; }

        public string TeacherAddress { get; set; }

        public string TeacherEmail { get; set; }

        public string TeacherContactNumber { get; set; }

        //public virtual Designation Designation { get; set; }
        public Designations DesignationId { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }

        public float TeacherCredits { get; set; }


        //Methods
        public bool CheckTeacherEmailAvailability(string teacherEmail)
        {
            return _context.Teachers.Any(t => t.TeacherEmail == teacherEmail);
        }

        public bool CheckTeacherContactAvailability(string teacherContact)
        {
            return _context.Teachers.Any(t => t.TeacherContactNumber == teacherContact);
        }

        public IEnumerable<SelectListItem> GetTeachersByDepartment(int? id)
        {
            List<SelectListItem> teachersByDepartment = _context.Teachers.Where(t => t.DepartmentId == id)
                .OrderBy(t => t.TeacherName)
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.TeacherName
                }).ToList();

            return new SelectList(teachersByDepartment, "Value", "Text");
        }
    }

    public enum Designations
    {
        [Description("--Select a Designation--")]
        Default = 0,

        [Description("Chair Professor")]
        ChairProfessor,

        [Description("Professor")]
        Professor,

        [Description("Associate Professor")]
        AssociateProfessor,

        [Description("Assistant Professor")]
        AssistantProfessor,

        [Description("Visiting Professor")]
        VisitingProfessor,

        [Description("Adjunct Professor")]
        AdjunctProfessor,

        [Description("Lecturer")]
        Lecturer
    }

    public class Enum<T> where T : struct, IConvertible
    {
        public static List<SelectListItem> GetListItems()
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
        }
    }
}