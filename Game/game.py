print("Hello, World!")

10+1
# ほげほげ
total = 0

for i in range(1, 11):
    total += i

print("1から10までの合計は:", total)


# pythonのゲーム
import random

print("数字当てゲームを始めます！")
print("1から20までの数値を当ててください。")

number = random.randint(1, 20)
guess = None
count = 0

while guess != number:
    # ユーザの入力が数字
    while True:
        user_input = input("予想した数字を入力してください: ")
        
        if user_input.isdigit():
            print("入力された値は数字です。")
            break
        else:
            print("入力された値は数字ではありません。再度入力してください。")

    # 
    guess = int(user_input)
    count += 1
    
    if guess < number:
        print("もっと大きな数を予想してください。")
    elif guess > number:
        print("もっと小さな数を予想してください。")
    else:
        print(f"正解です！{count}回目で当てました。")

print("ゲームを終了します。お疲れ様でした！")


print("end")
