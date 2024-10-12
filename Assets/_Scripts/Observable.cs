using System;
using System.Collections.Generic;

public class Observable<T>
{
    private readonly List<Action<T>> observers = new List<Action<T>>();
    private T value;
    public T Value
    {
        get => value;
        set
        {
            this.value = value;
            observers.ForEach(observer => observer(value));
        }
    }
    
    public void AddObserver(Action<T> observer) => observers.Add(observer);
    public void RemoveObserver(Action<T> observer) => observers.Remove(observer);
}