using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalkaKontrol : MonoBehaviour
{
    [SerializeField] float dönmeHizi;
    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, dönmeHizi * Time.deltaTime);
    }
}
