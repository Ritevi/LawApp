using System.Threading.Tasks;

namespace LawApp.Bll.Services
{
    public interface IAdminService
    {
        Task PopulateDbAsync();
    }
}