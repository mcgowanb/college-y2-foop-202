using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;

namespace NewsReader
{
    class XmlParser
    {

        #region params
        private string url;
        private XmlDocument doc;
        private List<Article> list;
        private int WebsiteID;
        #endregion params
        #region ctor
        public XmlParser(string url)
        {
            this.url = url;
            this.doc = new XmlDocument();
            this.list = new List<Article>();
            this.WebsiteID = GenerateWebsiteID();
        }

        public XmlParser() {}
        #endregion ctor


        /// <summary>
        /// fetche and retuns a list of articles from the selected website,
        /// parses the xml and returns article objects
        /// </summary>
        /// <returns></returns>
        public List<Article> FetchArticles()
        {
            doc.Load(url);

            XmlElement rootNode = doc.DocumentElement;
            XmlNodeList nodes = rootNode.SelectNodes("channel/item");

            foreach (XmlNode node in nodes)
            {
                String GUID = node["guid"].InnerText;
                String title = node["title"].InnerText;
                DateTime date = Convert.ToDateTime(node["pubDate"].InnerText);
                String description = node["description"].InnerText;
                String category;
                try
                {
                    category = (node["category"].InnerText == null) ? node["category"].InnerText : " ";
                }
                catch (NullReferenceException)
                {
                    category = "null";
                }

                String hashTag;
                try
                {
                    hashTag = node["category"].InnerText;
                }
                catch (NullReferenceException)
                {
                    hashTag = "#null";
                }
                Article article = new Article(GUID, title, date, description, category, hashTag, WebsiteID);
                list.Add(article);
            }
            return list;
        }

        public int GenerateWebsiteID()
        {
            int id = 0;
            switch (url)
            {
                case "http://www.thejournal.ie/feed/":
                    id = 1;
                    break;
                case "http://www.the42.ie/feed/":
                    id = 2;
                    break;
                case "http://www.dailyedge.ie/feed/":
                    id = 3;
                    break;
                default:
                    id = 0;
                    break;
            }
            return id;
        }
    }
}
