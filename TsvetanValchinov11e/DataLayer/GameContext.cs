using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
    {
    public class GameContext : IDB<Game,int>
        {
        private TsvetanValchinov11eDbContext _context;

        public GameContext(TsvetanValchinov11eDbContext context)
            {
            this._context = context;
            }

        public void Create(Game item)
            {
            try
                {
                List<Genre> genres = new List<Genre>();

                foreach (var genre in item.Genres)
                    {
                    Genre genreFromDb = _context.Genres.Find(genre.ID);

                    if (genreFromDb != null)
                        {
                        genres.Add(genreFromDb);
                        }

                    else
                        {
                        genres.Add(genre);
                        }
                    }

                item.Genres = genres;

                _context.Games.Add(item);
                _context.SaveChanges();
                }
            catch (Exception ex)
                {
                throw ex;
                }
            }

        public Game Read(int key, bool useNavigationProperties = false)
            {
            try
                {
                IQueryable<Game> games = _context.Games;

                if (useNavigationProperties)
                    {
                    games = games.Include(g => g.Genres).Include(g => g.Users);
                    }

                return games.SingleOrDefault(g => g.ID == key);
                }
            catch (Exception ex)
                {
                throw ex;
                }
            }

        public IEnumerable<Game> ReadAll(bool useNavigationProperties = false)
            {
            try
                {
                IQueryable<Game> games = _context.Games.AsNoTracking();

                if (useNavigationProperties)
                    {
                    games = games.Include(g => g.Genres).Include(g => g.Users);
                    }

                return games.ToList(); ;
                }
            catch (Exception ex)
                {
                throw ex;
                }
            }

        public void Update(Game item, bool useNavigationProperties = false)
            {
            try
                {
                Game gameFromDb = Read(item.ID, useNavigationProperties);

                if (useNavigationProperties)
                    {
                    List<Genre> genres = new List<Genre>();

                    foreach (Genre genre in item.Genres)
                        {
                        Genre genreFromDb = _context.Genres.Find(genre.ID);

                        if (genreFromDb != null)
                            {
                            genres.Add(genreFromDb);
                            }

                        else
                            {
                            genres.Add(genre);
                            }
                        }

                    gameFromDb.Genres = genres;
                    }

                _context.Entry(gameFromDb).CurrentValues.SetValues(item);
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
                _context.Games.Remove(Read(key));
                _context.SaveChanges();
                }
            catch (Exception ex)
                {
                throw ex;
                }
            }
        }
    }
