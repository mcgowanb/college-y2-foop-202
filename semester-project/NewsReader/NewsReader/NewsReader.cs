using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsReader
{
    class NewsReader
    {
        s00165159Entities db;
        public NewsReader()
        {
            db = new s00165159Entities();
        }

        public List<Website> LoadWebsites()
        {
            var query = from wb in db.Websites
            select wb;
            return query.ToList();
        }


    }
}
