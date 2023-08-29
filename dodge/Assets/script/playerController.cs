using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //키보드 수직축과 수평축 입력 감지
        float xinput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");
        //실제 이동속도를 입력값과 속력을 사용해 결정
        float xspeed = xinput * speed;
        float zspeed = zinput * speed;
        //Vector3 속도를 (xspeed,0f,zspeed)로 생성
        Vector3 newVelocity = new Vector3(xspeed,0f,zspeed);
        //리지드바디 속도에 newVelocity 저장
        playerRigidbody.velocity = newVelocity;
    }

    public void dead() {
        //사망 처리
        //게임 오브젝트 비활성화
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        //게임매니저 오브젝트에서 EndGame()을 호출한다
        gameManager.EndGame();
    }
}
