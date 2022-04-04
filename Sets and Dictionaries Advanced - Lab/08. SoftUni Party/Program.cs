using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            string command;
           

            while ((command = Console.ReadLine()) != "PARTY")
            {
                //isValid
                if (command.Length != 8)
                {
                    continue;
                }
                else
                {
                    //isVIP
                    if (IsReservationVipType(command))
                    {
                        vipGuests.Add(command);
                    }
                    else
                    {
                        regularGuests.Add(command);
                    }
                }
            }

            while ((command = Console.ReadLine()) != "END")
            {
                if (vipGuests.Contains(command))
                {
                    vipGuests.Remove(command);
                }
                else if (regularGuests.Contains(command))
                {
                    regularGuests.Remove(command);
                }
            }
            var totalCount = vipGuests.Count + regularGuests.Count;
            Console.WriteLine(totalCount);

            foreach (var item in vipGuests)
            {
                Console.WriteLine(item);
            }

            foreach (var item in regularGuests)
            {
                Console.WriteLine(item);
            }
        }
        static bool IsReservationVipType(string command)
        {
            if (char.IsDigit(command[0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}
