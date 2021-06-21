# DennouCoil

電脳コイル(アニメ)の世界をイメージ。<br>
メタバグ(宝石のようなもの)を集めたり、電脳ペットを連れて歩く事が出来る。<br>

# DEMO

<p align="center">
  <img src="readme_img/exampleRun.gif" width="266">
</p>

# Implementation

- ゲーミ中の天気と現実世界の天気を同期<br>
気象庁のwebサイトにリクエストを送り、レスポンスで返ってきたJSON形式の天気予報情報をパース。<br>
本日の天気予報の値に応じて、skyboxやlightの変更だったりパーティクルで雨を表現したり実装。

- NPCの移動<br>
NPCである電脳ペットが、playerの動きに合わせステージ上を追いかける動きをnavmeshを使い実装。

# Usage

- "↑↓→←"ボタン→player移動<br>
- "space"ボタン→ジャンプ<br>
- メタバグに衝突→メタバグ取得<br>
- "p"ボタン→取得したメタバグ数を確認するWindowの表示・非表示切替。<br>

# Author

- 伊島悠矢
- b.ald.m.wn@gmail.com