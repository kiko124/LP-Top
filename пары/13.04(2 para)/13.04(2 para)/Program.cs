using System;

using System.Collections.Generic;

using System.Globalization;

using System.Linq;

using System.Net;

using System.Net.Http.Headers;

using System.Runtime.InteropServices;

using System.Text;

using System.Threading.Tasks;

using System.Web;

namespace SeniorRoadmap

{

    class Program

    {

        public interface ITransport

        {

            void Deliver();

        }

        public class Truck : ITransport

        {

            public void Deliver()

            {

                Console.WriteLine("Доставка транспортом");

            }

        }

        public class Ship : ITransport

        {

            public void Deliver()

            {

                Console.WriteLine("Доставка морским транспортом");

            }

        }
        public class Airplan : ITransport

        {

            public void Deliver()

            {

                Console.WriteLine("Доставка воздушным транспортом");

            }

        }
        public class Сourier : ITransport

        {

            public void Deliver()

            {

                Console.WriteLine("Доставка курьером");

            }

        }

        public abstract class LogisticCompany

        {

            public abstract ITransport CreateTransport();

            public void PlanDelivery()

            {

                ITransport transport = CreateTransport();

                Console.WriteLine("Планирование маршрута доставки");

                transport.Deliver();

            }

        }

        public class RoadLogistic : LogisticCompany

        {

            public override ITransport CreateTransport()

            {

                return new Truck();

            }

        }

        public class SeaLogistic : LogisticCompany

        {

            public override ITransport CreateTransport()

            {

                return new Ship();

            }

        }
        public class skyLogistic : LogisticCompany

        {

            public override ITransport CreateTransport()

            {

                return new Airplan();

            }

        }
        public class onfootLogistic : LogisticCompany

        {

            public override ITransport CreateTransport()

            {

                return new Сourier();

            }

        }

        static void Main()

        {

            LogisticCompany company = new onfootLogistic();


            ITransport createdTransport = company.CreateTransport();

            createdTransport.Deliver();

        }

    }

}

