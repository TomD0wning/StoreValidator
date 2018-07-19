﻿using FluentValidation;
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

        [DataType(DataType.Text)]
        public string Address { get; set; }

        [DataType(DataType.Text)]
        public string PostCode { get; set; }

        public StoreType StoreType { get; set; }
        
        public long StoreSize { get; set; }

        [DataType(DataType.Date)]
        public string OpenDate { get; set; }

        public bool Concessions { get; set; }

        public Departments Department { get; set; }
        
    }
    public class StoreDataValidator : AbstractValidator<Store>
    {
        public StoreDataValidator()
        {
            Regex r = new Regex("^([Gg][Ii][Rr] 0[Aa]{2}|([A-Za-z][0-9]{1,2}|[A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2}|[A-Za-z][0-9][A-Za-z]|[A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z]) ?[0-9][A-Za-z]{2})$");


            //Stop processing rules when the first one fails.
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(s => s.Name).NotEmpty().Matches("(\\w)").MaximumLength(10);
            RuleFor(s => s.Desc).MaximumLength(120).Matches("\\w");
            RuleFor(s => s.Address).Matches("\\w");
            RuleFor(s => s.PostCode).Matches(r).WithMessage("Input does not match the UK post code standard");
            RuleFor(s => s.StoreSize).GreaterThanOrEqualTo(0).WithMessage("Size must be greater than or equal to 0");
            RuleFor(s => s.StoreType).IsInEnum();
            //RuleFor(s => s.Concessions).
            RuleFor(s => s.Department).IsInEnum();


            //TODO - Add some custom rules around store size and the corresponding store type.
        }
    }
}
