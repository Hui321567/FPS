using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject HealthUIPrefab;

    public Canvas canvas;

    public Transform HealthBarPoint;

    Image HealthSlider;

    Transform UIBar;

    Transform Cam;

    

    

    EnemyControl EnemyByAttack;

    public bool AlwaysVisible;

    public float VisibleTime;

    private float VisibleLeft;
               

    // Start is called before the first frame update

    void Awake()
    {
        EnemyByAttack = GetComponent<EnemyControl>();
        EnemyByAttack.UpdateHealthBarOnAttack += UpdateHealthBar;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {

        Cam = Camera.main.transform;
        

        if (canvas.renderMode == RenderMode.WorldSpace)
        {
            UIBar = Instantiate(HealthUIPrefab, canvas.transform).transform;
            HealthSlider = UIBar.GetChild(0).GetComponent<Image>();
            UIBar.gameObject.SetActive(AlwaysVisible);
        }
    }

    void UpdateHealthBar(int HP , int MaxHP)
    {
        if(HP == 0)
        {
            Destroy(UIBar.gameObject);
        }
        UIBar.gameObject.SetActive(true);
        float SilderPercent = (float)HP/ MaxHP;
        HealthSlider.fillAmount = SilderPercent;
        VisibleLeft = VisibleTime;
    }

    void LateUpdate()
    {
        if (UIBar != null)
        {
            UIBar.position = HealthBarPoint.position;
            UIBar.forward = -Cam.forward;

            if(VisibleLeft <= 0f && AlwaysVisible == false)
            {
                UIBar.gameObject.SetActive(false);
            }
            VisibleLeft -= Time.deltaTime;
            
        }
    }
}
