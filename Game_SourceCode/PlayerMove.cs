using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    private float moveX;
    private float moveY;
    public float MoveSpeed = 20;
    public float JumpSpeed = 200;
    public bool isGround;
    public LayerMask GroundMask;

    public GameObject Enemy;
    public float timer1;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        isGround = Physics.Raycast(transform.position, Vector3.down, 1.2f, GroundMask);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                Jump();
            }
            
        }


        timer1 += Time.deltaTime;
        if (timer1 > 7f)
        {
            Instantiate(Enemy, new Vector3(Random.Range(2f, 8f), 0f, Random.Range(-3f, 3)), Enemy.transform.rotation);
            timer1 = 0;
        }
    }

    private void FixedUpdate()
    {   
        Vector3 direction = transform.right * moveX + transform.forward * moveY;
        rb.AddForce(direction * MoveSpeed);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * JumpSpeed);
    }
}
