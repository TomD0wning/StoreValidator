using FluentValidation;
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
            string UkPostCodeRegex = "^(GIR 0AA)|[a-z-[qvx]](?:\\d|\\d{2}|[a-z-[qvx]]\\d|[a-z-[qvx]]\\d[a-z-[qvx]]|[a-z-[qvx]]\\d{2})(?:\\s?\\d[a-z-[qvx]]{2})?$";
            Regex r = new Regex(UkPostCodeRegex);
           

            RuleFor(s => s.Name).NotEmpty().Matches("(\\w)").MaximumLength(10);
            RuleFor(s => s.Desc).MaximumLength(120).Matches("\\w");
            RuleFor(s => s.Address).Matches("\\w");
            RuleFor(s => s.PostCode).Matches(r).WithMessage("Input does not match the UK post code Standard");
            RuleFor(s => s.StoreSize).GreaterThanOrEqualTo(0).WithMessage("Size must be greater than or equal to 0");
            RuleFor(s => s.StoreType).IsInEnum();
            //RuleFor(s=> s.Concessions)
            RuleFor(s => s.Department).IsInEnum();
        }
    }
}
