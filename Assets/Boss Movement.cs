using TMPro;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 5;
    private bool goingUp = true;
    //Rate&Fireball timers
    private float RatWait = 1, FireballWait = 2;
    private float RatTimer = 0, FireballTimer = 0;

    public GameObject Rat;
    public GameObject Fireball;

    // Update is called once per frame
    void Update()
    {
        //Spawning prefabes for boss
        RatTimer += Time.deltaTime;
        FireballTimer += Time.deltaTime;

        if (RatTimer > RatWait)
        {
            Instantiate(Rat, transform.position, Quaternion.identity);
            RatTimer = 0;
            RatWait = Random.Range(1f, 2f);
        }
        if (FireballTimer > FireballWait)
        {
            Instantiate(Fireball, transform.position, Quaternion.identity);
            FireballTimer = 0;
            FireballWait = Random.Range(2f, 3f);
        }

        transform.Translate(transform.up * speed * Time.deltaTime);
        if (transform.position.y > 4.5 && goingUp == true)
        // If trying to go above screen, goes down or vice versa.
        {
            goingUp = false;
            speed *= -1;
        }
        if (transform.position.y < -4.5 && goingUp == false)
        {
            goingUp = true;
            speed *= -1;
        }
    }
}