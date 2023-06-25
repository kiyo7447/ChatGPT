import tkinter as tk
from tkinter import messagebox

root = tk.Tk()
root.geometry('300x150')

txt = tk.Entry(width=20)
txt.pack(pady=50)

# ハンドラ関数
def click(event):
  messagebox.showinfo('メッセージ', txt.get())

# Labelウィジェットの生成
label = tk.Label(root,
                 text='ここをクリック',
                 foreground='red')

# Labelウィジェットの配置
label.pack()
# ハンドラ関数を設定
label.bind("<Button-1>", click)

print(root.children)

root.mainloop()


