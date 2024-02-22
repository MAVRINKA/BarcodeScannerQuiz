using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarcodeQuiz : MonoBehaviour
{
    public List<GameObject> objectsToFind;
    public Text infoText;
    private int objectsFound = 0;
    private float timer = 60f;

    public InputField input;

    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        while (timer > 0f && objectsFound < 5)
        {
            yield return null; // Проверка штрих-кода (ваша логика

            if (objectsFound >= 5)
            {
                EndGame();
                break;
            }

            CheckBarcode(); // Функция для проверки считанной информации

            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                EndGame();
            }
        }
    }

    public void CheckBarcode()
    {
        string scannedText = infoText.text.ToLower();
        infoText.text = input.text;
        foreach (GameObject obj in objectsToFind)
        {
            if (obj.name.ToLower() == scannedText)
            {
                objectsToFind.Remove(obj);
                Destroy(obj);
                objectsFound++;
                break;
            }
        }

        if (objectsFound >= 5)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("EndGame");
    }
}
