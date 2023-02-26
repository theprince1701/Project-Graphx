using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float maxTime = 120f;
    [SerializeField] private TextMeshProUGUI orbsCollectedText;
    [SerializeField] private TextMeshProUGUI timeRemainingText;
    [SerializeField] private GameObject gameWonScreen;
    [SerializeField] private GameObject gameLostScreen;


    private float _timeRemaining;

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _timeRemaining = maxTime;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _timeRemaining -= Time.deltaTime;
        orbsCollectedText.text = "ORBS COLLECTED: " + Player.OrbsCollected + "/" + Player.MaxOrbs;
        
        
        int minutes = Mathf.FloorToInt(_timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(_timeRemaining - minutes * 60);

        timeRemainingText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        if (_timeRemaining <= 0)
        {
            Player.HasLost = true;
            _playerMovement.enabled = false;
            gameLostScreen.SetActive(true);
            orbsCollectedText.gameObject.SetActive(false);
            timeRemainingText.gameObject.SetActive(false);
        }

        if (Player.HasWon)
        {
            _playerMovement.enabled = false;
            gameWonScreen.SetActive(true);
            orbsCollectedText.gameObject.SetActive(false);
            timeRemainingText.gameObject.SetActive(false);
        }

    }
}
