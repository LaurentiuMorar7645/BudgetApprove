
namespace BudgetApproved.Services
{
    public interface IHttpClientService
    {
        Task<IEnumerable<T>> GetAsync<T>(string endpoint);

        Task<T> PostAsync<T>(string endpoint, T data);
        
        void SetBaseAddress(string baseAddress);
    }
}
