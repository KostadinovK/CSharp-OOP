using System;
using Skeleton.Contracts;

public class Dummy : ITarget
{
    private int health;
    private int experience;
    public bool IsDead => this.health <= 0;

    public Dummy(int health, int experience)
    {
        this.health = health;
        this.experience = experience;
    }

    public int Health 
    {
        get { return this.health; }
    }

    public int Experience
    {
        get { return this.experience; }
    }

    public void TakeAttack(int attackPoints)
    {
        if (this.IsDead)
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        this.health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!this.IsDead)
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return this.experience;
    }

}
