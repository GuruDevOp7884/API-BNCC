using Puc.BnccTeste.Domain.Entidade;
using Puc.BnccTeste.Infra.Data.Interface;
using Puc.BnccTeste.Service.DTOs;
using Puc.BnccTeste.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Puc.BnccTeste.Service.Service
{
    public class BnccMateriasGeraisEfService : IBnccMateriasGeraisEfService
    {

        private readonly IBnccMatematicaEfService _matematica;
        private readonly IBnccLinguaPortuguesaEfService _portugues;

        public BnccMateriasGeraisEfService(IBnccLinguaPortuguesaEfService portugues, IBnccMatematicaEfService matematica)
        {
            _matematica = matematica;
            _portugues = portugues;
        }

        public List<dynamic> ListarAnosDasMaterias(string materia, bool todos, bool primeiroAno, bool segundoAno, bool terceiroAno, bool quartoAno, bool quintoAno, bool sextoAno, bool setimoAno, bool oitavoAno, bool nonoAno)
        {
            throw new NotImplementedException();
        }
    }
}
