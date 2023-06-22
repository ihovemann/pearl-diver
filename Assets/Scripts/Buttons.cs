using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //for buttons to change scene
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        
    }
}
