using System;

namespace mono_lvl3.Web_API.ViewModels
{
    public class ArtistViewModel
    {
        public Guid Id { get; set; }
        public string ArtistName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string From { get; set; }
    }
}