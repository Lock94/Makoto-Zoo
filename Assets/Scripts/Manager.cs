using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    #region 单例模式
    private static Manager _instance;
    public static Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Manager").GetComponent<Manager>();
            }
            return _instance;
        }
    }
    #endregion

    private void Awake()
    {
    
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButtonDown(1) && hit.collider != null && hit.collider.tag == "Building")
        {
            //Debug.Log(hit.collider.name);
            hit.collider.GetComponent<Building>().ShowBuildingPanel();
        }
    }
}
