using Newtonsoft.Json;

namespace LibSnoo.Models
{
    public class UserViewModel
    {

        [JsonProperty("is_employee")]
        public bool IsEmployee { get; set; }

        [JsonProperty("seen_layout_switch")]
        public bool SeenLayoutSwitch { get; set; }

        [JsonProperty("has_visited_new_profile")]
        public bool HasVisitedNewProfile { get; set; }

        [JsonProperty("pref_no_profanity")]
        public bool PrefNoProfanity { get; set; }

        [JsonProperty("has_external_account")]
        public bool HasExternalAccount { get; set; }

        [JsonProperty("pref_geopopular")]
        public string PrefGeopopular { get; set; }

        [JsonProperty("seen_redesign_modal")]
        public bool SeenRedesignModal { get; set; }

        [JsonProperty("pref_show_trending")]
        public bool PrefShowTrending { get; set; }

        [JsonProperty("subreddit")]
        public SubredditViewModel Subreddit { get; set; }

        [JsonProperty("is_sponsor")]
        public bool IsSponsor { get; set; }

        [JsonProperty("gold_expiration")]
        public object GoldExpiration { get; set; }

        [JsonProperty("has_gold_subscription")]
        public bool HasGoldSubscription { get; set; }

        [JsonProperty("num_friends")]
        public int NumFriends { get; set; }

        [JsonProperty("features")]
        public FeaturesViewModel Features { get; set; }

        [JsonProperty("has_android_subscription")]
        public bool HasAndroidSubscription { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("new_modmail_exists")]
        public object NewModmailExists { get; set; }

        [JsonProperty("pref_autoplay")]
        public bool PrefAutoplay { get; set; }

        [JsonProperty("coins")]
        public int Coins { get; set; }

        [JsonProperty("has_paypal_subscription")]
        public bool HasPaypalSubscription { get; set; }

        [JsonProperty("has_subscribed_to_premium")]
        public bool HasSubscribedToPremium { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("has_stripe_subscription")]
        public bool HasStripeSubscription { get; set; }

        [JsonProperty("seen_premium_adblock_modal")]
        public bool SeenPremiumAdblockModal { get; set; }

        [JsonProperty("can_create_subreddit")]
        public bool CanCreateSubreddit { get; set; }

        [JsonProperty("over_18")]
        public bool Over18 { get; set; }

        [JsonProperty("is_gold")]
        public bool IsGold { get; set; }

        [JsonProperty("is_mod")]
        public bool IsMod { get; set; }

        [JsonProperty("suspension_expiration_utc")]
        public object SuspensionExpirationUtc { get; set; }

        [JsonProperty("has_verified_email")]
        public bool HasVerifiedEmail { get; set; }

        [JsonProperty("is_suspended")]
        public bool IsSuspended { get; set; }

        [JsonProperty("pref_video_autoplay")]
        public bool PrefVideoAutoplay { get; set; }

        [JsonProperty("in_chat")]
        public bool InChat { get; set; }

        [JsonProperty("in_redesign_beta")]
        public bool InRedesignBeta { get; set; }

        [JsonProperty("icon_img")]
        public string IconImg { get; set; }

        [JsonProperty("has_mod_mail")]
        public bool HasModMail { get; set; }

        [JsonProperty("pref_nightmode")]
        public bool PrefNightmode { get; set; }

        [JsonProperty("oauth_client_id")]
        public string OauthClientId { get; set; }

        [JsonProperty("hide_from_robots")]
        public bool HideFromRobots { get; set; }

        [JsonProperty("link_karma")]
        public int LinkKarma { get; set; }

        [JsonProperty("force_password_reset")]
        public bool ForcePasswordReset { get; set; }

        [JsonProperty("inbox_count")]
        public int InboxCount { get; set; }

        [JsonProperty("pref_top_karma_subreddits")]
        public bool PrefTopKarmaSubreddits { get; set; }

        [JsonProperty("has_mail")]
        public bool HasMail { get; set; }

        [JsonProperty("pref_show_snoovatar")]
        public bool PrefShowSnoovatar { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pref_clickgadget")]
        public int PrefClickgadget { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("gold_creddits")]
        public int GoldCreddits { get; set; }

        [JsonProperty("created_utc")]
        public int CreatedUtc { get; set; }

        [JsonProperty("has_ios_subscription")]
        public bool HasIosSubscription { get; set; }

        [JsonProperty("pref_show_twitter")]
        public bool PrefShowTwitter { get; set; }

        [JsonProperty("in_beta")]
        public bool InBeta { get; set; }

        [JsonProperty("comment_karma")]
        public int CommentKarma { get; set; }

        [JsonProperty("has_subscribed")]
        public bool HasSubscribed { get; set; }

        [JsonProperty("seen_subreddit_chat_ftux")]
        public bool SeenSubredditChatFtux { get; set; }
    }
}


