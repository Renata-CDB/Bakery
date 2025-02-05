﻿using Bakery.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Dominio
{
    public class Ingrediente : IEntity
    {
        public int Id { get; set; }
        public int IdMateriaPrima { get; set; }
        public ProdutoMateriaPrima MateriaPrima { get; set; }
        public int IdProdutoFinalProduzido { get; set; }
        public ProdutoFinalProduzido ProdutoFinalProduzido { get; set; }
        public decimal Quantidade { get; set; }
        public bool ValidaQuantidade()
        {
            return Quantidade > decimal.Zero;
        }

    }
}
