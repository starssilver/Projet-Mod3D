using UnityEngine;

public class AgentController : MonoBehaviour
{
    public float speed = 3.5f;
    public float Stopping_Distance = 0.5f;
    public float raduis = 0.5f;
    public Transform cible;
    void Update()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(cible.position);
    }
}
