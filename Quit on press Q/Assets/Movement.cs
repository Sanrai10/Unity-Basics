using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode jumpKey;
    public float speed = 5f;
    public float rotateSpeed = 10f;

    void Update()
    {
        Vector3 pos = transform.position;

        // Move up
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }

        // Move down
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }

        // Move forward and rotates in horizantally
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * rotateSpeed);
        }

        // Move backward and rotate horizantally
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * rotateSpeed);
        }

        transform.position = pos;
    }
}

