using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TestingLayer
    {
    public class GenreContextNUnitTest
        {
        private TsvetanValchinov11eDbContext dbContext;
        private GenreContext genreContext;
        DbContextOptionsBuilder builder;

        [SetUp]
        public void Setup()
            {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            dbContext = new TsvetanValchinov11eDbContext(builder.Options);
            genreContext = new GenreContext(dbContext);
            }

        [Test]
        public void TestCreateGenre()
            {
            int genresBefore = genreContext.ReadAll().Count();
            genreContext.Create(new Genre("multiplayer"));

            int genresAfter = genreContext.ReadAll().Count();

            Assert.IsTrue(genresBefore != genresAfter);
            }

        [Test]
        public void TestReadGenre()
            {
            genreContext.Create(new Genre("racing"));
            Genre genre = genreContext.Read(1);

            Assert.That(genre != null, "There isn't record with that id: 1");
            }

        [Test]
        public void TestUpdateGenre()
            {
            genreContext.Create(new Genre("Racing"));
            Genre genre = genreContext.Read(1);

            genre.Name = "Sport";
            genreContext.Update(genre);

            Genre genre1 = genreContext.Read(1);

            Assert.IsTrue(genre1.Name == "Sport", "Genre Update() does not change the name of the genre!");
            }

        [Test]
        public void TestDeleteGenre()
            {
            genreContext.Create(new Genre("Cards"));
            int genresBeforeDelete = genreContext.ReadAll().Count();

            genreContext.Delete(1);

            int genresAfterDelete = genreContext.ReadAll().Count();

            Assert.AreNotEqual(genresBeforeDelete, genresAfterDelete);
            }
        }
    }
