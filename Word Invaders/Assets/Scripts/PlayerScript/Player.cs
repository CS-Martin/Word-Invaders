using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    private float angle = 90f;
    private int currentHealth;

    public Transform bulletPoint;
    public WordManager wordManager;
    public GameObject bulletPrefab;
    public HealthBar healthBar;

    void Start() {
        SetHealth(100);
        transform.rotation = Quaternion.AngleAxis(500f, Vector3.forward);
    }

    void Update() {
        UpdatePlayerRotation();
    }

    void UpdatePlayerRotation() {
        if (wordManager.GetHasActiveWord() && wordManager.GetActiveWord().GetCursedWord() != null)
            RotateTowardsCursedWord();
        else
            ResetPlayerRotation();

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void RotateTowardsCursedWord() {
        GameObject targetObject = wordManager.GetActiveWord().GetCursedWord().gameObject;
        Vector3 direction = targetObject.transform.position - bulletPoint.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    private void ResetPlayerRotation() {
        if (angle < 90f)
            angle = (float)Math.Round((double)angle) + 1f;
        else if (angle > 90f)
            angle = (float)Math.Round((double)angle) - 1f;
    }

    public void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("CursedWordTarget"))
            TakenDamage(20);
    }

    void TakenDamage(int damage) {
        SetHealth(currentHealth - damage);
        healthBar.SetHealth(currentHealth);
    }

    public int GetHealth() {
        return currentHealth;
    }

    public void SetHealth(int health) {
        currentHealth = health;
    } 

}
