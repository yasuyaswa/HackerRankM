using System;
using System.Collections.Generic;
 
class Solution
{
    public static void Main(string[] args)
    {
        string[] input1 = Console.ReadLine().Split(' ');
        int numCookies = Convert.ToInt32(input1[0]);
        int minSweetness = Convert.ToInt32(input1[1]);
        int count = 0;
        PriorityQueue<int> he = new PriorityQueue<int>(numCookies);
 
        string[] sweetnessValues = Console.ReadLine().Split(' ');
        foreach (var sweetness in sweetnessValues)
        {
            he.Add(Convert.ToInt32(sweetness));
        }
 
        while (he.Peek() < minSweetness && he.Count > 1)
        {
            int ne = he.Poll() + 2 * he.Poll();
            he.Add(ne);
            count++;
        }
 
        if (he.Peek() >= minSweetness)
        {
            Console.WriteLine(count);
        }
        else
        {
            Console.WriteLine(-1);
        }
    }
}
 
// PriorityQueue implementation in C#
class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> heap;
 
    public int Count { get { return heap.Count; } }
 
    public PriorityQueue(int capacity)
    {
        heap = new List<T>(capacity);
    }
 
    public void Add(T item)
    {
        heap.Add(item);
        int currentIndex = Count - 1;
 
        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;
            if (heap[currentIndex].CompareTo(heap[parentIndex]) >= 0)
            {
                break;
            }
 
            Swap(currentIndex, parentIndex);
            currentIndex = parentIndex;
        }
    }
 
    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("PriorityQueue is empty");
        }
 
        return heap[0];
    }
 
    public T Poll()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("PriorityQueue is empty");
        }
 
        T item = heap[0];
        int lastIndex = Count - 1;
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);
 
        int currentIndex = 0;
        while (true)
        {
            int leftChildIndex = 2 * currentIndex + 1;
            int rightChildIndex = 2 * currentIndex + 2;
 
            if (leftChildIndex >= Count)
            {
                break;
            }
 
            int smallerChildIndex = leftChildIndex;
            if (rightChildIndex < Count && heap[rightChildIndex].CompareTo(heap[leftChildIndex]) < 0)
            {
                smallerChildIndex = rightChildIndex;
            }
 
            if (heap[currentIndex].CompareTo(heap[smallerChildIndex]) <= 0)
            {
                break;
            }
 
            Swap(currentIndex, smallerChildIndex);
            currentIndex = smallerChildIndex;
        }
 
        return item;
    }
 
    private void Swap(int index1, int index2)
    {
        T temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }
}
