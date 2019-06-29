using System;

namespace LibSnoo.Models
{
    public partial class UserViewModel
    {
        public bool IsEmployee { get; set; }
        public bool SeenLayoutSwitch { get; set; }
        public bool HasVisitedNewProfile { get; set; }
        public bool PrefNoProfanity { get; set; }
        public bool HasExternalAccount { get; set; }
        public string PrefGeopopular { get; set; }
        public bool SeenRedesignModal { get; set; }
        public bool PrefShowTrending { get; set; }
        public SubredditViewModel Subreddit { get; set; }
        public bool IsSponsor { get; set; }
        public object GoldExpiration { get; set; }
        public bool HasGoldSubscription { get; set; }
        public long NumFriends { get; set; }
        public FeaturesViewModel Features { get; set; }
        public bool HasAndroidSubscription { get; set; }
        public bool Verified { get; set; }
        public bool PrefAutoplay { get; set; }
        public long Coins { get; set; }
        public bool HasPaypalSubscription { get; set; }
        public bool HasSubscribedToPremium { get; set; }
        public string Id { get; set; }
        public bool HasStripeSubscription { get; set; }
        public bool SeenPremiumAdblockModal { get; set; }
        public bool CanCreateSubreddit { get; set; }
        public bool Over18 { get; set; }
        public bool IsGold { get; set; }
        public bool IsMod { get; set; }
        public object SuspensionExpirationUtc { get; set; }
        public bool HasVerifiedEmail { get; set; }
        public bool IsSuspended { get; set; }
        public bool PrefVideoAutoplay { get; set; }
        public bool InRedesignBeta { get; set; }
        public Uri IconImg { get; set; }
        public bool PrefNightmode { get; set; }
        public string OauthClientId { get; set; }
        public bool HideFromRobots { get; set; }
        public long LinkKarma { get; set; }
        public bool ForcePasswordReset { get; set; }
        public long InboxCount { get; set; }
        public bool PrefTopKarmaSubreddits { get; set; }
        public bool PrefShowSnoovatar { get; set; }
        public string Name { get; set; }
        public long PrefClickgadget { get; set; }
        public long Created { get; set; }
        public long GoldCreddits { get; set; }
        public long CreatedUtc { get; set; }
        public bool HasIosSubscription { get; set; }
        public bool PrefShowTwitter { get; set; }
        public bool InBeta { get; set; }
        public long CommentKarma { get; set; }
        public bool HasSubscribed { get; set; }
        public bool SeenSubredditChatFtux { get; set; }
    }
}
