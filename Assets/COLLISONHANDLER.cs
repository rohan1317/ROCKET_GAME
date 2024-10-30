using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class COLLISONHANDLER : MonoBehaviour
{
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip win;
    [SerializeField] ParticleSystem successparticles;
    [SerializeField] ParticleSystem crashpraticles;

    AudioSource audioSource;

    bool istransitioning = false;
    
    void  Update()
    {
        
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter( Collision other)
    {
        if (istransitioning)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
           case "Friendly":
                Debug.Log("u have started");
                break;
           case "Finish":
                startingdelay();
                break;
            default:
                CrashSeq();
                break;    
                         
        }
        
    }

    void startingdelay()
    {
        istransitioning = true;
        audioSource.Stop();
        GetComponent<MOVEMENT>().enabled = false;
        audioSource.PlayOneShot(win);
        successparticles.Play();
        Invoke("NEWLEVEL",3f);
    }
    
    void CrashSeq()
    {
        istransitioning = true;
        audioSource.Stop();
        GetComponent<MOVEMENT>().enabled = false;
        audioSource.PlayOneShot(crash);
        crashpraticles.Play();
        Invoke("Reloadlevel",3f);

    }


 

    void NEWLEVEL()
{
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;

    if (currentSceneIndex == 1) // Check if it's level 2
    {
        nextSceneIndex = 2; // Load the third scene
    }
    else if (currentSceneIndex == 3) // Check if it's scene 4
    {
        nextSceneIndex = 4; // Load scene 5
    }
    else if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
    {
        nextSceneIndex = 0; // Loop back to the first scene if it's the last one
    }
    
    SceneManager.LoadScene(nextSceneIndex); // Load the next scene instead of the current one
}

    void Reloadlevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(currentSceneIndex);
    
    }

}
