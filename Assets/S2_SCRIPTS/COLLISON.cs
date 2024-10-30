using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class COLLISONHANDLER2 : MonoBehaviour
{
    void OnCollisionEnter( Collision other)
    {
        switch (other.gameObject.tag)
        {
           case "Friendly":
                Debug.Log("u have started");
                break;
           case "Finish":
                NEWLEVEL2();
                break;
            case "Fuel":
                Debug.Log("u have fuel");
                break;
            default:
                crashsequunce1();
                break;    
                         
        }
    }
    void crashsequunce1()
    {
        GetComponent<MOVEMENT>().enabled = false;
        Invoke("Reloadlevel2",1f);
    }    

     void NEWLEVEL2()
    {
        SceneManager.LoadScene(0);
    }

    void Reloadlevel2()
    {
        SceneManager.LoadScene(0);
    }

}
