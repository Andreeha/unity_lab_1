using UnityEngine;

public class DeathZoneHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.gameObject.GetComponent<PlayerMovement>();
        player.Die();
    }
}
