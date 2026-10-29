using UnityEngine;

public class Poweredbullet : MonoBehaviour
{
    public float speed = 5;
    void Update()
    {
        //Destroys if off screen and moves
        transform.Translate(transform.up * speed * Time.deltaTime);
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
