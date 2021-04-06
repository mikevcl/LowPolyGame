using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public Slider healthBar;
    healthSystem playerHP = new healthSystem(100);

    // Start is called before the first frame update
    void Start()
    {
        // This will set the health bar value to the players health
        healthBar.value = playerHP.getHealth();
    }

    // Update is called once per frame
    void Update()
    {	
		// Testing the healthbar function, press space to get 10 dmg
        /*
         if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            playerHP.Damage(10);
            healthBar.value = playerHP.getHealth();
            Debug.Log("Health:" + playerHP.getHealth());
        }
        */
    }
}
