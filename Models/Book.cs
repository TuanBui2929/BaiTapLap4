namespace BaiTapLap4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [Required(ErrorMessage ="Không được để trống")]
        [StringLength(50)]
        public string Id { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(30, ErrorMessage = "Kí tự không được quá 30 kí tự")]
        public string Arthor { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(100,ErrorMessage ="Kí tự không được quá 100")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(50)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
       
        public string ImageCover { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [Range(1000,1000000,ErrorMessage ="Tu 1K den 1M")]
        public double? Price { get; set; }
    }
}
