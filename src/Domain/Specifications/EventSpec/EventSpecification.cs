﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications.EventSpec
{
    public class EventSpecification : BaseSpecification<Event>
    {
        public EventSpecification(EventSpecParams eventSpecParams, bool include = true)
            : base(o => (string.IsNullOrEmpty(eventSpecParams.BrandId) || o.BrandId.ToString() == eventSpecParams.BrandId) &&
                        o.Brand.Name.Contains(eventSpecParams.BrandName) &&
                        (eventSpecParams.Field == Enums.BrandField.All || o.Brand.Field == eventSpecParams.Field.ToString())
            )
        {
            AddJoin(o => o.Brand);
            AddOrderByDescending(o => o.StartAt);
            if (include)
            {
                AddInclude(o => o.Brand);
                AddInclude(o => o.Game);
                AddInclude(o => o.UserEvents);
                AddInclude(o => o.EventVouchers);
            }

            ApplyPaging(eventSpecParams.PageSize * (eventSpecParams.PageIndex - 1), eventSpecParams.PageSize); 
        }
    }
}