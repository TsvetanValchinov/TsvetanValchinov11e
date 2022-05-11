using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
    {
    public class Genre
        {
        [Key]
        public int ID { get; private set; }

        [Required,MaxLength(20)]
        public string Name { get; set; }

        public IEnumerable<Game> Games { get; set; }

        private Genre()
            {

            }

        public Genre(string name)
            {
            this.Name = name;
            }
        }
    }
