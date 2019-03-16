#region --Using--
using Bogus;
using Desafio.Entidades;
using Desafio.Enums;
using Desafio.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static Bogus.DataSets.Name;
#endregion

namespace Tests.Services
{
    public class OrganizerUnitTests
    {
        [Test(Description = "Ordena uma lista de inteiros de maneira descendente.")]
        public void Organize_WhenCalled_ReturnsIntegerListInDescendingOrder()
        {
            var integerList = new Faker<List<int>>().Generate();

            Assert.That
            (
                new Organizer<int>().Organize
                (
                    listToOrganize: integerList,
                    field: i => i,
                    direction: Direction.Descending
                ),
                Is.EqualTo(integerList.OrderByDescending(i => i))
            );
        }

        [Test(Description = "Ordena uma lista de inteiros de maneira ascendente.")]
        public void Organize_WhenCalled_ReturnsIntegerListInAscendingOrder()
        {
            var integerList = new Faker<List<int>>().Generate();

            Assert.That
            (
                new Organizer<int>().Organize
                (
                    listToOrganize: integerList,
                    field: i => i,
                    direction: Direction.Ascending
                ),
                Is.EqualTo(integerList.OrderBy(i => i))
            );
        }
        
        [Test(Description = "Ordena uma lista de pessoas de maneira descendente pelo campo Id.")]
        public void Organize_WhenCalled_ReturnsPessoaListInDescendingOrderedById()
        {
            var pessoasList = new Faker<Pessoa>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Nome, f => f.Name.FirstName())
                .RuleFor(p => p.Nascimento, f => f.Date.Past())
                    .Generate(10);

            Assert.That
            (
                new Organizer<Pessoa>().Organize
                (
                    listToOrganize: pessoasList,
                    field: p => p.Id,
                    direction: Direction.Descending
                ),
                Is.EqualTo(pessoasList.OrderByDescending(p => p.Id))
            );
        }

        [Test(Description = "Ordena uma lista de pessoas de maneira ascendente pelo campo Id.")]
        public void Organize_WhenCalled_ReturnsPessoaListInAscendingOrderedById()
        {
            var pessoasList = new Faker<Pessoa>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Nome, f => f.Name.FirstName())
                .RuleFor(p => p.Nascimento, f => f.Date.Past())
                    .Generate(10);

            Assert.That
            (
                new Organizer<Pessoa>().Organize
                (
                    listToOrganize: pessoasList,
                    field: p => p.Id,
                    direction: Direction.Ascending
                ),
                Is.EqualTo(pessoasList.OrderBy(p => p.Id))
            );
        }

        [Test(Description = "Ordena uma lista de pessoas de maneira descendente pelo campo Nome.")]
        public void Organize_WhenCalled_ReturnsPessoaListInDescendingOrderedByNome()
        {
            var pessoasList = new Faker<Pessoa>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Nome, f => f.Name.FirstName())
                .RuleFor(p => p.Nascimento, f => f.Date.Past())
                    .Generate(10);

            Assert.That
            (
                new Organizer<Pessoa>().Organize
                (
                    listToOrganize: pessoasList,
                    field: p => p.Nome,
                    direction: Direction.Descending
                ),
                Is.EqualTo(pessoasList.OrderByDescending(p => p.Nome))
            );
        }

        [Test(Description = "Ordena uma lista de pessoas de maneira ascendente pelo campo Nome.")]
        public void Organize_WhenCalled_ReturnsPessoaListInAscendingOrderedByNome()
        {
            var pessoasList = new Faker<Pessoa>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Nome, f => f.Name.FirstName())
                .RuleFor(p => p.Nascimento, f => f.Date.Past())
                    .Generate(10);

            Assert.That
            (
                new Organizer<Pessoa>().Organize
                (
                    listToOrganize: pessoasList,
                    field: p => p.Nome,
                    direction: Direction.Ascending
                ),
                Is.EqualTo(pessoasList.OrderBy(p => p.Nome))
            );
        }

        [Test(Description = "Ordena uma lista de pessoas de maneira ascendente pelo campo Nascimento.")]
        public void Organize_WhenCalled_ReturnsPessoaListInAscendingOrderedByNascimento()
        {
            var pessoasList = new Faker<Pessoa>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Nome, f => f.Name.FirstName())
                .RuleFor(p => p.Nascimento, f => f.Date.Past())
                    .Generate(10);

            Assert.That
            (
                new Organizer<Pessoa>().Organize
                (
                    listToOrganize: pessoasList,
                    field: p => p.Nascimento,
                    direction: Direction.Ascending
                ),
                Is.EqualTo(pessoasList.OrderBy(p => p.Nascimento))
            );
        }

        [Test(Description = "Ordena uma lista de pessoas de maneira descendente pelo campo Nascimento.")]
        public void Organize_WhenCalled_ReturnsPessoaListInDescendingOrderedByNascimento()
        {
            var pessoasList = new Faker<Pessoa>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.Nome, f => f.Name.FirstName())
                .RuleFor(p => p.Nascimento, f => f.Date.Past())
                    .Generate(10);

            Assert.That
            (
                new Organizer<Pessoa>().Organize
                (
                    listToOrganize: pessoasList,
                    field: p => p.Nascimento,
                    direction: Direction.Descending
                ),
                Is.EqualTo(pessoasList.OrderByDescending(p => p.Nascimento))
            );
        }

    }
}