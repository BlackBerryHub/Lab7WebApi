namespace Lab7WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Equipments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipments()
        {
            Documents = new HashSet<Documents>();
        }

        [Key]
        public int ID_Equipment { get; set; }

        [Display(Name = "����� ����������")]
        [StringLength(30, ErrorMessage = "����� ���������� ����� �� 30 �������")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "����� ���������� �������")]
        public string nameEquipment { get; set; }

        [Display(Name = "����������� ����������")]
        [StringLength(50, ErrorMessage = "����������� ���������� ����� �� 50 �������")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "����������� ���������� ������")]
        public string Appointment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documents> Documents { get; set; }
    }
}
