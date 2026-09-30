using System.Runtime.CompilerServices;
using UnityEngine;

public class Echo : MonoBehaviour
{
    public float speed = 5;
    // Update is called once per frame
    void Update()
    {
        //Echo moves to right when space is pressed, is destroyed after certain travel distance
        transform.Translate(transform.right * speed * Time.deltaTime);
        if (gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
    //DESTROYS projectiles that comes in contact with "Echo"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
        }
    }
}