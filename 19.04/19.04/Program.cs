using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._04
{
    public interface IAnimal
    {
        string MakeSound();
    }

    public class Dog : IAnimal
    {
        public string MakeSound() => "Гав-гав!";
    }

    public class Cat : IAnimal
    {
        public string MakeSound() => "Мяу-мяу!";
    }

    public interface IVehicle
    {
        string StartEngine();
        string Honk();
    }

    public class Car : IVehicle
    {
        public string StartEngine() => "Врум-врум!";
        public string Honk() => "Бип-бип!";
    }

    public class Motorcycle : IVehicle
    {
        public string StartEngine() => "Дрын-дрын-дрын!";
        public string Honk() => "Пип-пип!";
    }

    public class VehicleToAnimalAdapter : IAnimal
    {
        private readonly IVehicle _vehicle;
        private readonly bool _useHonk;

        public VehicleToAnimalAdapter(IVehicle vehicle, bool useHonk = true)
        {
            _vehicle = vehicle ?? throw new ArgumentNullException(nameof(vehicle));
            _useHonk = useHonk;
        }

        public string MakeSound()
        {
            return _useHonk ? _vehicle.Honk() : _vehicle.StartEngine();
        }
    }

    public class SoundMaker
    {
        public string MakeAnimalSound(IAnimal animal)
        {
            return animal.MakeSound();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var soundMaker = new SoundMaker();

            Console.WriteLine("Настоящие животные:");
            Console.WriteLine(soundMaker.MakeAnimalSound(new Dog()));
            Console.WriteLine(soundMaker.MakeAnimalSound(new Cat()));

            Console.WriteLine("\nТранспорт, адаптированный под животных:");

            var car = new Car();
            var motorcycle = new Motorcycle();

            IAnimal carAnimal = new VehicleToAnimalAdapter(car);
            IAnimal motorcycleAnimal = new VehicleToAnimalAdapter(motorcycle);

            Console.WriteLine("Машина как животное: " + soundMaker.MakeAnimalSound(carAnimal));
            Console.WriteLine("Мотоцикл как животное: " + soundMaker.MakeAnimalSound(motorcycleAnimal));

 
            IAnimal carEngineAnimal = new VehicleToAnimalAdapter(car, false);
            Console.WriteLine("Машина (звук двигателя): " + soundMaker.MakeAnimalSound(carEngineAnimal));
        }
    }
}
