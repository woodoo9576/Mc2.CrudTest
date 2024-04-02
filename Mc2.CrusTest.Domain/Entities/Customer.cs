using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Common.Entities;
public class Customer : BaseEntity
{

    [Required]
    [MinLength(2, ErrorMessage = "Please Enter FirstName")]
    [MaxLength(55, ErrorMessage = "FirstName cannot exceed 55 characters")]
    public required string FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Please Enter LastName")]
    [MaxLength(55, ErrorMessage = "LastName cannot exceed 55 characters")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Date Of Birth is Required")]
    [DataType(DataType.Date, ErrorMessage = "Please Enter valid date Format")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Phone Number is Required")]
    public long PhoneNumber { get; set; }

    [Required(ErrorMessage = "Email is Required")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter Valid E-Mail address")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Bank Account Number is Required")]
    [Range(1000000000, 9999999999, ErrorMessage = "Please Enter Valid Bank Account Number")]
    public long BankAccountNumber { get; set; }
}