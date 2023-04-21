using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    public Transform bulletPoint;
    public WordManager wordManager;
    public GameObject bulletPrefab;
    private GameObject cursedWordObject;
    private float angle = 90f;

    /// <Note> Health bar methods
    public HealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth;

    void Start() {
        /// <Note> Set current health to maxHealth
        currentHealth = maxHealth;

        transform.rotation = Quaternion.AngleAxis(500f, Vector3.forward);
    }

    void Update() {
        bool check = false;

        /// <Note> If checker if true, then it means player failed to shoot cursedwords
        /// <Note> Then we call checker
        checker(check);

        UpdatePlayerRotation();
    }

    public void checker(bool check) {
        if (check = true) {
            TakenDamage(20);
        }
    }

    /// <Brief> Deduct player's life points
    /// <Param> Damage to the player
    void TakenDamage(int damage) {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void UpdatePlayerRotation() {
        if(wordManager.hasActiveWord){
            GameObject targetObject = wordManager.activeWord.cursedWord.gameObject;
            Vector3 direction = targetObject.transform.position - bulletPoint.transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
        else{
            if(angle < 90f) angle = (float)Math.Round((double)angle) + 1f;
            else if(angle > 90f) angle = (float)Math.Round((double)angle) - 1f;
        }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
    }


}
