using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    [SerializeField] GameObject heartPrefab;
    [SerializeField] GameObject brokenHeartPrefab;

    [SerializeField] float scale = 1;

    public void DrawHearts(int hearts, int maxHearts)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < maxHearts; i++)
        {
            if (i + 1 <= hearts)
            {
                GameObject heart = Instantiate(heartPrefab, transform.position, Quaternion.identity, transform);
                heart.transform.localScale = new Vector3(scale, scale, scale);
            }
            else
            {
                GameObject heart = Instantiate(brokenHeartPrefab, transform.position, Quaternion.identity, transform);
                heart.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }
}
