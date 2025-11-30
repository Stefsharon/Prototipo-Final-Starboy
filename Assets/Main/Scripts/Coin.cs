using UnityEngine;

public class Coin : MonoBehaviour
{
    int points = 1;

    public AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Desactivo la parte visual y de colisión
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            // Reproduzco sonido
            audioSource.Play();

            collision.gameObject.GetComponent<PlayerStats>().AddScore(points);

            // Destruyo el objeto después de la duración del clip
            Destroy(gameObject, audioSource.clip.length);
           
        }
    }

    public void DeactivateCoin()
    {

    }
}
