using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed = 5;
    public int points = 100;

    // Update is called once per frame
    void Update()
    {
        //Projectiles moves to left, is destroyed after certain travel distance
        transform.Translate(-transform.right * speed * Time.deltaTime);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

    }
}