using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniStore.Models.BindingModels
{
    public class GameBindingModel
    {
        public string Title { get; set; }

        public string Trailer { get; set; }

        public string ImageThumbnail { get; set; }

        public decimal Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
