using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GenericBoxofInteger
{
    public class Box<T>
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
    }
}
