using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;
    public GameObject Explosion;
   
    void Update()
    {
        //Destroys if off screen
        transform.Translate(-transform.up * speed * Time.deltaTime);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBu") || collision.gameObject.CompareTag("GalagaPlayer"))
        {
            Destroy(gameObject);
        }

    }
}
