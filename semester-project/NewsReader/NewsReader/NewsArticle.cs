using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsReader
{
    class NewsArticle : Article
    {
        private const int TWEET_LENGTH = 136;

        public NewsArticle(String guid, String title, DateTime date, String desc, String category, String hashtag, int websiteID)
        {
            GUID = guid;
            Title = title;
            Date = date;
            Description = desc;
            Category = category;
            HashTag = SetHashTag(hashtag);
            WebsiteID = websiteID;
        }



        public override string ToString()
        {
            int length = TWEET_LENGTH - (GUID.Length + HashTag.Length);
            if (Title.Length >= length)
            {
                Title = Title.Substring(0, (length - 3)) + "...";
            }
            return String.Format("{0}. {1} {2}", Title, GUID, HashTag);
        }

        public String GetArticleForTwitter()
        {
            int length = TWEET_LENGTH - (GUID.Length + HashTag.Length);
            if (Title.Length >= length)
            {
                Title = Title.Substring(0, (length - 3)) + "...";
            }
            return String.Format("{0}. {1} {2}", Title, GUID, HashTag);
        }

        private String SetHashTag(String tag)
        {
            return String.Format("#{0}", tag.ToLower().Replace(" ", ""));
        }

    }
}
