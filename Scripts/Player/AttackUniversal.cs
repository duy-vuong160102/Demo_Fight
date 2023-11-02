using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject hitPS;

    private float radius = 1f;

    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }

    private void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, layerMask);

        if (hit.Length > 0)
        {
            Debug.Log("Attack");

            Vector3 hitPos = hit[0].transform.position;

            hitPos.y += 1.5f;
            Instantiate(hitPS, hitPos, Quaternion.identity);
        }
    }
}
