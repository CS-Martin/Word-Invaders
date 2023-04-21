using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour {
    
    public GameObject cursedWordPrefab;
    public Transform wordCanvas;

    public CursedWord SpawnWord() {

        Vector3 randomPosition = new Vector3 (Random.Range(-2.5f, 2.5f), 7f);

        //Quaternion.identity means to set no rotation
        GameObject cursedWordObject = Instantiate(cursedWordPrefab, randomPosition, Quaternion.identity, wordCanvas);
        CursedWord cursedWord = cursedWordObject.GetComponent<CursedWord>();
        return cursedWord;
    }

}
