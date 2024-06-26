using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target; // 타겟 설정
    public float speed; // 회전 속도
    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }


    void Update()
    {
        transform.position = target.position + offset;

        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime); // RotateAround 회전시켜주는함수

        offset = transform.position - target.position;
    }
}
