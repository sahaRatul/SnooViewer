using Newtonsoft.Json;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace LibSnoo.Models
{
    public class MainDataViewModel
    {
        //Base properties
        [JsonProperty("user_flair_background_color")]
        public string UserFlairBackgroundColor { get; set; }

        [JsonProperty("submit_text_html")]
        public string SubmitTextHtml { get; set; }

        [JsonProperty("restrict_posting")]
        public bool? RestrictPosting { get; set; }

        [JsonProperty("user_is_banned")]
        public bool? UserIsBanned { get; set; }

        [JsonProperty("free_form_reports")]
        public bool FreeFormReports { get; set; }

        [JsonProperty("wiki_enabled")]
        public bool? WikiEnabled { get; set; }

        [JsonProperty("user_is_muted")]
        public bool? UserIsMuted { get; set; }

        [JsonProperty("user_can_flair_in_sr")]
        public bool? UserCanFlairInSr { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("header_img")]
        public string HeaderImg { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("icon_size")]
        public object IconSize { get; set; }

        [JsonProperty("primary_color")]
        public string PrimaryColor { get; set; }

        [JsonProperty("active_user_count")]
        public int? ActiveUserCount { get; set; }

        [JsonProperty("icon_img")]
        public string IconImg { get; set; }

        [JsonProperty("display_name_prefixed")]
        public string DisplayNamePrefixed { get; set; }

        [JsonProperty("accounts_active")]
        public object AccountsActive { get; set; }

        [JsonProperty("public_traffic")]
        public bool PublicTraffic { get; set; }

        [JsonProperty("subscribers")]
        public int? Subscribers { get; set; }

        [JsonProperty("user_flair_richtext")]
        public IList<object> UserFlairRichtext { get; set; }

        [JsonProperty("videostream_links_count")]
        public int? VideostreamLinksCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quarantine")]
        public bool? Quarantine { get; set; }

        [JsonProperty("hide_ads")]
        public bool? HideAds { get; set; }

        [JsonProperty("emojis_enabled")]
        public bool? EmojisEnabled { get; set; }

        [JsonProperty("advertiser_category")]
        public string AdvertiserCategory { get; set; }

        [JsonProperty("public_description")]
        public string PublicDescription { get; set; }

        [JsonProperty("comment_score_hide_mins")]
        public int? CommentScoreHideMins { get; set; }

        [JsonProperty("user_has_favorited")]
        public bool? UserHasFavorited { get; set; }

        [JsonProperty("user_flair_template_id")]
        public string UserFlairTemplateId { get; set; }

        [JsonProperty("community_icon")]
        public string CommunityIcon { get; set; }

        [JsonProperty("banner_background_image")]
        public string BannerBackgroundImage { get; set; }

        [JsonProperty("original_content_tag_enabled")]
        public bool? OriginalContentTagEnabled { get; set; }

        [JsonProperty("submit_text")]
        public string SubmitText { get; set; }

        [JsonProperty("description_html")]
        public string DescriptionHtml { get; set; }

        [JsonProperty("spoilers_enabled")]
        public bool? SpoilersEnabled { get; set; }

        [JsonProperty("header_title")]
        public string HeaderTitle { get; set; }

        [JsonProperty("header_size")]
        public object HeaderSize { get; set; }

        [JsonProperty("user_flair_position")]
        public string UserFlairPosition { get; set; }

        [JsonProperty("all_original_content")]
        public bool? AllOriginalContent { get; set; }

        [JsonProperty("collections_enabled")]
        public bool? CollectionsEnabled { get; set; }

        [JsonProperty("is_enrolled_in_new_modmail")]
        public bool? IsEnrolledInNewModmail { get; set; }

        [JsonProperty("key_color")]
        public string KeyColor { get; set; }

        [JsonProperty("event_posts_enabled")]
        public bool? EventPostsEnabled { get; set; }

        [JsonProperty("can_assign_user_flair")]
        public bool? CanAssignUserFlair { get; set; }

        [JsonProperty("created")]
        public double Created { get; set; }

        [JsonProperty("wls")]
        public object Wls { get; set; }

        [JsonProperty("show_media_preview")]
        public bool? ShowMediaPreview { get; set; }

        [JsonProperty("submission_type")]
        public string SubmissionType { get; set; }

        [JsonProperty("user_is_subscriber")]
        public bool? UserIsSubscriber { get; set; }

        [JsonProperty("disable_contributor_requests")]
        public bool? DisableContributorRequests { get; set; }

        [JsonProperty("allow_videogifs")]
        public bool? AllowVideogifs { get; set; }

        [JsonProperty("user_flair_type")]
        public string UserFlairType { get; set; }

        [JsonProperty("collapse_deleted_comments")]
        public bool? CollapseDeletedComments { get; set; }
        
        [JsonProperty("emojis_custom_size")]
        public object EmojisCustomSize { get; set; }

        [JsonProperty("public_description_html")]
        public string PublicDescriptionHtml { get; set; }

        [JsonProperty("allow_videos")]
        public bool? AllowVideos { get; set; }

        [JsonProperty("notification_level")]
        public string NotificationLevel { get; set; }

        [JsonProperty("can_assign_link_flair")]
        public bool? CanAssignLinkFlair { get; set; }

        [JsonProperty("has_menu_widget")]
        public bool? HasMenuWidget { get; set; }

        [JsonProperty("accounts_active_is_fuzzed")]
        public bool? AccountsActiveIsFuzzed { get; set; }

        [JsonProperty("submit_text_label")]
        public string SubmitTextLabel { get; set; }

        [JsonProperty("link_flair_position")]
        public string LinkFlairPosition { get; set; }

        [JsonProperty("user_sr_flair_enabled")]
        public bool? UserSrFlairEnabled { get; set; }

        [JsonProperty("user_flair_enabled_in_sr")]
        public bool? UserFlairEnabledInSr { get; set; }

        [JsonProperty("allow_discovery")]
        public bool? AllowDiscovery { get; set; }

        [JsonProperty("user_sr_theme_enabled")]
        public bool? UserSrThemeEnabled { get; set; }

        [JsonProperty("link_flair_enabled")]
        public bool? LinkFlairEnabled { get; set; }

        [JsonProperty("subreddit_type")]
        public string SubredditType { get; set; }

        [JsonProperty("suggested_comment_sort")]
        public string SuggestedCommentSort { get; set; }

        [JsonProperty("banner_img")]
        public string BannerImg { get; set; }

        [JsonProperty("user_flair_text")]
        public string UserFlairText { get; set; }

        [JsonProperty("banner_background_color")]
        public string BannerBackgroundColor { get; set; }

        [JsonProperty("show_media")]
        public bool? ShowMedia { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("user_is_moderator")]
        public bool? UserIsModerator { get; set; }

        [JsonProperty("over18")]
        public bool? Over18 { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("submit_link_label")]
        public string SubmitLinkLabel { get; set; }

        [JsonProperty("user_flair_text_color")]
        public string UserFlairTextColor { get; set; }

        [JsonProperty("restrict_commenting")]
        public bool? RestrictCommenting { get; set; }

        [JsonProperty("user_flair_css_class")]
        public string UserFlairCssClass { get; set; }

        [JsonProperty("allow_images")]
        public bool? AllowImages { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("whitelist_status")]
        public string WhitelistStatus { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_utc")]
        public int? CreatedUtc { get; set; }

        [JsonProperty("banner_size")]
        public object BannerSize { get; set; }

        [JsonProperty("mobile_banner_image")]
        public string MobileBannerImage { get; set; }

        [JsonProperty("user_is_contributor")]
        public bool? UserIsContributor { get; set; }

        //Post specific properties
        [JsonProperty("approved_at_utc")]
        public int? ApprovedAtUtc { get; set; }

        [JsonProperty("subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty("selftext")]
        public string Selftext { get; set; }

        [JsonProperty("author_fullname")]
        public string AuthorFullname { get; set; }

        [JsonProperty("saved")]
        public bool? Saved { get; set; }

        [JsonProperty("mod_reason_title")]
        public string ModReasonTitle { get; set; }

        [JsonProperty("gilded")]
        public int? Gilded { get; set; }

        [JsonProperty("clicked")]
        public bool? Clicked { get; set; }

        [JsonProperty("link_flair_richtext")]
        public IList<object> LinkFlairRichtext { get; set; }

        [JsonProperty("subreddit_name_prefixed")]
        public string SubredditNamePrefixed { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("pwls")]
        public int? Pwls { get; set; }

        [JsonProperty("link_flair_css_class")]
        public string LinkFlairCssClass { get; set; }

        [JsonProperty("downs")]
        public int? Downs { get; set; }

        [JsonProperty("thumbnail_height")]
        public int? ThumbnailHeight { get; set; }

        [JsonProperty("hide_score")]
        public bool? HideScore { get; set; }

        [JsonProperty("link_flair_text_color")]
        public string LinkFlairTextColor { get; set; }

        [JsonProperty("author_flair_background_color")]
        public string AuthorFlairBackgroundColor { get; set; }

        [JsonProperty("ups")]
        public int? Ups { get; set; }

        [JsonProperty("total_awards_received")]
        public int? TotalAwardsReceived { get; set; }

        [JsonProperty("thumbnail_width")]
        public int? ThumbnailWidth { get; set; }

        [JsonProperty("author_flair_template_id")]
        public string AuthorFlairTemplateId { get; set; }

        [JsonProperty("is_original_content")]
        public bool? IsOriginalContent { get; set; }

        [JsonProperty("user_reports")]
        public IList<object> UserReports { get; set; }

        [JsonProperty("is_reddit_media_domain")]
        public bool IsRedditMediaDomain { get; set; }

        [JsonProperty("is_meta")]
        public bool IsMeta { get; set; }

        [JsonProperty("category")]
        public object Category { get; set; }

        [JsonProperty("link_flair_text")]
        public string LinkFlairText { get; set; }

        [JsonProperty("can_mod_post")]
        public bool CanModPost { get; set; }

        [JsonProperty("score")]
        public int? Score { get; set; }

        [JsonProperty("approved_by")]
        public object ApprovedBy { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("edited")]
        public object Edited { get; set; }

        [JsonProperty("author_flair_css_class")]
        public string AuthorFlairCssClass { get; set; }

        [JsonProperty("author_flair_richtext")]
        public IList<object> AuthorFlairRichtext { get; set; }

        [JsonProperty("gildings")]
        public Gildings Gildings { get; set; }

        [JsonProperty("content_categories")]
        public object ContentCategories { get; set; }

        [JsonProperty("is_self")]
        public bool IsSelf { get; set; }

        [JsonProperty("mod_note")]
        public object ModNote { get; set; }

        [JsonProperty("link_flair_type")]
        public string LinkFlairType { get; set; }

        [JsonProperty("banned_by")]
        public object BannedBy { get; set; }

        [JsonProperty("author_flair_type")]
        public string AuthorFlairType { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("allow_live_comments")]
        public bool? AllowLiveComments { get; set; }

        [JsonProperty("selftext_html")]
        public string SelftextHtml { get; set; }

        [JsonProperty("likes")]
        public object Likes { get; set; }

        [JsonProperty("suggested_sort")]
        public string SuggestedSort { get; set; }

        [JsonProperty("banned_at_utc")]
        public object BannedAtUtc { get; set; }

        [JsonProperty("view_count")]
        public object ViewCount { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("no_follow")]
        public bool NoFollow { get; set; }

        [JsonProperty("is_crosspostable")]
        public bool IsCrosspostable { get; set; }

        [JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [JsonProperty("all_awardings")]
        public IList<object> AllAwardings { get; set; }

        [JsonProperty("media_only")]
        public bool MediaOnly { get; set; }

        [JsonProperty("link_flair_template_id")]
        public string LinkFlairTemplateId { get; set; }

        [JsonProperty("can_gild")]
        public bool CanGild { get; set; }

        [JsonProperty("spoiler")]
        public bool Spoiler { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("author_flair_text")]
        public string AuthorFlairText { get; set; }

        [JsonProperty("visited")]
        public bool Visited { get; set; }

        [JsonProperty("num_reports")]
        public object NumReports { get; set; }

        [JsonProperty("distinguished")]
        public string Distinguished { get; set; }

        [JsonProperty("subreddit_id")]
        public string SubredditId { get; set; }

        [JsonProperty("mod_reason_by")]
        public object ModReasonBy { get; set; }

        [JsonProperty("removal_reason")]
        public object RemovalReason { get; set; }

        [JsonProperty("link_flair_background_color")]
        public string LinkFlairBackgroundColor { get; set; }

        [JsonProperty("is_robot_indexable")]
        public bool IsRobotIndexable { get; set; }

        [JsonProperty("report_reasons")]
        public object ReportReasons { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("num_crossposts")]
        public int? NumCrossposts { get; set; }

        [JsonProperty("num_comments")]
        public int? NumComments { get; set; }

        [JsonProperty("send_replies")]
        public bool? SendReplies { get; set; }

        //[JsonProperty("whitelist_status")]
        //public string WhitelistStatus { get; set; }

        [JsonProperty("contest_mode")]
        public bool? ContestMode { get; set; }

        [JsonProperty("mod_reports")]
        public IList<object> ModReports { get; set; }

        [JsonProperty("author_patreon_flair")]
        public bool? AuthorPatreonFlair { get; set; }

        [JsonProperty("author_flair_text_color")]
        public string AuthorFlairTextColor { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("parent_whitelist_status")]
        public string ParentWhitelistStatus { get; set; }

        [JsonProperty("stickied")]
        public bool? Stickied { get; set; }

        [JsonProperty("subreddit_subscribers")]
        public int SubredditSubscribers { get; set; }

        [JsonProperty("discussion_type")]
        public object DiscussionType { get; set; }

        [JsonProperty("is_video")]
        public bool? IsVideo { get; set; }

        //Comment specific properties
        [JsonProperty("link_id")]
        public string LinkId { get; set; }

        [JsonProperty("replies")]
        public KindViewModel Replies { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("is_submitter")]
        public bool? IsSubmitter { get; set; }

        [JsonProperty("collapsed_reason")]
        public string CollapsedReason { get; set; }

        [JsonProperty("body_html")]
        public string BodyHtml { get; set; }

        [JsonProperty("score_hidden")]
        public bool? ScoreHidden { get; set; }

        [JsonProperty("collapsed")]
        public bool? Collapsed { get; set; }

        [JsonProperty("controversiality")]
        public int? Controversiality { get; set; }

        [JsonProperty("depth")]
        public int? Depth { get; set; }

        //FUCK Reddit's json format
        public List<MainDataViewModel> RepliesShallow { get; set; }
        public int? CommentDepth { get; set; }
        public Thickness Padding { get; set; }
    }
}
