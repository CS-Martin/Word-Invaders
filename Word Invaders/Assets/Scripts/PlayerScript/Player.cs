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

    void Start() {
        transform.rotation = Quaternion.AngleAxis(500f, Vector3.forward);
    }

    void Update() {
        UpdatePlayerRotation();
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
