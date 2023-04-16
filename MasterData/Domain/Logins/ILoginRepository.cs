
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Logins
{
    public interface ILoginRepository: IRepository< Login,  LoginId>
    {
        Task< Login> GetByUserAsync(string user);
    }
}