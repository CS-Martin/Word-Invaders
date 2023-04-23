using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word {
    
    private int typeIndex;
    private string word;
    private CursedWord cursedWord;
    
    public Word(string word, CursedWord cursedWord) {
        this.word = word;
        this.typeIndex = 0;
        this.cursedWord = cursedWord;
        this.cursedWord.SetWord(this.word);
    }

    public string GetWord() {
        return word;
    }

    public CursedWord GetCursedWord() {
        return cursedWord;
    }

    public char GetNextLetter() {
        return word[typeIndex];
    }

    public void TypeLetter() {
        typeIndex++;
        cursedWord.RemoveLetter();
    }

    public bool WordTyped() {
        bool isWordTyped = (typeIndex >= word.Length);
        return isWordTyped;
    }

    public void SetWordToActive() {
        cursedWord.DeactivateIsTrigger();
        cursedWord.SetIsActiveWord(true);
    }

}
