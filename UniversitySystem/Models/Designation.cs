using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySystem.Models
{
    public class Designation
    {
        private readonly ApplicationDbContext _context;

        public Designation()
        {
            _context = new ApplicationDbContext();
        }

        public DesignationList Id { get; set; }
        public string DesignationName { get; set; }

        //methods
        public IEnumerable<SelectListItem> GetDesignationListItems()
        {
            List<SelectListItem> designationList = _context.Designations.AsNoTracking()
                .OrderBy(d => d.DesignationName)
                .Select(d =>
                    new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.DesignationName
                    }).ToList();

            designationList.Insert(0, new SelectListItem{Value = "0", Text = "--Select Designation--"});

            return new SelectList(designationList, "Value", "Text");
        }
    }

    public enum DesignationList
    {
        ChairProfessor = 1,
        Professor,
        AssociateProfessor,
        AssistantProfessor,
        VisitingProfessor,
        AdjunctProfessor,
        Lecturer
    }
}