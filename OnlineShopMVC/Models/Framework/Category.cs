namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Alias { get; set; }

        [DisplayName("Parent")]
        public int? ParentId { get; set; }


        [DisplayName("Created Date")]
        public DateTime? CreatedDate { get; set; }

        public int? Order { get; set; }

        public bool? Status { get; set; }
    }
}
