using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModelLibrary
{
    /// <summary>
    /// Class that holds information for a character.
    /// </summary>
    public class Character
    {
        // Getters and setters for a Character's name.
        public string Name { get; set; }
        // Getters and setters for a Character's id.
        public int Id { get; set; }

        // Constructor
        public Character(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
