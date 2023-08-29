using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapUpdate : MonoBehaviour
{
    //맵 회전 속도
    public float rotationSpeed = 60f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,rotationSpeed * Time.deltaTime,0f);
    }
}
