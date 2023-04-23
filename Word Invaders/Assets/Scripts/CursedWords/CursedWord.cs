using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CursedWord : MonoBehaviour
{
    private float fallSpeed = 0.95f;
    private bool isActiveWord = false;
    private int cursedWordLife;

    public TextMeshProUGUI text;
    public GameObject playerObject;
    public Collider2D collider;
    public WordManager wordManager;

    private void Start() {
        GetWordManagerComponent();
        FindPlayerObject();
        setCursedWordLife(text.text.Length);
    }

    private void Update() {
        MoveTowardsPlayer();
        CheckAndDestroyWhenTyped();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            if(isActiveWord) wordManager.DestroyActiveWord();
            Destroy(gameObject);
        }
    }

    private void GetWordManagerComponent() {
        GameObject wordManagerObject = GameObject.Find("WordManager");
        wordManager = wordManagerObject.GetComponent<WordManager>();
    }

    private void FindPlayerObject() {
        playerObject = GameObject.Find("Juan");
    }

    private void MoveTowardsPlayer() {
        transform.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, fallSpeed * Time.deltaTime);
    }

    private void CheckAndDestroyWhenTyped() {
        if(cursedWordLife == 0){
            Destroy(gameObject);
        }
    }

    public void SetIsActiveWord(bool isActiveWord){
        this.isActiveWord = isActiveWord;
    }

    public bool GetIsActiveWord() {
        return isActiveWord;
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
        if(collider != null) collider.isTrigger = false;
    }

    public int getCursedWordLife() {
        return this.cursedWordLife;
    }

    public void setCursedWordLife(int cursedWordLife) {
        this.cursedWordLife = cursedWordLife;
    }

}
