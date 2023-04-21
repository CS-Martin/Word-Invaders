using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {
    
    public List<Word> words;
    public WordSpawner wordSpawner;
    public bool hasActiveWord;
    public Word activeWord;
    public ScoreDisplay scoreDisplay;
    public Player player;

    public void AddWord() {
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
        // Debug.Log(word.word);
        words.Add(word);
    }

    public void TypeLetter(char letter) {
        if (hasActiveWord) {
            // playerController.WordTyped(activeWord);
            if (activeWord.GetNextLetter() == letter) {
                activeWord.TypeLetter();
                player.Shoot();
            }
        }
        else {
            foreach(Word word in words) {
                if (word.GetNextLetter() == letter) {
                    activeWord = word;
                    activeWord.SetWordToActive();
                    hasActiveWord = true;
                    word.TypeLetter();
                    player.Shoot();
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.WordTyped()) {
            hasActiveWord = false;
            words.Remove(activeWord);
            scoreDisplay.UpdateScore();
        } 
    }

}
