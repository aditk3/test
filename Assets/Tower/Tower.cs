using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [SerializeField] private int   cost       = 75;
    [SerializeField] private float buildDelay = 1f;

    private void Start() {
        StartCoroutine(Build());
    }

    public bool CreateTower(Tower tower, Vector3 pos) {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null) return false;
        
        if (bank.CurrentBalace >= cost) {
            Instantiate(tower.gameObject, pos, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }

    IEnumerator Build() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
            foreach (Transform grandchild in child) {
                child.gameObject.SetActive(false);
            }
        }
        
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandchild in child) {
                child.gameObject.SetActive(true);
            }
        }
    }
}