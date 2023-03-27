using MyStore_MAUI.Models;

namespace MyStore_MAUI.Services
{
    interface IAuth
    {
        Task<IEnumerable<MAuth>> GetAllUsersAsync();
        bool Login(string email, string password);
        bool Register(string name, string email, string password);
    }
}
