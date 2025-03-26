using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectorUIController : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    private int currentIndex = 0;
    public void OnClickSelectNext()
    {
        characters[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % characters.Length;
        characters[currentIndex].SetActive(true);
    }
    public void OnClickSelectPrevious()
    {
        characters[currentIndex].SetActive(false);
        currentIndex = (currentIndex - 1 + characters.Length) % characters.Length;
        characters[currentIndex].SetActive(true);
    }
    public void OnClickStartGame()
    {
        PlayerPrefs.SetInt("PlayerIndex", currentIndex);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Arena");
    }
}
