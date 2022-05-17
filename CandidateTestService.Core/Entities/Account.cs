using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CandidateTestService.Core.Entities
{
    [Table("Account")]
    public class Account : BaseEntity
    {
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
       
        [StringLength (100)]
        public string Password { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(20)]
        public string Role { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        public ICollection<TestResult> TestResults { get; set; }

        public ICollection<TestAccount> TestAccounts { get; set; }
    }
}
