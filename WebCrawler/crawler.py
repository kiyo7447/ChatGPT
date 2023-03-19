import os
import requests
from bs4 import BeautifulSoup
from urllib.parse import urljoin

def download_file(url, folder):
    response = requests.get(url)
    filename = os.path.basename(url)
    filepath = os.path.join(folder, filename)

    with open(filepath, "wb") as f:
        f.write(response.content)

def crawl(url, folder, user_agent):
    headers = {"User-Agent": user_agent}
    response = requests.get(url, headers=headers)
    soup = BeautifulSoup(response.text, "html.parser")

    for link in soup.find_all("a", title=True):
        href = link.get("href")

        if href.startswith("http"):
            target_url = href
        else:
            target_url = urljoin(url, href)

        search_sakurafile_links(target_url, folder, user_agent)

def search_sakurafile_links(url, folder, user_agent):
    headers = {"User-Agent": user_agent}
    response = requests.get(url, headers=headers)
    soup = BeautifulSoup(response.text, "html.parser")

    for link in soup.find_all("a", href=True):
        href = link.get("href")

        if "sakurafile.com" in href:
            print(f"見つかったsakurafileリンク: {href}")

if __name__ == "__main__":
    top_pages = [f"https://manga-zip.is/post/{i}" for i in range(1, 11)]
    folder = "downloads"

    if not os.path.exists(folder):
        os.makedirs(folder)

    user_agent = "Mozilla/5.0 (iPhone; CPU iPhone OS 15_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 Mobile/15E148 Safari/604.1"

    for page in top_pages:
        crawl(page, folder, user_agent)
