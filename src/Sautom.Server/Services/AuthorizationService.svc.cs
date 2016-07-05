using System.ServiceModel;
using Sautom.Queries;
using Sautom.Server.Interfaces;
using Sautom.Server.TransportDto;

namespace Sautom.Server.Services
{
    //todo T4
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    sealed public class AuthorizationService : IAuthorizationService 
    {
	    private readonly Sautom.Services.AuthorizationService _authorizationService;

	    #region Constructors

	    public AuthorizationService(IAuthorizationFinder authorizationFinder, Sautom.Services.AuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            AuthorizationFinder = authorizationFinder;
        }

	    #endregion

	    #region Properties

	    public IAuthorizationFinder AuthorizationFinder { get; set; }

	    #endregion

	    #region Implementation of IAuthorizationService

	    public AunthorizationCredentialsDtoOutput GetCredentials(string name, string password)
        {
            return AutoMapper.Mapper.Map<AunthorizationCredentialsDtoOutput>(AuthorizationFinder.GetCredentials(name, password));
        }

	    public bool ChangePassword(string name, string password, string newPassword)
        {
            return _authorizationService.ChangePassword(name, password, newPassword).IsValid;
        }

	    #endregion
    }
}
