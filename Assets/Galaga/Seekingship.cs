using UnityEngine;
public class Seekingship : MonoBehaviour
{
    public GameObject Explosion;
    private GameObject player;
    public float speed = 2f;
    public float maxDegrees = 10f;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //modifies transformation of ship based on player position
        transform.up = -(player.transform.position - transform.position);
        transform.rotation = Quaternion.Euler(Mathf.Rad2Deg * transform.rotation.x,
            Mathf.Rad2Deg * transform.rotation.y,
            Mathf.Clamp(Mathf.Rad2Deg * transform.rotation.z, -maxDegrees, maxDegrees));
        transform.Translate(-transform.up * speed * Time.deltaTime);
        //If goes below screen kills them
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBu") || collision.gameObject.CompareTag("GalagaPlayer"))
        {
            if (collision.gameObject.CompareTag("PlayerBu"))
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
