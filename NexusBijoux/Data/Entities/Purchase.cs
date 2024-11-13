<<<<<<< HEAD
=======
using System;
>>>>>>> 89020bfd6b72eae40aa9e5d8886ed41a5a56d68b
using System.ComponentModel.DataAnnotations;

namespace NexusBijoux.Web.Data.Entities
{
    public class Purchase
    {
        [Key]
        public int Purchase_ID { get; set; }

<<<<<<< HEAD
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        public int User_ID { get; set; }

        [Display(Name = "Fecha de Compra")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [DataType(DataType.Date, ErrorMessage = "El campo '{0}' debe tener un formato de fecha vÃ¡lido.")]
=======
        // Clave foránea que referencia a la entidad User
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        //[ForeignKey("User")]
        public int User_ID { get; set; }

        // Relación con la entidad User
        //public User User { get; set; }


        [Display(Name = "Fecha de Compra")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [DataType(DataType.Date, ErrorMessage = "El campo '{0}' debe tener un formato de fecha válido.")]
>>>>>>> 89020bfd6b72eae40aa9e5d8886ed41a5a56d68b
        public DateTime Purchase_date { get; set; }

        [Display(Name = "Monto Total")]
        [Required(ErrorMessage = "El campo '{0}' es requerido.")]
        [Range(0.01, 100000.00, ErrorMessage = "El monto total debe estar entre {1} y {2} pesos.")]
        public decimal Total_amount { get; set; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 89020bfd6b72eae40aa9e5d8886ed41a5a56d68b
