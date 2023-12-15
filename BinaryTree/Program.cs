//#define CHECK_ERASE
//#define UNIQUE_TREE
#define BASE_CHECK
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if BASE_CHECK
            Random random = new Random(0);
            Console.Write("Введите размер дерева: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Tree tree = new Tree();
            for (int i = 0; i < n; i++)
            {
                tree.Insert(random.Next(100));
            }
            //tree.Print();
            //tree.Clear();
            Stopwatch sw = new Stopwatch();

            try
            {
                sw.Start();
                //Console.WriteLine($"Минимальное значение в дереве:{tree.MinValue()}");
                
                //Console.WriteLine($"Максимальное значение в дереве:{tree.MaxValue()}");
                //Console.WriteLine($"Сумма элементов в дереве: {tree.Sum()}");
                //Console.WriteLine($"Глубина дерева:{tree.Depth()}");

                //Console.Write("Введите удаляемое значение: ");
                //int value = Convert.ToInt32(Console.ReadLine());
                //tree.Erase(value);
                //tree.Print();
                //tree.PrintTreeLikeATree();
#if UNIQUE_TREE
                UniqueTree u_Tree = new UniqueTree();
                for (int i = 0; i < n; i++)
                {
                    u_Tree.Insert(random.Next(100));
                }
                u_Tree.Print();
                Console.WriteLine($"Минимальное значение в дереве:{u_Tree.MinValue()}");
                Console.WriteLine($"Максимальное значение в дереве:{u_Tree.MaxValue()}");
                Console.WriteLine($"Сумма элементов в дереве: {u_Tree.Sum()}");
                Console.WriteLine($"Глубина дерева:{u_Tree.Depth()}");
                Console.WriteLine($"Количество элеметов дерева:{u_Tree.Count()}"); 
#endif

                Console.WriteLine();

                TreePerformance<int>.Measure("Максимальное значение в дереве: ", tree.MaxValue);
                TreePerformance<int>.Measure("Сумма элементов дерева: ", tree.Sum);
                TreePerformance<int>.Measure("Количество элементов дерева: ", tree.Count);
                TreePerformance<double>.Measure("Среднее-арифметическое элементов дерева: ", tree.Avarage);
                TreePerformance<int>.Measure("Глубина дерева: ", tree.Depth);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }
            Console.WriteLine($"Количество элементов дерева:{tree.Count()}");

#endif
#if CHECK_ERASE
            Tree tree = new Tree(50, 25, 75, 16, 32, 64, 80, 17);
			tree.Print();
			Console.WriteLine($"Глубина дерева: {tree.Depth()}");
			Console.Write("Введите удаляемое значение: ");
			int value = Convert.ToInt32(Console.ReadLine());
			tree.Erase(value);
			tree.Print(); 
#endif

        }
    }
}
