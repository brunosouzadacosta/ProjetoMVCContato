using System;
using System.Collections.Generic;

namespace ProjetoMVCContato.Models
{
    public class Data
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public void SetData(int dia, int mes, int ano)
        {
            Dia = dia;
            Mes = mes;
            Ano = ano;
        }

        public override string ToString()
        {
            return $"{Dia:D2}/{Mes:D2}/{Ano}";
        }
    }

    public class Telefone
    {
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public bool Principal { get; set; }

        public Telefone(string tipo, string numero, bool principal)
        {
            Tipo = tipo;
            Numero = numero;
            Principal = principal;
        }
    }

    public class Contato
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public Data DtNasc { get; set; }
        public List<Telefone> Telefones { get; private set; }

        public Contato(string email, string nome, Data dtNasc)
        {
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
            Telefones = new List<Telefone>();
        }

        public void AdicionarTelefone(Telefone t)
        {
            Telefones.Add(t);
        }

        public string GetTelefonePrincipal()
        {
            var telefonePrincipal = Telefones.Find(t => t.Principal);
            return telefonePrincipal != null ? telefonePrincipal.Numero : "N/A";
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Email: {Email}, Data de Nascimento: {DtNasc}, Telefone Principal: {GetTelefonePrincipal()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Contato contato)
            {
                return Email == contato.Email;
            }
            return false;
        }
    }

    public class Contatos
    {
        private List<Contato> agenda;

        public Contatos()
        {
            agenda = new List<Contato>();
        }

        public bool Adicionar(Contato c)
        {
            if (!agenda.Contains(c))
            {
                agenda.Add(c);
                return true;
            }
            return false;
        }

        public Contato Pesquisar(Contato c)
        {
            return agenda.Find(x => x.Equals(c));
        }

        public bool Alterar(Contato c)
        {
            var contatoExistente = Pesquisar(c);
            if (contatoExistente != null)
            {
                contatoExistente.Nome = c.Nome;
                contatoExistente.Email = c.Email;
                contatoExistente.DtNasc = c.DtNasc;
                return true;
            }
            return false;
        }

        public bool Remover(Contato c)
        {
            return agenda.Remove(c);
        }

        public List<Contato> ListarContatos()
        {
            return agenda;
        }
    }
}
