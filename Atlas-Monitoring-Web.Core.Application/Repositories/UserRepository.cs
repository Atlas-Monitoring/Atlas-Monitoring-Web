using Atlas_Monitoring_Web.Core.Interfaces.Application;
using Atlas_Monitoring_Web.Core.Interfaces.Infrastructure;
using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Properties
        private readonly IUserDataLayer _userDataLayer;
        #endregion

        #region Constructor
        public UserRepository(IUserDataLayer userDataLayer)
        {
            _userDataLayer = userDataLayer;
        }
        #endregion

        #region Publics Methods
        #region Create

        #endregion

        #region Read
        public async Task<string> AuthUser(AuthUserViewModel authUserViewModel)
        {
            return await _userDataLayer.AuthUser(authUserViewModel);
        }
        #endregion

        #region Update
        public async Task UpdatePassword(AuthUserViewModel authUserViewModel)
        {
            await _userDataLayer.UpdatePassword(authUserViewModel);
        }
        #endregion

        #region Delete

        #endregion
        #endregion
    }
}
