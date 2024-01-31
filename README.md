# AImage
これらのImages,Resources,Scenes,ScriptsはAImageをUnityで作成する際にAsset内に作ったフォルダたちである
実際にAImageを作成した際にはこれらのフォルダ以外にFontsというフォルダ文字のフォントを格納するフォルダ（自分はSenobi-Gothic-Regularを使用）（https://modi.jpn.org/font_senobi.php)
とPluginsというフォルダにUnitaskというパッケージをダウンロードしてインポートをして使用した（https://github.com/Cysharp/UniTask/releases）
注意点
実際にAImageを使う際にはinputPrompt.csの58行目にあるrequest.SetRequestHeader("Authorization", "Bearer <個人のOpenAI apiキー>");の<個人のOpenAIのapiキー>という箇所には自分のapiキーを入力する必要がある．またapiキーを用いた画像生成には料金がかかるということも注意が必要である
