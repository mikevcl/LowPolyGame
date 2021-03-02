using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float healthCurrent;
    public float healthMax = 100;

    public Slider healthBar;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        healthCurrent = healthMax;
        healthBar.value = healthCurrent;
        healthBar.value = healthMax;
    }

    // Update is called once per frame
    void Update()
    {	
		// Testing the healthbar function, press space to get 10 dmg
         /*if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            sendDamage(10);
        }
		*/
    }

    public void sendDamage(float damageValue)
    {
        healthCurrent = healthCurrent - damageValue;
        healthBar.value = healthCurrent;
    }
}
