using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        Debug.Log("haz muerto");
        collision.transform.GetComponent<PlayerRespawn>().PlayerDamage();
    }
}
