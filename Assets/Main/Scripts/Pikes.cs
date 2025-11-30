using UnityEngine;

public class Pikes : MonoBehaviour
{
    int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
