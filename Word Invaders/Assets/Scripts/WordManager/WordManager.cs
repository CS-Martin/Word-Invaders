using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {
    
    public List<Word> words;
    public WordSpawner wordSpawner;
    public ScoreDisplay scoreDisplay;
    public Player player;

    public AudioSource shootingSound;

    private bool hasActiveWord = false;
    private Word activeWord;

    private void Update() {
        if(hasActiveWord) Debug.Log(activeWord.GetWord());
    }

    public void AddWord() {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
        words.Add(word);
    }

    public void TypeLetter(char letter) {
        if (TryTypeActiveWord(letter)) {
            // Player shoot
            player.Shoot();
            
            // Play gun sound when firing
            shootingSound.Play();
            if (activeWord.WordTyped()) {
                DestroyActiveWord();
                scoreDisplay.UpdateScore();
            }
        }
        else {
            if(!hasActiveWord)
                TryTypeNewWord(letter);
        }
    }

    private bool TryTypeActiveWord(char letter) {
        if (hasActiveWord && activeWord.GetNextLetter() == letter) {
            activeWord.TypeLetter();
            return true;
        }
        return false;
    }

    private void TryTypeNewWord(char letter) {
        foreach (Word word in words) {
            if (word.GetNextLetter() == letter) {
                shootingSound.Play();
                SetActiveWord(word);
                activeWord.TypeLetter();
                player.Shoot();
                break;
            }
        }
    }

    public void DestroyActiveWord() {
        SetHasActiveWord(false);
        words.Remove(activeWord);
    }

    public void SetActiveWord(Word word) {
        activeWord = word;
        activeWord.SetWordToActive();
        SetHasActiveWord(true);
    }

    public Word GetActiveWord() {
        return activeWord;
    }

    public void SetHasActiveWord(bool hasActiveWord) {
        this.hasActiveWord = hasActiveWord;
    }

    public bool GetHasActiveWord() {
        return hasActiveWord;
    }

}
