﻿using eUseControl.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.Web.Models
{
    public class UserData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be less than 50 characters")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Text")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Post text must be more than 8 characters")]
        public string Text { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }
        public string Username { get; set; }
        public List<string> TitleList { get; set; }
        public List<string> TextList { get; set; }
        public List<string> ImageList { get; set; }

        public URole Level { get; set; }
    }
}