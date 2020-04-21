using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace ThemeExample
{
    public class Class1 : MySubClass, IClass
    {
        private readonly IFormatProvider _field;
        private static readonly bool _canBeSeen = false;
        public const string NEVER = "Gonna give you up\n";

        public Class1(IFormatProvider provider)
        {
            _field = provider;
            Regex regex = new Regex(@"meh[0-9]+\n");
            PrintName();
        }

        public string GetSome()
        {
            // We only like people who are positive.
            if (Number > 0)
            {
                return @$"Your number is {Number}";
            }
            return _canBeSeen ? "John Cena" : "Not today, Satan";
        }

        public void SetSome(int parameter)
        {
            #region My Region
            Number = parameter;
            #endregion
        }

        public async Task DoStuffAsync(int parameter)
        {
            System.Reflection.PropertyInfo[] local = _field.GetType().GetProperties();
            List<Task> list = new List<Task>();
            local.ToList().ForEach(p => list.Add(Task.Run(() =>
            {
                if (p.Name.Length > parameter)
                {
                    PrintName();
                    Console.WriteLine("Not big enough!");
                }
                return;
            })));
            foreach (Task t in list)
            {
                await t;
            }
            Console.WriteLine(NEVER);
        }
    }

    public interface IClass
    {
        /// <summary>
        /// Some XML comments. See <see cref="MyParentClass.Number"/> for more information on numbers.
        /// </summary>
        /// <param name="o"></param>
        void SetSome(int o);
        string GetSome();
    }

    public class MySubClass : MyParentClass
    {
        protected override void PrintName()
        {
            Console.WriteLine("Sub Class");
        }
    }

    public abstract class MyParentClass
    {
        protected int Number { get; set; } = 0;
        protected virtual void PrintName()
        {
            Console.Write("Name");
        }
    }

    public enum MrEnumerable
    {
        Zero,
        One,
        Two,
        Three,
        Six = 6
    }
}
