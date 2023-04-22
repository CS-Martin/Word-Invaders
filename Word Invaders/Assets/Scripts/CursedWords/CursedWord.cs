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
    public WordManager wordManager;
    public bool isActiveWord;
    private int cursedWordLife;

    private void Start() {
        GameObject wordManagerObject = GameObject.Find("WordManager");
        wordManager = wordManagerObject.GetComponent<WordManager>();
        isActiveWord = false;
        playerObject = GameObject.Find("Juan");
        cursedWordLife = text.text.Length;
    }

    private void Update() {
        //cursed words only moves downwards and not towards juan
        //transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);

        //cursed words moves towards juan
        transform.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, fallSpeed * Time.deltaTime);

        if(cursedWordLife == 0) Destroy(gameObject);
    }

    public void SetWord(string word) {
        text.text = word;
    }

    public void RemoveLetter() {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    public void DeactivateIsTrigger() {
        isActiveWord = true;
        if(collider != null) collider.isTrigger = false;
    }

    public int getCursedWordLife() {
        return this.cursedWordLife;
    }

    public void setCursedWordLife(int cursedWordLife) {
        this.cursedWordLife = cursedWordLife;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            if(isActiveWord) wordManager.DestroyActiveWord();
            Destroy(gameObject);
        }
    }
}
