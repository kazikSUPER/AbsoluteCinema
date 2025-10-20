using System.Runtime.InteropServices;
using AbsoluteCinema.PatternExamples.Shared.Models;

namespace AbsoluteCinema.PatternExamples.Behavioural.Iterator;

public class MovieIterator : IIterator
{
    public Container? current;
    private Container? head;
    private Container tail;
    private Type type;
    
    public T Next<T>()
    {
        if (current.next != null){
            var prev = current;
            current = current.next;
            return (T)prev.content;
        }
        return (T)current.content;
    }

    public bool HasNext()
    {
        if (current != null)
        {
            return current.next != null;
        }
        return false;
    }

    public void AddItem(object item)
    {
        var container = new Container();
        container.content = item;
        type = item.GetType();
        if (head == null)
        {
            head = container;
            tail = head;
            current = head;
        }
        else
        {
            tail.next = container;
            tail = container;
        }
    }

    public void MoveToHead()
    {
        current = head;
    }
}