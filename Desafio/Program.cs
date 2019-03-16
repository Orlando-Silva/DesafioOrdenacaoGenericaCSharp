#region --Using--
using Bogus;
using Desafio.Entidades;
using Desafio.Enums;
using Desafio.Services;
using System;
#endregion

namespace Desafio
{
    class Program
    {
        static void Main(string[] args)
        {
            var listaDePessoas = new Faker<Pessoa>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Nome, f => f.Name.FirstName())
                .RuleFor(p => p.Nascimento, f => f.Date.Past())
                    .Generate(4);

            Console.WriteLine("Lista de pessoas sem ordenação:\n");

            foreach(var pessoa in listaDePessoas)
            {
                Console.WriteLine($"ID: { pessoa.Id }\n");
                Console.WriteLine($"Nome: { pessoa.Nome }\n");
                Console.WriteLine($"Nascimento: { pessoa.Nascimento.ToShortDateString() }\n");
                Console.WriteLine($"\n-------------------------------------------------------\n");
            }

            Console.WriteLine("Lista de pessoas com ordenação por nascimento descendente:\n");

            var listaOrdenadaDePessoas = new Organizer<Pessoa>().Organize
                                            (
                                                listToOrganize: listaDePessoas,
                                                field: p => p.Nascimento,
                                                direction: Direction.Descending
                                            );

            foreach (var pessoa in listaOrdenadaDePessoas)
            {
                Console.WriteLine($"ID: { pessoa.Id }\n");
                Console.WriteLine($"Nome: { pessoa.Nome }\n");
                Console.WriteLine($"Nascimento: { pessoa.Nascimento.ToShortDateString() }\n");
                Console.WriteLine($"\n-------------------------------------------------------\n");
            }

            Console.WriteLine("Para mais testes, olhe os testes unitários.\n");
            Console.ReadLine();
        
        }
    }
}
