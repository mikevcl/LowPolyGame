public class healthSystem
{
    private int health;
    private int healthMax;
    
    public healthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        this.health = healthMax;
    }

    // returns objects health
    public int getHealth()
    {
        return health;
    }

    // setHealth function allows you to set a health without the constraints of the max health and lowest health (0)
    public void setHealth(int newHealth)
    {
        this.health = newHealth;
    }
	
    // Damage() will damage the object with an integer amount passed to the function 
	public void Damage(int damageAmount)
	{
		health -= damageAmount;
        if (health < 0)
        {
            health = 0;
        }
	}
	
    // Heal() will heal the object
	public void Heal(int healAmount)
	{
		health+= healAmount;
        if (health > healthMax)
        {
            health = healthMax;
        }
	}

}
