using System.Threading.Tasks;

namespace WebAPIapp.Service
{
    public interface ITestService
    {
        Task<int> StreamProcessingScore(string input);
    }
}