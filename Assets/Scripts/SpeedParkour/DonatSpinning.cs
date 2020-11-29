using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonatSpinning : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    // Start is called before the first frame update
    
    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.AngleAxis(rotationSpeed, Vector3.forward);
        transform.rotation *= rotation;
    }
}
