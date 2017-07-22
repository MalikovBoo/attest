using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    abstract public class Products              // абстрактный класс продуктов
    {
        private string title;                    // название продукта
        private int acode;                       // артикул продукта

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public int Acode
        {
            get
            {
                return acode;
            }

            set
            {
                acode = value;
            }
        }

        protected Products(string t, int A)     // конструктор класса
        {
            Title = t;                          // t для названия продукта 
            Acode = A;                          // A для артикула
        }
    }


    public class Pieces : Products              // Дочерний класс для поштучных товаров
    {
        private float priceFP;                   // цена за 1 штуку
        private int count;                       // количество штук

        public float PriceFP
        {
            get
            {
                return priceFP;
            }
            set
            {
                priceFP = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }


        public Pieces(string t, int A, int c, float p) : base(t, A)    // конструктор класса 
        {
            Title = t;                          // t для названия продукта
            Acode = A;                          // A для артикула
            Count = c;                          // c для количества штук
            PriceFP = p;                        // p цена за штуку
        }
    }


    public class Mass : Products                // Дочерний класс для развесных товаров
    {
        private float priceFK;                   // цена за килограмм
        private float weight;                    // масса в килограммах

        public float PriceFK
        {
            get
            {
                return priceFK;
            }
            set
            {
                priceFK = value;
            }
        }

        public float Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        public Mass(string t, int A, float w, float p) : base(t, A)     // конструктор класса 
        {
            Title = t;                          // t для названия продукта
            Acode = A;                          // A для артикула
            Weight = w;                         // w для массы в килограммах
            PriceFK = p;                        // p цена за килограмм
        }
    }


}
