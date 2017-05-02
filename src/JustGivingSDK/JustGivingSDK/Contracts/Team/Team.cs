using System;
using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Team
{
    public class Team 
    {
        /// <summary>
        /// Team Id, unused in create / update
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The name of the team
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// teamShortName which translates to "/teams/{teamShortName}" on JustGiving.com
        /// </summary>
        public string TeamShortName { get; set; }

        /// <summary>
        /// The story of the team
        /// </summary>
        public string Story { get; set; }

        /// <summary>
        /// Team target type is "Fixed" or "Aggregate"
        /// </summary>
        public TeamTargetType TargetType { get; set; }

        /// <summary>
        /// Team invite mode, one of "Open", "Closed", "ByInvitationOnly"
        /// </summary>
        public TeamType TeamType { get; set; }

        /// <summary>
        /// Team target is a total of member pages: "Aggregate"
        /// Team target is specified value: "Fixed"
        /// </summary>
        public decimal TeamTarget { get; set; }

        /// <summary>
        /// Team creation date, automatically generated on the server, unused in create / update
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Team total, automatically generated on the server, unused in create / update
        /// </summary>
        public decimal? RaisedSoFar { get; set; }

        public string CurrencySymbol { get; set; }

        public decimal LocalRaisedSoFar { get; set; }

        public string LocalCurrencySymbol { get; set; }

        /// <summary>
        /// TeamMembers to add to team using PageShortName. Already existing team members will be ignored in the request as will team members without a valid PageShortName 
        /// </summary>
        public IList<TeamMember> TeamMembers { get; set; }

        /// <summary>
        /// TeamImages to add to team using 
        /// </summary>
        public TeamImages TeamImages { get; set; }
    }
}
