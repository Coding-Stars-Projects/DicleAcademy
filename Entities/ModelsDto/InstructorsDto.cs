using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class InstructorsDto
    {
        
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AreaOfExpertise { get; set; }

    }
}
