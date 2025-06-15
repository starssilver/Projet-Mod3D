using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Transform target;
    public float sightRange = 10f;
    public float attackRange = 2f;

    public Animator animator;

    NavMeshAgent agent;
    bool isBuffed = false;
    bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= sightRange)
        {
            if (!isBuffed)
            {
                Buff();
            }
            else if (distanceToTarget > attackRange)
            {
                Chase();
            }
            else if (!isAttacking)
            {
                Attack();
            }
        }
        else
        {
            PatrolOrSleep();
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    void Buff()
    {
        isBuffed = true;
        agent.isStopped = true;
        animator.SetTrigger("Buff");
        Invoke(nameof(Chase), 1.5f); // Temps pour Buff avant de courir
    }

    void Chase()
    {
        agent.isStopped = false;
        agent.speed = 6f; // vitesse course
        agent.SetDestination(target.position);
    }

    void Attack()
    {
        isAttacking = true;
        agent.isStopped = true;
        int attackIndex = Random.Range(1, 4); // 1, 2, 3 inclus
        animator.SetInteger("AttackIndex", attackIndex);
        animator.SetBool("IsAttacking", true);

        // Débloquer après un temps ou via event animation
        Invoke(nameof(ResetAttack), 1.2f); // durée attaque
    }

    void ResetAttack()
    {
        animator.SetBool("IsAttacking", false);
        isAttacking = false;
    }

    void PatrolOrSleep()
    {
        isBuffed = false;
        agent.speed = 2f; // vitesse marche
        agent.isStopped = false;

        // Exemple : aller vers un point aléatoire proche
        Vector3 randomDirection = Random.insideUnitSphere * 5f;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 5f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }

        // Optionnel : faire dormir aléatoirement
        if (Random.value < 0.01f)
        {
            agent.isStopped = true;
            animator.SetTrigger("Sleep");
        }
    }
}
