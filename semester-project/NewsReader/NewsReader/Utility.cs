using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsReader
{
    static class Utility
    {
        /// <summary>
        /// Static utility wrapper class for returning data from the system
        /// </summary>
        public enum WebSites { TheJournal, The42, TheDailyEdge };
        public const String BASELINE_URL = "https://twitter.com/ROINewsNow/status/";
        public static String GetWebURI(WebSites site)
        {
            String URI;
            switch (site)
            {
                case WebSites.TheJournal:
                    URI = Properties.Settings.Default.TheJournalXmlUri;
                    break;
                case WebSites.TheDailyEdge:
                    URI = Properties.Settings.Default.DailyEdgeXmlUri;
                    break;
                case WebSites.The42:
                    URI = Properties.Settings.Default.The42XmlUri;
                    break;
                default:
                    URI = null;
                    break;
            }
            return URI;
        }

        public static String GetUserID()
        {
            return Properties.Settings.Default.UserID;
        }

        public static String GetAccessToken()
        {
            return Properties.Settings.Default.AccessToken;
        }

        public static String GetAccessSecret()
        {
            return Properties.Settings.Default.AccessSecret;
        }

        public static String GetConsumeKey()
        {
            return Properties.Settings.Default.ConsumerKey;
        }

        public static String GetConsumerSecret()
        {
            return Properties.Settings.Default.ConsumerSecret;
        }
    }
}
