using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JustGivingSDK.Contracts.Team;
using JustGivingSDK.Logging;

namespace JustGivingSDK.Clients.Team
{
    public class TeamClient : ClientBase, ITeamClient
    {
        public TeamClient(HttpClient http, ApiRequestLogger logger) : base(http, logger)
        {
        }

        public async Task<TeamSearchResponse> TeamSearch(int? page, int? pageSize, string teamShortName, int? teamId, string teamName, DateTime? teamCreatedOn, int? teamMemberPageId, string teamMemberPageShortName, string teamMemberPageOwnerName)
        {
            var resource = $"/v1/team/search?page={page}&pageSize={pageSize}&teamShortName={Uri.EscapeDataString(teamShortName)}&teamId={teamId}&teamName={Uri.EscapeDataString(teamName)}&teamCreatedOn={FormatDate(teamCreatedOn)}&teamMemberPageId={teamMemberPageId}&teamMemberPageShortName={Uri.EscapeDataString(teamMemberPageShortName)}&teamMemberPageOwnerName={Uri.EscapeDataString(teamMemberPageOwnerName)}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<TeamSearchResponse>(request);
        }

        public async Task<Contracts.Team.Team> GetTeam(string teamShortName)
        {
            var resource = $"/v1/team/{teamShortName}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<Contracts.Team.Team>(request);
        }

        public async Task<TeamCreatedResponse> CreateOrUpdateTeam(string teamShortName, Contracts.Team.Team team)
        {
            var resource = $"/v1/team/{teamShortName}";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            return await Execute<TeamCreatedResponse, Contracts.Team.Team>(request, team);
        }

        public async Task<bool> CheckIfTeamExists(string teamShortName)
        {
            var resource = $"/v1/team/{teamShortName}";
            var request = new HttpRequestMessage(HttpMethod.Head, resource);
            return await ResourceExists(request);
        }

        public async Task JoinTeam(string teamShortName, string pageShortName)
        {
            var dto = new JoinTeamRequest {PageShortName = pageShortName};
            var resource = $"/v1/team/join/{teamShortName}";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            await Execute(request, dto);
        }

        public async Task<TeamCreatedResponse> CreateTeam(Contracts.Team.Team team)
        {
            var resource = "/v1/team";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            return await Execute<TeamCreatedResponse, Contracts.Team.Team>(request, team);
        }

        public async Task<TeamUpdatedResponse> CreateTeam(string teamShortName, Contracts.Team.Team team)
        {
            var resource = $"/v1/team/{teamShortName}";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            return await Execute<TeamUpdatedResponse, Contracts.Team.Team>(request, team);
        }

        private static string FormatDate(DateTime? dt)
        {
            if(!dt.HasValue) return String.Empty;

            return Uri.EscapeDataString($"{dt.Value.Year}-{dt.Value.Month}-{dt.Value.Day}");
        }
    }
}
