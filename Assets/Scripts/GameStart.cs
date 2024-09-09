using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject instructionText;

    private bool gameStarted = false;

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        gameStarted = true;

        if (instructionText != null)
        {
            instructionText.SetActive(false);
        }

    }
}
