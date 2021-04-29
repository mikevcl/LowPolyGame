using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
	public healthSystem zombieHealth = new healthSystem(100);
	//public playerHealth playerH = new playerHealth(100);
	public Slider healthBar;
	//
	public float lookRadius = 10f;
	Animator animator;
	Transform target;
	NavMeshAgent agent;
	//[Header("Audio Clips")]
	//[Tooltip("The audio clip that is played while zombie is idle."), SerializeField]
	//private AudioSource z_idling;

	//[Tooltip("The audio clip that is played while zombie is running."), SerializeField]
	//private AudioSource z_running;

	//[Tooltip("The audio clip that is played while zombie is dying."), SerializeField]
	//private AudioSource z_dying;

	//[Tooltip("The audio clip that is played while zombie is attacking."), SerializeField]
	//private AudioSource zombieNoises;

	void Start()
	{
		healthBar.value = zombieHealth.getHealth();
		//
		
		animator = GetComponent<Animator>();
		target = FindingPlayer.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();

		
		//zombieNoises = GetComponent<AudioSource>();
		/*
		z_idling = GetComponent<AudioSource>();
		z_dying = GetComponent<AudioSource>();
		z_running = GetComponent<AudioSource>();
		*/
	}

	void Update()
	{
		if (target == null || target.position == null || transform.position == null)
			return;
		float distance = Vector3.Distance(target.position, transform.position);


		if (zombieHealth.getHealth() <= 1)
		{
			//z_dying.Play();
			animator.SetBool("isDead", true);
			FindObjectOfType<AudioManager>().Play("z_dying");
			StartCoroutine(wait());
			wait();
			enabled = false;
		}
		//if player is inside look radius and isn't in attacking distance then run
		if(distance < lookRadius)
			animator.SetBool("isRunning", true);
		if (distance <= lookRadius && distance > agent.stoppingDistance)
		{
			animator.SetBool("isRunning", true);
			distance = Vector3.Distance(target.position, transform.position);
			//z_running.Play();
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
		if (distance <= (agent.stoppingDistance+.3))
		{
			//zombieNoises.Play();
			LookAtPlayer();
			//z_attacking.Play();
			
			animator.SetBool("isAttacking", true);
			//StartCoroutine(waitAttAud());
			//waitAttAud();
			
			//put damage to player from zombie here
			//Debug.Log("attacking true");
			//DamagePlayer(10);
		}
		// else set attacking to false
		else
		{
			animator.SetBool("isAttacking", false);
			//Debug.Log("attacking false");
		}
		
	}
	/*
	void DamagePlayer(int damage)
	{
		playerH.playerHP.Damage(damage);
		playerH.healthBar.value = playerH.playerHP.getHealth();
		Debug.Log("Health:" + playerH.playerHP.getHealth());
	}
	*/
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
		Debug.Log("Zombie health:" + zombieHealth.getHealth());
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
	/*
	public IEnumerator waitAttAud()
	{

		Debug.Log(Time.time);
		FindObjectOfType<AudioManager>().Play("z_attacking");
		yield return new WaitForSeconds(3);
		
	}
	*/

}