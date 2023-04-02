#memo
#手動でプロファイルファイルを実行する場合は、以下のコマンドを実行してください。
#. $PROFILE

#ファイルの場所
#echo $PROFILE

#$env:KIYO_WIN = "パスを設定" # 環境変数を設定
$alias_file = Join-Path $env:KIYO_WIN -ChildPath "Alias\aliases.txt"

Get-Content $alias_file | ForEach-Object {
    if (-not [string]::IsNullOrWhiteSpace($_) -and -not $_.StartsWith('#')) {
        $alias_data = $_.Split(':')
        #echo -Name $alias_data[0] -Value $alias_data[1]
        Set-Alias -Name $alias_data[0] -Value $alias_data[1]
    }
}

#Power Shell 特化
Set-Alias -Name c -Value clear
#https://mseeeen.msen.jp/windows-10-set-alias-automatically-in-powershell/
Set-Alias wget Invoke-WebRequest
Set-Alias ic Invoke-Command
