using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eUseControl.Domain.Enums;

namespace eUseControl.Domain.Entities.User
{
    public class PostsTable
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
    }
}
