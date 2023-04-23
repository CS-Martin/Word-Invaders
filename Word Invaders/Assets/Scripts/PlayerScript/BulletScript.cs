using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private WordManager wordManager;
    private CursedWord cursedWord;
    private GameObject player;
    private float speed = 10f;

    void Start() {
        FindWordManager();
        FindPlayer();
        IgnorePlayerCollision();
        SetCursedWord();
    }

    void Update() {
        FollowTargetWord();
    }

    private void FollowTargetWord() {
        if(cursedWord != null){
            transform.position = Vector2.MoveTowards(transform.position, cursedWord.gameObject.transform.position, speed * Time.deltaTime);
            transform.up = cursedWord.gameObject.transform.position - transform.position;
        }
        else{
            Destroy(gameObject);
        }
    }

    private void FindWordManager() {
        GameObject wordManagerObject = GameObject.Find("WordManager");
        wordManager = wordManagerObject.GetComponent<WordManager>();
    }

    private void FindPlayer() {
        player = GameObject.Find("Juan");
    }

    private void IgnorePlayerCollision() {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void SetCursedWord() {
        Word activeWord = wordManager.GetActiveWord();
        if (activeWord != null) {
            CursedWord activeWordCursedWord = activeWord.GetCursedWord();
            if (activeWordCursedWord != null) {
                cursedWord = activeWordCursedWord;
            }
        }
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("CursedWordTarget")){
            if(cursedWord != null)
                cursedWord.setCursedWordLife(cursedWord.getCursedWordLife() - 1);
            Destroy(gameObject);
        }
    }
}
