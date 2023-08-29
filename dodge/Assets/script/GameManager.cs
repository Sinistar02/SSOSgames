using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //게임 오버시 활성화할 게임 텍스트
    public GameObject gameOverText;
    //현재 생존 시간을 표시할 컴포넌트
    public Text timeText;
    //최고 생존 기록을 표시할 컴포넌트
    public Text recordText;
    //현재 생존 시간
    private float surviveTime;
    //게임오버 상태
    private bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        //생존시간과 게임오버 상태를 초기화
        surviveTime = 0f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어가 아직 총알에 맞지 않았으면
        if(isGameOver==false){
            //현재 생존 시간 계속 기록
            surviveTime += Time.deltaTime;
            timeText.text = "Time : "+(int)surviveTime;
        } else {
            //플레이어가 총알에 맞았으면
            //게임오버 화면에서 R키를 누를 경우
            if(Input.GetKeyDown(KeyCode.R)){
                //SampleScene 씬 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    //게임오버로 변경하는 메서드
    public void EndGame(){
        //플레이어가 사망했으니 isGameOver를 true로 함
        isGameOver = true;
        // 게임오버 텍스트를 활성화함
        gameOverText.SetActive(true);
        /*최고 신기록을 저장*/
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if(surviveTime > bestTime){
            //최고기록에 생존기록 저장
            bestTime=surviveTime;
            //변경된 최고기록을 BestTime키로 저장
            PlayerPrefs.SetFloat("BestTime",bestTime);
        }
        recordText.text = "Best Time : " + (int)bestTime;
    }
    
}
