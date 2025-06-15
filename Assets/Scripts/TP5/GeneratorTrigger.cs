using Unity.AI.Navigation;
using UnityEngine;

public class GeneratorTrigger : MonoBehaviour
{
    public GameObject obstacle;
    public NavMeshSurface surface;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (obstacle.activeSelf == false)
            {
                obstacle.SetActive(true);
            }
            else
            {
                obstacle.SetActive(false);
            }
            surface.BuildNavMesh();
        }
    }

}
