using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mono_lvl3.WebAPI.ViewModels
{
    public class ArtistViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Umjetničko ime")]
        [StringLength(50, ErrorMessage = "Maksimalno dozvoljena dužina je 50 znakova.")]
        public string ArtistName { get; set; }

        [DisplayName("Ime")]
        [StringLength(50, ErrorMessage = "Maksimalno dozvoljena dužina je 50 znakova.")]
        public string FName { get; set; }

        [DisplayName("Prezime")]
        [StringLength(50, ErrorMessage = "Maksimalno dozvoljena dužina je 50 znakova.")]
        public string LName { get; set; }

        [DisplayName("Država")]
        [StringLength(50, ErrorMessage = "Maksimalno dozvoljena dužina je 50 znakova.")]
        public string From { get; set; }


        /// <summary>
        ///  Navigation properties
        /// </summary>
        public virtual ICollection<AlbumViewModel> Albums { get; set; }
        public virtual ICollection<SongViewModel> Songs { get; set; }
    }
}