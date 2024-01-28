using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // TextMesh Proの名前空間
using System.Collections.Generic;
using JetBrains.Annotations;

public class Title_to_Check : MonoBehaviour
{
    public TMP_Dropdown Number_of_player; // TextMesh Proのドロップダウン
    public Button to_Check_Button; // ボタンへの参照

    public static int player_counter;
    public static int now = 0;

    public string[,] question1_random = { 
        { "裸の王様", "殺人ピエロ", "スーパー小学生", "かわいい宇宙人", "ちっちゃいくま" },
        { "光速バイク", "ロックスター", "人喰いサメ", "レッサーパンダ", "超アイドル"},
        { "大型ブルドッグ", "最強ハンター", "変なスーパーマン", "クレイジー芸人", "レインボーイルカ" },
        { "マンチカン", "韓国系イケメン", "世界一のりんご", "2軍の野球選手", "男性型人魚" }
    };

    public string[,] question2_random = { 
        { "荒れている渋谷", "のどかな田舎", "思い出のふるさと", "最古のエジプト", "美しい空" },
        { "おしゃれなイタリア", "最先端の江戸", "にぎやかな大阪", "勢いのある川", "広大なサバンナ"},
        { "イギリス文化", "エモい昭和", "未来の東京", "話題の動物園", "アフリカの伝統"},
        { "情熱のメキシコ", "平成の思い出", "福岡のグルメ", "深海のロマン", "生命みなぎるジャングル"}
    };
    public string[,] question3_random = { 
        { "カラフルな学校", "捨てられたおもちゃ", "流行の音楽", "バトル系漫画", "おばちゃんの恋愛" },
        { "お正月のテレビ", "真冬の運動会", "豪華な演劇", "平和なSNS", "ストリート系ファッション"},
        { "迷惑系YouTuber", "一人の修学旅行", "きりんダンス", "FPSゲーム", "地雷系メイク"},
        { "ギャルとナイトプール", "つまらない文化祭", "こども総理大臣", "危険な出会い系アプリ", "パリピサンタ"}
    };
    public static string[] Result = new string[11];
    public static string Correct_Answer;

    public static string[] Question1 = new string[4];
    public static string[] Question2 = new string[4];
    public static string[] Question3 = new string[4];

    void Start()
    {
        System.Random rand = new System.Random();

        int[] question1_index = new int[4];
        int[] question2_index = new int[4];
        int[] question3_index = new int[4];

        for( int i = 0; i < 4; i++){
            question1_index[i] = rand.Next(5);
            question2_index[i] = rand.Next(5);
            question3_index[i] = rand.Next(5);
        }

        for(int i = 0; i < 4; i++){
            Question1[i] = question1_random[i, question1_index[i]];
            Question2[i] = question2_random[i, question2_index[i]];
            Question3[i] = question3_random[i, question3_index[i]];
        }

        Debug.Log("Question1 " + Question1);
        Debug.Log("Question2 " + Question2);
        Debug.Log("Question3 " + Question3);

        int answer1_index = rand.Next(4);
        int answer2_index = rand.Next(4);
        int answer3_index = rand.Next(4);

        Correct_Answer = Question1[answer1_index] + " " + Question2[answer2_index] + " " + Question3[answer3_index];
        Result[0] = Correct_Answer;

        Debug.Log("Reslt[0] " + Result[0]);

        to_Check_Button.onClick.AddListener(LoadScene);
        Number_of_player.onValueChanged.AddListener(delegate {
            DropdownValueChanged(Number_of_player);
        });
    }

    void LoadScene()
    {
        if(player_counter != 1){
            SceneManager.LoadScene("PlayerCheck");
        }else{
            Debug.Log("人数を選択してください");
        }
        
    }

    // DropdownValueChangedメソッドの引数をTMP_Dropdown型に変更
    void DropdownValueChanged(TMP_Dropdown dropdown)
    {
        player_counter = dropdown.value + 1;
        Debug.Log("Selected Option: " + player_counter);
    }
}
