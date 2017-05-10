using System;

namespace HW
{

    class Program
    {
        static void Main(string[] args)
        {
            // Calculate the area of a rectangle. 

            double area = TriangleCal(6,9);
            Console.WriteLine("The area of the Triangle with sides lenght 6 and 9 is {0}", area);
            Console.WriteLine("Please provide a height for a Triange.");
            double height= Convert.ToDouble (Console.ReadLine());
            Console.WriteLine("Please provide a width for a Triange.");
            double width= Convert.ToDouble (Console.ReadLine());
            double area = TriangleCal(height,width);
            Console.WriteLine("The area of the Triangle is {0}", area);


            //Creates Multiplication tables 

            Console.WriteLine("Please enter a value for the multiplication table.");
            int n= Convert.ToInt32(Console.ReadLine());
            if (n<1 ||n>30)
            {
                Console.WriteLine("You must choose an integer from 1 to 30.");
            }
            else
            {
                Multi (n);
            }

            /*write a function for the HR system that will take a list
             of everyone's salaries and increase it by 10 percent. */

            Console.WriteLine("The number of employees in your department is 10.");
            Console.WriteLine("Please enter how many will be given a raised, an increase of 10%.");
            int upgrade = Convert.ToInt32(Console.ReadLine());
            if( upgrade >10 || upgrade< 1)
            {
                 Console.Write("You must enter a number between 1 and 10.");
            }
            else
            {
            
                double [] office = {78920,65380,38999,49877,66000.7,91000,55510,84012.8,59923,80000};
                int emplyId;
                double salary;
                Console.WriteLine("You choose to raise the salaries of only {0} employee(s).",upgrade);
                Console.Write("The orginal salaries were: ");
                for (emplyId=0; emplyId< upgrade;emplyId++)
                { 
                    Console.Write(" ${0} ,",office[emplyId]);
                }

                Console.WriteLine();
                Console.Write("After the raised the salaries are: ");
                for (emplyId=0; emplyId< upgrade;emplyId++)
                {
                    salary=office[emplyId];
                    office[emplyId]= getRaise(salary);
                    Console.Write(" ${0} ,",office[emplyId]);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            
            /*Writes a function called Max that accepts a variable number of integer parameters.
             Find the largest number in the collection and return it from your Max function.*/
             Max();
        }

        static void Max(){
            Console.WriteLine("Please provide the size of an array.");
            int k = Convert.ToInt32(Console.ReadLine());
            int p;
            int x;
            
            int[ ] theMax = new int[k];
            int max= theMax[0];
            
            for (p = 0; p < k; p++) {
                Console.WriteLine("Enter a number.");
                x = Convert.ToInt32(Console.ReadLine());
                theMax[p] = x;

                if (theMax[p]>max)
                {
                    max = theMax[p];
                }

            }
            Console.WriteLine("The largest number in your array subset is {0}",max);

        }

        static int Multi (int n){
            for(int y=1;y<(n+1);y++){
                
                for(int w=1;w<(n+1);w++){
                   int stuff = w*y;
                    Console.Write(stuff);
                    if (stuff < 10)
                    {
                        Console.Write("   ");
                    }
                    else if (stuff<100)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }          
            Console.WriteLine();
            return n;
        }

        static double getRaise(double amount){
            return amount *=1.10;

        }
            static double TriangleCal (double height, double width){
                double half = 0.5;
                return half *height *width;
                
        }
    }
}
