using ControleCinema.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloSala
{
    public class Sala: EntidadeBase
    {
        public int capacidade;
        public int numSala;

        public Sala(int capac, int numsala)
        {
            this.capacidade = capac;
            this.numSala = numsala;
        }

    }
}
