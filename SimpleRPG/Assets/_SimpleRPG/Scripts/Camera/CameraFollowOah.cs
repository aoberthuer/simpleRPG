using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.CameraUI
{
    public class CameraFollowOah : MonoBehaviour
    {

        [SerializeField] GameObject player;

        [SerializeField] public Vector3 offset = new Vector3(-13, -12, 0);
        [SerializeField] public float smoothSpeed = 2f;

        [SerializeField] float currentZoom = 1f;
        [SerializeField] readonly float maxZoom = 1.5f;
        [SerializeField] readonly float minZoom = 0.5f;
        [SerializeField] readonly float zoomSensitivity = .5f;

        [SerializeField] readonly float yawSpeed = 50f;

        private float zoomSmoothVelocity;
        private float targetZoom;

        private readonly float xAxisTiltDegrees = 30f;
        private float currentYaw = -90f;    
   

        void Start()
        {
            transform.LookAt(player.transform);
            targetZoom = currentZoom;
        }

        void Update()
        {
            ComputeZoom();
            ComputeYaw();
        }

        void LateUpdate()
        {
            transform.position = player.transform.position - offset * currentZoom;
            transform.LookAt(player.transform.position);

            float xTilt = xAxisTiltDegrees * currentZoom;
            Quaternion rotation = Quaternion.Euler(xTilt, currentYaw, 0); // use player.transform..rotation.y here ?
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1f);
        }

        private void ComputeZoom()
        {
            float scroll = Input.GetAxisRaw("Mouse ScrollWheel") * zoomSensitivity;

            if (scroll != 0f)
            {
                targetZoom = Mathf.Clamp(targetZoom - scroll, minZoom, maxZoom);
            }
            currentZoom = Mathf.SmoothDamp(currentZoom, targetZoom, ref zoomSmoothVelocity, .15f);
        }

        private void ComputeYaw()
        {
            currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
            currentYaw = Mathf.Clamp(currentYaw, -120f, -60f);
        }
    }
}