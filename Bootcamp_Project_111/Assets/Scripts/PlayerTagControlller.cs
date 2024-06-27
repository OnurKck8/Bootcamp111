using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTagControlller : MonoBehaviour
{ 
    public PuzzleManager puzzleManager;
    public string triggerSequence;// Her kap� i�in farkl� triggerSequence
    public string doorName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            puzzleManager.ActivatePuzzle(triggerSequence);
            puzzleManager.sceneName = doorName;
            Debug.Log("Puzzle Activated with sequence: " + triggerSequence);
        }
    }
}

