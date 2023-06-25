from direct.showbase.ShowBase import ShowBase
import sys
# テキスト表示
from direct.gui.OnscreenText import OnscreenText
from panda3d.core import TextNode
# 衝突検出マスク
from panda3d.core import BitMask32
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
        self.maze = loader.loadModel("models/maze")
        self.maze.reparentTo(render)
        # 迷路の壁の衝突検出用マスク
        self.walls = self.maze.find("**/wall_collide")
        self.walls.node().setIntoCollideMask(BitMask32.bit(0))
        # 迷路の地面の衝突検出用マスク
        self.mazeGround = self.maze.find("**/ground_collide")
        self.mazeGround.node().setIntoCollideMask(BitMask32.bit(1))
        # 迷路の穴の衝突検出用マスク
        self.loseTriggers = []
        for i in range(6):
            trigger = self.maze.find("**/hole_collide" + str(i))
            trigger.node().setIntoCollideMask(BitMask32.bit(0))
            trigger.node().setName("loseTrigger")
            self.loseTriggers.append(trigger)

        # ボールオブジェクトの設定

        # ゴールオブジェクトの設定

        # ライトの設定

        # start関数の呼び出し
        self.start()

    # start関数の定義
    def start(self):
        # ボールの初期位置の設定

        # rollTask関数の呼び出し
        taskMgr.remove("rollTask")
        self.mainLoop = taskMgr.add(self.rollTask, "rollTask")

    # rollTask関数の定義
    def rollTask(self, task):
        dt = globalClock.getDt()
        if dt > .2:
            return task.cont
    
        # ボールが衝突したときの処理の分岐
        
        # ボールの速度や向きの計算
        
        # 迷路の傾きのマウス操作
        if base.mouseWatcherNode.hasMouse():
            mpos = base.mouseWatcherNode.getMouse()
            self.maze.setP(mpos.getY() * -10)
            self.maze.setR(mpos.getX() * 10)
        
        return task.cont

    # groundCollideHandler関数の定義

    # wallCollideHandler関数の定義

    # loseGame関数の定義

    # winGame関数の定義

game = BallInMazeDemo()
game.run()