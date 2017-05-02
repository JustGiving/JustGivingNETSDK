using System.Threading.Tasks;
using JustGivingSDK.Contracts.Project;

namespace JustGivingSDK.Clients.Project
{
    public interface IProjectClient
    {
        Task<GlobalProject> GetGlobalProjectById(int id);
    }
}