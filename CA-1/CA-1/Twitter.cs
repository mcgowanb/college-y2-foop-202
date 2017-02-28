using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace CA_1
{
    class Twitter
    {
        private String consumerKey = "Tg6Au8WRLlOtZQBjJI8Bk56QL";
        private String consumerSecret = "uo3AZ5TCuruw5A4yP1F0998ZoYSPkyw8gpu8zfqWw8HcUMQW9T";
        private String accessToken = "4222277297-W7AxgyKv6jnGizv2y8mpCv8MpRpbqQLzaw2fOeJ";
        private String accessTokenSecret = "fHrQ4JKWhskLKfwJFl5ow7FGqD1BXRW9KrlmqXgcUxaSS";

        public String Tweet(String s)
        {
            s = Utility.TrimTweetForDevelopment(s);
            SendTweetOptions options = new SendTweetOptions()
            {
                Status = s
            };
            TwitterService service = new TwitterService(this.consumerKey, this.consumerSecret);
            service.AuthenticateWith(this.accessToken, this.accessTokenSecret);
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
    }
}
