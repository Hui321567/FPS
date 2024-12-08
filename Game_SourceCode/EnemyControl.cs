using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyControl : MonoBehaviour
{
    public int HP = 3;
    
    public float MoveY;
    public float timer;
    
    public float speed = 2;
    Rigidbody rb;
    public event Action<int, int> UpdateHealthBarOnAttack;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        timer += Time.deltaTime;
        

        
        

        if (timer > 3f) 
        {
            
            MoveY = UnityEngine.Random.Range(0f, 360f);

            transform.Rotate(new Vector3(0f, MoveY,0f));

            
            timer = 0f;
        }
        transform.position += transform.forward * speed * Time.deltaTime;





        if (HP == 0)
        {
            Destroy(gameObject,0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            EmenyByAttack();
        }
        
    }
    public void EmenyByAttack()
    {
        HP--;
        UpdateHealthBarOnAttack?.Invoke(HP, 3);
    }
}
