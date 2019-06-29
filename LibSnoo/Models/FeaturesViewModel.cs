using Newtonsoft.Json;

namespace LibSnoo.Models
{
    public class FeaturesViewModel
    {

        [JsonProperty("chat_subreddit")]
        public bool ChatSubreddit { get; set; }

        [JsonProperty("show_amp_link")]
        public bool ShowAmpLink { get; set; }

        [JsonProperty("read_from_pref_service")]
        public bool ReadFromPrefService { get; set; }

        [JsonProperty("chat_rollout")]
        public bool ChatRollout { get; set; }

        [JsonProperty("chat")]
        public bool Chat { get; set; }

        [JsonProperty("chat_reddar_reports")]
        public bool ChatReddarReports { get; set; }

        [JsonProperty("default_srs_holdout")]
        public DefaultSrsHoldout DefaultSrsHoldout { get; set; }

        [JsonProperty("is_email_permission_required")]
        public bool IsEmailPermissionRequired { get; set; }

        [JsonProperty("richtext_previews")]
        public bool RichtextPreviews { get; set; }

        [JsonProperty("chat_subreddit_notification_ftux")]
        public bool ChatSubredditNotificationFtux { get; set; }

        [JsonProperty("email_verification")]
        public EmailVerification EmailVerification { get; set; }

        [JsonProperty("mweb_xpromo_revamp_v2")]
        public MwebXpromoRevampV2 MwebXpromoRevampV2 { get; set; }

        [JsonProperty("mweb_xpromo_modal_listing_click_daily_dismissible_ios")]
        public bool MwebXpromoModalListingClickDailyDismissibleIos { get; set; }

        [JsonProperty("community_awards")]
        public bool CommunityAwards { get; set; }

        [JsonProperty("dual_write_user_prefs")]
        public bool DualWriteUserPrefs { get; set; }

        [JsonProperty("do_not_track")]
        public bool DoNotTrack { get; set; }

        [JsonProperty("chat_user_settings")]
        public bool ChatUserSettings { get; set; }

        [JsonProperty("mweb_xpromo_interstitial_comments_ios")]
        public bool MwebXpromoInterstitialCommentsIos { get; set; }

        [JsonProperty("mweb_xpromo_interstitial_comments_android")]
        public bool MwebXpromoInterstitialCommentsAndroid { get; set; }

        [JsonProperty("mweb_sharing_web_share_api")]
        public MwebSharingWebShareApi MwebSharingWebShareApi { get; set; }

        [JsonProperty("chat_group_rollout")]
        public bool ChatGroupRollout { get; set; }

        [JsonProperty("custom_feeds")]
        public bool CustomFeeds { get; set; }

        [JsonProperty("spez_modal")]
        public bool SpezModal { get; set; }

        [JsonProperty("mweb_xpromo_modal_listing_click_daily_dismissible_android")]
        public bool MwebXpromoModalListingClickDailyDismissibleAndroid { get; set; }
    }

    public class DefaultSrsHoldout
    {

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("variant")]
        public string Variant { get; set; }

        [JsonProperty("experiment_id")]
        public int ExperimentId { get; set; }
    }

    public class EmailVerification
    {

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("variant")]
        public string Variant { get; set; }

        [JsonProperty("experiment_id")]
        public int ExperimentId { get; set; }
    }

    public class MwebXpromoRevampV2
    {

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("variant")]
        public string Variant { get; set; }

        [JsonProperty("experiment_id")]
        public int ExperimentId { get; set; }
    }

    public class MwebSharingWebShareApi
    {

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("variant")]
        public string Variant { get; set; }

        [JsonProperty("experiment_id")]
        public int ExperimentId { get; set; }
    }
}
