﻿using Puc.BnccTeste.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.BnccTeste.Service.Interface
{
    public interface IBnccLinguaPortuguesaEfService
    {
        IList<BnccLinguaPortuguesaEf> ListarTodos();
        IList<BnccLinguaPortuguesaEf> ListarAnosPortugues(
            string materia,
            bool todos,
            bool primeiroAno,
            bool segundoAno,
            bool terceiroAno,
            bool quartoAno,
            bool quintoAno,
            bool sextoAno,
            bool setimoAno,
            bool oitavoAno,
            bool nonoAno
            );
    }
}