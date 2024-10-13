﻿namespace Atlas_Monitoring_Web.Core.Models.ViewModels
{
    public class EntityReadViewModel
    {
        public Guid EntityId { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class EntityWriteViewModel
    {
        public Guid EntityId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
