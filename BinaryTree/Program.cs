using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(0);
            Console.Write("Введите размер дерева: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Tree tree =  new Tree();
            for(int i = 0; i < n; i++)
            {
                tree.Insert(random.Next(100));
            }
            tree.Print();
        Console.WriteLine($"Минимальное значение в дереве:{tree.MinValue()}");
        Console.WriteLine($"Максимальное значение в дереве:{tree.MaxValue()}");
        Console.WriteLine($"Сумма элементов в дереве: {tree.Sum()}");
        Console.WriteLine($"Глубина дерева:{tree.Depth()}");

            Console.Write("Введите удаляемое значение: ");
            int value = Convert.ToInt32(Console.ReadLine());
            tree.Erase(value);
            tree.Print();
        }
    }
}
