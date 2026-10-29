using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float speed = 5;
    
    void Update()
    {
        //destroyed if off screen and moves
        transform.Translate(-transform.up * speed * Time.deltaTime);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    //Deleted when touched by player
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GalagaPlayer"))
        {
            Destroy(gameObject);
        }
    }
}

