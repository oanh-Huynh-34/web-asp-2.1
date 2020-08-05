using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnWebBanGiay.Models
{
    public class PagingInfo
    {
        public int totalItems { set; get; }
        public int ItemsPerPage { set; get; }
        public int CurrentPage { set; get; }
        public int totalPage => (int)Math.Ceiling((decimal)totalItems / ItemsPerPage);
        public string urlParam { set; get; }
    }
}
