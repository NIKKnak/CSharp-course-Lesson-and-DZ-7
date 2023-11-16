using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Text;

namespace CSharp_course_Lesson_and_DZ_7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //создать методы создающий этот класс вызывая один из его 
            //конструкторов(по одному конструктору на метод). Задача не очень 
            //сложна и служит больше для разогрева перед следующей задачей.

            var v = CreateTestClassInstance(1, 11, "ssad", 3, new char[] { '4', '3', '8', '2' }, new char[] { 'f', 'g', 'k', 'i' });
            /*
            Напишите 2 метода использующие рефлексию
            1 - сохраняет информацию о классе в строку
            2 - позволяет восстановить класс из строки с информацией о методе
            В качестве примере класса используйте класс TestClass.
            Шаблоны методов для реализации:
            static object StringToObject(string s) { }
            static string ObjectToString(object o) { }
            */

            /*
            Пример того как мог быть выглядеть сохраненный в строку объект:
            “TestClass, test2, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null:TestClass | I:1 | S:STR | D:2.0 |”
            */
            string str = ObjectToString(v);
            Console.WriteLine(str);
            object str2 = StringToObject(str);
        }

        public static TestClass CreateTestClassInstance(int i,int ii, string s, decimal d, char[] c, char[] cc)
        {
            var testClassType = typeof(TestClass);
            var testClass = Activator.CreateInstance(testClassType) as TestClass;

            var testClassTwo = Activator.CreateInstance(testClassType, new object[] { i });

            var testClassThird = Activator.CreateInstance(testClassType, new object[] { i,ii, s, d, c,cc });

            return testClassThird as TestClass;
        }
        // "CSharp-course-Lesson-and-DZ-7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
        public static object StringToObject(string endString)
        {
            string[] str = endString.Split("\n");
            var obj = Activator.CreateInstance(str[1], str[0])?.Unwrap();



            return endString;
        }
        // “TestClass, test2, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null:TestClass | I:1 | S:STR | D:2.0 |”
        public static string ObjectToString(object obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var type = obj.GetType();
            stringBuilder.Append(type.ToString() + "\n");
            stringBuilder.Append(type.Assembly + "\n");
            stringBuilder.Append(type.Name + "\n");
            var properties = type.GetProperties(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            foreach (var item in properties)
            {
                var value = item.GetValue(obj);

                stringBuilder.Append(item.Name + ":");
                if (item.PropertyType == typeof(char[]))
                {
                    stringBuilder.Append(new String(value as char[]) +"\n");
                }
                else
                {
                    stringBuilder.Append(value + "\n");
                }
            }
            
            return stringBuilder.ToString();
        }


    }
}