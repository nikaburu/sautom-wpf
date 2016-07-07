using System.ServiceModel;
using AutoMapper;
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

	    public AuthorizationService(IMapper mapper, IAuthorizationFinder authorizationFinder, Sautom.Services.AuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
		    Mapper = mapper;
		    AuthorizationFinder = authorizationFinder;
        }

	    #endregion

	    #region Properties

	    public IMapper Mapper { get; set; }
	    public IAuthorizationFinder AuthorizationFinder { get; set; }

	    #endregion

	    #region Implementation of IAuthorizationService

	    public AunthorizationCredentialsDtoOutput GetCredentials(string name, string password)
        {
            return Mapper.Map<AunthorizationCredentialsDtoOutput>(AuthorizationFinder.GetCredentials(name, password));
        }

	    public bool ChangePassword(string name, string password, string newPassword)
        {
            return _authorizationService.ChangePassword(name, password, newPassword).IsValid;
        }

	    #endregion
    }
}
