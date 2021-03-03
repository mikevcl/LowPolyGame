public class healthSystem
{
    private int health;
    private int healthMax = 100;
    
    public healthSystem(int health)
    {
        this.healthMax = healthMax;
        this.health = healthMax;
    }

    public int getHealth()
    {
        return health;
    }

    public void setHealth(int newHealth)
    {
        this.health = newHealth;
    }
	
	public void Damage(int damageAmount)
	{
		health -= damageAmount;
        if (health < 0)
        {
            health = 0;
        }
	}
	
	public void Heal(int healAmount)
	{
		health+= healAmount;
        if (health > healthMax)
        {
            health = healthMax;
        }
	}

}
