using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utility_bills_rework
{
    /// <summary>
    /// Написать программу, рассчитывающую сумму коммунальных платежей: 
    /// есть базовые тарифы на отопление (на 1 м2 площади), 
    /// 
    /// на воду (на 1 чел), 
    /// на газ (на 1 чел), 
    /// на текущий ремонт (на 1 м2 площади). 
    /// 
    /// Задается метраж помещения, количество проживающих людей, 
    /// сезон (осенью и зимой отопление дороже), 
    /// наличие льгот (ветеран труда– 30 % от его части; ветеран войны- 50% от его части). 
    /// Вывести таблицу со столбцами: 
    /// 
    /// Вид платежа, 
    /// Начислено, 
    /// Льготная скидка, 
    /// Итого. 
    /// 
    /// Посчитать итоговую сумму
    /// 
    /// </summary>
    class Communalka
    {
        private double rateForOtoplenie;
        private double rateForWater;
        private double rateForGas;
        private double rateForRepair;
        private double area;
        private int    numberOfResidents;
        private bool   isWinter;
        private bool   isVeteranOfWork;
        private bool   isWarVeteran;


        public Communalka(double otoplenie, double water, double gas, double repair, double area, int residents, bool winter, bool veteranOfWork, bool warVeteran)
        { 
            rateForOtoplenie  = otoplenie;
            rateForWater      = water;
            rateForGas        = gas;
            rateForRepair     = repair;
            this.area         = area;
            numberOfResidents = residents;
            isWinter          = winter;
            isVeteranOfWork   = veteranOfWork;
            isWarVeteran      = warVeteran;
        }

        public double this[string paymentType]
        {
            get
            {
                switch (paymentType)
                {
                    case "Otoplenie":
                        double paymentForOtoplenie = rateForOtoplenie * area * (isWinter ? 1.2 : 1.0);
                        if (isVeteranOfWork)
                        {
                            paymentForOtoplenie *= 0.7; // 30% для ветерана труда
                        }
                        if (isWarVeteran)
                        {
                            paymentForOtoplenie *= 0.5; //50% для ветерана войны
                        }
                        return paymentForOtoplenie;

                    case "Water":
                        return rateForWater * numberOfResidents;

                    case "Gas":
                        return rateForGas * numberOfResidents;

                    case "Repair":
                        return rateForRepair * area;

                    default:
                        return 0.0;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Тариф на отопление за 1 м2: ");
            double rateForOtoplenie = Convert.ToDouble(Console.ReadLine());

            Console.Write("Тариф на воду за 1 человека: ");
            double rateForWater = Convert.ToDouble(Console.ReadLine());

            Console.Write("Тариф на газ за 1 человека: ");
            double rateForGas = Convert.ToDouble(Console.ReadLine());

            Console.Write("Тариф на текущий ремонт за 1 м2 ");
            double rateForRepair = Convert.ToDouble(Console.ReadLine());

            Console.Write("Площадь помещения: ");
            double area = Convert.ToDouble(Console.ReadLine());

            Console.Write("Количество проживающих: ");
            int numberOfResidents = Convert.ToInt32(Console.ReadLine());

            bool isWinter        = true; // Для примера, можно изменить при необходимости (я поставил true, так как 
            bool isVeteranOfWork = false; // Измените, если вететран работы
            bool isWarVeteran    = false; // Изменить, если вететран войны

            Communalka payments = new Communalka(rateForOtoplenie, rateForWater, rateForGas, rateForRepair, area, numberOfResidents, isWinter, isVeteranOfWork, isWarVeteran);

            double totalPayment = 0.0;

            Console.WriteLine("Вид платежа\tНачислено\tЛьготная скидка\tИтого");

            string[] paymentTypes = { "Otoplenie", "Water", "Gas", "Repair" };

            foreach (string paymentType in paymentTypes)
            {
                double payment  = payments[paymentType];
                double discount = payment * (isVeteranOfWork ? 0.3 : 0.0);
                double total    = payment - discount;

                totalPayment   += total;

                Console.WriteLine($"{paymentType}\t{payment}\t{discount}\t{total}");
            }

            Console.WriteLine($"Итого\t{totalPayment}\t{totalPayment * (isVeteranOfWork ? 0.3 : 0.0)}\t{totalPayment}");
        }
    }
}
