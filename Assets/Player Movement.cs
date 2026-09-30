using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;
    private int scoreVal = 0;
    public TextMeshProUGUI scoreBox;
    public GameObject Echo;
    private float EchoWait = 3;
    private float EchoTimer = 0;
    // Update is called once per frame
    void Update()
    {
        EchoTimer += Time.deltaTime;
        //Spawns Echo @player position and has timer so player can't spam it
        if (Input.GetKey(KeyCode.Space) && EchoTimer > EchoWait)
        {
            Instantiate(Echo, transform.position, Quaternion.identity);
            EchoTimer = 0;
            EchoWait = 3;
        }
        //traveling up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        //traveling down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
        //traveling right and left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        //Score can't be negative
        if (scoreVal <= 0)
        {
            scoreVal = 0;
            scoreBox.text = "Score = 0";
        }
        //Constraining cube to certain X & Y values, prof used Z but mine does not take multiple arguments?
        transform.position = new Vector2 (Mathf.Clamp(transform.position.x, -8.5f, 8.5f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f));
    }
    //Deletes projectile that collides with player, updates score accordingly
        private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.gameObject.tag == "Projectile")
            {
            if(collision.GetComponent<ProjectileMove>() != null)
            {
                scoreVal += collision.GetComponent<ProjectileMove>().points;
                scoreBox.text = "Score = " + scoreVal;
            }
            Destroy(collision.gameObject);
            }
        }
}
