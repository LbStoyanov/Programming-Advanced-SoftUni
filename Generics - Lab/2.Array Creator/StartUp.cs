﻿using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            var arr = ArrayCreator.Create(5, "1");

            Console.WriteLine(String.Join("**",arr));
        }
    }
}
