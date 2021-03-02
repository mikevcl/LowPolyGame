using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthSystem
{
    private int health;

    public healthSystem(int health)
    {
        this.health = health;
    }

    public int getHealth()
    {
        return health;
    }
}
