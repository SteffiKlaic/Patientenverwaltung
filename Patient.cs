using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPatientenVerwaltung
{
    internal class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public int Versicherungsnummer { get; set; }
    }
}
