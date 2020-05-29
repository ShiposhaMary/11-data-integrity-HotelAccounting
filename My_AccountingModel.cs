using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    /*
    double Price — цена за одну ночь. Должна быть неотрицательной.
    int NightsCount — количество ночей. Должно быть положительным.
    double Discount — скидка в процентах. Никаких дополнительных
    ограничений.
    double Total — сумма счёта. Должна быть не отрицательна
    и должна быть согласована с предыдущими тремя свойствами по правилу:
    Total == Price * NightsCount * (1-Discount/100).
    */
  public class My_AccountingModel: ModelBase
    { public double price;
        public int nightsCount;
        public double discount;
        public double total;
        public double Price
        {
            get
            {
              return   price;
            }
            set
            {
                if (value >= 0) price = value;
                else throw new ArgumentException("Цена не может быть отрицательной.");
                CountNewTotal();
                Notify(nameof(Price));
            }
        }
        public int NightsCount
        {   get
            {
                return nightsCount;
            }
            set
            {
                if (value > 0) nightsCount = value;
                else throw new ArgumentException("Количество ночей должно быть больше 0.");
                CountNewTotal();
                Notify(nameof (NightsCount));
            }
        }
        public double Discount
        {   get
            {
                return discount;
            }
            set
            {
                discount = value;
                if (discount != ((-1) * Total / (Price * NightsCount) + 1) * 100)
                    CountNewTotal();
                Notify(nameof(Discount));

            }
        }
        public double Total
        {   get
            {
                return total;
            }
            set
            {
                if (value >= 0) total = value;
                else throw new ArgumentException("Итоговая цена не может быть меньше 0.");
                if (total != Price * NightsCount * (1 - Discount / 100))
                    CountNewDiscount();
                Notify(nameof( Total));
            }
        }
        private void CountNewTotal()
        {
            Total = Price * NightsCount * (1 - Discount / 100);
        }
        private void CountNewDiscount()
        {
            Discount= ((-1) * Total / (Price * NightsCount) + 1) * 100;
        }
    }
}
