using System;
using System.Collections.Generic;

namespace zv_practica.Models;

public partial class Пользователи
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Lastname { get; set; }

    public DateTime Birthday { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsAdmin { get; set; }

    public virtual Адрес LoginNavigation { get; set; } = null!;

    public virtual ICollection<Заказ> Заказ { get; } = new List<Заказ>();

    public virtual ICollection<ОценкаТовара> ОценкаТовараs { get; } = new List<ОценкаТовара>();
}
