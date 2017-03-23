using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsReader
{
    class News
    {
        public List<Website> Websites { get; private set; }
        public List<Article> CurrentNewsArticles { get; private set; }
        public List<Article> NewArticles { get; private set; }
        NewsEntities db;
        public News()
        {
            db = new NewsEntities();
            LoadWebsiteList();
            LoadCurrentNewsArticles();
        }

        private void LoadWebsiteList()
        {
            var query = from wb in db.Websites
                        select wb;
            Websites = query.ToList();

        }

        private void LoadCurrentNewsArticles()
        {
            try
            {
                var query = from a in db.Articles
                            select a;
                CurrentNewsArticles = query.ToList();
            }
            catch (System.Reflection.TargetInvocationException e)
            {
                CurrentNewsArticles = new List<Article>();
            }
        }


        public void RefreshArticles()
        {
            CurrentNewsArticles.Clear();
            foreach (var item in Websites)
            {
                String url = item.URL;
                XmlParser p = new XmlParser(url);
                CurrentNewsArticles.AddRange(p.FetchArticles());
            }

            DeleteRecords();
            InsertRecords();
        }

        private void InsertRecords()
        {
            foreach (var item in CurrentNewsArticles)
            {
                db.Articles.Add(item);
            }
            db.SaveChanges();
        }

        private void DeleteRecords()
        {
            var deleteRecords = from n in db.Articles
                                select n;

            if (deleteRecords.Any())
            {
                foreach (var item in deleteRecords)
                {
                    db.Articles.Remove(item);
                }

                db.SaveChanges();
            }
        }
    }
}
