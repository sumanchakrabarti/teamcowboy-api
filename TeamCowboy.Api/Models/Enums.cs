using Newtonsoft.Json;

namespace TeamCowboy.Api.Models
{
    public enum EventStatus
    {
        [JsonProperty("active")]
        Active,

        [JsonProperty("postponed")]
        postponed,

        [JsonProperty("canceled")]
        Canceled,

        [JsonProperty("forfeited")]
        Forfeited
    }

    public enum IsHomeAway
    {
        [JsonProperty("home")]
        Home,

        [JsonProperty("away")]
        Away
    }

    public enum EventOutcome
    {
        [JsonProperty("win")]
        Win,

        [JsonProperty("loss")]
        Loss,

        [JsonProperty("tie")]
        Tie
    }

    public enum EventRsvpStatus
    {
        [JsonProperty("available")]
        Available,

        [JsonProperty("yes")]
        Yes,

        [JsonProperty("maybe")]
        Maybe,

        [JsonProperty("no")]
        No,

        [JsonProperty("noresponse")]
        NoResponse,
    }

    public enum EventRsvpResponseStatus
    {
        [JsonProperty("rsvpOverTotal")]
        RsvpOverTotal,

        [JsonProperty("rsvpNotAllowed")]
        RsvpNotAllowed,

        [JsonProperty("userNotOnTeam")]
        UserNotOnTeam,

        [JsonProperty("commentsOverMaxLength")]
        CommentsOverMaxLength,

        [JsonProperty("generalError")]
        GeneralError,
    }

    public enum TeamEventsFilter
    {
        Past,
        Future,
        SpecificDates,
        NextEvent,
        PreviousEvent
    }

    public enum TeamMessagesSortBy
    {
        Title,
        LastUpdated,
    }

    public enum TeamRosterSortBy
    {
        PlayerType,
        PlayerType_sex,
        Sex,
        Sex_playerType,
        Email,
        Email2,
        FirstName,
        LastName,
        Phone,
        TshirtSize,
        TshirtNumber,
        PantsSize,
        LastLogin,
        Active,
        InviteStatus
    }

    public enum SortDirection
    {
        Asc,
        Desc
    }
}
