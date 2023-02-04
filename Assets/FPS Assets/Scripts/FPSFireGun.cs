using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSFireGun : MonoBehaviour
{
    public float myDamage;
    public float headShotMultiplier;
    public float torsoShotMultiplier;
    public float limbShotMultiplier;

    public LayerMask camLayerMask;

    public GameObject myEnemy;

    GameObject enemyParentObj;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        //Shoot();
    }

    void Shoot()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, camLayerMask))
        {
            print("Shot Fired");
            if (hit.collider.gameObject.CompareTag("EnemyHead"))
            {
                myEnemy = hit.collider.gameObject;
                enemyParentObj = myEnemy.transform.parent.gameObject;
                enemyParentObj.GetComponent<FPSEnemy>().myHealth -= myDamage * headShotMultiplier;
                print(enemyParentObj.GetComponent<FPSEnemy>().myHealth + "Headshot");
            }

            if (hit.collider.gameObject.CompareTag("EnemyTorso"))
            {
                myEnemy = hit.collider.gameObject;
                enemyParentObj = myEnemy.transform.parent.gameObject;
                enemyParentObj.GetComponent<FPSEnemy>().myHealth -= myDamage * torsoShotMultiplier;
                print(enemyParentObj.GetComponent<FPSEnemy>().myHealth + "Torsoshot");
            }

            if (hit.collider.gameObject.CompareTag("EnemyLimb"))
            {
                myEnemy = hit.collider.gameObject;
                enemyParentObj = myEnemy.transform.parent.gameObject;
                enemyParentObj.GetComponent<FPSEnemy>().myHealth -= myDamage * limbShotMultiplier;
                print(enemyParentObj.GetComponent<FPSEnemy>().myHealth + "Limbshot");
            }
        }
    }
}
