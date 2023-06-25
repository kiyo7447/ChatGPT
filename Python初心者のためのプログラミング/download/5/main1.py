from direct.showbase.ShowBase import ShowBase
import sys
# テキスト表示
from direct.gui.OnscreenText import OnscreenText
from panda3d.core import TextNode
# 衝突検出マスク

# 衝突判定

# ボールの速度計算

# インターバル

# ゴールの衝突判定

# ライトと素材

class BallInMazeDemo(ShowBase):
    # init関数の定義
    def __init__(self):
        # 画面の生成
        ShowBase.__init__(self)

        # カメラの設定
        self.disableMouse() # カメラマウス制御 OFF
        camera.setPosHpr(11, -11, 25, 45, -60, 0) # カメラの位置
        
        # Escキーでプログラムの終了
        self.accept("escape", sys.exit)
        # テキストの表示
        # windowsの場合
        font = loader.loadFont('/c/Windows/Fonts/msgothic.ttc')
        # macの場合
        # font = loader.loadFont('/System/Library/Fonts/Hiragino Sans GB.ttc')
        # タイトル文字を表示する
        self.title = \
            OnscreenText(text="ボールをゴール地点まで運べ！",
                         parent=base.a2dBottomRight, align=TextNode.ARight,
                         fg=(1, 1, 1, 1), pos=(-0.1, 0.1), scale=.08, font=font,
                         shadow=(0, 0, 0, 0.5))
        # サブタイトル文字を表示する
        self.instructions = \
            OnscreenText(text="マウスを動かすと迷路を傾けることができます",
                         parent=base.a2dTopLeft, align=TextNode.ALeft,
                         fg=(1, 1, 1, 1), pos=(0.1, -0.15), scale=.06, font=font,
                         shadow=(0, 0, 0, 0.5))

        # 迷路オブジェクトの設定

        # ボールオブジェクトの設定

        # ゴールオブジェクトの設定

        # ライトの設定

        # start関数の呼び出し

    # start関数の定義
        # ボールの初期位置の設定
        
        # rollTask関数の呼び出し

    # rollTask関数の定義
        # ボールが衝突したときの処理の分岐

        # ボールの速度や向きの計算

        # 迷路の傾きのマウス操作

    # groundCollideHandler関数の定義

    # wallCollideHandler関数の定義

    # loseGame関数の定義

    # winGame関数の定義

game = BallInMazeDemo()
game.run()