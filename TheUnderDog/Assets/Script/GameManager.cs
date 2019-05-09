using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int re_count;
    public float playtime;
    public Light lt;
    public Text bestScore;
    public Text timeText;

    private float surviveTime;




	void Start () {
        lt = GetComponent<Light>();
        timeText = GameObject.Find("Time").GetComponent<Text>();
        bestScore = GameObject.Find("BestScore").GetComponent<Text>();
        surviveTime = 0f;
	}
	
	void Update () {


        //게임 오버가 아닌 동안
        if (!Mover.isDead)
        {
            surviveTime += Time.deltaTime;

            // 갱신한 생존 시간을 텍스트 컴포넌트를 통해 표시
            //float 을 int 로 변환해서 소수점 아래를 잘라 표시
            timeText.text = "Time : " + (int)surviveTime;
            


            if (40 > surviveTime)
            {
                lt.color -= Color.white / 2.0F * (Time.deltaTime / 7);
            }

            else
            {
                lt.color += Color.red / 2.0F * (Time.deltaTime / 7);
            }

        }
            if (Mover.isDead)
            {
                /* text2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    LoadGame();
                } */
                Mover.xSpeed = 0;
                Invoke("LoadGame", 5);


            }


        // 이전까지의 최고 기록이 BestTime이라는 키로 저장되어 있다면 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime)
        {
            //최고 기록의 값을 현재 생존 시간의 값으로 변경
            bestTime = surviveTime;
            //변경된 최고 기록 값을 BestTime 이라는 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 최고 기록을 recordText 텍스트 컴포너트를 통해 표시
        bestScore.text = "Best Time : " + (int)bestTime;


    }




        public void LoadGame()
        {
            Mover.isDead = false;
            SceneManager.LoadScene("DieScene");
        }

    }
