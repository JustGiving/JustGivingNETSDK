using System;
using System.Threading.Tasks;
using JustGivingSDK.Contracts.Team;

namespace JustGivingSDK.Clients.Team
{
    public interface ITeamClient
    {
        Task<TeamSearchResponse> TeamSearch(int? page, int? pageSize, string teamShortName, int? teamId, string teamName, DateTime? teamCreatedOn, int? teamMemberPageId, string teamMemberPageShortName, string teamMemberPageOwnerName);
        Task<Contracts.Team.Team> GetTeam(string teamShortName);
        Task<TeamCreatedResponse> CreateOrUpdateTeam(string teamShortName, Contracts.Team.Team team);
        Task<bool> CheckIfTeamExists(string teamShortName);
        Task JoinTeam(string teamShortName, string pageShortName);
        Task<TeamCreatedResponse> CreateTeam(Contracts.Team.Team team);
        Task<TeamUpdatedResponse> CreateTeam(string teamShortName, Contracts.Team.Team team);
    }
}