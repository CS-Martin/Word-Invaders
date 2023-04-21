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
        wordManager = wordManagerObject.GetComponent<WordManager>();
        cursedWord = wordManager.activeWord.cursedWord;
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, cursedWord.gameObject.transform.position, speed * Time.deltaTime);
        transform.up = cursedWord.gameObject.transform.position - transform.position;
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("CursedWordTarget")) {
            Destroy(gameObject);
        }
    }
}
