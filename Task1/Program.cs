using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = null;
            try
            {
                //вызываем конструкторы и получаем исключения
                //получение NullReferenceException
                //p = new Person(null, null);
                //FormatException
                //p = new Person("a1x", "dfd");
                //PersonException 1
                //p = new Person("a1x", "25");
                //PersonException 2
                //p = new Person("a", "25");
                //Необработанное исключение которое свалилось в Exception
                //p = new Person("aaaa", "999");
                p = new Person("Ivan", "25");
            }
            catch (PersonException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Слишком короткое имя");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Нулевой указатель при передачи параметра.");
            }

            catch (FormatException)
            {
                Console.WriteLine("Возраст введен не корректно");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            finally
            {
                if (p == null)
                    Console.WriteLine("Person not created");
                else
                    Console.WriteLine(p.ToString());
            }
            Console.ReadKey();
        }

    }
    class PersonException : Exception
    {
        public PersonException(string message) : base(message) { }
    }
    class Person
    {
        public Person(string name, string age)
        {
            if (age == null || name == null)
                throw new NullReferenceException();

            this.age = age;
            this.name = name;
            if (name.Length < 2)
                throw new ArgumentOutOfRangeException();            
        }
        int _age;
        string age
        {
            get
            {
                return _age.ToString();
            }
            set
            {
                int a = int.Parse(value);
                if (a < 18)
                    throw new PersonException("Возраст не может быть меньше 18.");
                if (a > 110)
                    throw new ArgumentException();
                _age = a;
            }
        }

        string _name;
        string name
        {
            get
            {
                return _name;
            }
            set
            {
                for( int i = 0; i < value.Length; i++)
                {
                    if (!(value[i] >= 'a' && value[i] <= 'z' || value[i] >= 'A' && value[i] <= 'Z'))
                        throw new PersonException("Имя состоит только из букв.");
                }
                _name = value;
            }
        }

        public override string ToString()
        {
            return $"{name} {age} years old.";
        }
    }
}
