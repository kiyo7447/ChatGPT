import os
import time
import requests
from bs4 import BeautifulSoup
from urllib.parse import urljoin
from selenium import webdriver
from selenium.webdriver.chrome.options import Options

def click_free_download_button(url, user_agent):
    options = Options()
    options.add_argument(f"user-agent={user_agent}")
    options.add_argument("--headless")
    options.add_argument("--disable-gpu")
    options.add_argument("--no-sandbox")
    driver = webdriver.Chrome(options=options)

    driver.get(url)

    try:
        free_download_button = driver.find_element_by_xpath("//a[contains(text(), 'Free Download')]")
        free_download_button.click()
        time.sleep(5)
    except Exception as e:
        print(f"Error: {e}")

    driver.quit()

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
            click_free_download_button(href, user_agent)

if __name__ == "__main__":
    top_pages = [f"https://manga-zip.is/post/{i}" for i in range(1, 11)]
    folder = "downloads"

    if not os.path.exists(folder):
        os.makedirs(folder)

    user_agent = "Mozilla/5.0 (iPhone; CPU iPhone OS 15_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 Mobile/15E148 Safari/604.1"

    for page in top_pages:
        crawl(page, folder, user_agent)
