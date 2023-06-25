# ウィジェットの実験
import tkinter

# ボタンを押した時に実行する関数
def button_click(event):
  # ラベルを書き換える 
  lab.configure(text=textv.get())

root = tkinter.Tk()   # ウインドウを作成

# ラベルを作成
lab = tkinter.Label(root, text='Label')  
lab.place(x=10, y=10, width=160, height=20)

textv = tkinter.StringVar()   # ウィジェット変数
textv.set('Entry')            # テキストを格納
# エントリーを作成
ent = tkinter.Entry(root, textvariable=textv)
ent.place(x=10, y=70, width=160, height=20)

# ボタンを作成
btn = tkinter.Button(root, text='Button')
btn.place(x=10, y=130, width=160, height=30)
# ボタンを押した時に実行する関数を設定
btn.bind("<Button-1>", button_click)

root.mainloop()
