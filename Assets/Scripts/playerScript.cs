using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public GameObject bullet;
    public float bulletVelocity;
    private Rigidbody2D rb;
    public float speed;
    private Vector2 moveDirection;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), mousePos - transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D bulletRB = bulletInstance.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(bulletInstance.transform.up * bulletVelocity, ForceMode2D.Impulse);
        }

        float horMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horMovement, verMovement).normalized;

        if(horMovement != 0 || verMovement != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.velocity = moveDirection * speed;
        }
        else rb.velocity = Vector2.zero;
    }
}
