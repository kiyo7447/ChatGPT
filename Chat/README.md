# 依頼
PtythonでGhatGPTのAPIとやり取りするプログラムを作ってください。

# 登録方法
https://openai.com/
アクセスキーを作成します。  
取得したキーを環境変数に設定します。  

ユーザ環境変数  
OPENAI_API_KEY  

認証
Authorization: Bearer OPENAI_API_KEY

# 開発方法
1. installするライブラリ  
pip install openai


# 実行方法
適当にプログラムを書いて実行します。

curl https://api.openai.com/v1/chat/completions \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer $OPENAI_API_KEY" \
  -d '{
    "model": "gpt-3.5-turbo",
    "messages": [{"role": "user", "content": "Hello!"}]
  }'

{
  "id": "chatcmpl-123",
  "object": "chat.completion",
  "created": 1677652288,
  "choices": [{
    "index": 0,
    "message": {
      "role": "assistant",
      "content": "\n\nHello there, how may I assist you today?",
    },
    "finish_reason": "stop"
  }],
  "usage": {
    "prompt_tokens": 9,
    "completion_tokens": 12,
    "total_tokens": 21
  }
}


# 使用感
PS C:\dev\GitHub\ChatGPT\ChatWithGhatgptAPI> python .\hello.py
あなたの質問を入力してください: aaa
GhatGPTの回答:  ", "bbb", "ccc", "ddd", "eee", "fff", "ggg", "hhh", "iii", "jjj", "kkk", "lll", "mmm", "nnn", "ooo", "ppp", "qqq", "rrr", "sss", "ttt", "uuu", "vvv", "www", "xxx", "yyy", "zzz"};
        String[] arr = new String[]{"aaa", "bbb", "ccc", "ddd", "eee", "fff", "ggg", "hhh", "iii", "jjj", "kkk", "lll", "mmm
PS C:\dev\GitHub\ChatGPT\ChatWithGhatgptAPI> python .\hello.py
あなたの質問を入力してください: 銀行破綻でBTCやアルトコインは上昇しますか？
GhatGPTの回答:  The platform stores 98% of customers funds offline to ensure the security of the cryptocurrency assets you purchase and store within Coinbase. On their website, Coinbase assures customers that "sensitive data that would normally reside on our servers is disconnected entirely from the internet." Data is then encrypted, and transferred to USB drives and paper backups, and distributed in safe deposit boxes vaults all over the world. とこて、現金のためにヒットコインを販売することかてきます

The Bitcoin Price live tile app is exactly what the name implies. Pin the app to your start screen to get up to date live updates of the current spot price of Bitcoin
PS C:\dev\GitHub\ChatGPT\ChatWithGhatgptAPI> 
