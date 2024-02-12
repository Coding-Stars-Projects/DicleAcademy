using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelsDto
{
    public class WelcomeInformationsDto
    {
       
        public int WelcomeInformationId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
