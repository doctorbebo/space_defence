using System;
using UnityEngine;

public class PropulsionTowards : PropulsionSystem
{
    [SerializeField]
    private Transform target;

    [SerializeField] 
    private bool lockX;
    
    [SerializeField] 
    private bool lockY;

    [SerializeField] 
    private bool lockZ;

    protected new void FixedUpdate()
    {
        Vector3 direction = target.position - transform.position;
        Vector3 newRot = Quaternion.LookRotation(direction).eulerAngles;
        Vector3 currentRot = transform.rotation.eulerAngles;
        newRot = new Vector3
        (
            lockX ? currentRot.x : newRot.x, 
            lockY ? currentRot.y : newRot.y,
            lockZ ? currentRot.z : newRot.z
        );
        
        transform.rotation = Quaternion.Euler(newRot);
        base.FixedUpdate();
    }
}