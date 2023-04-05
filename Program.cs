using System.Collections;

namespace Lab13_Collections_KazanovAlexandr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCollection collection = new MyCollection(5);
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.Add(4);
            collection.Add(5);

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            collection.Remove(3);
            Console.WriteLine("\n");

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

        }
    }

    public class MyCollection : IEnumerable
    {
        private int[] _array;
        private int _index = 0;

        public MyCollection()
        {
            _array = new int[10];
        }

        public MyCollection(int arrayLength)
        {
            _array = new int[arrayLength];
        }

        public void Add(int data)
        {
            if (_index == _array.Length - 1)
            {
                Array.Resize(ref _array, _array.Length * 2);
            }
            _array[_index++] = data;
        }

        public void Remove(int index)
        {
            var tmpArray = new int[_array.Length];
            var tmpIndex = 0;
            if (index < _array.Length || index >= 0)
            {
                for (int i = 0; i < _array.Length; i++)
                {
                    if (index != i)
                    {
                        tmpArray[tmpIndex++] = _array[i];
                    }
                }
                _array = tmpArray;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (i < _array.Length - 1)
                {
                   yield return _array[i] + _array[i + 1];
                }
                else yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetEnumerator();
        }
    }

}