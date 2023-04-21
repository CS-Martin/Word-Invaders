using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordCollider : MonoBehaviour
{

    public WordManager wordManager;
    public TextMeshProUGUI textMeshPro;
    private string parentText;
   
    void Start() {
        GameObject wordManagerObject = GameObject.Find("WordManager");
        wordManager = wordManagerObject.GetComponent<WordManager>();
        textMeshPro = GetComponentInParent<TextMeshProUGUI>();
        parentText = textMeshPro.text;
    }

    void Update() {
        if(wordManager.hasActiveWord == true) {
            if(wordManager.activeWord.word == parentText) {
                Debug.Log(parentText);
            }
        }

    }
}
