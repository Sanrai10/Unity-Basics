using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private float rotationSpeed = 10f;
    private float speed = 5f;
    private Rigidbody2D rb2d;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float bulletSpeed = 20f;
    private float cooldown = 0.5f;
    private float nextFire = 0f;

    void Start () {
      rb2d = GetComponent<Rigidbody2D> ();
    }
	
    void Update () {
      UpdateMotion();
      ProcessBulletSpwan();
    }

    private void UpdateMotion() {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
          
        }

        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
          
        }

        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
           
        }

        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
    
        }

        transform.position = pos;

         // Rotate the player towards the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y) * rotationSpeed;
        transform.up = direction;
    }
    
    private void ProcessBulletSpwan() {
      if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && Time.time > nextFire) {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D re = bullet.GetComponent<Rigidbody2D>();
        re.velocity = firePoint.up * bulletSpeed;
        nextFire = Time.time + cooldown;
      }
    }
}
