﻿using Weapsy.Infrastructure.Domain;

namespace Weapsy.Domain.Sites.Events
{
    public class SiteDeleted : DomainEvent
    {
        public string Name { get; set; }
    }
}
