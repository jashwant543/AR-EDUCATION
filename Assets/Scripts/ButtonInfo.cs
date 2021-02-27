using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonInfo : MonoBehaviour
{
    // Start is called before the first frame update

    public static string ComponentName;
    public static bool ButtonCheck = false , WireBool = false , NodeBool = false, RotationBool = false;

    private GameObject ButtonInfoObject;

    private GameObject WireRenderer;

    private Animator ComponentCanvasAnim; 


    void Start()
    {
        ButtonInfoObject = GameObject.Find("ButtonInfo");
        ComponentCanvasAnim = GameObject.Find("ComponentCanvas").GetComponent<Animator>();
        WireRenderer = GameObject.Find("WireRenderer");
    }

    public void ButtonInfomation()
    {
        ComponentName = EventSystem.current.currentSelectedGameObject.name.Split('(')[0];
        Debug.Log(ComponentName);
        ButtonCheck = true;
    }

    public void MovmentOfComponent()
    {
        WireBool = false;
        RotationBool = false;
        NodeBool = false;
        ButtonCheck = false;
        if(!ButtonInfoObject.GetComponent<MovementScript>().enabled)
            ButtonInfoObject.GetComponent<MovementScript>().enabled = true;
        else
            ButtonInfoObject.GetComponent<MovementScript>().enabled = false;  
        
        Debug.Log("Yes");
    }

    public void ComponentButtonMethod()
    {

      
        bool currentstate = ComponentCanvasAnim.GetBool("ComponentBaarAnimBool");
         ComponentCanvasAnim.GetComponent<Animator>().SetBool("ComponentBaarAnimBool", !currentstate);
    }
    
    public void WireButton()
    {
        ButtonCheck = false;
        NodeBool = false;
        // Instantiate(WireRenderer , new Vector3(0,0,0), Quaternion.identity);
        if (!WireBool)
        {
            WireBool = true;
            WireRenderer.GetComponent<WireController_LR>().enabled = true;
        }
        else
        {
            WireBool = false;
        }
        
    }

    public void EditNode()
    {
        ButtonCheck = false; 
        WireBool = false;
       if (!NodeBool)
        {
            NodeBool = true;
        }
        else
        {
            NodeBool = false;
        }
    }

    public void RoationofComponent()
    {
        
        WireBool = false;
        NodeBool = false;
        ButtonCheck = false;
        if(!ButtonInfoObject.GetComponent<RotationScript>().enabled)
            ButtonInfoObject.GetComponent<RotationScript>().enabled = true;
        else
            ButtonInfoObject.GetComponent<RotationScript>().enabled = false;
    }

    public void DeleteComponent(GameObject Component)
    {
        Destroy(Component);
        // instantiate.ComponentPositionList.Remove(Component.transform.position);
    }

    // Update is called once per frame
}
