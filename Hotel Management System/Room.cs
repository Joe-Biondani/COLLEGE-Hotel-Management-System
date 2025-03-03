using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System
{
    class Room
    {
        private int roomNumber;
        private string roomType;
        private int roomPrice;
        private bool roomAvailable;

        public Room(int roomNumber, string roomType, int roomPrice)
        {
            this.roomNumber = roomNumber;
            this.roomType = roomType;
            this.roomPrice = roomPrice;
            this.roomAvailable = true;
        }

        public int GetRoomNumber() { return this.roomNumber; }
        public void SetAvailability(bool value) { this.roomAvailable = value; }
        public bool GetAvailability() { return this.roomAvailable; }
        public string GetRoomType() { return this.roomType; }
        public int GetPrice() { return this.roomPrice; }
    }
}
