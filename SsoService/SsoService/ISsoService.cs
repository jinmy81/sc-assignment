using SsoService.Dto;
using System.ServiceModel;

namespace SsoService
{
    [ServiceContract]
    public interface ISsoService
    {
        [OperationContract]
        LoginDto Login(string userName, string password);

        [OperationContract]
        RegisterDto Register(string userName, string password);
    }
}