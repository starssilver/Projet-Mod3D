using UnityEngine;

public class Push : MonoBehaviour
{
    public string playerTag = "Player";
    public float pushDistance = 1.5f;
    public float pushForce = 10f;

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= pushDistance)
        {
            Rigidbody playerRb = player.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                Vector3 pushDirection = (player.transform.position - transform.position).normalized;
                pushDirection.y = 0f; // Pas de poussée verticale

                playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }
}
