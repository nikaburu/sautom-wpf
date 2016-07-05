using Sautom.Domain.Entities;
using Sautom.Services.Repositories;
using Sautom.Services.UnitOfWork;

namespace Sautom.Services
{
    public sealed class AuthorizationService
    {
	    #region Constructors

	    public AuthorizationService(IUnitOfWorkFactory unitOfWorkFactory, IAuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

	    #endregion

	    public ICommandState ChangePassword(string name, string password, string newPassword)
        {
            using (IUnitOfWork uow = _unitOfWorkFactory.Create())
            {
                Authorization auth = _authorizationRepository.GetAuthorization(name, password);
                if (auth == null)
                {
                    return new DefaultCommandState { IsValid = false };
                }

                auth.Password = newPassword;
                _authorizationRepository.Update(auth);

                uow.Commit();
            }
            
            return new DefaultCommandState { IsValid = true };
        }

	    #region Properties

	    private readonly IAuthorizationRepository _authorizationRepository;
	    private readonly IUnitOfWorkFactory _unitOfWorkFactory;

	    #endregion
    }
}
