using System;
using System.Collections.Generic;
 
class Solution {
    static void Main(String[] args) {
        int Q = Convert.ToInt32(Console.ReadLine());
        MinHeap heap = new MinHeap();
 
        for (int i = 0; i < Q; i++) {
            string[] query = Console.ReadLine().Split(' ');
            int type = Convert.ToInt32(query[0]);
 
            if (type == 1) {
                int element = Convert.ToInt32(query[1]);
                heap.Insert(element);
            } else if (type == 2) {
                int element = Convert.ToInt32(query[1]);
                heap.Delete(element);
            } else if (type == 3) {
                Console.WriteLine(heap.GetMinimum());
            }
        }
    }
}
 
class MinHeap {
    private List<int> heap;
 
    public MinHeap() {
        heap = new List<int>();
    }
 
    public void Insert(int element) {
        heap.Add(element);
        HeapifyUp();
    }
 
    public void Delete(int element) {
        int index = heap.IndexOf(element);
        Swap(index, heap.Count - 1);
        heap.RemoveAt(heap.Count - 1);
        HeapifyDown(index);
    }
 
    public int GetMinimum() {
        return heap.Count > 0 ? heap[0] : -1;
    }
 
    private void HeapifyUp() {
        int index = heap.Count - 1;
        while (index > 0) {
            int parentIndex = (index - 1) / 2;
            if (heap[index] < heap[parentIndex]) {
                Swap(index, parentIndex);
                index = parentIndex;
            } else {
                break;
            }
        }
    }
 
    private void HeapifyDown(int index) {
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;
        int smallest = index;
 
        if (leftChild < heap.Count && heap[leftChild] < heap[smallest]) {
            smallest = leftChild;
        }
 
        if (rightChild < heap.Count && heap[rightChild] < heap[smallest]) {
            smallest = rightChild;
        }
 
        if (smallest != index) {
            Swap(index, smallest);
            HeapifyDown(smallest);
        }
    }
 
    private void Swap(int i, int j) {
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}
 
