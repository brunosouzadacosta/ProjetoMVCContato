using System;
using ProjetoMVCContato.Models;

namespace ProjetoMVCContato.Controllers
{
    public class ContatoController
    {
        private Contatos contatos;

        public ContatoController()
        {
            contatos = new Contatos();
        }

        public void AdicionarContato()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Data de Nascimento (dd/mm/aaaa): ");
            string[] dataParts = Console.ReadLine().Split('/');
            Data dtNasc = new Data();
            dtNasc.SetData(int.Parse(dataParts[0]), int.Parse(dataParts[1]), int.Parse(dataParts[2]));

            Contato contato = new Contato(email, nome, dtNasc);
            Console.Write("Telefone (tipo:numero): ");
            string[] telefoneParts = Console.ReadLine().Split(':');
            Telefone telefone = new Telefone(telefoneParts[0], telefoneParts[1], true);
            contato.AdicionarTelefone(telefone);

            if (contatos.Adicionar(contato))
                Console.WriteLine("Contato adicionado com sucesso!");
            else
                Console.WriteLine("Contato já existe.");
        }

        public void PesquisarContato()
        {
            Console.Write("Email do contato: ");
            string email = Console.ReadLine();

            // Cria um contato apenas com o email para pesquisar
            Contato contatoParaBuscar = new Contato(email, "", new Data());

            Contato contato = contatos.Pesquisar(contatoParaBuscar);
            if (contato != null)
            {
                Console.WriteLine("Contato encontrado:");
                Console.WriteLine(contato);
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        public void AlterarContato()
        {
            Console.Write("Email do contato a ser alterado: ");
            string email = Console.ReadLine();
            Contato contato = contatos.Pesquisar(new Contato(email, "", new Data()));
            if (contato != null)
            {
                Console.Write("Novo Nome: ");
                contato.Nome = Console.ReadLine();
                Console.Write("Novo Email: ");
                contato.Email = Console.ReadLine();
                Console.Write("Nova Data de Nascimento (dd/mm/aaaa): ");
                string[] dataParts = Console.ReadLine().Split('/');
                contato.DtNasc.SetData(int.Parse(dataParts[0]), int.Parse(dataParts[1]), int.Parse(dataParts[2]));

                if (contatos.Alterar(contato))
                    Console.WriteLine("Contato alterado com sucesso!");
                else
                    Console.WriteLine("Erro ao alterar contato.");
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        public void RemoverContato()
        {
            Console.Write("Email do contato a ser removido: ");
            string email = Console.ReadLine();
            Contato contato = contatos.Pesquisar(new Contato(email, "", new Data()));
            if (contato != null)
            {
                if (contatos.Remover(contato))
                    Console.WriteLine("Contato removido com sucesso!");
                else
                    Console.WriteLine("Erro ao remover contato.");
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        public void ListarContatos()
        {
            var lista = contatos.ListarContatos();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
            }
            else
            {
                foreach (var contato in lista)
                {
                    Console.WriteLine(contato);
                }
            }
        }
    }
}
