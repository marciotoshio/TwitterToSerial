using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetSharp;

namespace TwitterToSerialLib
{
    public class Twitter
    {
        private long lastTweetId = 0;
        public IEnumerable<Tweet> GetTweets(int take = 10)
        {
            List<Tweet> tweets = new List<Tweet>();
            tweets.Add(new Tweet() { Text = "tweet 1" });
            tweets.Add(new Tweet() { Text = "tweet 2" });
            tweets.Add(new Tweet() { Text = "tweet 3" });
            tweets.Add(new Tweet() { Text = "tweet 4" });
            tweets.Add(new Tweet() { Text = "tweet 5" });
            return tweets;

            //var service = new TwitterService();
            //IEnumerable<TwitterStatus> tweets;
            //if (lastTweetId == 0)
            //{
            //    tweets = service.ListTweetsOnSpecifiedUserTimeline("marciotoshio", take);
            //}
            //else
            //{
            //    tweets = service.ListTweetsOnSpecifiedUserTimelineSince("marciotoshio", lastTweetId, 10);

            //}
            //lastTweetId = tweets.First().Id;
            //return tweets;
        }
    }
}
