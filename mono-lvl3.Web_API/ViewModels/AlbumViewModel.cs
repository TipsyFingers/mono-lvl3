using System;

namespace mono_lvl3.Web_API.ViewModels
{
    public class AlbumViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime Relased { get; set; }
    }
}