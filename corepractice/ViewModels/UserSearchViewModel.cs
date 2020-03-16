using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace corepractice.ViewModels
{
    public class UserSearchViewModel
    {
        public int Type { get; set; }
        [Display(Name = "Search by Firstname")]
        public string Firstname { get; set; }
        [Display(Name = "Search by Lastname")]
        public string Lastname { get; set; }
        [Display(Name = "Search by Email")]
        public string Email{ get; set; }
        [Display(Name = "Search by Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Search by Phone")]
        public string Phone { get; set; }
        [Display(Name = "Search by Mobile")]
        public string Mobile { get; set; }
    }
}
