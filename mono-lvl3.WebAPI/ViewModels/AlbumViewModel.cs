﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace mono_lvl3.WebMVC.ViewModels
{
    public class AlbumViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Ime albuma")]
        [StringLength(50, ErrorMessage = "Maksimalno dozvoljena dužina je 50 znakova.")]
        public string Name { get; set; }

        [DisplayName("Žanr")]
        [StringLength(50, ErrorMessage = "Maksimalno dozvoljena dužina je 50 znakova.")]
        public string Genre { get; set; }

        [DisplayName("Cijena")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Price { get; set; }


        /// <summary>
        ///  Navigation properties
        /// </summary>
        public virtual ICollection<ArtistViewModel> Artists { get; set; }
        public virtual ICollection<SongViewModel> Songs { get; set; }
    }
}