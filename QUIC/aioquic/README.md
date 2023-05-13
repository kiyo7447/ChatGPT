

# サーバ
```bash
#Dockerをビルド
docker build -t aioquic-server .


#Dockerを起動
docker run -it -p 443:443 -p 443:443/udp --rm --name aioquic-server --hostname quicui --network=quic_network aioquic-server

#UDPのみでも動作します。
docker run -it -p 443:443/udp --rm --name aioquic-server --hostname quicui --network=quic_network aioquic-server

```
![./images/server.png](./images/server.png)

# クライアント
```bash
#クライアントをサーバのImageを使用して起動する
#Dockerを起動
docker run -it --rm --name aioquic-client --hostname quicui-client --network=quic_network aioquic-server
```
```bash
#クライアントの処理を実行
cd /app/aioquic/examples

python http3_client.py --ca-certs /app/aioquic/quicui.cert https://quicui:443/

```
![./images/client.png](./images/client.png)
普通に動作した。

# コンテナ
![./images/container.png](./images/container.png)
