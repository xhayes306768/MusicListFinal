using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicListFinal.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        //name
        [Required(ErrorMessage = "Please enter the artist's name.")]
        public string Name { get; set; } = string.Empty;


        //dob
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter the artist's date of birth.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        //songs
        [Display(Name = "List of Songs")]
        public List<string> Songs { get; set; } = new List<string>();


        //awards
        [Display(Name = "Awards Won")]
        [Range(0, int.MaxValue, ErrorMessage = "Awards must be a non-negative number.")]
        public int? AwardsWon { get; set; }
    }
}
