using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mono_lvl3.WebAPI.ViewModels
{
    public class SongViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Ime")]
        [StringLength(50, ErrorMessage = "Maksimalno dozvoljena dužina je 50 znakova.")]
        public string Name { get; set; }

        [DisplayName("Trajanje")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Duration { get; set; }

        [DisplayName("Žanr")]
        [StringLength(50, ErrorMessage = "Maksimalno dozvoljena dužina je 50 znakova.")]
        public string Genre { get; set; }

        public Guid AlbumId { get; set; }


        /// <summary>
        ///  Navigation properties
        /// </summary>
        //public virtual AlbumViewModel Album { get; set; }
        public virtual ICollection<ArtistViewModel> Artists { get; set; }
    }
}