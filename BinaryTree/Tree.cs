using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Tree
    {
        public class Element
        {
            public int Data { get; set; }
            public Element pLeft { get; set; }
            public Element pRight { get; set; }

            public Element(int data, Element pLeft = null, Element pRight = null)
            {
                this.Data = data;
                this.pLeft = pLeft;
                this.pRight = pRight;
                Console.WriteLine($"EConstructor{GetHashCode()}");
            }
            ~Element()
            {
                Console.WriteLine($"EDestructor{GetHashCode()}");
            }
        }
        protected Element Root { get; set; }

        public Tree()
        {
            Root = null;
            Console.WriteLine($"TConstructor{GetHashCode()}");
        }
        public Tree(params int[] values) : this()
        {
            foreach (int i in values)
            {
                Insert(i, Root);
            }
        }
        ~Tree()
        {
            Console.WriteLine($"EDestructor{GetHashCode()}");
        }
        public void Insert(int Data)
        {
            Insert(Data, Root);
        }
        private void Insert(int Data, Element Root)
        {
            if (this.Root == null) this.Root = new Element(Data);
            if (Root == null) return;
            if (Data < Root.Data)
            {
                if (Root.pLeft == null) Root.pLeft = new Element(Data);
                else Insert(Data, Root.pLeft);
            }
            else
            {
                if (Root.pRight == null) Root.pRight = new Element(Data);
                else Insert(Data, Root.pRight);
            }

        }
        public void Erase(int Data) => Erase(Data, Root, null);
        void Erase(int Data, Element Root, Element Parent)
        {
            if (Root == null) return;
            Erase(Data, Root.pLeft, Root);
            Erase(Data, Root.pRight, Root);
            if (Data == Root.Data)
            {
                if (Root.pLeft == Root.pRight)
                {
                    if (Root.Equals(Parent.pLeft)) Parent.pLeft = null;
                    if (Root.Equals(Parent.pRight)) Parent.pRight = null;
                    // Equals проверяет объекты на идентичность. Если они идентичны возвращает true.
                    // Если объекты разные возвращает false.
                    Root = null;
                    GC.Collect(1);
                }
                else
                {
                    if (Count(Root.pLeft) > Count(Root.pRight))
                    {
                        Root.Data = MaxValue(Root.pLeft);
                        Erase(MaxValue(Root.pLeft), Root.pLeft, Root);
                    }
                    else
                    {
                        Root.Data = MinValue(Root.pRight);
                        Erase(MinValue(Root.pRight), Root.pRight, Root);
                    }
                }
            }
        }
        public void Clear()
        {
            //if (Root == null) return;
            //Clear(Root.pLeft);
            //Clear(Root.pRight);
            //Root = null;
            Root = null;
            GC.Collect(1);
        }

        public int MinValue() => MinValue(Root); // => это return 
        int MinValue(Element Root)
        {
            if (Root == null) throw new Exception("Tree is empty in MinValue");
            return Root.pLeft == null ? Root.Data : MinValue(Root.pLeft);
        }
        public int MaxValue() => MaxValue(Root);
        int MaxValue(Element Root)
        {
            if (Root == null) throw new Exception("Tree is empty MaxValue");
            return Root.pRight == null ? Root.Data : MaxValue(Root.pRight);
        }
        public int Sum() => Sum(Root);
        int Sum(Element Root)
        {
            if (Root == null) return 0;
            else return Sum(Root.pLeft) + Sum(Root.pRight) + Root.Data;
        }
        public int Count() => Count(Root);
        int Count(Element Root)
        {
            return Root == null ? 0 : Count(Root.pLeft) + Count(Root.pRight) + 1;
        }
        public double Avarage() => (double)Sum(Root) / Count(Root);
        public int Depth() => Depth(Root);
        int Depth(Element Root)
        {
            if (Root == null) return 0;
            int l_depth = Depth(Root.pLeft) + 1;
            int r_depth = Depth(Root.pRight) + 1;
            return l_depth > r_depth ? l_depth : r_depth;
        }
        public void Print()
        {
            Print(Root);
            Console.WriteLine();
        }
        void Print(Element Root)
        {
            if (Root == null) return;
            Print(Root.pLeft);
            Console.Write(Root.Data + "\t");
            Print(Root.pRight);
        }
        public void PrintTreeLikeATree()
        {
            PrintTreeLikeATree(Root);
            Console.WriteLine();
        }
        void PrintTreeLikeATree(Element Root, int padding = 0)
        {
            if (Root != null)
            {
                if (Root.pRight != null)
                {
                    PrintTreeLikeATree(Root.pRight, padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (Root.pRight != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(Root.Data.ToString() + "\n ");
                if (Root.pLeft != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    PrintTreeLikeATree(Root.pLeft, padding + 4);

                }
            }
        }
        
    }
    
}
          
    
