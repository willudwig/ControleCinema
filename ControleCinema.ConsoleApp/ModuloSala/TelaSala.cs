using ControleCinema.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloSala
{
    public class TelaSala : TelaBase, ITelaCadastravel
    {
        IRepositorio<Sala> repoSala;
        public TelaSala(IRepositorio<Sala> repoSala) : base("Cadastro de Sala")
        {
            this.repoSala = repoSala;
        }

        public void Editar()
        {
            bool registroOK = VisualizarRegistros("tela");
            if (registroOK == false)
                return;

            Console.Write("Escolha o ID para editar: ");
            int idSelec = Convert.ToInt32(Console.ReadLine());

            Sala novaSala = repoSala.SelecionarRegistro(idSelec);

            novaSala.id = idSelec;
            novaSala = InputarSala();
            repoSala.Editar(idSelec, novaSala);

            nota.ApresentarMensagem("Editado com sucesso", TipoMensagem.Sucesso);

        }


        public void Excluir()
        {
            bool registroOK = VisualizarRegistros("tela");
            if (registroOK == false)
                return;

            Console.Write("Escolha o ID para excluir: ");
            int idSelec = Convert.ToInt32(Console.ReadLine());

            repoSala.Excluir(idSelec);

            nota.ApresentarMensagem("Excluido com sucesso", TipoMensagem.Sucesso);
        }

        public void Inserir()
        {
            MostrarTitulo("Inserindo Nova Sala");
            Sala novaSala = InputarSala();
            repoSala.Inserir(novaSala);
            nota.ApresentarMensagem("Inserido com sucesso", TipoMensagem.Sucesso);

        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            Console.Clear();

            List<Sala> salas = repoSala.SelecionarTodos();

            foreach (Sala s in salas)
            {
                Console.WriteLine(

                    $"ID..........: {s.id}\n\r" +
                    $"Capacidade..: {s.capacidade}\n\r" +
                    $"Sala número.: {s.numSala}"
                    );
            }

            Console.WriteLine();
            Console.ReadKey();
            return true;
        }


        private Sala InputarSala()
        {
            int capacidade = 0;
            int numeroSala = 0;

            Console.Write("Capacidade: ");
            try { capacidade = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { throw; };

            Console.Write("Numero da Sala: ");
            try { numeroSala = Convert.ToInt32(Console.ReadLine()); } catch (Exception) { throw; };

            return new Sala(capacidade, numeroSala);

        }
    }
}
