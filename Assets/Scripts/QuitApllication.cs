using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApllication : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
            Debug.Log("i quit the game");
        }        
    }
}
