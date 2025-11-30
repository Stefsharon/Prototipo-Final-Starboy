using UnityEngine;
using UnityEngine.UIElements;

public class Coin_base : MonoBehaviour
{
    public int points = 1;
   
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Player")
       {

            collision.gameObject.GetComponent<Player_stats>().AddScore(points);

           Destroy(gameObject);
       }

       

    }
}
