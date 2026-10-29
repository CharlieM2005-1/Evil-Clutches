using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalagaMovement : MonoBehaviour
{
    public float speed = 4;
    public GameObject PlayerBullet;
    public Image[] lives;
    public int lifecount = 3;
    public int charge = 0;
    public GameObject Poweredbullet;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(PlayerBullet, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
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
        //Stops from going off screen
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -8.5f, 8.5f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f));
        //How to shoot powered bullet, Once shot reduces charge by 1
        if (charge >= 1 && Input.GetKeyUp(KeyCode.Z))
        {
            Instantiate(Poweredbullet, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
            charge = charge - 1;
        }
    }


    //If thing hit by player bullet, it dies

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When pick up power up +1 charge
        if (collision.gameObject.CompareTag("Powerup"))
        {
            charge = charge + 1;
        }
        if (collision.gameObject.CompareTag("GalagaShip"))
        {
            lifecount -= 1;
            if (lifecount <= 0)
            {
                lifecount = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            lives[lifecount].enabled = false;
        }
    }
}
