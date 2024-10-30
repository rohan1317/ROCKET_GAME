using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJECT_MOVER : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;
        
        const float tau = Mathf.PI * 2;
        float rawsinewave = Mathf.Sin(cycles * tau);

        movementFactor = (rawsinewave + 1f) / 2f;
        
        Vector3 offset = movementVector * movementFactor;
        transform.position =  startingPosition + offset;
    }
}