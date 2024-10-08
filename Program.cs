using System;
using ProjetoMVCContato.Controllers;

namespace ContactManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            ContatoController controller = new ContatoController();
            int opcao;

            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar contato");
                Console.WriteLine("2. Pesquisar contato");
                Console.WriteLine("3. Alterar contato");
                Console.WriteLine("4. Remover contato");
                Console.WriteLine("5. Listar contatos");
                Console.Write("Escolha uma opção: ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        controller.AdicionarContato();
                        break;
                    case 2:
                        controller.PesquisarContato();
                        break;
                    case 3:
                        controller.AlterarContato();
                        break;
                    case 4:
                        controller.RemoverContato();
                        break;
                    case 5:
                        controller.ListarContatos();
                        break;
                }
                Console.WriteLine();
            } while (opcao != 0);
        }
    }
}
