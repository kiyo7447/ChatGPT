
# 依頼
Webのクローラープログラムを作ってください。
ページのリンクを辿ってそこにあるファイルのダウンロードできるファイルをダウンロードするで処理を作ってください。
言語は、Pythonです。

指定したページから下記の条件で検索をかけます。
・title属性もつリンクは先は調べる。
　・その先にあるリンクURLに「sakurafile.com」が含まれているページを調べる。
　・
・クローラー対象のトップページを10個指定できる
・トップページにはダウンロードが対象がない。
・スマホを偽装して動いてください。

対象のURLは下記の1～10にしてください。
https://manga-zip.is/post/1
https://manga-zip.is/post/2
https://manga-zip.is/post/3
～
https://manga-zip.is/post/9
https://manga-zip.is/post/10



## インストール
pip install requests
pip install beautifulsoup4


# 依頼
見つかったsakurafileのリンク先にあるFree Downloadボタンを押してください。

## Selenium（Chrome）を入れる場合のインストール
pip install selenium

PythonでreCAPTCHA V2を突破する方法
https://pythonbasics.org/solve-captcha/

