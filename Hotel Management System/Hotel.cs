using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System
{
    class Hotel
    {
        static string[] ROOM_TYPES = new string[]
        {
                "Standard",
                "Double",
                "Twin",
                "King",
        };
        static int[] ROOM_PRICES = new int[]
        {
                40, // standard
                60, // double
                70, // twin
                90, // king
        };

        private string name;
        private string location;
        private int roomsCount;
        private Room[] rooms;
        private List<Guest> CurrentGuests = new List<Guest>();

        public Hotel(string name, string location, int roomsCount) {
            this.name = name;
            this.location = location;
            this.roomsCount = roomsCount;
            this.rooms = new Room[roomsCount];

            Random random = new Random();
            for (int roomNumber = 1; roomNumber <= roomsCount; roomNumber++)
            {
                int roomTypeIndex = random.Next(0, ROOM_TYPES.Length);
                this.rooms[roomNumber - 1] = new Room(roomNumber, ROOM_TYPES[roomTypeIndex], ROOM_PRICES[roomTypeIndex]);
            }
        }

        public Room FindRoomByNumber(int roomNumber)
        {
            foreach (Room room in this.rooms)
            {
                if (room.GetRoomNumber() == roomNumber) return room;
            }
            throw new Exception(); // shouldn't happen but in unlikely scenario
        }

        public Guest FindGuestByRoomNumber(int roomNumber)
        {
            foreach (Guest guest in this.CurrentGuests)
            {
                if (guest.GetRoomNumber() == roomNumber) return guest;
            }
            throw new Exception(); // again unlikely!
        }

        public void Check_In(Guest guest, int roomNumber, string checkin, string checkout, int stayTime)
        {
            try
            {
                Room room = FindRoomByNumber(roomNumber);
                if (room.GetAvailability())
                {
                    room.SetAvailability(false);
                    guest.SetRoom(roomNumber);
                    guest.SetCheckIn(checkin);
                    guest.SetCheckOut(checkout);
                    guest.SetStayTime(stayTime);
                    this.CurrentGuests.Add(guest);
                }
                else { Console.WriteLine("Desired room not available!"); }
            }
            catch (Exception) { Console.WriteLine("Room not found!"); }
        }

        public void Check_Out(Guest guest, int roomNumber)
        {
            try
            {
                Room room = FindRoomByNumber(roomNumber);
                if (!room.GetAvailability())
                {
                    room.SetAvailability(true);
                    guest.SetRoom(-1);
                    guest.SetCheckIn("");
                    guest.SetCheckOut("");
                    guest.SetStayTime(-1);
                    this.CurrentGuests.Remove(guest);
                }
                else { Console.WriteLine("No one was in this room!"); }
            }
            catch (Exception) { Console.WriteLine("Room not found!"); }
        }

        public void View_Available_Rooms()
        {
            foreach (Room room in this.rooms)
            {
                if (room.GetAvailability())
                    Console.WriteLine($"{room.GetRoomNumber(),3} || {room.GetRoomType()}");
            }
        }

        public void View_Occupied_Rooms()
        {
            foreach (Room room in this.rooms)
            {
                if (!room.GetAvailability())
                {
                    Guest guest = FindGuestByRoomNumber(room.GetRoomNumber());
                    Console.WriteLine(
                        "{0,3} || {1} || {2,-20} {3,4} - {4} days until checkout",
                        room.GetRoomNumber(),
                        room.GetRoomType(),
                        guest.GetName(),
                        "(" + guest.GetAge() + ")",
                        guest.GetStayTime()
                    );
                }
            }
        }

        public int Calculate_Bill(Guest guest)
        {
            Room room = FindRoomByNumber(guest.GetRoomNumber());

            int price = room.GetPrice() * guest.GetStayTime();

            return price;
        }

        public void View_Guests()
        {
            foreach (Guest guest in this.CurrentGuests)
            {
                if (guest.GetRoomNumber() != -1)
                {
                    Console.WriteLine(
                        "{0,-20} {1,4} - {2} days until checkout",
                        guest.GetName(),
                        "(" + guest.GetAge() + ")",
                        guest.GetStayTime()
                    );
                }
            }
        }
    }
}
