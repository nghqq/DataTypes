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
                Console.WriteLine($"EConstructor{ GetHashCode() }");
            }
            ~Element() 
            {
                Console.WriteLine($"EDestructor{GetHashCode()}");
            }
        }
        public Element Root { get; set; }
        public Tree()
        {
            Root = null;
            Console.WriteLine($"TConstructor{GetHashCode()}");
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
            if (this.Root == null) Root.pLeft = new Element(Data);
            if (Root == null) return;
            if (Data < Root.Data)
            {
                if (Root.pLeft == null) Root.pLeft = new Element(Data);
                else Insert(Data, Root.pLeft);
            }
            else
            {
                if(Root.pRight==null) Root.pRight = new Element(Data);
                else Insert(Data, Root.pRight);
            }
            
        }
       public int MinValue()
        {
            return MinValue(Root);
        }
       public int MaxValue()
        {
            return MaxValue(Root);
        }
        int MinValue(Element Root)
        {
            if(Root == null) throw new Exception("Tree is empty") ;
            return Root.pLeft == null? Root.Data: MinValue(Root.pLeft);
        }
         int MaxValue(Element Root)
        {
            if (Root == null) throw new Exception("Tree is empty");
            return Root.pRight == null ? Root.Data : MaxValue(Root.pRight);
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
            Console.WriteLine(Root.Data+"\t");
            Print(Root.pRight);
        }
    }
}
