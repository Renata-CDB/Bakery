﻿using Bakery.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Data.Interface
{
    public interface IIngredienteRepositorio : IBaseRepositorio<Ingrediente>
    {
        bool MateriaPrimaSemProdutoFinal(int IdMateriaPrima);
    }
}
