namespace RBkonuk.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class agents_k_import
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Тип_агента { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Наименование_агента { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Электронная_почта_агента { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Телефон_агента { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Логотип_агента { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string Юридический_адрес { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Приоритет { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Директор { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ИНН { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int КПП { get; set; }
    }
}
