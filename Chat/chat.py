import openai
import os

# APIキーを設定
openai.api_key = os.environ['OPENAI_API_KEY']

def chat_with_gpt(prompt, model="gpt-3.5-turbo", tokens=150):
    messages = [
        {"role": "system", "content": "You are a helpful assistant."},
        {"role": "user", "content": prompt}
    ]

    response = openai.ChatCompletion.create(
        model=model,
        messages=messages,
        max_tokens=tokens,
        n=1,
        temperature=0.5,
    )

    message = response.choices[0].message.content;
    return message

if __name__ == "__main__":
    user_prompt = input("あなたの質問を入力してください: ")
    response = chat_with_gpt(user_prompt)
    print("GPTの回答: ", response)
