using UnityEngine;

public class BulletShip : MonoBehaviour
{
    public float speed = 5;
    public GameObject bullet;
    public GameObject Explosion; 
    public float bulletTimer = 0, bulletWait = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
       //Waits, Then shoots, Then when off screen dies
        bulletTimer += Time.deltaTime;
        if (bulletTimer > bulletWait)
        {
            Instantiate(bullet, transform.position - new Vector3(0, .5f, 0), Quaternion.identity);
            bulletTimer = 0;
        }
        transform.Translate(-transform.up * speed * Time.deltaTime);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    //If hit by player bullet dies
    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if (collision.gameObject.CompareTag("PlayerBu") || collision.gameObject.CompareTag("GalagaPlayer"))
        {
            if(collision.gameObject.CompareTag("PlayerBu"))
                Destroy(collision.gameObject);
            GameObject temp = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
            Destroy(gameObject);
        }
        //If hit by powerup bullet, does not destroy bullet
        if (collision.gameObject.CompareTag("PowBu") || collision.gameObject.CompareTag("GalagaPlayer"))
        {
            if (collision.gameObject.CompareTag("PowBu"))
            {
                GameObject temp = Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(temp, 1.0f);
                Destroy(gameObject);
            }
            
        }

    }
}
