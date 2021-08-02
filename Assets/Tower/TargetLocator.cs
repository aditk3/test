using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour {
    [SerializeField] private Transform      weapon;
    [SerializeField] private ParticleSystem projectileParticles;
    [SerializeField] private float          range = 15f;

    private Transform target;

    void Start() {
        target = FindObjectOfType<Enemy>().transform;
    }

    void Update() {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget() {
        Enemy[]   enemies       = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float     maxDistance   = Mathf.Infinity;

        foreach (Enemy enemy in enemies) {
            float targetDist = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDist < maxDistance) {
                closestTarget = enemy.transform;
                maxDistance   = targetDist;
            }
        }

        target = closestTarget;
    }

    void AimWeapon() {
        float targetDist = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        Attack(targetDist < range);
    }

    void Attack(bool isActive) {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}