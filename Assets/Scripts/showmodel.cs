using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class showmodel : MonoBehaviour
{
    //private circuitmodel models;
    public static string expname;
    //private GameObject mo;
    public void SceneManage(string SceneName)
    {
        
        SceneManager.LoadScene(SceneName);
       

        // DontDestroyOnLoad(SceneName);
    }
    public void whenclicked()
    {
        expname = EventSystem.current.currentSelectedGameObject.name.Split('(')[0];
        Debug.Log(expname);
    }
    //public void model1fun()
    //{
    //    models.model1.SetActive(true);
    //}
}