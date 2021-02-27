using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnexp : MonoBehaviour
{
    
    public GameObject[] exp;
    // private bool isthere = false;
    public GameObject maincamera,tabelcamera;
    // Start is called before the first frame update
    void Start()
    {
        // exp = Resources.Load<GameObject>("expmodel/" + showmodel.expname);
       
    }

    // Update is called once per frame
    void Update()
    {
        
        // if (!isthere)
        // {
        //     spawnmodel();
        // }
    }

    public void spawnmodel()
    {
        // Vector3 pos = new Vector3(0, 0, 0);
        
        // Instantiate(exp, pos, Quaternion.identity);

        for (int i = 0; i < exp.Length; i++)
        {
           if(showmodel.expname == exp[i].transform.name) 
           {
               exp[i].SetActive(true);
           }  
        }
        
        // GameObject exp = GameObject.transform.Find(" " + showmodel.expname).gameObject;
        // Debug.Log(exp.transform.name);
        // GameObject exp = ExperimentModels.ContainsKey(showmodel.expname);
        
        // isthere = true;
    }

    public void Cameracheck()
    {
        maincamera.SetActive(false);
        tabelcamera.SetActive(true);
    }
}
