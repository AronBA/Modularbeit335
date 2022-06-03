using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ModularbeitM335
{
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }    
        public string developer { get; set; }   
        public DateTime releasedate { get; set; } 
    }
}
