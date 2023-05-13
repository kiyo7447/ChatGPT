# Ubuntu 20.04とPython3.8をベースにする
FROM ubuntu:20.04
FROM python:3.8

# 環境変数を設定
ENV PYTHONDONTWRITEBYTECODE 1
ENV PYTHONUNBUFFERED 1

# 作業ディレクトリを設定
WORKDIR /app

# 必要なパッケージをインストール
# https://github.com/aiortc/aioquic/tree/main
RUN apt-get update && apt-get install -y \
    net-tools \
    git \
    openssl \
    libssl-dev \
    python3-dev \
    && rm -rf /var/lib/apt/lists/*

# Pythonの依存関係をコピーしてインストール
# COPY requirements.txt ./
# RUN pip install --no-cache-dir -r requirements.txt

# aioquicをクローン
RUN git clone https://github.com/aiortc/aioquic.git


# ワーキングディレクトリをaioquicに設定
WORKDIR /app/aioquic

# setup.pyが存在することを確認
#RUN ls

# aioquicとその依存関係をインストール
RUN pip install -e .

# wsproto、httpbinをインストール
#RUN pip install wsproto httpbin
#↓
# https://github.com/aiortc/aioquic/tree/main/examples
RUN pip install asgiref dnslib "flask<2.2" httpbin starlette "werkzeug<2.1" wsproto


# サーバーコードをコピー
# quicui.key quicui.cert
COPY . .

# サーバーを起動
CMD [ "python", "/app/aioquic/examples/http3_server.py", \
    "--certificate", "/app/aioquic/quicui.cert", \
    "--private-key", "/app/aioquic/quicui.key", \
    "--host=0.0.0.0", \
    "--port=443" ]
