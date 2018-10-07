using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //카메라의 위치 정보
    public Transform cameraTransform;
    //날아가는 방향
    public Vector3 dir;
    //속도
    public float speed;
    //데미지
    public int damage;
    //현재 존재하고 있는 시간
    public float currentTime;
    //파괴되는 시간
    public float destroyTime;

    //카메라 컨트롤러
    CameraController cameraController;

    //무기 정보
    WeaponBehaviour weapon;


    //0.33
    void Update()
    {
        //현재 시간에 프레임 오차 값을 증가
        currentTime += Time.deltaTime;
        //현재 시간이 파괴되는 시간을 넘어간 경우
        if (currentTime >= destroyTime)
        {
            //오브젝트를 파괴하는 함수(파괴하고 싶은 것);
            DestroyObject();
        }
    }

    //총알은 물리 업데이트 기준으로 움직임
    public void FixedUpdate()
    {
        dir = cameraTransform.forward;
        //forward = 앞 / back = 뒤 / left = 왼쪽 / right = 오른쪽 
        //up = 위 / down = 아래

        //Position = 위치 / rotation = 회전 / scale = 크기
        transform.position += dir * speed * Time.deltaTime;
        transform.localEulerAngles = cameraTransform.localEulerAngles;
    }

    //함수! >> 스피드 값, 파괴되는 시간, 카메라 트랜스폼을 지정
    public void SetBullet(WeaponBehaviour _weapon, float _speed, float _destroyTime, int _damage, Transform _transform)
    {
        weapon = _weapon;
        speed = _speed;
        destroyTime = _destroyTime;
        cameraTransform = _transform;

        cameraController = cameraTransform.GetComponent<CameraController>();

        cameraTransform.GetComponent<TargetFollower>().SetTarget(transform);
        damage = _damage;
        currentTime = 0;
    }


    //예약된 함수
    //IS Trigger 가 체크 되있는 경우
    void OnTriggerEnter(Collider _collider)
    {
        //_collider = 컴포넌트에 충돌한 오브젝트 정보
        if (_collider.CompareTag("Obstacle"))
        {
            Destroy(_collider.gameObject);
            weapon.ResetDelay();
            GameManager.instance.AddScore();
            DestroyObject();
        }

    }

    void DestroyObject()
    {
        cameraTransform.GetComponent<TargetFollower>().SetTarget(null);
        cameraController.ResetPosition();
        Destroy(this.gameObject);
    }

}
