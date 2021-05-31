using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Implement
{
    public class Math_B : IMath
    {
        public int sum(int a, int b) => (a + b)*2;
    }
}
