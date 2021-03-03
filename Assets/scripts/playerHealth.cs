using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    //public float healthCurrent;
    //public float healthMax = 100;
    public Slider healthBar;
    healthSystem playerHP = new healthSystem(100);


    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = playerHP.getHealth();
        //healthBar.value = healthCurrent;

        //Debug.Log("Health:" + playerHP.getHealth());
        //playerHP.Damage(30);
        //Debug.Log("Health:" + playerHP.getHealth());
        //playerHP.Heal(10);
        //Debug.Log("Health:" + playerHP.getHealth());

        //playerHP.Damage(10);
        //Debug.Log("Health:" + playerHP.getHealth());

    }

    // Update is called once per frame
    void Update()
    {	
		// Testing the healthbar function, press space to get 10 dmg
         if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            playerHP.Damage(10);
            healthBar.value = playerHP.getHealth();
            Debug.Log("Health:" + playerHP.getHealth());
        }

    }

    //public void takeDamage(float damageValue)
    //{
    //    healthCurrent = healthCurrent - damageValue;
    //    healthBar.value = healthCurrent;
    //}
}
