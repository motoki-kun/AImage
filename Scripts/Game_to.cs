using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro; 

public class Game_to : MonoBehaviour
{
    public GameObject[] toggleGroups; // 3つのToggleグループを含むGameObjectの配列
    public Button Game_to_Button;
    // Start is called before the first frame update
    void Start()
    {
        Game_to_Button.onClick.AddListener(GetSelectedToggles);
        Game_to_Button.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
    void LoadScene()
    {
        if(Title_to_Check.now < (Title_to_Check.player_counter - 1)){
            SceneManager.LoadScene("PlayerCheck");
            Title_to_Check.now++;
        }else{
            SceneManager.LoadScene("Result");
        }
    }
    void GetSelectedToggles()
    {
        string[] selected_ans = new string[3];
        int i = 0;
        // 各Toggleグループを反復処理
        foreach (GameObject group in toggleGroups)
        {
            Debug.Log("group " + group);
            // 各グループ内のToggleを取得
            Toggle[] toggles = group.GetComponentsInChildren<Toggle>();

            // 選択されたToggleを見つける
            foreach (Toggle toggle in toggles)
            {
                Debug.Log("toggle " + toggle.GetComponentInChildren<Text>().text);
                if (toggle.isOn)
                {
                    Debug.Log("toggle is On " + toggle.GetComponentInChildren<Text>().text);
                    selected_ans[i] = toggle.GetComponentInChildren<Text>().text;
                    i++;
                    break; // 一つのグループで一つのToggleのみが選択される
                }
            }
        }
        for(int j = 0; j < 3; j++){
            Debug.Log("selected ans " + selected_ans[j]);
        }
        string Players_Answer = selected_ans[0] + " " + selected_ans[1] + " " + selected_ans[2];
        Debug.Log("Players_Answer " + Players_Answer);
        Title_to_Check.Result[Title_to_Check.now + 1] = Players_Answer;
        Debug.Log("Reslt[" + (Title_to_Check.now + 1) +"] " + Title_to_Check.Result[Title_to_Check.now + 1]);
    }
}
