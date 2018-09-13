using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class Participant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string RegNo { get; set; }
        public string ContactNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public int BatchId { get; set; }
        public Batch Batch { get; set; }



    }
}
