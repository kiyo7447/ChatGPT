#aliases.txt
# $alias_file = Join-Path $env:KIYO_WIN -ChildPath "Alias\aliases.txt"
# Copy-Item -Path "aliases.txt" -Destination $alias_file

#Power Shell
# Copy-Item -Path "Microsoft.PowerShell_profile.ps1" -Destination $PROFILE 

#C:\Users\kiyot\OneDrive\ドキュメント\PowerShell


#新しいインストーラーは、下記の行がMicrosoft.PowerShell_profile.ps1になければ追加する。

# 環境変数からパスを取得
$kiyoWinPath = $env:KIYO_WIN

# alias_powershell.ps1 のパス
$aliasScriptPath = Join-Path -Path $kiyoWinPath -ChildPath "Alias/alias_powershell.ps1"

# 追加する行
$lineToAdd = ". `"$aliasScriptPath`""

# $PROFILE のディレクトリパスを取得
$profileDir = Split-Path -Path $PROFILE -Parent

# Microsoft.PowerShell_profile.ps1 ファイルのパス
$profilePath = Join-Path -Path $profileDir -ChildPath "Microsoft.PowerShell_profile.ps1"

# ファイルが存在しない場合、新規作成
if (-not (Test-Path -Path $profilePath)) {
    New-Item -ItemType File -Path $profilePath -Force
}

# ファイルの内容を取得
$content = Get-Content -Path $profilePath

# 指定の行が存在しない場合、追加
if (-not ($content -contains $lineToAdd)) {
    Add-Content -Path $profilePath -Value $lineToAdd
}
