﻿using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Interfaces.Infrastructure
{
    public interface IEntityDataLayer
    {
        #region Create
        /// <summary>
        /// Add new entiry
        /// </summary>
        /// <param name="entityWriteViewModel">Object EntityWriteViewModel</param>
        /// <returns>Object EntityReadViewModel</returns>
        public Task<EntityReadViewModel> CreateNewEntity(EntityWriteViewModel entityWriteViewModel);
        #endregion

        #region Read
        /// <summary>
        /// Get list of entity
        /// </summary>
        /// <returns>Object EntityReadViewModel</returns>
        public Task<List<EntityReadViewModel>> GetListOfEntity();
        #endregion

        #region Update

        #endregion

        #region Delete
        /// <summary>
        /// Delete one entity by ID
        /// </summary>
        /// <param name="entityId">Entity Id</param>
        public Task DeleteOneEntity(Guid entityId);
        #endregion
    }
}
