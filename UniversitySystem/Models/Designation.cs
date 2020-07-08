using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UniversitySystem.Models
{
    public class Designation
    {
        /*public Designations Id { get; set; }
        public string DesignationName { get; set; }*/

        //methods
        /*public IEnumerable<SelectListItem> GetListItems()
        {
            List<SelectListItem> designationList = _context.Designations.AsNoTracking()
                .OrderBy(d => d.DesignationName)
                .Select(d =>
                    new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.DesignationName.ToString()
                    }).ToList();

            designationList.Insert(0, new SelectListItem{Value = "0", Text = "--Select Designation--"});

            return new SelectList(designationList, "Value", "Text");
        }
    }*/
    }

    public enum Designations
    {
        [Description("Chair Professor")]
        ChairProfessor = 1,

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

                        item.Text = ((DescriptionAttribute) descriptionAttributes[0]).Description;
                    }

                    items.Add(item);


                }

            }

            return items;
        }
    }
}