namespace Tuan4_VN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string LecturerId { get; set; }

        [StringLength(255)]
        public string Place { get; set; }

        public DateTime? DateTime { get; set; }

        public int? CategoryId { get; set; }
        public List<Category> list = new List<Category>();
    }
}
