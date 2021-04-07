using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
	public healthSystem zombieHealth = new healthSystem(100);
	public Slider healthBar;
	//
	public float lookRadius = 10f;
	Animator animator;
	Transform target;
	NavMeshAgent agent;

	void Start()
	{
		healthBar.value = zombieHealth.getHealth();
		//
		
		animator = GetComponent<Animator>();
		target = FindingPlayer.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		float distance = Vector3.Distance(target.position, transform.position);


		if (zombieHealth.getHealth() <= 1)
		{
			animator.SetBool("isDead", true);
			StartCoroutine(wait());
			wait();
			enabled = false;
		}
		//if player is inside look radius and isn't in attacking distance then run
		if(distance > lookRadius)
			animator.SetBool("isRunning", true);
		if (distance <= lookRadius && distance>agent.stoppingDistance)
		{
			animator.SetBool("isRunning", true);
			distance = Vector3.Distance(target.position, transform.position);
			if (distance > lookRadius)
				agent.SetDestination(transform.position);
			else
				agent.SetDestination(target.position);
			//Debug.Log("running true");
		}
		//else running is false 
		else
		{
			animator.SetBool("isRunning", false);
			//Debug.Log("running false");
		}
		//if player is within attacking distance then attack
		if (distance <= (agent.stoppingDistance + .3))
		{
			
			LookAtPlayer();
			
			animator.SetBool("isAttacking", true);
			//put damage to player from zombie here
			//Debug.Log("attacking true");
		}
		// else set attacking to false
		else
		{
			animator.SetBool("isAttacking", false);
			//Debug.Log("attacking false");
		}
		
	}

	void LookAtPlayer()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}

	public void takeDamage(int damage)
	{
		zombieHealth.Damage(damage);
		healthBar.value = zombieHealth.getHealth();
		Debug.Log("Zombie health:" + zombieHealth.getHealth()) ;
		/*if (zombieHealth.getHealth() == 0)
		{
			//wait(15);
			
		}*/
	}
	public IEnumerator wait()
	{

		Debug.Log(Time.time);
		yield return new WaitForSeconds(15);
		Destroy(this.gameObject);

	}
}