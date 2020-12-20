namespace Lab7WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pacients
    {
        [Key]
        public int ID_Pacinents { get; set; }

        [Display(Name = "��'� ��������")]
        [StringLength(20, ErrorMessage = "��'� �������� ����� �� 20 �������")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "��'� �������� ������")]
        public string Name { get; set; }

        [Display(Name = "������� ��������")]
        [StringLength(40, ErrorMessage = "������� �������� ����� �� 40 �������")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "������� �������� ������")]
        public string LastName { get; set; }
    }
}
