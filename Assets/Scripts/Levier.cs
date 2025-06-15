using UnityEngine;

public class Levier : MonoBehaviour
{
    public string cageTag = "Cage";
    public string agentTag = "Agent";  // Le tag du GameObject de l'agent

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(agentTag))
        {
            Debug.Log("Levier activ� par l'agent.");
            GameObject[] cages = GameObject.FindGameObjectsWithTag(cageTag);
            foreach (var cage in cages)
            {
                cage.SetActive(false); // D�sactive toutes les cages actives
            }
        }
    }
}
