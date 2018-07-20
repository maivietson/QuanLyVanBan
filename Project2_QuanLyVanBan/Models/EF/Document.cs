namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Document
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        public int? Number { get; set; }

        [StringLength(50)]
        public string Symbol { get; set; }

        [StringLength(100)]
        public string Signer { get; set; }

        [StringLength(250)]
        public string Type { get; set; }

        public DateTime? ReleasedDate { get; set; }

        [StringLength(250)]
        public string ReleasedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? UploadDate { get; set; }

        [StringLength(50)]
        public string UploadBy { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public long? CategotyID { get; set; }

        public int? ViewCount { get; set; }
    }
}
