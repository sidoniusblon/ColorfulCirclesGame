using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    [SerializeField] Transform topTransform;
    private void LateUpdate()
    {
        if (topTransform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,topTransform.position.y,transform.position.z);
        }
    }
}
