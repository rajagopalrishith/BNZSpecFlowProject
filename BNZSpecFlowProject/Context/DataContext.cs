using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNZSpecFlowProject.Context
{
    public class DataContext
    {

        public double EverydayAccountInitialBalance { get; set; }
        public double EverydayAccountCurrentBalance { get; set; }


        public double BillsAccountInitialBalance { get; set; }
        public double BillsAccountCurrentBalance { get; set; }
    }
}
