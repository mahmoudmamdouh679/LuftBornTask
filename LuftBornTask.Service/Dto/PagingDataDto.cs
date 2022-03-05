using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Services.Dto
{
    public class PagingDataDto
    {
        const int PageMaxSize = 20;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > PageMaxSize) ? PageMaxSize : value;
        }

    }
}
