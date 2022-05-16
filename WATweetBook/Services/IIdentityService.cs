using System.Threading.Tasks;
using WATweetBook.Domain;

namespace WATweetBook.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
    }
}
