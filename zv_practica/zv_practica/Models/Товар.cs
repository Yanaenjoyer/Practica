using System;
using System.Collections.Generic;

namespace zv_practica.Models;

public partial class Товар
{
    public int ProductId { get; set; }

    public double? ProductPrice { get; set; }

    public double? ProductWeight { get; set; }

    public double? ProductLenght { get; set; }

    public double? ProductWidth { get; set; }

    public string? Comment { get; set; }

    public bool IsDeleted { get; set; }

    public int? SumProduct { get; set; }

    public virtual Категории Product { get; set; } = null!;

    public virtual ICollection<ЗаказТовара> ЗаказТовараs { get; } = new List<ЗаказТовара>();

    public virtual ICollection<ОценкаТовара> ОценкаТовараs { get; } = new List<ОценкаТовара>();
}
