using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//              자신이 만든 클래스 이름 ㅣ MonoBehaviour
public class PlayerController : MonoBehaviour
{
    //속도
    [SerializeField]
    float moveSpeed;
    //방향
    Vector3 dir;
    //점프력
    [SerializeField]
    float jumpPower;

    //horizontal = 수평, vertical = 수직
    float h, v;

    Rigidbody ri;

    void Awake()
    {
        ri = GetComponent<Rigidbody>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        dir = new Vector3(h, 0, v) * moveSpeed;

        transform.position += dir;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            ri.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

    }


}

