line1='source "$KIYO_WIN/Alias/alias_bash_init.sh"'
line2='source "$KIYO_WIN/Alias/alias_bash_proc.sh"'

# ユーザーのホームディレクトリにある .bashrc ファイル
bashrc_file="$HOME/.bashrc"

# line1が.bashrcファイルに既に存在するかどうかを確認
if ! grep -Fxq "$line1" "$bashrc_file"; then
    # 行が存在しない場合、.bashrc ファイルの末尾に追加
    echo "$line1" >> "$bashrc_file"
    echo "Line1 added to .bashrc file."
else
    echo "Line1 already exists in .bashrc file."
fi

# line2が.bashrcファイルに既に存在するかどうかを確認
if ! grep -Fxq "$line2" "$bashrc_file"; then
    # 行が存在しない場合、.bashrc ファイルの末尾に追加
    echo "$line2" >> "$bashrc_file"
    echo "Line2 added to .bashrc file."
else
    echo "Line2 already exists in .bashrc file."
fi
