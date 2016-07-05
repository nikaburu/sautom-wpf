using System.ServiceModel;
using Sautom.Server.TransportDto;

namespace Sautom.Server.Interfaces
{
    [ServiceContract]
    public interface IAuthorizationService
    {
	    [OperationContract]
        AunthorizationCredentialsDtoOutput GetCredentials(string name, string password);

	    [OperationContract]
        bool ChangePassword(string name, string password, string newPassword);
    }
}
