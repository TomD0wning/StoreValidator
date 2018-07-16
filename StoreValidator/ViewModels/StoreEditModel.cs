using System;
using System.ComponentModel.DataAnnotations;
using StoreValidator.Models;

namespace StoreValidator.ViewModels
{
    public class StoreEditModel
    {
            
        [Display(Name = "Store Name")]
        [DataType(DataType.Text)]
        [Required, MaxLength(80)]
        public string Name { get; set; }

        [Display(Name = "Store Description")]
        [DataType(DataType.Text)]
        [MaxLength(120)]
        public string Desc { get; set; }

        [DataType(DataType.Text)]
        public string Address { get; set; }

        [DataType(DataType.Text)]
        public string PostCode { get; set; }

        [DataType(DataType.Text)]
        public StoreType StoreType { get; set; }


        public long StoreSize { get; set; }

        [DataType(DataType.Date)]
        public string OpenDate { get; set; }
    }
}
