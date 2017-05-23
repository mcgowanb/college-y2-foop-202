using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q_2
{
    //simple class to display the summaries for the categories
    class CategorySummary
    {
        public String Name { get; set; }
        public int Total { get; set; }

        public CategorySummary(){}
        public CategorySummary(String name, int total)
        {
            Name = name;
            Total = total;
        }

        public override string ToString()
        {
            return String.Format("{0} - ({1} Products)", Name, Total);
        }
    }
}
