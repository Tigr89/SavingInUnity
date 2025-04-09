using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        Destroy(gameObject, 5);
    }

}
