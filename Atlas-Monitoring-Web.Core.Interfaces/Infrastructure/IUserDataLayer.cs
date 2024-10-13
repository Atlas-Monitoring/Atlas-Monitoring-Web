using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Interfaces.Infrastructure
{
    public interface IUserDataLayer
    {
        #region Create

        #endregion

        #region Read
        /// <summary>
        /// Auth user
        /// </summary>
        /// <param name="authUserViewModel">Object AuthUserViewModel</param>
        /// <returns>Token</returns>
        Task<string> AuthUser(AuthUserViewModel authUserViewModel);
        #endregion

        #region Update
        /// <summary>
        /// Update password
        /// </summary>
        /// <param name="authUserViewModel">Object AuthUserViewModel</param>
        Task UpdatePassword(AuthUserViewModel authUserViewModel);
        #endregion

        #region Delete

        #endregion
    }
}
