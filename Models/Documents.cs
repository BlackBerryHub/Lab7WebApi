namespace Lab7WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Documents
    {
        [Key]
        public int ID_Documents { get; set; }

        [Display(Name = "ID ����������")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID ���������� ������")]
        public int ID_Equipment { get; set; }

        [Display(Name = "ID ���������")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID ��������� ������")]
        public int ID_Procedure { get; set; }
    }
}
