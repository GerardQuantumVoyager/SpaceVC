using System;

namespace SpaceVc
{
    public class CustomArray<T>
    {
        private T[] array; // Internal array to store elements
        private int count; // Number of elements currently in the array

        // Constructor to initialize the internal array with a default size
        public CustomArray()
        {
            array = new T[4];
            count = 0;
        }

        // Method to add a new element to the array
        public void Add(T element)
        {
            // Check if the internal array needs to be resized
            if (count == array.Length)
            {
                Resize(array.Length * 2);
            }
            // Add the element to the array and increment the count
            array[count++] = element;
        }

        // Method to get an element at a specific index
        public T Get(int index)
        {
            // Check if the index is within the bounds of the array
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }
            return array[index];
        }

        // Method to search for an element in the array
        public int Search(T element)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(element))
                {
                    return i; // Return the index if element is found
                }
            }
            return -1; // Return -1 if element is not found
        }

        // Method to remove an element from the array
        public bool Remove(T element)
        {
            int index = Search(element);
            if (index == -1) return false; // Return false if element is not found

            // Shift elements to fill the gap left by the removed element
            for (int i = index; i < count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            count--; // Decrement the count
            return true; // Return true to indicate the element was removed
        }

        // Method to print all elements in the array
        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        // Private method to resize the internal array
        private void Resize(int newSize)
        {
            T[] newArray = new T[newSize];
            for (int i = 0; i < count; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray; // Replace the old array with the new array
        }
    }
}
