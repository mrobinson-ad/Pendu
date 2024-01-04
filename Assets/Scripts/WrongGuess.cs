using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongGuess : MonoBehaviour
{
    public int lives;

    [SerializeField] GameManager gameManager;
    public Petal[] childs;
    public GameObject parent;
    [SerializeField] Vector3 targetPosition;
    private float speed=5;
    [SerializeField] Quaternion target;

    void Start()
    {
       lives = 7;     
    }

    // When called this function applies the Fade coroutine to the petal corresponding to the current lives
    public void PetalFall()
    {
        Petal child = childs[lives];
        StartCoroutine(child.Fade(targetPosition, target, speed));

        if (lives == 0)
        {
            gameManager.Invoke("Lose", 1);
        }
    }



}
