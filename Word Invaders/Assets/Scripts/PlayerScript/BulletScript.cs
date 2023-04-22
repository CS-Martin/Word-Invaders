using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private WordManager wordManager;
    private CursedWord cursedWord;
    private float speed = 10f;

    void Start() {
        GameObject wordManagerObject = GameObject.Find("WordManager");
        GameObject player = GameObject.Find("Juan");
        wordManager = wordManagerObject.GetComponent<WordManager>();
        if(wordManager.activeWord.cursedWord != null)
            cursedWord = wordManager.activeWord.cursedWord;
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void Update() {
        if(cursedWord != null){
            transform.position = Vector2.MoveTowards(transform.position, cursedWord.gameObject.transform.position, speed * Time.deltaTime);
            transform.up = cursedWord.gameObject.transform.position - transform.position;
        }
        else{
            Destroy(gameObject);
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
