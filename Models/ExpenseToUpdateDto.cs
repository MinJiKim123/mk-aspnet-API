using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KimMinAPI.Models
{
    public class ExpenseToUpdateDto
    {
        public string Content { get; set; }
        public string Date { get; set; }
        public double Price { get; set; }
    }
}
