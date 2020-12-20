namespace Lab7WebApi.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Procedure")]
    public partial class Procedure
    {
        [Key]
        public int ID_Procedure { get; set; }

        public string Name { get; set; }

       public int? Cost { get; set; }
    }
}
