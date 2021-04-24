using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 70f;
    [SerializeField] GameObject impactEffect;

    private Transform target;

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Calc movement
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        // Check for hit
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // Move
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        GameObject effects = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effects, 2f);
        Destroy(gameObject);
        Destroy(target.gameObject); // TODO: Remove
        target = null;
    }

    public void Seek(Transform seekTarget)
    {
        target = seekTarget;
    }
}
