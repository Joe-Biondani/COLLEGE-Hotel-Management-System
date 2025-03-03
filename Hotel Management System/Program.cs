using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System
{
    internal class Program
    {
        static int NUMBER_OF_ROOMS = 50;

        static void Main(string[] args)
        {
            Random random = new Random();
            Hotel hotel = new Hotel("Elephant Hotel", "Paris", NUMBER_OF_ROOMS);
        }
    }
}
