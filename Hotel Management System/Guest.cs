using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System
{
    class Guest
    {
        private string name;
        private int age;
        private int roomNumber;
        private string checkInDate;
        private string checkOutDate;
        private int stayTime;

        public Guest(string name, int age, int roomNumber, string checkInDate, string checkOutDate, int stayTime)
        {
            this.name = name;
            this.age = age;
            this.roomNumber = -1;
            this.checkInDate = "";
            this.checkOutDate = "";
            this.stayTime = -1;
        }

        public void SetRoom(int value) { this.roomNumber = value; }
        public void SetStayTime(int value) { this.stayTime = value; }
        public void SetCheckIn(string value) { this.checkInDate = value; }
        public void SetCheckOut(string value) { this.checkOutDate = value; }
        public int GetRoomNumber() { return this.roomNumber; }
        public string GetName() { return this.name; }
        public string GetCheckOut() { return this.checkOutDate; }
        public int GetAge() { return this.age; }
        public int GetStayTime() { return this.stayTime; }
    }
}
