using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    Animator anim;

    public Transform playerRotate;
    public Text gameOver;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        rb.velocity = Vector3.right * movement * speed;
        anim.SetFloat("Speed", Mathf.Abs(movement), 0.1f, Time.deltaTime);
        playerRotate.localEulerAngles = new Vector3(0, movement * 90, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Virus"))
        {
            Time.timeScale = 0;
            Destroy(gameObject);
            gameOver.text = "Game Over!\nPress 'R' to Restart";
        }
    }
}
