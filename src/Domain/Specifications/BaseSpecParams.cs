using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications
{
    public class BaseSpecParams
    {
        private const int MaxPageSize = 10;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        
        public string? Sort { get; set; }
        
        private string? _searchTerm { get; set; }

        public string? SearchTerm
        {
            get => _searchTerm;
            set => _searchTerm = value?.ToLower();
        }
    }
}
