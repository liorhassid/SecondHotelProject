using SecondHotelProject.Exceptions;
using SecondHotelProject.Models.Abstract;
using System.Collections.Generic;

namespace SecondHotelProject
{
    public class MiniBar
    {
        public IList<MiniBarItem> MiniBarItems { get; private set; }
        public double MiniBarBill { get; private set; }

        public MiniBar(IList<MiniBarItem> miniBarItems)
        {
            MiniBarItems = miniBarItems;
            MiniBarBill = 0;
        }

        public void AddItemToMiniBar(MiniBarItem miniBarItem)
        {
            MiniBarItems.Add(miniBarItem);
        }

        public void ConsumeItemByCustomer(MiniBarItem miniBarItem)
        {
            if (MiniBarItems.Contains(miniBarItem))
            {
                MiniBarBill += miniBarItem.Price;
                MiniBarItems.Remove(miniBarItem);
            }
            else
                throw new ItemDoesNotExistInMiniBarException();
        }

        public void ResetMiniBarBill()
        {
            MiniBarBill = 0;
        }

        public override bool Equals(object obj)
        {
            return obj is MiniBar bar &&
                   EqualityComparer<IList<MiniBarItem>>.Default.Equals(MiniBarItems, bar.MiniBarItems) &&
                   MiniBarBill == bar.MiniBarBill;
        }
    }
}