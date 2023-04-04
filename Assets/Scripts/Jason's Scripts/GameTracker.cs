using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTracker : MonoBehaviour {
    bool gameActive = true;

    int towerHealth = 3;
    [SerializeField] TMP_Text healthDisplay;

    float subTimer = 0f;
    int timer = 60;
    [SerializeField] TMP_Text timerDisplay;

    public GameObject winScreen;
    public GameObject loseScreen;

    // Update is called once per frame
    void FixedUpdate(){
        if(gameActive){
            subTimer += Time.fixedDeltaTime;
            if(subTimer >= 1){
                if(timer == 0){
                    WinGame();
                } else {
                    timer--;
                }
                subTimer = 0;
            }
            timerDisplay.text = ("SURVIVE FOR " + timer + " SECONDS");
        }
    }

    public void DamageTower(){
    //    towerHealth--;
        healthDisplay.text = (towerHealth + " / 3 HEALTH REMAINING");
        if(towerHealth == 0){
            LoseGame();
        }
    }

    void WinGame(){
        winScreen.SetActive(true);
        loseScreen.SetActive(false);

        FindObjectOfType<PlayerMovement>().enabled = false;
        gameActive = false;
    }

    void LoseGame(){
        winScreen.SetActive(false);
        loseScreen.SetActive(true);
        FindObjectOfType<PlayerMovement>().enabled = false;

        gameActive = false;
    }

    public bool CheckGameActive(){
        return gameActive;
    }
}