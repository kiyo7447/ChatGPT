#ノーマル
alias_file="${KIYO_WIN}/Alias/aliases.txt"

#C:\User を /C/Users へ変更
#alias_file="$(echo ${KIYO_WIN}/Alias/aliases.txt |  sed -e 's/^\([a-zA-Z]\):/\/\1/' -e 's/\\/\//g')"
#C:\User を /mnt/c/Users へ変更
#alias_file="$(echo ${KIYO_WIN}/Alias/aliases.txt | sed -e 's/^\([a-zA-Z]\):/\/mnt\/\L\1/' -e 's/\\/\//g')"


# UTF-8 BOM を除去するために sed を使用
# sed '1s/^\xEF\xBB\xBF//' "$alias_file"
# UTF-8 BOM を除去するために awk を使用
# awk 'NR==1{sub(/^\xef\xbb\xbf/, "")}{print}' "$alias_file"
# UTF-8 BOM を除去するために awk を使用

alias_proc_sh="${KIYO_WIN}/Alias/alias_bash_proc.sh"

echo "#このファイルは動的生成されます。" > $alias_proc_sh

# SED/AWKは効かないのでやめる。
awk 'NR==1{sub(/^\xef\xbb\xbf/, "")}{print}' "$alias_file" | while IFS=":" read -r name value; do
    if [[ ! -z "$name" && ! $name =~ ^# ]]; then
        # Valueに $clsなどの環境変数が使えるようになります。
        # eval "value=\"$value\""

        # Debug Message
        # echo name = "$name"
        # echo value = "$value"

        # 効かなかった対応
        # shopt -s expand_aliases

        alias "$name"="$value"
        #↓ 頑張ったんですけど、aliasが効かなくて強制回避をしました。
        #
        echo "alias $name=""$value""" >> $alias_proc_sh

        # Debug Message
        # echo ■COUNT
        # alias

        # 効かなかった対応
        # export "$name"
    fi
done 

# Debug Message
# echo ■LAST
# alias

# while IFS=":" read -r alias_name common_cmd
# do
#     if [[ ! -z $alias_name  &&  ! $alias_name =~ ^# ]]
#     then
#         echo "$alias_name=$common_cmd"
#         alias "$alias_name"="$common_cmd"
#         export "$alias_name"
#     fi
# done < "$alias_file"


#Bash
echo "alias c=clear" >> $alias_proc_sh

#alias d=docker

#memo
#Windows
#   C:\Users
#Git Bash
#   /C/Users
#WSL
#   /mnt/c/User

#Git Bashでは、実行中のシェルスクリプト内で設定されたエイリアスは、
#そのシェルスクリプトの実行が終了すると破棄されます。
#そのため、スクリプトを実行しても、エイリアスが登録されていないように見えます。

