using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_course_Lesson_and_DZ_7
{
    internal class TestClass
    {
        public int I {  get; set; }
        private int II {  get; set; }
        public string? S { get; set; }
        public decimal? D { get; set; }
        public char[]? C { get; set; }
        private char[]? CC { get; set; } 

        public TestClass()
        {
            
        }
        public TestClass(int i)
        {
            I = i;
        }
        public TestClass(int i,int ii,string s, decimal d, char[] c, char[] cc) : this(i)
        {
            S = s;
            D = d;
            C = c;
            II = ii;
            CC = cc;

        }

    }
}
