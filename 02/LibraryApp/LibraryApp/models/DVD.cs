using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.models
{
    internal class DVD : LibraryItem<DVD>
    {
        public DVD(string Director, int id, string Title) : base(id, Title)
        {
            this.Director = Director;
        }

        public string Director { get; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Autor {Director}");
        }
    }
    }

