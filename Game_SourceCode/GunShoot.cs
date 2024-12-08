using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletPoint;

    private float timer = 0f;
    private float cd = 0.2f;
    public int BulletCount = 10;
    public Text BulletText;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
       

        timer += Time.deltaTime;
        if(timer > cd && Input.GetMouseButton(0) && BulletCount > 0)
        {
            timer = 0f;

            Instantiate(Bullet, BulletPoint.position, BulletPoint.rotation);
            

            BulletCount --;
            Debug.Log(BulletCount);

            BulletText.text = BulletCount.ToString();

            if (BulletCount == 0)
            {
                Invoke("reload", 1.5f);
            }
        }

        


        if (Input.GetKeyDown(KeyCode.R) && BulletCount != 10)
        {
            BulletCount = 0;
            Invoke("reload", 1.5f);
        }
    }
    private void reload()
    {   

        BulletCount = 10;
        BulletText.text = BulletCount.ToString();
        
    }    
}
