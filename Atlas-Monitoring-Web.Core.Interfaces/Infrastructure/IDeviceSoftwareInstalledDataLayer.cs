﻿using Atlas_Monitoring_Web.Core.Models.ViewModels;

namespace Atlas_Monitoring_Web.Core.Interfaces.Infrastructure
{
    public interface IDeviceSoftwareInstalledDataLayer
    {
        #region Read
        /// <summary>
        /// Get all software install on a device
        /// </summary>
        /// <param name="deviceId">Device id</param>
        /// <returns>List of software</returns>
        public Task<List<DeviceSoftwareInstalledReadViewModel>> ListOfSoftwareOnDevice(Guid deviceId);
        #endregion
    }
}
