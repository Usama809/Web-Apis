using Attribute_Routing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Attribute_Routing.Controllers
{
    public class StudentV2Controller : ApiController
    {
        List<StudentV2> students = new List<StudentV2>()
        {
            new StudentV2 () {Id = 1 , FirstName ="Zain" , LastName="Akram"},
            new StudentV2() {Id = 2 , FirstName="Omer",LastName="Amjad"},
            new StudentV2 () {Id = 3 , FirstName ="Hassan", LastName="Ijaz"},
        };
        public IEnumerable<StudentV2> Get()
        {
            return students;
        }
        public StudentV2 Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
