using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{

	public float lookRadius = 10f;
	Animator animator;
	Transform target;
	NavMeshAgent agent;

	void Start()
	{
		animator = GetComponent<Animator>();
		target = FindingPlayer.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		float distance = Vector3.Distance(target.position, transform.position);

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
			Debug.Log("running true");
		}
		//else running is false 
		else
		{
			animator.SetBool("isRunning", false);
			Debug.Log("running false");
		}
		//if player is within attacking distance then attack
		if (distance <= (agent.stoppingDistance + .3))
		{
			
			LookAtPlayer();
			//put damage to player from zombie here
			animator.SetBool("isAttacking", true);
			Debug.Log("attacking true");
		}
		// else set attacking to false
		else
		{
			animator.SetBool("isAttacking", false);
			Debug.Log("attacking false");
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

}