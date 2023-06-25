import tkinter as tk

# ウインドウ（トップレベルTkウィジェット）を生成
root = tk.Tk()
# ウインドウの中身の大きさを指定
root.geometry('300x150')

# Entryウィジェットの生成と配置
txt = tk.Entry(width=20)
txt.pack(pady=50)

# ウインドウの子ウィジェットを表示
print(root.children)

# ウインドウを表示
root.mainloop()


