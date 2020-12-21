using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace KimMinAPI.Models
{
    
    public class ExpenseDto
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public double Price { get; set; }
        
    }
}
