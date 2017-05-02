using System.Net.Http;
using System.Threading.Tasks;
using JustGivingSDK.Contracts.Project;
using JustGivingSDK.Logging;

namespace JustGivingSDK.Clients.Project
{
    public class ProjectClient : ClientBase, IProjectClient
    {
        public ProjectClient(HttpClient http, ApiRequestLogger logger) : base(http, logger)
        {
        }

        public async Task<GlobalProject> GetGlobalProjectById(int id)
        {
            var resource = $"/v1/project/global/{id}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GlobalProject>(request);
        }
    }
}
