using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class Box<T> where T: IComparable
    {
        private T item;

        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        public Box(T item)
        {
            Item = item;
        }
        public override string ToString()
        {
            return $"{Item.GetType()}: {Item}";
        }  
        
        public int CompareTo(T itemToCompare)
        {
            return Item.CompareTo(itemToCompare);
        }
    }
}
