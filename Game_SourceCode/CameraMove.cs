using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float MouseX;
    public float MouseY;
    public float RotationX;
    public float RotationY;
    public  Transform Player;
    
    
    // Start is called before the first frame update
    void Start()
    {   
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MouseX = Input.GetAxisRaw("Mouse X");
        MouseY = Input.GetAxisRaw("Mouse Y");
        RotationX += MouseX;
        RotationY -= MouseY;
        transform.rotation = Quaternion.Euler(RotationY, RotationX,0f);
        Player.rotation = Quaternion.Euler(RotationY,RotationX,0f);
        
    }
}
