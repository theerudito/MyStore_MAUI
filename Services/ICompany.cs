using MyStore_MAUI.Models;

namespace MyStore_MAUI.Services
{
    internal interface ICompany
    {
        Task<MCompany> createCompanyAsync(MCompany company);

        Task<MCompany> companyAsync();

        Task<MCompany> getCompanyAsync(int ruc);

        Task<bool> updateCompanyAsync(MCompany company, int ruc);

        Task<bool> deleteCompanyAsync(int ruc);
    }
}
