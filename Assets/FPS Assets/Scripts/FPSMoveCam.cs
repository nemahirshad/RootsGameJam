using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMoveCam : MonoBehaviour
{
    public Transform camPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = camPosition.position;
    }
}
