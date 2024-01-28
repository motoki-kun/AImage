using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // TextMesh Proの名前空間

public class Check_to_Game : MonoBehaviour
{
    // Start is called before the first frame update
    public Button to_Game_Button;

    void Start()
    {
        to_Game_Button.onClick.AddListener(LoadScene);
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
