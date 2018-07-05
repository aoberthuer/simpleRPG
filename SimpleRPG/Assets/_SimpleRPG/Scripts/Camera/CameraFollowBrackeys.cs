﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.CameraUI
{
    public class CameraFollowBrackeys : MonoBehaviour
    {

        public Transform target;

        public Vector3 offset;
        public float smoothSpeed = 2f;

        public float currentZoom = 1f;
        public float maxZoom = 1.5f;
        public float minZoom = 0.5f;
        public float zoomSensitivity = .7f;
        float dst;

        float zoomSmoothV;
        float targetZoom;

        void Start()
        {
            dst = offset.magnitude;
            transform.LookAt(target);
            targetZoom = currentZoom;
        }

        void Update()
        {
            float scroll = Input.GetAxisRaw("Mouse ScrollWheel") * zoomSensitivity;

            if (scroll != 0f)
            {
                targetZoom = Mathf.Clamp(targetZoom - scroll, minZoom, maxZoom);
            }
            currentZoom = Mathf.SmoothDamp(currentZoom, targetZoom, ref zoomSmoothV, .15f);
        }

        void LateUpdate()
        {
            transform.position = target.position - transform.forward * dst * currentZoom;
            transform.LookAt(target.position);

            Quaternion rotation = Quaternion.Euler(30 * currentZoom, -90, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.1f);
        }
    }
}