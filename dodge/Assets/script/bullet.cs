using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 8f;
    public Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //리지드바디의 속력 = 총알 앞쪽 방향 * 속력
        bulletRigidbody.velocity = transform.forward * speed;
        //3초 뒤에 총알 스스로 삭제함
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            //총알과 충돌한 오브젝트의 태그가 Player인 경우
            //충돌한 오브젝트의 컴포넌트 중에서 "PlayerController" 컴포넌트를 가져와 Dead() 실행
            other.GetComponent<playerController>().dead();
        }
    }
}
