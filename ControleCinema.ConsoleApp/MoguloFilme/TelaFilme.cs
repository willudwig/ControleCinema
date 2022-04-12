using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloGenero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.MoguloFilme
{
    public class TelaFilme : TelaBase, ITelaCadastravel
    {
        IRepositorio<Filme> repoFilme;
        IRepositorio<Genero> repoGen;
        TelaCadastroGenero telaGen;
        public TelaFilme(IRepositorio<Filme> repoFilme, IRepositorio<Genero> repoGenero, TelaCadastroGenero telaGen) : base("Cadastro de Filme")
        {
            this.repoFilme = repoFilme;
            repoGen = repoGenero;
            this.telaGen = telaGen;
        }

        public void Editar()
        {
            bool registroOK = VisualizarRegistros("tela");

            if (registroOK == false)
                return;

            Console.Write("Escolha o ID para editar: ");
            int idSelec = Convert.ToInt32(Console.ReadLine());

            Filme novoFilme = repoFilme.SelecionarRegistro(idSelec);

            novoFilme.id = idSelec;
            novoFilme = InputarFilme();
            repoFilme.Editar(idSelec, novoFilme);

            nota.ApresentarMensagem("Editado com sucesso", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            bool registroOK = VisualizarRegistros("tela");
            if (registroOK == false)
                return;

            Console.Write("Escolha o ID para excluir: ");
            int idSelec = Convert.ToInt32(Console.ReadLine());

            repoFilme.Excluir(idSelec);

            nota.ApresentarMensagem("Excluido com sucesso", TipoMensagem.Sucesso);
        }

        public void Inserir()
        {
            MostrarTitulo("Inserindo Novo Filme");
            repoFilme.Inserir(InputarFilme());
            nota.ApresentarMensagem("Inserido com sucesso", TipoMensagem.Sucesso);
        }

        private Filme InputarFilme()
        {
            string titulo;
            int duracaoEmMinutos;
            Genero gen = null;
            bool lancamento = false;

            Console.Write("Titulo: ");
            try { titulo = Console.ReadLine(); } catch (Exception) { throw; };

            Console.Write("Duração: ");
            try { duracaoEmMinutos = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { throw; };

            Console.Write("É lançamento?: [1- SIM] [2- NÃO]");
            char op = Console.ReadKey().KeyChar;

            switch (op)
            {
                case'1':
                    lancamento = true;
                    break;
                default:
                    break;
            }

            Console.Write("\n\nGenero: ");
            List<Genero> generos = new List<Genero>();
            generos = repoGen.SelecionarTodos();

            telaGen.VisualizarRegistros("tela");

            Console.Write("Selecione um ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            gen = generos.Find(g => g.id.Equals(id));

            return new Filme(titulo, duracaoEmMinutos, gen, lancamento);

        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            Console.Clear();

            List<Filme> filmes = repoFilme.SelecionarTodos();

            foreach (Filme f in filmes)
            {
                Console.WriteLine(

                    $"ID......: {f.id}\n\r" +
                    $"Título..: {f.titulo}\n\r" +
                    $"Duração.: {f.duracaoEmMinutos}\n\r"+
                    $"Genero..: {f.gen.Descricao}"

                    );
            }

            Console.WriteLine();
            Console.ReadKey();
            return true;
        }
    }
}
