using System;
using System.Collections;
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

        /// <summary>
        /// Loads current articles from database
        /// </summary>
        private void LoadCurrentNewsArticles()
        {
            try
            {
                var query = from a in db.Articles
                            orderby a.Date descending
                            select a;
                CurrentNewsArticles = query.ToList();
            }
            catch (System.Reflection.TargetInvocationException e)
            {
                CurrentNewsArticles = new List<Article>();
            }
        }


        /// <summary>
        /// Discard all articles in the database and reload with new ones from website
        /// </summary>
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

        public void FilterArticlesByName(string selected)
        {
            var query = from a in db.Articles
                        where a.Website.Name.Equals(selected)
                        select a;

            CurrentNewsArticles = query.ToList();
        }

        /// <summary>
        /// Inserts records into records table
        /// </summary>
        private void InsertRecords()
        {
            foreach (var item in CurrentNewsArticles)
            {
                db.Articles.Add(item);
            }
            db.SaveChanges();
        }

        //deletes all records from articles table
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

        private void LoadTwitterFeed()
        {

        }
    }
}
