using UnityEngine;
using UnityEngine.AI;

public class AgentLevier : MonoBehaviour
{
    public NavMeshAgent agent;
    public string playerTag = "Player";
    public string cageTag = "Cage";
    public GameObject levier;
    public float triggerDistance = 1.5f;

    private Transform player;
    private bool enRouteVersLevier = false;
    private bool levierActivé = false;

    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
            player = playerObj.transform;
        else
            Debug.LogError("Aucun objet avec le tag 'Player' trouvé.");
    }

    void Update()
    {
        // Si une cage est active, on va vers le levier
        if (IsAnyCageActive())
        {
            if (!enRouteVersLevier)
            {
                enRouteVersLevier = true;
                levierActivé = false;
                agent.SetDestination(levier.transform.position);
            }

            float dist = Vector3.Distance(transform.position, levier.transform.position);
            if (dist <= triggerDistance && !levierActivé)
            {
                levierActivé = true; // Évite les boucles
                Debug.Log("Agent a atteint le levier.");
            }
        }
        else
        {
            // Repart chasser si levier activé ou pas besoin de l’activer
            if (player != null)
            {
                agent.SetDestination(player.position);
                enRouteVersLevier = false;
            }
        }
    }

    bool IsAnyCageActive()
    {
        GameObject[] cages = GameObject.FindGameObjectsWithTag(cageTag);
        foreach (var cage in cages)
        {
            if (cage.activeInHierarchy)
                return true;
        }
        return false;
    }
}
