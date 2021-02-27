using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expshow : MonoBehaviour
{
    public GameObject[] exp;
    private int num = 6;
    // Start is called before the first frame update
    public void showlist()
    {
        exp[0].SetActive(true);
        for(int i = 1; i < num; i++)
        {
            exp[i].SetActive(false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
