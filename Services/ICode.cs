using MyStore_MAUI.Models;

namespace MyStore_MAUI.Services
{
    public interface ICode
    {
        Task<MCodeApp> getCodeAsync(int codeAdmin);
    }
}