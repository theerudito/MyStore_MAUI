using MyStore_MAUI.Models;

namespace MyStore_MAUI.Services
{
    public interface IClient
    {

        Task<IEnumerable<MClient>> GetAllClientAsync();

        Task<MClient> GetOneClientAsync(int id);

        Task<MClient> createClientAsync(MClient client);

        Task<bool> updateClientAsync(MClient client);

        Task<bool> deleteClientAsync(MClient client);
    }
}
