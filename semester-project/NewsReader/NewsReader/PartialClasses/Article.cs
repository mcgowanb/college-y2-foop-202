namespace NewsReader
{
    using System;
    using System.Collections.Generic;

    public partial class Article
    {
        private const int TWEET_LENGTH = 136;

        private String iconUrl;
        

        public Article(String guid, String title, DateTime date, String desc, String category, String hashtag, int websiteID)
        {
            GUID = guid;
            Title = title;
            Date = date;
            Description = desc;
            Category = category;
            HashTag = SetHashTag(hashtag);
            WebsiteID = websiteID;
        }
        public Article()
        {

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

        public String getIconUrl()
        {
            String returnString = "";
            switch (this.WebsiteID)
            {
                case 1:
                    returnString = "images/journal.ico";
                    break;
                case 2:
                    returnString = "images/the42.png";
                    break;
                case 3:
                    returnString = "images/dailyEdge.ico";
                    break;
            }
            return returnString;
        }
    }
}

