using System;
using System.Collections.Generic;

namespace zv_practica.Models
{

    public partial class Заказ
    {
        public int OrderNumber { get; set; }

        public DateTime? OrderDate { get; set; }

        public string? Login { get; set; }

        public double? Price { get; set; }

        public bool IsDeleted { get; set; }

        public string? DeliveryType { get; set; }

        public string? Status { get; set; }

        public virtual Пользователи? LoginNavigation { get; set; }

        public virtual ICollection<ЗаказТовара> ЗаказТовараs { get; } = new List<ЗаказТовара>();
    }
}
