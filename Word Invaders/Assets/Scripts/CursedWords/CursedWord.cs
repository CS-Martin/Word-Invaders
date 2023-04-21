using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CursedWord : MonoBehaviour
{
    public float fallSpeed = 0.95f;
    public TextMeshProUGUI text;
    public GameObject playerObject;
    public Collider2D collider;
    private int cursedWordLife;

    private void Start() {
        playerObject = GameObject.Find("Juan");
        cursedWordLife = text.text.Length;
    }

    private void Update() {
        //cursed words only moves downwards and not towards juan
        //transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);

        //cursed words moves towards juan
        transform.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, fallSpeed * Time.deltaTime);
    }

    public void SetWord(string word) {
        text.text = word;
    }

    public void RemoveLetter() {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    public void RemoveWord() {
        Destroy(gameObject);
    }

    private void OnBecameInvisible() {
        // Destroy the game object when it becomes invisible
        Destroy(gameObject);
    }

    public void DeactivateIsTrigger() {
        collider.isTrigger = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        cursedWordLife--;
        if(cursedWordLife == 0) {
            Destroy(gameObject);
        }
    }
}
