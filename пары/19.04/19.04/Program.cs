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
using System.Xml.Linq;

namespace SeniorRoadmap
{
    internal class Program
    {

        #region
        //public class TreeNode
        //{
        //    public int Value { get; set; }
        //    public TreeNode Left { get; set; }
        //    public TreeNode Right { get; set; }

        //    public TreeNode(int value)
        //    {
        //        Value = value;
        //        Left = Right = null;
        //    }
        //}

        //public interface IIterator<T>
        //{
        //    bool HasNext();
        //    T Next();
        //}

        //public class Preor : IIterator<TreeNode>
        //{
        //    private Stack<TreeNode> _stack = new Stack<TreeNode>();

        //    public Preor(TreeNode root)
        //    {
        //        if (root != null)
        //            _stack.Push(root);
        //    }

        //    public bool HasNext() => _stack.Count > 0;

        //    public TreeNode Next()
        //    {
        //        TreeNode current = _stack.Pop();
        //        if (current.Right != null) _stack.Push(current.Right);
        //        if (current.Left != null) _stack.Push(current.Left);
        //        return current;
        //    }
        //}

        //public class Levelor : IIterator<TreeNode>
        //{
        //    private Queue<TreeNode> _queue = new Queue<TreeNode>();

        //    public Levelor(TreeNode root)
        //    {
        //        if (root != null)
        //            _queue.Enqueue(root);
        //    }

        //    public bool HasNext() => _queue.Count > 0;

        //    public TreeNode Next()
        //    {
        //        TreeNode current = _queue.Dequeue();
        //        if (current.Left != null) _queue.Enqueue(current.Left);
        //        if (current.Right != null) _queue.Enqueue(current.Right);
        //        return current;
        //    }
        //}
        #endregion
        #region
        public interface IObserver

        {
            void Update(int message);
        }

        // Интерфейс субъекта

        public interface ISubject

        {

            void RegisterObserver(IObserver observer);

            void RemoveObserver(IObserver observer);

            void NotifyObservers();

        }

        // Конкретный наблюдатель

        public class ConcreteObserver : IObserver

        {

            private string _name;
            private int _minSum;

            public ConcreteObserver(string name, int minsum)
            {

                _name = name;
                _minSum = minsum;

            }

            public void Update(int sum)

            {

                Console.WriteLine($"{_name} получил сообщение о снижении цены {sum}, он ждал цену ниже {_minSum}");
                if (sum <= _minSum)
                {
                    Console.WriteLine($"{_name} купил товар ");
                }

            }

        }

        // Конкретный субъект

        public class ConcreteSubject : ISubject

        {

            private List<IObserver> _observers = new List<IObserver>();

            private int _cost;
            private string _name;
            public int State

            {

                get { return _cost; }

                set

                {

                    _cost = value;

                    NotifyObservers();

                }

            }

            public void RegisterObserver(IObserver observer)

            {

                _observers.Add(observer);

            }

            public void RemoveObserver(IObserver observer)

            {

                _observers.Remove(observer);

            }

            public void NotifyObservers()

            {

                foreach (var observer in _observers)

                {

                    observer.Update(_cost);

                }

            }
            #endregion
            static void Main()
            {


                var subject = new ConcreteSubject();


                var observer1 = new ConcreteObserver("Наблюдатель 1", 200);

                var observer2 = new ConcreteObserver("Наблюдатель 2", 150);


                subject.RegisterObserver(observer1);

                subject.RegisterObserver(observer2);

                subject.State = 203;

                Console.WriteLine();

                subject.State = 197;
                #region
                //TreeNode root = new TreeNode(1);
                //root.Left = new TreeNode(2);
                //root.Right = new TreeNode(3);
                //root.Left.Left = new TreeNode(4);
                //root.Left.Right = new TreeNode(5);

                //Console.WriteLine("PreOrder traversal:");
                //IIterator<TreeNode> preIterator = new Preor(root);
                //while (preIterator.HasNext())
                //{
                //    Console.Write(preIterator.Next().Value + " ");
                //}

                //Console.WriteLine("\n\nLevelOrder traversal:");
                //IIterator<TreeNode> levelIterator = new Levelor(root);
                //while (levelIterator.HasNext())
                //{
                //    Console.Write(levelIterator.Next().Value + " ");
                //}
                #endregion
            }
        }
    }
}



// Написать 2 итератора для обхода древовидной коллекции
// Вы можете взять 2 ЛЮБЫХ алгоритма

// Написать класс товар(subject) у которого обновляется цена
// написать класс покупатель(наблюдатель) с минимальной ценой для покупки
// как только цена становится <= покупатель покупает товар
//после покупки покупатель удаляется из списка на оповещение