using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTransform : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(target.position - transform.position);
    }
}
