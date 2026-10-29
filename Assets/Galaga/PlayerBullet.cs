using UnityEngine;


public class PlayerBullet : MonoBehaviour
{
    public float speed = 5;
    // Update is called once per frame
    void Update()
    {
        //Destroys if off screen
        transform.Translate(transform.up * speed * Time.deltaTime);
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }

    }

}
