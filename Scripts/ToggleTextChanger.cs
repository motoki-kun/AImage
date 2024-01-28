using UnityEngine;
using UnityEngine.UI; // UI要素を扱うために必要

public class ToggleTextChanger : MonoBehaviour
{
    // ToggleのGameObjectの配列
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    // Start is called before the first frame update
    void Start()
    {
        // 各ページ内のTogglesを取得
        Toggle[] toggles1 = page1.GetComponentsInChildren<Toggle>(true);
        // 各ToggleのTextを変更
        for (int j = 0; j < toggles1.Length; j++)
        {
            // Toggleの子オブジェクトの中からTextコンポーネントを探して、新しいテキストを設定
            Text label = toggles1[j].GetComponentInChildren<Text>();
            if (label != null && j < Title_to_Check.Question1.Length)
            {
                label.text = Title_to_Check.Question1[j];
            }
        }

        Toggle[] toggles2 = page2.GetComponentsInChildren<Toggle>(true);
        // 各ToggleのTextを変更
        for (int j = 0; j < toggles2.Length; j++)
        {
            // Toggleの子オブジェクトの中からTextコンポーネントを探して、新しいテキストを設定
            Text label = toggles2[j].GetComponentInChildren<Text>();
            if (label != null && j < Title_to_Check.Question2.Length)
            {
                label.text = Title_to_Check.Question2[j];
            }
        }

        Toggle[] toggles3 = page3.GetComponentsInChildren<Toggle>(true);
        // 各ToggleのTextを変更
        for (int j = 0; j < toggles3.Length; j++)
        {
            // Toggleの子オブジェクトの中からTextコンポーネントを探して、新しいテキストを設定
            Text label = toggles3[j].GetComponentInChildren<Text>();
            if (label != null && j < Title_to_Check.Question3.Length)
            {
                label.text = Title_to_Check.Question3[j];
            }
        }
    }
}
