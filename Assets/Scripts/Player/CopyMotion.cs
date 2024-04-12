using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMotion : MonoBehaviour
{

    public Transform targetLimb;
    public bool inverse;
    ConfigurableJoint cj;
    Quaternion startRot;

    void Start()
    {
        cj = GetComponent<ConfigurableJoint>();
        startRot = transform.localRotation;
    }

    void Update()
    {
        if (!inverse) cj.targetRotation = targetLimb.localRotation * startRot;
        else cj.targetRotation = Quaternion.Inverse(targetLimb.localRotation) * startRot;
    }
}