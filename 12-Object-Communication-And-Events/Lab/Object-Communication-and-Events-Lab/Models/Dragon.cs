using System;
using System.Collections.Generic;

public class Dragon : ITarget, ISubject
{
    private const string THIS_DIED_EVENT = "{0} dies";

    private string id;
    private int hp;
    private int reward;
    private bool eventTriggered;
    private IHandler handler;
    private List<IObserver> observers;

    public Dragon(string id, int hp, int reward, IHandler handler)
    {
        this.id = id;
        this.hp = hp;
        this.reward = reward;
        this.handler = handler;
        observers = new List<IObserver>();
    }

    public bool IsDead { get => this.hp <= 0; }

    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if(this.IsDead && !eventTriggered)
        {
            handler.Handle(LogType.EVENT, String.Format(THIS_DIED_EVENT, this));
            this.eventTriggered = true;
            NotifyObservers();
        }
    }

    public void Register(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnRegister(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(reward);
        }
    }

    public override string ToString()
    {
        return this.id;
    }
}
