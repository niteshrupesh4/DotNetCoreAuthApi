using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Helpers
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int ItemPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PaginationHeader(int currenttPage, int itemperPage, int totalItems, int totalPages)
        {
            this.CurrentPage = currenttPage;
            this.ItemPerPage = itemperPage;
            this.TotalItems = totalItems;
            this.TotalPages = totalPages;
        }
    }
}
