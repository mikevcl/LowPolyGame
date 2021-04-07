using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manZombieHealth : MonoBehaviour
{
    /*
    public healthSystem zombieHealth = new healthSystem(100);
    public Slider healthBar;
    */
    //public int healthCurrent;
    //public int healthMax = 100;

    // Start is called before the first frame update
    void Start()
    {
        /*
        //healthCurrent = healthMax;
        //healthBar.value = healthCurrent;
        healthBar.value = zombieHealth.getHealth();
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void takeDamage(int damage)
    {
        //healthCurrent -= damage;
        //healthBar.value = healthCurrent;
        //Debug.Log("Zombie health:" + healthCurrent);
        zombieHealth.Damage(damage);
        //Debug.Log("Zombie health:" + zombieHealth.getHealth());
        healthBar.value = zombieHealth.getHealth();
        if (zombieHealth.getHealth() == 0)
        {          
            Destroy(gameObject,15);
        }
    }
    */

}
