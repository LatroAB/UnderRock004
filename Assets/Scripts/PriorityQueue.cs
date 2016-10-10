using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueue<T> : IEnumerator, IEnumerable
{
    public class NodeElement<T1, T2>
    {
        private T1 item;
        private T2 priority;

        public NodeElement(T1 item, T2 priority)
        {
            this.item = item;
            this.priority = priority;
        }

        public T1 Item
        {
            get { return this.item; }
        }

        public T2 Priority
        {
            get { return this.priority; }
        }
    }

    int position = -1;

    private List<NodeElement<T, double>> elements = new List<NodeElement<T, double>>();

    public int Count
    {
        get { return elements.Count; }
    }

    public void Enqueue(T item, double priority)
    {
        NodeElement<T, double> elem = new NodeElement<T, double>(item, priority);

        // add the element to the end
        elements.Add(elem);
    }

    public T Dequeue()
    {
        NodeElement<T, double> bestItem;

        Sort();

        if (Count > 0)
        {
            bestItem = elements[0];
            elements.RemoveAt(0);
            return bestItem.Item;
        }

        return default(T);
    }

    private void Sort()
    {
        // insert sort routines here
        // going to start with a total kludge and scan the list looking for the highest priority node, swapping it for the 0th node
        // need to implement this with a more efficient data structure (binary heap)
        int bestIndex = 0;
        double highestPriority = elements[0].Priority;
        NodeElement<T, double> bestItem;

        for (int i = 1; i < elements.Count; i++)
        {
            if (elements[i].Priority < highestPriority)
            {
                bestIndex = i;
            }
        }

        if (bestIndex != 0)
        {
            bestItem = elements[bestIndex];
            elements.RemoveAt(bestIndex);
            elements.Insert(0, bestItem);
        }

    }

    // interfaces
    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)this;
    }

    public void Reset()
    {
        position = 0;
    }

    public object Current
    {
        get { return elements[position]; }
    }

    public bool MoveNext()
    {
        position++;
        return (position < elements.Count);   
    }
}
