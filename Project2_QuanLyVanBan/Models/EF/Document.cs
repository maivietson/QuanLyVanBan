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

        [StringLength(10)]
        public string Number { get; set; }

        [StringLength(50)]
        public string Symbol { get; set; }

        [StringLength(100)]
        public string Signer { get; set; }

        [StringLength(250)]
        public string Type { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? ReleasedDate { get; set; }

        [StringLength(250)]
        public string ReleasedBy { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? UploadDate { get; set; }

        [StringLength(50)]
        public string UploadBy { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{yyyy-mm-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? ExpirationDate { get; set; }

        public long? CategotyID { get; set; }

        public int? ViewCount { get; set; }
    }
}
