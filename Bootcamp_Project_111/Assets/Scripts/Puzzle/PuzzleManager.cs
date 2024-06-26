using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public AudioSource audioSource;
    public AudioClip[] keySounds;
    public string correctSequence = "ASDF"; // �al�nacak sabit nota listesi
   
    public string playerSequence = "";
    private string currentTriggerSequence = "";

    public bool isPuzzleActive = false;
   
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        bool keyPressed = false;

        if (isPuzzleActive)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                PlaySound(0);
                playerSequence += "A";
                keyPressed=true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                PlaySound(1);
                playerSequence += "S";
                keyPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                PlaySound(2);
                playerSequence += "D";
                keyPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                PlaySound(3);
                playerSequence += "F";
                keyPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                PlaySound(4);
                playerSequence += "G";
                keyPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                PlaySound(5);
                playerSequence += "H";
                keyPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                PlaySound(6);
                playerSequence += "J";
                keyPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                PlaySound(7);
                playerSequence += "K";
                keyPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                PlaySound(8);
                playerSequence += "L";
                keyPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
               ResumeGame();
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                playerSequence = "";
                Debug.Log("Player sequence cleared");
            }

            if (keyPressed)
            {
                CheckSequence();
            }
        }
    }

    void PlaySound(int index)
    {
        if (index >= 0 && index < keySounds.Length)
        {
            audioSource.clip = keySounds[index];
            audioSource.Play();
        }
    }

    void CheckSequence()
    {
        if (playerSequence.Length >= correctSequence.Length)
        {
            if (playerSequence == correctSequence)
            {
                Debug.Log("Puzzle Solved!");
                // Puzzle solved logic here
                StartCoroutine(PuzzleSolved());
            }
            else
            {
                Debug.Log("Incorrect Sequence");
                // Reset player sequence if incorrect
                playerSequence = "";
            }
        }
    }

    public void ActivatePuzzle(string triggerSequence)
    {
        playerSequence = ""; // Reset player sequence when a new puzzle is activated
        Time.timeScale = 0f; // Oyun durduruldu
        StartCoroutine(PlayTriggerSequence(triggerSequence));
    }

    public void ResumeGame()
    {
        isPuzzleActive = false;
        Time.timeScale = 1f; // Oyun devam ediyor
    }

    private IEnumerator PlayTriggerSequence(string triggerSequence)
    {
        foreach (char note in triggerSequence)
        {
            int index = GetIndexFromKey(note);
            PlaySound(index);
            yield return new WaitForSecondsRealtime(audioSource.clip.length + 0.1f); // Sesin tamam�n� �almak i�in bekle
        }

        isPuzzleActive = true; // Trigger sequence bitti�inde oyuncu tu�lara basabilir
    }

    private IEnumerator PuzzleSolved()
    {
        // Son notan�n tamamen �al�nmas� i�in biraz bekle
        yield return new WaitForSecondsRealtime(audioSource.clip.length);
        Debug.Log("Puzzle Solved!");
        ResumeGame();
    }

    private int GetIndexFromKey(char key)
    {
        switch (key)
        {
            case 'A': return 0;
            case 'S': return 1;
            case 'D': return 2;
            case 'F': return 3;
            case 'G': return 4;
            case 'H': return 5;
            case 'J': return 6;
            case 'K': return 7;
            case 'L': return 8;
            default: return -1;
        }
    }
}
