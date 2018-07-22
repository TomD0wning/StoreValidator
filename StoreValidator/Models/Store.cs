using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StoreValidator.Models
{
    public class Store
    {
        public int Id { get; set; }

        [Display(Name = "Store Name")]
        [DataType(DataType.Text)]
        [Required, MaxLength(10)]
        public string Name { get; set; }

        [Display(Name="Store Description")]
        [DataType(DataType.Text)]
        [MaxLength(120)]
        public string Desc { get; set; }

        [Display(Name="Address")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Display(Name="Post code")]
        [DataType(DataType.Text)]
        public string PostCode { get; set; }

        [Display(Name="Store type")]
        public StoreType StoreType { get; set; }

        [Display(Name="Store size")]
        public long StoreSize { get; set; }

        [Display(Name="Open date")]
        [DataType(DataType.Date)]
        public string OpenDate { get; set; }

        public bool Concessions { get; set; }

        public Departments Department { get; set; }
        
    }
    public class StoreDataValidator : AbstractValidator<Store>
    {
        public StoreDataValidator()
        {
            var storeSizeList = new List<KeyValuePair<StoreType, long>>()
            {
                new KeyValuePair<StoreType, long>(StoreType.None,0),
                new KeyValuePair<StoreType, long>(StoreType.Supermarket,50000),
                new KeyValuePair<StoreType, long>(StoreType.Convienence,25000),
                new KeyValuePair<StoreType, long>(StoreType.Micro,15000),
                new KeyValuePair<StoreType, long>(StoreType.PFS,10000)
            };


            Regex r = new Regex("^([Gg][Ii][Rr] 0[Aa]{2}|([A-Za-z][0-9]{1,2}|[A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2}|[A-Za-z][0-9][A-Za-z]|[A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z]) ?[0-9][A-Za-z]{2})$");
            //Stop processing rules when the first one fails.
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(s => s.Name).NotEmpty().Matches("(\\w)").MaximumLength(10);
            RuleFor(s => s.Desc).MaximumLength(120).Matches("\\w");
            RuleFor(s => s.Address).Matches("\\w");
            RuleFor(s => s.PostCode).Matches(r).WithMessage("Input does not match the UK post code standard");
            RuleFor(s => s.StoreType).IsInEnum();
            RuleFor(s => s.StoreSize).GreaterThanOrEqualTo(0).WithMessage("Size must be greater than or equal to 0");
            RuleFor(s => s.Department).IsInEnum();


            //TODO - Add some custom rules around store size and the corresponding store type.

        //None:0
        //Supermarket: >= 25000sqft
        //Convienence: >= 15000sqft < 25000sqft
        //Micro: >= 5000sqft < 15000sqft
        //PFS: < 5000sqft
        }
    }
}
