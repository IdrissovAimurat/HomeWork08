using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utility_bills
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Сделаем вид, что у нас, в стране, а не только в Алматы такие низкие цены, аминь...

            Console.WriteLine("Тариф на отопление за 1 м2: ");
            double rateForOtoplenie = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Тариф на воду за 1 человека: ");
            double rateForWater = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Тариф на газ за 1 человека: ");
            double rateForGas = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Тариф на текущий ремонт за 1 м2 ");
            double rateForRepair = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Площадь помещения: ");
            double area = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Количество проживающих: ");
            int numberOfResidents = Convert.ToInt32(Console.ReadLine()); 

            bool isWinter         = true;     //true/false
            bool isVeteranOfWork  = false;    //true/false
            bool isWarVeteran     = false;    //true/false

            double PaymentForOtoplenie = rateForOtoplenie * area * (isWinter ? 1.2 : 1.0);
            double PaymentForWater     = rateForWater     * numberOfResidents;
            double PaymentForGas       = rateForGas       * numberOfResidents;
            double PaymentForRepair    = rateForRepair    * area;

            if (isVeteranOfWork)
            {
                PaymentForOtoplenie *= 0.7; // 30% для ветерана труда
            }
            if (isWarVeteran)
            {
                PaymentForOtoplenie *= 0.5; //50% для ветерана войны
            }

            //извиняюсь за нечитабельный код (условие с тернарными операторы), но так красиво

            double totalPayment = PaymentForOtoplenie + PaymentForWater + PaymentForGas + PaymentForRepair;

            Console.WriteLine("Вид платежа\tНачислено\tЛьготная скидка\tИтого");


            Console.WriteLine("Отопление\t{0}\t{1}\t{2}", PaymentForOtoplenie, PaymentForOtoplenie * (isVeteranOfWork ? 0.3 : 0.0), PaymentForOtoplenie * (isVeteranOfWork ? 0.7 : 1.0));
            
            
            Console.WriteLine("Вода\t{0}\t0\t{0}", PaymentForWater);
            
            
            Console.WriteLine("Газ\t{0}\t0\t{0}", PaymentForGas);
            
            
            Console.WriteLine("Ремонт\t{0}\t0\t{0}", PaymentForRepair);
            
            
            Console.WriteLine("Итого\t{0}\t{1}\t{2}", totalPayment, totalPayment * (isVeteranOfWork ? 0.3 : 0.0), totalPayment * (isVeteranOfWork ? 0.7 : 1.0));

        }
    }
}
