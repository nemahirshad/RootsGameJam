using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerFightingController pfc;

    private void OnTriggerEnter(Collider other)
    {
        print("Help");
        if (other.CompareTag("Ground"))
        {
            pfc.ground = true;
            print("lol");
        }
    }
}
