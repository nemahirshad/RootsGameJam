using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingGameAnimationEvents : MonoBehaviour
{
    public List<Collider> hitboxes;

    public void ActivateHitbox(int index)
    {
        hitboxes[index].enabled = true;
    }

    public void DeactivateHitbox(int index)
    {
        hitboxes[index].enabled = false;
    }
}
