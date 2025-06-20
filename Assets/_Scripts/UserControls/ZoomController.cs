using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UserControls
{
    
    
    public class ZoomController : MonoBehaviour
    {
        public Transform cameraTran;
        public float zoomSpeed = 5f;
        public float zoomSmooth = 0.2f;
        public float minZoom = 5f;
        public float maxZoom = 50f;

        private Transform target;
        private Vector3 newPos;
        private Vector3 velocity = Vector3.zero;
        
        private void Start()
        {
            newPos = cameraTran.localPosition;
            target = transform.root;
            cameraTran.LookAt(target.position);
        }
        
        private void Update()
        {
            if (Mouse.current.scroll.IsActuated())
            {
                Vector3 targetPosition = target.position;
                float distance = Vector3.Distance(cameraTran.localPosition, targetPosition);
                float zoomAmount = Mouse.current.scroll.y.ReadValue() * zoomSpeed * Time.deltaTime;
                distance = Mathf.Clamp(distance - zoomAmount, minZoom, maxZoom);
                Vector3 zoomDir = cameraTran.localRotation * Vector3.forward;
                newPos = targetPosition - zoomDir * distance;
            }
            cameraTran.localPosition = Vector3.SmoothDamp(cameraTran.localPosition, newPos, ref velocity, zoomSmooth);
        }
    }
}
