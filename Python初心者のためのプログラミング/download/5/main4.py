from direct.showbase.ShowBase import ShowBase
import sys
# テキスト表示
from direct.gui.OnscreenText import OnscreenText
from panda3d.core import TextNode
# 衝突検出マスク
from panda3d.core import BitMask32
# 衝突判定
from panda3d.core import CollisionTraverser, CollisionNode
from panda3d.core import CollisionHandlerQueue, CollisionRay
# ボールの速度計算
from panda3d.core import LVector3, LRotationf
ACCEL = 70
MAX_SPEED = 5
MAX_SPEED_SQ = MAX_SPEED ** 2
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
        self.ballRoot = render.attachNewNode("ballRoot")
        self.ball = loader.loadModel("models/ball")
        self.ball.reparentTo(self.ballRoot)
        # ボールの衝突検出用のマスク
        self.ballSphere = self.ball.find("**/ball")
        self.ballSphere.node().setFromCollideMask(BitMask32.bit(0))
        self.ballSphere.node().setIntoCollideMask(BitMask32.allOff())
        # ボールが床と衝突したときの位置を知る光線
        self.ballGroundRay = CollisionRay()
        self.ballGroundRay.setOrigin(0, 0, 10)
        self.ballGroundRay.setDirection(0, 0, -1)
        # 光線の衝突検出用のマスク
        self.ballGroundCol = CollisionNode('groundRay')
        self.ballGroundCol.addSolid(self.ballGroundRay)
        self.ballGroundCol.setFromCollideMask(BitMask32.bit(1))
        self.ballGroundCol.setIntoCollideMask(BitMask32.allOff())
        self.ballGroundColNp = self.ballRoot.attachNewNode(self.ballGroundCol)
        # 衝突ハンドラーにボールと光線を追加
        self.cTrav = CollisionTraverser()
        self.cHandler = CollisionHandlerQueue()
        self.cTrav.addCollider(self.ballSphere, self.cHandler)
        self.cTrav.addCollider(self.ballGroundColNp, self.cHandler)

        # ゴールオブジェクトの設定

        # ライトの設定

        # start関数の呼び出し
        self.start()

    # start関数の定義
    def start(self):
        # ボールの初期位置の設定
        startPos = self.maze.find("**/start").getPos()
        self.ballRoot.setPos(startPos)
        self.ballV = LVector3(0, 0, 0)
        self.accelV = LVector3(0, 0, 0)

        # rollTask関数の呼び出し
        taskMgr.remove("rollTask")
        self.mainLoop = taskMgr.add(self.rollTask, "rollTask")

    # rollTask関数の定義
    def rollTask(self, task):
        dt = globalClock.getDt()
        if dt > .2:
            return task.cont
    
        # ボールが衝突したときの処理の分岐
        for i in range(self.cHandler.getNumEntries()):
            entry = self.cHandler.getEntry(i)
            name = entry.getIntoNode().getName()
            if name == "wall_collide":
                self.wallCollideHandler(entry)
            elif name == "ground_collide":
                self.groundCollideHandler(entry)
            elif name == "loseTrigger":
                self.loseGame(entry)
            elif name =="goalCol":
                self.winGame(entry)

        # ボールの速度や向きの計算
        self.ballV += self.accelV * dt * ACCEL
        if self.ballV.lengthSquared() > MAX_SPEED_SQ:
            self.ballV.normalize()
            self.ballV *= MAX_SPEED
        self.ballRoot.setPos(self.ballRoot.getPos() + (self.ballV * dt))
        prevRot = LRotationf(self.ball.getQuat())
        axis = LVector3.up().cross(self.ballV)
        newRot = LRotationf(axis, 45.5 * dt * self.ballV.length())
        self.ball.setQuat(prevRot * newRot)
        
        # 迷路の傾きのマウス操作
        if base.mouseWatcherNode.hasMouse():
            mpos = base.mouseWatcherNode.getMouse()
            self.maze.setP(mpos.getY() * -10)
            self.maze.setR(mpos.getX() * 10)
        
        return task.cont

    # groundCollideHandler関数の定義
    def groundCollideHandler(self, colEntry):
        newZ = colEntry.getSurfacePoint(render).getZ()
        self.ballRoot.setZ(newZ + .4)

        norm = colEntry.getSurfaceNormal(render)
        accelSide = norm.cross(LVector3.up())
        self.accelV = norm.cross(accelSide)

    # wallCollideHandler関数の定義
    def wallCollideHandler(self, colEntry):
        norm = colEntry.getSurfaceNormal(render) * -1 # 壁の法線
        curSpeed = self.ballV.length() # 現在の速度
        inVec = self.ballV / curSpeed # 進行方向
        velAngle = norm.dot(inVec) # 角度
        hitDir = colEntry.getSurfacePoint(render) - self.ballRoot.getPos()
        hitDir.normalize()

        hitAngle = norm.dot(hitDir)
        
        if velAngle > 0 and hitAngle > .995:
            reflectVec = (norm * norm.dot(inVec * -1) * 2) + inVec
            self.ballV = reflectVec * (curSpeed * (((1 - velAngle) * .5) + .5))
            disp = (colEntry.getSurfacePoint(render) -
                    colEntry.getInteriorPoint(render))
            newPos = self.ballRoot.getPos() + disp
            self.ballRoot.setPos(newPos)

    # loseGame関数の定義

    # winGame関数の定義

game = BallInMazeDemo()
game.run()