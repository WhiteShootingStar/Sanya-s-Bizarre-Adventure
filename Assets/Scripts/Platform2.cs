using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform2 : MonoBehaviour
{
    public bool rotatingLeft;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotatingLeft) transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        else transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
