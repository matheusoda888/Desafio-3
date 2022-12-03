using System;
using System.Collections.Generic;

namespace Desafio3.Models;

public partial class Fornecedore
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Produto> Produtos { get; } = new List<Produto>();
}
