using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp1
{
    public class Basket                         // Класс корзины
    {
        private Mass[] wm;                                       // Массив товаров на развес
        private Pieces[] cm;                                     // Массив поштучных товаров 
        private int wmi, cmi;                                    // количество товаров на развес и поштучных

        private float pricecm;                                   // общая сумма за поштучные товары
        private float pricewm;                                   // общая сумма за развесные товары

        public Mass[] WM
        {
            get
            {
                return wm;
            }

            set
            {
                wm = value;
            }
        }

        public Pieces[] CM
        {
            get
            {
                return cm;
            }

            set
            {
                cm = value;
            }
        }

        public int WMi
        {
            get
            {
                return wmi;
            }
            set
            {
                wmi = value;
            }
        }

        public int CMi
        {
            get
            {
                return cmi;
            }
            set
            {
                cmi = value;
            }
        }

        public float priceCM
        {
            get
            {
                return pricecm;
            }
            set
            {
                pricecm = value;
            }
        }

        public float priceWM
        {
            get
            {
                return pricewm;
            }
            set
            {
                pricewm = value;
            }
        }

        public Basket()                                         // конструктор класса
        {
            CMi = 0;                                            // по умолчанию корзины пусты и сумма равна 0
            WMi = 0;
            WM = new Mass[WMi];
            CM = new Pieces[CMi];
            priceCM = 0;
            priceWM = 0;
        }

        public void AddCM(Pieces p)                             // Добавление поштучного товара p
        {
            bool t = false;                                     // флаг, что данный товар не встречался в корзине.

            if (CMi != 0)                                         // если уже есть поштучные продукты, то начинаем цикл
                for (int i = 0; i < CMi; i++)                    // проходим по всем продуктам
                {
                    if (CM[i].Title == p.Title)                 // ищем совпадения по названию с добавляемым продуктом p
                    {
                        CM[i].Count = CM[i].Count + p.Count;    // если совпадения существуют, то просто заменяем количество штук товара на сумму старого и нового
                        t = true;                               // меняем флаг, что товар встретился
                        break;                                  // выходим из цикла
                    }
                }

            if (!t)                                             // если товар не встречался
            {
                CMi++;                                          // увеличиваем количество поштучных товаров 
                Array.Resize(ref cm, CM.Length + 1);            // увеличиваем динамически массив поштучных товаров
                CM[CMi - 1] = p;                                // присваиваем последнему элементу массива значения нового товара в корзине
            }

            priceCM = priceCM + p.Count * p.PriceFP;            // прибавляем к сумме стоимость нового товара
        }

        public void AddWM(Mass m)                               // Добавление развесного товара m
        {
            bool t = false;                                     // флаг, что данный товар не встречался в корзине.

            if (WMi != 0)                                         // если уже есть развесные продукты, то начинаем цикл
                for (int i = 0; i < WMi; i++)                   // проходим по всем продуктам
                {
                    if (WM[i].Title == m.Title)                 // ищем совпадения по названию с добавляемым продуктом m
                    {
                        WM[i].Weight = WM[i].Weight + m.Weight; // если совпадения существуют, то просто заменяем общую массу товара сумму старого и нового
                        t = true;                               // меняем флаг, что товар встретился
                        break;                                  // выходим из цикла
                    }
                }

            if (!t)                                             // если товар не встречался
            {
                WMi++;                                          // увеличиваем количество развесных товаров 
                Array.Resize(ref wm, WM.Length + 1);            // увеличиваем динамически массив развесных товаров
                WM[WMi - 1] = m;                                // присваиваем последнему элементу массива значения нового товара в корзине
            }

            priceWM = priceWM + m.Weight * m.PriceFK;           // прибавляем к сумме стоимость нового товара
        }

        public float Price()                                    // Находим общую сумму за развесные и поштучные товары вместе         
        {
            return priceCM + priceWM;
        }

        public int SumCount()                                 // сумма, показывающая сколько всего разных товаров в корзине
        {
            return CMi + WMi;
        }

    }
}
