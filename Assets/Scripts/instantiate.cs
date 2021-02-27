using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
// using UnityEngine.EventSystems;

public class instantiate : MonoBehaviour
{
    public static GameObject component = null;
    // public Camera maincamera;
    Vector3 touchPos;

    public Dictionary<Vector3,Vector3> ComponentDictionary = new Dictionary<Vector3,Vector3>();
    public static List<GameObject> ComponentList = new List<GameObject>();
    public static List<Vector3> ComponentPositionList = new List<Vector3>(); 

    // private string Name;

    public float grid = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
           
            touchPos = Camera.main.ScreenToWorldPoint(new Vector3((int)Input.mousePosition.x , (int)Input.mousePosition.y ,10.0f));
            
            
            // int x = (int)Math.Round(Math.Round(touchPos.x - transform.position.x  - grid / 1.0f) / grid);
            // int y = (int)Math.Round(Math.Round(touchPos.y - transform.position.y  - grid / 1.0f) / grid);
            // int z = (int)Math.Round(Math.Round(touchPos.z - transform.position.z  - grid / 1.0f) / grid);
            
            // touchPos.x = (float)(x) * grid  + transform.position.x + grid / 1.0f;
            // touchPos.y = (float)(y) * grid  + transform.position.y + grid / 1.0f;
            // touchPos.z = (float)(z) * grid  + transform.position.z + grid / 1.0f;
        
        
        if (ButtonInfo.ButtonCheck)
        {
            
            
         if (Input.GetMouseButtonDown(0))
         {
            
            if (!ComponentDictionary.ContainsKey(touchPos) && !IsPointerOverUIObject())
            {
                component = Resources.Load<GameObject>("Components/" + ButtonInfo.ComponentName);
                Instantiate(component, touchPos, Quaternion.identity);
                ComponentDictionary.Add(touchPos , component.transform.position);
                ComponentList.Add(component);
                ComponentPositionList.Add(touchPos);
            }
          }        
                  
        }
    }

    public static bool IsPointerOverUIObject()
    {
        Debug.Log("IsPointerOverUIObject");
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    
}
