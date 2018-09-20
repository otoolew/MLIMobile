﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class RayCastLine : MonoBehaviour
    {
        LineRenderer lineRenderer;
        Ray ray;
        RaycastHit rayHit;
        public float RayRange;
        public LayerMask LayerRayMask;
        public float effectDuration = 0.1f;
        public UnityEvent OnRayHit;
        public float damage;
        public bool readyToFire;
        private void Start()
        {
            lineRenderer = GetComponentInChildren<LineRenderer>();
        }

        public void Fire()
        {
            if (readyToFire)
            {
                StartCoroutine(FireFX());
            }           
        }
        IEnumerator FireFX()
        {
            readyToFire = false;
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            ray.origin = transform.position;
            ray.direction = transform.forward;

            if (Physics.Raycast(ray, out rayHit, RayRange, LayerRayMask))
            {
                try
                {
                    //Debug.Log("Debug RayHit: " + rayHit.collider.name);
                    //rayHit.collider.GetComponent<DamageZone>().HandleDamageZoneHit(damage);
                }
                catch (System.Exception e)
                {
                    Debug.Log(e);
                }

                OnRayHit.Invoke();

                lineRenderer.SetPosition(1, rayHit.point);

                //Debug.Log("Hit Success " + rayHit.collider.GetComponent<DamageBehaviour>().TakeDamage(10f));
            }
            else
            {
                lineRenderer.SetPosition(1, ray.origin + ray.direction * RayRange);
                //Debug.Log("Debug RayHit: NOTHING");
            }
            yield return new WaitForSeconds(effectDuration);
            readyToFire = true;
            lineRenderer.enabled = false;
        }
    }
}
