using _253501_Stepanov_Lab1.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;


namespace _253501_Stepanov_Lab1.Collections
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException() { }

        public ObjectNotFoundException(string message) : base(message) { }

        public ObjectNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
    internal class MyCustomCollection<T> : ICustomCollection<T>
    {
        private class Node
        {
            private T? _val;

            public Node? next;

            public T Value
            {
                get => _val;
                set { _val = value; }
            }

            public Node(T? val)
            {
                _val = val;

                next = null;
            }
        }

        private class MyEnumerator : IEnumerator<T>, IEnumerator
        {
            private Node? first;
            private Node? current;

            public void Dispose()
            {
                return;
            }

            object IEnumerator.Current
            {
                get => current.Value;
            }

            public T Current
            {
                get => current.Value;
            }

            public bool MoveNext()
            {
                if (current?.next is null)
                {
                    return false;
                }

                current = current.next;

                return true;
            }

            public void Reset() => current = first;

            public MyEnumerator(MyCustomCollection<T>.Node? first)
            {
                this.first = first;
                current = new Node(default(T));
                current.next = first;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator(first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        private Node? first;

        private Node? current;

        public T Current()
        {
            return current.Value;
        }

        public void Reset()
        {
            current = first;
        }

        public void Next()
        {
            current = current?.next;
        }

        public int Count
        {
            get
            {
                if (first is null)
                {
                    return 0;
                }

                var count = 1;

                var node = first;

                while (node?.next != null)
                {
                    node = node.next;

                    ++count;
                }

                return count;
            }
        }

        public void Add(T item)
        {
            var node = new Node(item);

            if (first == null)
            {
                first = node;

                current = node;

                return;
            }

            var tmp = first;

            while (tmp?.next != null)
            {
                tmp = tmp.next;
            }

            tmp.next = node;
        }

        public void Remove(T item)
        {
            var node = first;
            Node? prev = null;
            bool found = false;

            while (node?.next != null)
            {
                if (node.Value.Equals(item))
                {
                    found = true;

                    if (node == current)
                    {
                        if (node.next is null)
                        {
                            current = prev;
                        }
                        else
                        {
                            current = node.next;
                        }
                    }

                    if (node == first)
                    {
                        first.next = null;

                        first = node?.next;
                    }

                    prev.next = node?.next;

                    node.next = null;

                    break;
                }

                prev = node;
                node = node?.next;
            }
            if (!found) throw new ObjectNotFoundException("Элемент не найден");
        }

        public T RemoveCurrent()
        {
            var currentValue = current.Value;

            if (first == current)
            {
                first = current = current.next;

                return currentValue;
            }

            var node = first;

            while (node.next != null)
            {
                if (node.next == current)
                {
                    node.next = current.next;

                    current = node.next;
                }
            }

            return currentValue;
        }

        public T this[int index]
        {
            get
            {
                try
                {
                    if (index > Count - 1)
                    {
                        throw new IndexOutOfRangeException("Неверный диапазон");
                    }

                    var node = first;

                    for (var i = 0; i < index; ++i)
                    {
                        node = node?.next;
                    }

                    return node.Value;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }

            set
            {
                var node = first;

                for (var i = 0; i < index; ++i)
                {
                    node = node?.next;
                }

                node.Value = value;
            }
        }


        public MyCustomCollection()
        {
            first = null;
            current = null;
        }
    }
}



