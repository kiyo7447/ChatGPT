# ベースイメージを指定します
FROM ubuntu:20.04

# PowerShellのインストールに必要なパッケージをインストールします
RUN apt-get update \
    && apt-get install -y wget apt-transport-https \
    && wget -q https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb \
    && dpkg -i packages-microsoft-prod.deb \
    && apt-get update \
    && apt-get install -y powershell

COPY test.ps1 .

# コンテナ起動時にPowerShellを起動します
CMD ["pwsh"]

