namespace RBkonuk.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class products_short_k_import
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Наименование_продукции { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Тип_продукции { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Артикул { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte Количество_человек_для_производства { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte Номер_цеха_производства { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Минимальная_цена_для_агента { get; set; }
    }
}
