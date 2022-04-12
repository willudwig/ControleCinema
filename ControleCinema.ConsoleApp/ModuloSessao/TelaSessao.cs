using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloIngresso;
using ControleCinema.ConsoleApp.ModuloSala;
using ControleCinema.ConsoleApp.MoguloFilme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloSessao
{
    public class TelaSessao : TelaBase, ITelaCadastravel
    {
        IRepositorio<Sessao> repoSessao;
        IRepositorio<Filme> repoFilme;
        IRepositorio<Sala> repoSala;

        TelaFilme telaFilme;
        TelaSala telaSala;

        public TelaSessao(IRepositorio<Sessao> repoSessao, IRepositorio<Filme> repoFilme, IRepositorio<Sala> repoSala, TelaFilme tFilme, TelaSala tSala) : base("Cadastro de Sessao")
        {
            this.repoSessao = repoSessao;
            this.repoFilme = repoFilme;
            this.repoSala = repoSala;
            this.telaFilme = tFilme;
            this.telaSala = tSala;

        }
        public void Editar()
        {
            bool registroOK = VisualizarRegistros("tela");

            if (registroOK == false)
                return;

            Console.Write("Escolha o ID para editar: ");
            int idSelec = Convert.ToInt32(Console.ReadLine());

            Sessao novaSessao = repoSessao.SelecionarRegistro(idSelec);

            novaSessao.id = idSelec;
            novaSessao = InputarSessao();
            repoSessao.Editar(idSelec, novaSessao);

            nota.ApresentarMensagem("Editado com sucesso", TipoMensagem.Sucesso);
        }

        private Sessao InputarSessao()
        {
            Filme filme = null;
            Ingresso ingresso = new();
            Sala sala = null;
            int numMaxIngressos = 0;
            DateTime horario = DateTime.Now;

            //Filme
            Console.Write("Filme: ");
            List<Filme> filmes = new List<Filme>();
            filmes = repoFilme.SelecionarTodos();

            telaFilme.VisualizarRegistros("tela");

            Console.Write("Selecione um ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            filme = filmes.Find(g => g.id.Equals(id));
            //=================================================

            //Sala
            Console.Write("Sala: ");
            List<Sala> salas = new List<Sala>();
            salas = repoSala.SelecionarTodos();

            telaSala.VisualizarRegistros("tela");

            Console.Write("Selecione um ID: ");
            id = Convert.ToInt32(Console.ReadLine());

            sala = salas.Find(g => g.id.Equals(id));
            //================================================

            //Ingresso
            numMaxIngressos = sala.capacidade;

            Console.Write("Ingressos disponíveis: ");
            Console.WriteLine(numMaxIngressos);
            Console.Write("Número do assento: ");
            ingresso.numAssento = Convert.ToInt32(Console.ReadLine());
            Console.Write("É meia entrada?: [1- SIM] [2- NÃO]");
            char op = Console.ReadKey().KeyChar;

            switch (op)
            {
                case '1':
                    ingresso.eHmeio = true;
                    break;
                default:
                    break;
            }
            //================================================ 

            //Horario
            Console.WriteLine("Horario da Sessao: ");
            DateTime.TryParse(Console.ReadLine(), out horario);
            //================================================ 

            return new Sessao(filme, ingresso, sala, numMaxIngressos, horario);

        }

        public void Excluir()
        {
            bool registroOK = VisualizarRegistros("tela");
            if (registroOK == false)
                return;

            Console.Write("Escolha o ID para excluir: ");
            int idSelec = Convert.ToInt32(Console.ReadLine());

            repoSessao.Excluir(idSelec);

            nota.ApresentarMensagem("Excluido com sucesso", TipoMensagem.Sucesso);
        }

        public void Inserir()
        {
            MostrarTitulo("Inserindo Nova Sessao");
            repoSessao.Inserir(InputarSessao());
            nota.ApresentarMensagem("Inserido com sucesso", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            Console.Clear();

            List<Sessao> sessoes = repoSessao.SelecionarTodos();

            foreach (Sessao s in sessoes)
            {
                Console.WriteLine(

                    $"ID...................: {s.id}\n\r" +
                    $"Filme................: {s.filme}\n\r" +
                    $"Sala.................: {s.sala}\n\r" +
                    $"Número de Ingressos..: {s.numMaxIngressos}\n\r"+
                    $"Genero...............: {s.horario}\n\r"+
                    $"Genero...............: {s.ingresso.numAssento}\n\r"+
                    $"Genero...............: {s.estaEncerrada}\n\r"

                    );
            }

            Console.WriteLine();
            Console.ReadKey();
            return true;
        }
    }
}
