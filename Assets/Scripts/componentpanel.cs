using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class componentpanel : MonoBehaviour
{
    public GameObject panel;
    private float count = 0;
    public GameObject[] info;
    // Start is called before the first frame update
    public void showhide()
    {
        if(count%2 == 0)
        {
            panel.SetActive(true);
            count++;
        }
        else
        {
            panel.SetActive(false);
            count++;
            for(int i=0; i<18; i++)
            {
                info[i].SetActive(false);
            }
        }
       
    }
    
}
