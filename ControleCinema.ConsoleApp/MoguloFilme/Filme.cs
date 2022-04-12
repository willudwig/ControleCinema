using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloGenero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.MoguloFilme
{
    public class Filme : EntidadeBase
    {
        public string titulo;
        public int duracaoEmMinutos;
        public Genero gen;
        public bool eHLancamento;

        public Filme(string titulo, int duracao, Genero g, bool ehlancam)
        {
           this.titulo = titulo;
           this.duracaoEmMinutos = duracao;
           this.gen = g;
           this.eHLancamento = ehlancam;
        }
    }
}
