using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondHotelProject
{
    public class Hotel
    {
        public string HotelName { get; private set; }
        public IList<HotelRoom> HotelRooms { get; private set; }

        public Hotel(string hotelName, IList<HotelRoom> hotelRooms)
        {
            HotelName = hotelName;
            HotelRooms = hotelRooms;
        }

        public void CheckInGuestsByRoomRank(int rank, IList<Customer> customers)
        {
            IEnumerable<HotelRoom> rankedRooms = HotelRooms.Where<HotelRoom>
                (room => room.RoomRating == rank);
            foreach(var room in rankedRooms)
            {
                if (!room.IsRoomTaken())
                {
                    room.AddCustomersToRoom(customers);
                    return;
                }
            }
        }

        public void UpgradeRoomForCustomer(Customer customer)
        {
            var originalRoom = HotelRooms.First<HotelRoom>
                (room => room.RoomCustomers.Contains(customer));
            var destinationRoom = HotelRooms.Where<HotelRoom>
                (room => !room.IsRoomTaken()).First<HotelRoom>
                (room => room.IsRoomBetterThan(originalRoom));
            originalRoom.MoveCustomersToDifferentRoom(destinationRoom);

        }

        public void CheckoutCustomer(Customer customer, int customerHappiness)
        {
            var customerRoom = HotelRooms.First<HotelRoom>
                (room => room.RoomCustomers.Contains(customer));
            Console.WriteLine($"final room bill: {customerRoom.GetRoomBill()}");
            customerRoom.CheckoutRoom(customerHappiness);
        }
    }
}
