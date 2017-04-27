using System;
using System.Collections.Generic;
using System.Linq;
using TweetSharp;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace NewsReader
{
    class TwitterFactory
    {
        private string consumerKey, consumerSecret, accessToken, accessTokenSecret;
        long userID;
        private TwitterService service;
        private ListTweetsOnUserTimelineOptions options;

        #region constructors
        public TwitterFactory()
        {

        }

        public TwitterFactory(
            String accessToken,
            String accessTokenSecret,
            String consumerKey,
            String consumerSecret,
            String userID
            )
        {
            this.accessToken = accessToken;
            this.accessTokenSecret = accessTokenSecret;
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
            Int64.TryParse(userID, out this.userID);

            service = new TwitterService(consumerKey, consumerSecret);
            options = new ListTweetsOnUserTimelineOptions()
            {
                UserId = this.userID,
                Count = 100
            };
        }
        #endregion constructors

        /// <summary>
        /// Push tweet to twitter via api
        /// </summary>
        /// <param name="tweet"></param>
        /// <returns></returns>
        public String Push(string tweet)
        {
            SendTweetOptions options = new SendTweetOptions()
            {
                Status = tweet
            };
            TwitterService service = new TwitterService(consumerKey, consumerSecret);
            service.AuthenticateWith(accessToken, accessTokenSecret);
            TwitterStatus result = service.SendTweet(options);
            string status;
            if (result == null)
            {
                status = service.Response.Error.ToString();
            }
            else
            {
                status = "Tweet successfully sent";
            }
            return status;
        }


        /// <summary>
        /// returns users timeline of recent tweets.
        /// </summary>
        /// <returns></returns>
        public List<TwitterStatus> LoadTwitterTimeline()
        {
            service.AuthenticateWith(accessToken, accessTokenSecret);
            return service.ListTweetsOnUserTimeline(options).ToList();
        }
    }
}
