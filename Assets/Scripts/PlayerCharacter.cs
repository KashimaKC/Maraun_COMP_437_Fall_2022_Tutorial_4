using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private Camera cam;
    private int health;
    private int playerScore;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        health = 5;
        playerScore = 0;
    }

    public void Hurt(int damage) {
        health -= damage;
        //Debug.Log($"Health: {health}");
    }

    public void AddScore(int score) {
        playerScore += score;
        //Debug.Log($"Score: {playerScore}");
    }

    // void OnGUI() {
    //     //health GUI
    //     guiStyle.fontSize = 40;

    //     //change between health status messages.
    //     if (health > 0) {

    //         //Rect( horizontal, vertical, pos, pos)
    //         GUI.Label(new Rect(25, 25, 100, 30), $"Health: {health}", guiStyle);
    //         GUI.Label(new Rect(25, 75, 100, 30), $"Score: {playerScore}", guiStyle);

    //     } else {
    //         playerScore = 0;

    //         GUI.Label(new Rect(25, 25, 100, 30), $"DEAD", guiStyle);
    //         GUI.Label(new Rect(25, 75, 100, 30), $"Score: {playerScore}", guiStyle);

    //         StartCoroutine(Respawn());
    //     }
    // }
    

    private IEnumerator Respawn() {

        yield return new WaitForSeconds(1.5f);

        health = 5;
    }
}
