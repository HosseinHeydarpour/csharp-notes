using System.Collections;

namespace ListsApp
{
    internal class Program
    {


        static void Main(string[] args)
        {

            // Declaring an ArrayList with undefined amount of objects
            ArrayList myArrayList = new ArrayList();
            // We can also define the number of objects our arraylist will hold --> here is 100 objs
            ArrayList myArrayList2 = new ArrayList(100);

            myArrayList.Add(26);
            myArrayList.Add("Hello");
            myArrayList.Add(2.7);
            myArrayList.Add(true);
            myArrayList.Add(25.4);
            myArrayList.Add(2.7);


            // This will delete specific entry from the arrayList --> Only the first occurence
            myArrayList.Remove(2.7);


            // delete element at specific index(position)
            myArrayList.RemoveAt(0);


            Console.WriteLine(myArrayList.Count);

            double sum = 0;

            foreach (object obj in myArrayList)
            {
                if (obj is int)
                {
                    sum += Convert.ToDouble(obj);
                }
                else if (obj is double)
                {
                    sum += Convert.ToDouble(obj);
                }
                else if (obj is string)
                {
                    {
                        Console.WriteLine(obj);
                    }
                }

              
            }

            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}