using Newtonsoft.Json;
using System.Collections.Generic;

namespace LibSnoo.Models
{
    public class Gildings
    {
    }

    public class CommentViewModel
    {
        [JsonProperty("total_awards_received")]
        public int TotalAwardsReceived { get; set; }

        [JsonProperty("approved_at_utc")]
        public object ApprovedAtUtc { get; set; }

        [JsonProperty("ups")]
        public int Ups { get; set; }

        [JsonProperty("mod_reason_by")]
        public object ModReasonBy { get; set; }

        [JsonProperty("banned_by")]
        public object BannedBy { get; set; }

        [JsonProperty("author_flair_type")]
        public string AuthorFlairType { get; set; }

        [JsonProperty("removal_reason")]
        public object RemovalReason { get; set; }

        [JsonProperty("link_id")]
        public string LinkId { get; set; }

        [JsonProperty("author_flair_template_id")]
        public object AuthorFlairTemplateId { get; set; }

        [JsonProperty("likes")]
        public object Likes { get; set; }

        [JsonProperty("no_follow")]
        public bool NoFollow { get; set; }

        [JsonProperty("replies")]
        public string Replies { get; set; }

        [JsonProperty("user_reports")]
        public IList<object> UserReports { get; set; }

        [JsonProperty("saved")]
        public bool Saved { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("banned_at_utc")]
        public object BannedAtUtc { get; set; }

        [JsonProperty("mod_reason_title")]
        public object ModReasonTitle { get; set; }

        [JsonProperty("gilded")]
        public int Gilded { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("report_reasons")]
        public object ReportReasons { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("can_mod_post")]
        public bool CanModPost { get; set; }

        [JsonProperty("send_replies")]
        public bool SendReplies { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("author_fullname")]
        public string AuthorFullname { get; set; }

        [JsonProperty("approved_by")]
        public object ApprovedBy { get; set; }

        [JsonProperty("all_awardings")]
        public IList<object> AllAwardings { get; set; }

        [JsonProperty("subreddit_id")]
        public string SubredditId { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("edited")]
        public bool Edited { get; set; }

        [JsonProperty("author_flair_css_class")]
        public string AuthorFlairCssClass { get; set; }

        [JsonProperty("is_submitter")]
        public bool IsSubmitter { get; set; }

        [JsonProperty("downs")]
        public int Downs { get; set; }

        [JsonProperty("author_flair_richtext")]
        public IList<object> AuthorFlairRichtext { get; set; }

        [JsonProperty("author_patreon_flair")]
        public bool AuthorPatreonFlair { get; set; }

        [JsonProperty("collapsed_reason")]
        public object CollapsedReason { get; set; }

        [JsonProperty("body_html")]
        public string BodyHtml { get; set; }

        [JsonProperty("stickied")]
        public bool Stickied { get; set; }

        [JsonProperty("subreddit_type")]
        public string SubredditType { get; set; }

        [JsonProperty("can_gild")]
        public bool CanGild { get; set; }

        [JsonProperty("gildings")]
        public Gildings Gildings { get; set; }

        [JsonProperty("author_flair_text_color")]
        public string AuthorFlairTextColor { get; set; }

        [JsonProperty("score_hidden")]
        public bool ScoreHidden { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("num_reports")]
        public object NumReports { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty("author_flair_text")]
        public string AuthorFlairText { get; set; }

        [JsonProperty("collapsed")]
        public bool Collapsed { get; set; }

        [JsonProperty("created_utc")]
        public int CreatedUtc { get; set; }

        [JsonProperty("subreddit_name_prefixed")]
        public string SubredditNamePrefixed { get; set; }

        [JsonProperty("controversiality")]
        public int Controversiality { get; set; }

        [JsonProperty("depth")]
        public int Depth { get; set; }

        [JsonProperty("author_flair_background_color")]
        public string AuthorFlairBackgroundColor { get; set; }

        [JsonProperty("mod_reports")]
        public IList<object> ModReports { get; set; }

        [JsonProperty("mod_note")]
        public object ModNote { get; set; }

        [JsonProperty("distinguished")]
        public object Distinguished { get; set; }
    }
}
