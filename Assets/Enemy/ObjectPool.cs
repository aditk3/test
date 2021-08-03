using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] [Range(0,    50)]  private int   poolSize   = 5;
    [SerializeField] [Range(0.1f, 30f)] private float spawnDelay = 1f;

    private GameObject[] pool;

    private void Awake() {
        PopulatePool();
    }

    void Start() {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool() {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++) {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy() {
        while (true) {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void EnableObjectInPool() {
        for (int i = 0; i < pool.Length; i++) {
            if (!pool[i].activeInHierarchy) {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}