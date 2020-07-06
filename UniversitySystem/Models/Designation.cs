using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public class Designation
    {
        public DesignationList Id { get; set; }
        public string DesignationName { get; set; }
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