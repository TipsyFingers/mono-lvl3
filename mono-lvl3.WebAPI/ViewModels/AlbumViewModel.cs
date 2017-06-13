using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace mono_lvl3.WebAPI.ViewModels
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

        [DisplayName("Datum izlaska")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Relased { get; set; }


        /// <summary>
        ///  Navigation properties
        /// </summary>
        public virtual ICollection<ArtistViewModel> Artists { get; set; }
        public virtual ICollection<SongViewModel> Songs { get; set; }
    }

    public class DateFormatValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            var format = "0:dd/MM/yyyy";
            bool parsed = DateTime.TryParseExact((string)value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (!parsed)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}