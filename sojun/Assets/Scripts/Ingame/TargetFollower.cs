using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{

    //따라가야하는 타겟
    public Transform target;
    //벡터의 마진
    public Vector3 margin;

    public float lerpSpeed = 10f;

    Vector3 totalMargin;

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position - (target.forward * -margin.z + target.up * -margin.y), Time.deltaTime * lerpSpeed);
        }
       
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }


}
