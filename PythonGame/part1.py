# -*- coding: utf-8 -*-
import pygame  # ゲーム作成用のpygameライブラリ
import sys  # システム関連のライブラリ
import random  # 乱数関連のライブラリ

import math  # 数学関連のライブラリ
import time  # 時間関連のライブラリ
import os  # ファイル操作関連のライブラリ
import datetime  # 日付関連のライブラリ
import csv  # csvファイル操作関連のライブラリ
import codecs  # 文字コード関連のライブラリ

pygame.init()  # pygameの初期化
seFalse = pygame.mixer.Sound("false.mp3")  # 走る音
seFalse.play() # 走る音を再生

