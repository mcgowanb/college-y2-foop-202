using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsReader
{
    class News
    {
        public List<Website> Websites { get; private set; }
        public List<Article> CurrentNewsArticles { get; private set; }
        s00165159Entities db;
        public News()
        {
            db = new s00165159Entities();
            LoadWebsiteList();
            LoadCurrentNewsArticles();
        }

        private void LoadWebsiteList()
        {
            var query = from wb in db.Websites
                        select wb;
            Websites =  query.ToList();

        }

        private void LoadCurrentNewsArticles()
        {
            var query = from a in db.Articles
                        select a;
            CurrentNewsArticles = query.ToList();
        }
    }
}
