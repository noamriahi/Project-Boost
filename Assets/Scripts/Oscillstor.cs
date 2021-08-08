using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillstor : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period =2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Epsilon <= period){return;}
        float cycle =Time.time /period;
        const float tau = Mathf.PI * 2;
        float rawSinWave =Mathf.Sin(cycle * tau);
        movementFactor = (rawSinWave + 1f) / 2;
        Vector3 offset = movementVector * movementFactor;
        transform.position= startingPosition + offset;
    }
}
