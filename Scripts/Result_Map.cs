using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class Name_to_Game : MonoBehaviour
{
    public GameObject userTextPrefab; // ユーザーテキスト用の空のオブジェクトプレハブ
    public ScrollRect scrollView;
    public Button Title;
    public TextMeshProUGUI Result;

    void Start()
    {
        GenerateResult();
        Title.onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        for(int i = 0; i < 11; i++){
            Title_to_Check.Result[i] = null;
        }
        Title_to_Check.player_counter = 0;
        Title_to_Check.now = 0;
        Title_to_Check.Correct_Answer = null;
        

        SceneManager.LoadScene("Title");
    }
    void GenerateResult()
    {
        if(Title_to_Check.Result[0] == Title_to_Check.Result[Title_to_Check.player_counter]){
            Result.text = "正解！！";
        }else{
            Result.text = "不正解...";
        }
        RectTransform contentTransform = scrollView.content;

        for (int i = 0; i <= Title_to_Check.player_counter; i++)
        {
            // プレイヤー名のテキストオブジェクトを生成
            GameObject playerNameTextGO = Instantiate(userTextPrefab, contentTransform);
            playerNameTextGO.transform.localPosition = new Vector3(0, -i * 300 - 650, 0);

            TextMeshProUGUI playerNameTextTMP = playerNameTextGO.GetComponentInChildren<TextMeshProUGUI>();
            if (playerNameTextTMP != null)
            {
                if(i == 0){
                    playerNameTextTMP.text = "お題";
                }else{
                    playerNameTextTMP.text = "プレイヤー" + i;
                }
            }

            // 結果のテキストオブジェクトを生成
            GameObject resultTextGO = Instantiate(userTextPrefab, contentTransform);
            resultTextGO.transform.localPosition = new Vector3(0, -i * 300 - 800, 0);
            
            TextMeshProUGUI resultTextTMP = resultTextGO.GetComponentInChildren<TextMeshProUGUI>();
            if (resultTextTMP != null)
            {
                resultTextTMP.text = Title_to_Check.Result[i];
            }
        }
    }
}