﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications.EventSpec
{
    public class EventCountSpecification : BaseSpecification<Event>
    { 
        public EventCountSpecification(EventSpecParams eventSpecParams, bool include = true)
            : base(o => o.Brand.Name.Contains(eventSpecParams.BrandName) &&
                        (eventSpecParams.Field == Enums.BrandField.All || o.Brand.Field == eventSpecParams.Field.ToString())
            )
        {
            AddJoin(o => o.Brand);
        }
    }
}