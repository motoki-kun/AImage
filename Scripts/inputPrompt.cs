using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using TMPro; //TextMeshPro
using System.Threading.Tasks; //非同期処理

public class inputPrompt : MonoBehaviour
{

    //OpenAIのAPIにリクエストするJSON
    [Serializable]
    public class RequestBody
    {
        public string model;
        public string prompt;
        public int n;     //
        public string size;
    }

    //OpenAIのAPIからリターンのあるJSON
    [System.Serializable]
    public class ImageItem
    {
        public string revised_prompt;
        public string url;
    }
    [System.Serializable]
    public class ImageResponse
    {
        public int created;
        public ImageItem[] data;
    }


    public async void Start() //ボタンをクリックしたら呼ばれる
    {
        string mes = Title_to_Check.Result[Title_to_Check.now];//ユーザーが入力した内容を取得

        Debug.Log("mes " + mes);

        var url = "https://api.openai.com/v1/images/generations";

        RequestBody body = new RequestBody();
        body.model = "dall-e-3";
        body.prompt = mes;
        body.n = 1;
        body.size = "1024x1024";

        string jsonBody = JsonUtility.ToJson(body);

        //以下、OpenAIのAPIへJSONを投げる
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(postData);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer <個人のOpenAI apiキー>");

        var operation = request.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Delay(10);
        }
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(request.responseCode);

            // OpenAIのAPIが正常にレスポンスがあった場合は以下
            if (request.responseCode == 200 || request.responseCode == 201)
            {
                string text = request.downloadHandler.text;
                
                // JsonUtilityを使ってJSONデータを解析
                ImageResponse response = JsonUtility.FromJson<ImageResponse>(text);

                // 最初の画像のURLを取得
                string imageUrl = response.data[0].url;
                await DownloadAndSetTexture(imageUrl);
            }
            else
            {
                Debug.Log("Failure");
            }
        }
        request.Dispose();

    }


    async Task DownloadAndSetTexture(string url)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            www.SendWebRequest().completed += _ => tcs.SetResult(true);
            await tcs.Task;

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                //ダウンロードしたテクスチャを取得
                Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(www);

                // マテリアルの取得とテクスチャの設定
                Material material = GameObject.Find("Cube").GetComponent<Renderer>().material;
                material.shader = Shader.Find("Unlit/Texture");
                material.mainTexture = downloadedTexture;

            }
        }
    }

}
