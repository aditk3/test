using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private int goldReward  = 25;
    [SerializeField] private int goldPenalty = 25;

    private Bank _bank;

    // Start is called before the first frame update
    void Start() {
        _bank = FindObjectOfType<Bank>();
    }

    public void RewardGold() {
        if (_bank == null) return;
        _bank.Deposit(goldReward);
    }

    public void StealGold() {
        if (_bank == null) return;
        _bank.Withdraw(goldPenalty);
    }
}