using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloIngresso;
using ControleCinema.ConsoleApp.ModuloSala;
using ControleCinema.ConsoleApp.MoguloFilme;
using System;


namespace ControleCinema.ConsoleApp.ModuloSessao
{
    public class Sessao : EntidadeBase
    {
        public Filme filme;
        public Ingresso ingresso;
        public Sala sala;
        public bool estaEncerrada;
        public int numMaxIngressos;
        public DateTime horario = new();

        public Sessao(Filme f, Ingresso ing, Sala s, int numMxing, DateTime hora)
        {
            this.filme = f;
            this.ingresso = ing;
            this.sala = s;
            this.numMaxIngressos = numMxing;
            this.horario = hora;
        }
    }
}
