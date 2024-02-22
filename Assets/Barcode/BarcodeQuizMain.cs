using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarcodeQuizMain : MonoBehaviour
{
    public List<GameObject> allObjects;
    public List<GameObject> gameObjects;
    public Text infoText;
    private int objectsFound = 0;
    private float timer = 60f;

    public InputField input;

    void Start()
    {
        PickRandomObjects();
        StartCoroutine(StartGame());
    }

    void PickRandomObjects()
    {
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, allObjects.Count);
            gameObjects.Add(allObjects[randomIndex]);
            allObjects.RemoveAt(randomIndex);
        }
    }

    IEnumerator StartGame()
    {
        while (timer > 0f && objectsFound < 5)
        {
            yield return null; // Проверка штрих-кода (ваша логика)

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
        foreach (GameObject obj in gameObjects)
        {
            if (obj.name.ToLower() == scannedText)
            {
                gameObjects.Remove(obj);
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
