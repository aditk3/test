using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour {
    [SerializeField] private int startingBalance = 150;

    private int _currentBalace;
    public  int CurrentBalace => _currentBalace;

    [SerializeField] private TextMeshProUGUI displayBalance; 

    private void Awake() {
        _currentBalace = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount) {
        _currentBalace += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount) {
        _currentBalace -= Mathf.Abs(amount);
        UpdateDisplay();

        if (_currentBalace < 0) {
            ReloadScene();
        }
    }

    void UpdateDisplay() {
        displayBalance.text = "Gold: " + _currentBalace;
    }

    private void ReloadScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}