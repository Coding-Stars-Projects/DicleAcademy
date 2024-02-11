using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class GetInTouch
    {
        [Key]
        public int GetInTouchId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
