using SecondHotelProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondHotelProject
{
    public class HotelRoom
    {
        public MiniBar MiniBar { get; private set; }
        public int RoomFloor { get; private set; }
        public int RoomNumber { get; private set; }
        public IList<Customer> RoomCustomers { get; private set; }
        public int RoomCleaningLevel { get; private set; }
        public int RoomRating { get; private set; }
        public double CustomerHappiness { get; private set; }

        public const double DefultCustomerHappiness = 1;

        public HotelRoom(
            MiniBar miniBar,
            int roomNumber,
            int roomCleaningLevel,
            int roomRating)
        {
            MiniBar = miniBar;
            RoomNumber = roomNumber;
            RoomFloor = int.Parse(roomNumber.ToString()[0].ToString());
            RoomCustomers = new List<Customer>();
            RoomCleaningLevel = roomCleaningLevel;
            RoomRating = roomRating;
            CustomerHappiness = DefultCustomerHappiness;
        }

        public bool IsRoomTaken()
        {
            return RoomCustomers.Count() != 0;
        }

        public void ResetRoom()
        {
            RoomCustomers = null;
            MiniBar.ResetMiniBarBill();
        }

        public bool IsRoomBetterThan(HotelRoom otherRoom)
        {
            return RoomRating > otherRoom.RoomRating;
        }

        public void AddCustomersToRoom(IList<Customer> customers)
        {
            if (IsRoomTaken())
                throw new RoomIsAlreadyTakenException();
            ResetRoom();
            CustomerHappiness = DefultCustomerHappiness;
            RoomCustomers = new List<Customer>(customers);
        }

        public void CheckoutRoom(int customerHappiness)
        {
            CustomerHappiness = customerHappiness;
            ResetRoom();
        }

        public void MoveCustomersToDifferentRoom(HotelRoom destinationRoom)
        {
            destinationRoom.AddCustomersToRoom(RoomCustomers);
            ResetRoom();
        }

        public double GetRoomBill()
        {
            return (RoomRating * 100 + RoomCleaningLevel * 50)
                * RoomCustomers.Count() * RoomFloor + MiniBar.MiniBarBill;
        }

        public override bool Equals(object obj)
        {
            return obj is HotelRoom room &&
                   EqualityComparer<MiniBar>.Default.Equals(MiniBar, room.MiniBar) &&
                   RoomFloor == room.RoomFloor &&
                   RoomNumber == room.RoomNumber &&
                   EqualityComparer<IList<Customer>>.Default.Equals(RoomCustomers, room.RoomCustomers) &&
                   RoomCleaningLevel == room.RoomCleaningLevel &&
                   RoomRating == room.RoomRating &&
                   CustomerHappiness == room.CustomerHappiness;
        }
    }
}
