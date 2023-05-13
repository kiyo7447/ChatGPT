
# Container Imageを作成する
docker build -t powershell-ubuntu .

# Containerを実行する
docker run -it --rm --name powershell-ubuntu --hostname pshost --network=local_network powershell-ubuntu

# 結果
![./images/terminal.png](./images/terminal.png)

