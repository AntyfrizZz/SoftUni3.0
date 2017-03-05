using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniStore.Models.ViewModels
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public decimal Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
