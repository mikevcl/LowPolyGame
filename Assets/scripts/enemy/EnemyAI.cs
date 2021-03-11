using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WIGround, WIPlayer;
    
    //wandering
    public Vector3 wanderPoint;
    bool wanderPointSet;
    public float wanderPointRange;

    //zombie states
    public float visionRange, attackRange;
    public bool playerInVisionRange, playerInZombieRange;

    //zombie attacking
    public float attackCooldown;
    bool hasAttacked;
    //public GameObject projectile;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent <NavMeshAgent>();

    }

    private void Wandering()
    {
        //if we don't have a place to wander
        if (!wanderPointSet)
            FindAWanderPoint();

        if (wanderPointSet)
            agent.SetDestination(wanderPoint);

        Vector3 distanceToWanderPoint = transform.position - wanderPoint;

        if (distanceToWanderPoint.magnitude < 1f)
            wanderPointSet = false;
    }

    private void FindAWanderPoint()
    {
        //find a random x coord and a random z coord to walk to
        float randomZCoordinate = Random.Range(-wanderPointRange, wanderPointRange);
        float randomXCoordinate = Random.Range(-wanderPointRange, wanderPointRange);

        wanderPoint = new Vector3(transform.position.x + randomXCoordinate, transform.position.y, transform.position.z + randomZCoordinate);

        if (Physics.Raycast(wanderPoint, -transform.up, 2f, WIGround))
            wanderPointSet = true;
    }

    private void Chase()
    {
        //set new destination to where the player is located
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        //stand still while attacking to position
        agent.SetDestination(transform.position);
        //update to make sure enemy is facing player when attacking
        transform.LookAt(player);

        if (!hasAttacked)
        {
            //attack start
            /*Projectile code for later with zombies that can spit
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            */
            //attack end
            hasAttacked = true;
            Invoke(nameof(ResetAttack), attackCooldown);
        }

    }

    private void ResetAttack()
    {
        hasAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if player is in range
        playerInVisionRange = Physics.CheckSphere(transform.position, visionRange, WIPlayer);
        playerInZombieRange = Physics.CheckSphere(transform.position, attackRange, WIPlayer);
        if (!playerInVisionRange && !playerInZombieRange)
            Wandering();
        if (playerInVisionRange && !playerInZombieRange)
            Chase();
        if (playerInVisionRange && playerInZombieRange)
            Attack();

    }
}
