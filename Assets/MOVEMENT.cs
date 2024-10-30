using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEMENT : MonoBehaviour
{
    [SerializeField] AudioClip mainengine;
    [SerializeField] ParticleSystem MAINBOOSTER;
    [SerializeField] ParticleSystem left_booster;
    [SerializeField] ParticleSystem right_booster;

    
    Rigidbody rb;
    float mainthrust = 1000f;
    float rotationthrust = 100f;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    
    
    
    void ProcessThrust()
{
    if(Input.GetKey(KeyCode.Space))
    {
        rb.AddRelativeForce(Vector3.up * mainthrust * Time.deltaTime );
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainengine);
        }
        if(!MAINBOOSTER.isPlaying)
        {
            MAINBOOSTER.Play();
        }
    }
    else
    {
        audioSource.Stop();
        MAINBOOSTER.Stop();
    }
}

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationthrust * Time.deltaTime);
            if(!right_booster.isPlaying)
            {
                right_booster.Play();
            }
    
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationthrust * Time.deltaTime);
             if(!left_booster.isPlaying)
            {
                    left_booster.Play();
            }
        }
        else
        {
            right_booster.Stop();
            left_booster.Stop();

        }
        
    }
}

