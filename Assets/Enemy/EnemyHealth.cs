using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour {
    [SerializeField] private int maxHitPoints    = 5;
    
    [Tooltip("Adds amount to max HP when enemy dies.")]
    [SerializeField] private int difficultyRamp = 1;

    private int _currentHitPoints = 0;

    private Enemy _enemy;

    private void Start() {
        _enemy = GetComponent<Enemy>();
    }

    void OnEnable() {
        _currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    private void ProcessHit() {
        _currentHitPoints--;
        if (_currentHitPoints <= 0) {
            EnemyDied();
        }
    }

    private void EnemyDied() {
        gameObject.SetActive(false);
        maxHitPoints += difficultyRamp;
        _enemy.RewardGold();
    }
}