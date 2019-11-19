using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {
public float speed;
private float dead = 2;
private float score = 0;
private float ends = 0;
private float GERANDOM;
public GameObject start;
public GameObject lost;
public GameObject Playervis;
public GameObject Flipvis;
public GameObject restart;
public GameObject Fall;
public GameObject Winter;
public GameObject Snow;
public GameObject Leaves;
public GameObject Summer;
public GameObject Butterflies;
public GameObject startScreen;
public GameObject GE11;
public GameObject GE12;
public GameObject GE13;
public Text ScoreText;

//public GameObject firewrk;

	// Use this for initialization
	void Start () {
    score = 0;
	gameObject.transform.position = start.transform.position;
	InvokeRepeating("UpdateEverySecond", 1f, 1f);
	lost.SetActive(false);
	Playervis.SetActive(true);
    Flipvis.SetActive(false);
    dead = 2;
    Winter.SetActive(false);
    Fall.SetActive(false);
    Snow.SetActive(false);
    Leaves.SetActive(false);
    Summer.SetActive(true);
    Butterflies.SetActive(true);




    //LEVEL INITIALIZATIONgameObject.transform.position = restart.transform.position;
    
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("r") && dead == 0 || Input.GetKeyDown("r") && dead == 2) {
            dead = 1;
            lost.SetActive(false);
            speed = 10;
            Playervis.SetActive(true);
            Flipvis.SetActive(false);
            score = 0;
            startScreen.SetActive(false);
               
            GERANDOM = Random.Range(0, 2);
            Debug.Log(GERANDOM);

            if(GERANDOM == 0) {
                GE11.SetActive(true);
                GE12.SetActive(false);
                GE11.SetActive(false);
                Debug.Log("statue1");
            }

            if(GERANDOM == 1) {
                GE11.SetActive(false);
                GE12.SetActive(true);
                GE11.SetActive(false);
                Debug.Log("statue2");
            }

            if(GERANDOM == 2) {
                GE11.SetActive(false);
                GE12.SetActive(false);
                GE11.SetActive(true);
                Debug.Log("statue3");
            }

    	}
        if(dead == 2) {
    startScreen.SetActive(true);
    speed = 0;
    Playervis.SetActive(true);
    Flipvis.SetActive(false);
    score = 0;
        }
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		Vector3 direction = new Vector3(horizontal * 10, 0, speed);

		gameObject.transform.Translate(direction.normalized * Time.deltaTime * speed);

        ScoreText.text = score.ToString();

        score += speed;

        if(score%100000 == 0) {
            //firewrk.SetActive(true);
        }
	}
	void OnTriggerEnter(Collider other)
    {
    	Debug.Log("triggerLaunched");
    	if(other.tag=="End"){



        	gameObject.transform.position = restart.transform.position;
            ends ++;
            if(ends == 1){
                Winter.SetActive(false);
                Fall.SetActive(true);
                Snow.SetActive(false);
                Leaves.SetActive(true);
                speed = 40;
            } if(ends == 2){
                Snow.SetActive(true);
                Winter.SetActive(true);
                Fall.SetActive(false);
                Leaves.SetActive(false);
            }
    	} else if(other.tag == "Obstacle") {
            Debug.Log("Unity is stupid");
    		gameObject.transform.position = restart.transform.position;
    		lost.SetActive(true);
    		dead = 0;
    		speed = 0;
    		Playervis.SetActive(false);
            Flipvis.SetActive(true);
            Winter.SetActive(false);
            Fall.SetActive(false);
            Snow.SetActive(false);
            Leaves.SetActive(false);
            Summer.SetActive(true);
            Butterflies.SetActive(true);
            ends = 0;
    	   	
    }
}
    void UpdateEverySecond() {
    	if(dead == 1){
    		speed += 1;
            score += speed * 3;
    	}
    	Debug.Log(speed);
        Debug.Log(score);
        //firewrk.SetActive(false);
    }
}
