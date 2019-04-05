using System;
public abstract class AbstractHero : IAttacker, IObserver
{
    private const string TARGET_NULL_MESSAGE = "Target is null.";
    private const string NO_TARGET_MESSAGE = "{0} has no target.";
    private const string TARGET_DEAD_MESSAGE = "{0} is dead.";
    private const string SET_TARGET_MESSAGE = "{0} targets {1}.";

    private string id;
    private int damage;
    private ITarget target;
    protected IHandler handler;

    public AbstractHero(string id, int damage, IHandler handler)
    {
        this.id = id;
        this.damage = damage;
        this.handler = handler;
    }

    public void Attack()
    {
        if(this.target == null)
        {
            handler.Handle(LogType.ERROR, String.Format(NO_TARGET_MESSAGE, this));
        }
        else if(this.target.IsDead)
        {
            handler.Handle(LogType.EVENT, String.Format(TARGET_DEAD_MESSAGE, this.target));
        }
        else
        {
            this.ExecuteClassSpecificAttack(this.target, this.damage);
        }
    }

    public void SetTarget(ITarget target)
    {
        if(target == null)
        {
            handler.Handle(LogType.TARGET, TARGET_NULL_MESSAGE);
        }
        else
        {
            this.target = target;
            handler.Handle(LogType.TARGET, String.Format(SET_TARGET_MESSAGE, this, target));
        }
    }

    protected abstract void ExecuteClassSpecificAttack(ITarget target, int damage);

    
    public void Update(int reward)
    {
        handler.Handle(LogType.EVENT, $"Reward: {reward}!");
    }

    public override string ToString()
    {
        return this.id;
    }

}
