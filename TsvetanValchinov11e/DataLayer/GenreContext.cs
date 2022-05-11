using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
    {
    public class GenreContext : IDB<Genre,int>
        {
        private TsvetanValchinov11eDbContext _context;
        public GenreContext(TsvetanValchinov11eDbContext context)
            {
            this._context = context;
            }

        public void Create(Genre item)
        {
            try
            {
                _context.Genres.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Genre Read(int key, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Genre> genres = _context.Genres;

                if (useNavigationProperties)
                {
                    genres = genres.Include(g => g.Games);
                }

                return genres.SingleOrDefault(g => g.ID == key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Genre> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Genre> genres = _context.Genres.AsNoTracking();

                if (useNavigationProperties)
                {
                    genres = genres.Include(g => g.Games);
                }

                return genres.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Genre item, bool useNavigationProperties = false)
        {
            try
            {
                Genre genreFromDb = Read(item.ID);

                _context.Entry(genreFromDb).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                _context.Genres.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
