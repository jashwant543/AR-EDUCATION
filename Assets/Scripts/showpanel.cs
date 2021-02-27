using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showpanel : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject[] Butoon;
    public GameObject[] info;
    private float nc = 18;
    public void DisplayInfo()
    {
        int i = 0;
        info[0].SetActive(true);
        for (i = 1; i < nc; i++)
        {
            info[i].SetActive(false);

        }
    }
}