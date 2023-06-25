from direct.showbase.ShowBase import ShowBase

from panda3d.core import CollisionTraverser, CollisionNode
from panda3d.core import CollisionHandlerQueue, CollisionBox

class MyGame(ShowBase):
    # 初期化メソッド
    def __init__(self):
        # 画面を生成する
        ShowBase.__init__(self)
        # カメラを制御する
        self.disableMouse() # カメラのマウス制御をOFF
        camera.setPosHpr(0, -20, 5, 0, -15, 0) # カメラの位置と向き

        # cube1オブジェクトを生成する
        self.cube1 = self.loader.loadModel("models/misc/rgbCube") # パス
        self.cube1.reparentTo(self.render) # 描画
        self.cube1.setScale(1, 1, 1) # 大きさ
        self.cube1.setPos(0, -10, 0) # 位置
        self.cube1.setHpr(0, 0, 0) # 向き

        # 衝突検出オブジェクトcol1を3Dオブジェクトcube1に追加する
        c = CollisionNode('col1') # 名前
        c.addSolid(CollisionBox(0, 0.5, 0.5, 0.5)) # 形状
        cube1_c = self.cube1.attachNewNode(c) # 追加

        # cube2オブジェクトを生成する
        self.cube2 = self.loader.loadModel("models/misc/rgbCube") # パス
        self.cube2.reparentTo(self.render) # 描画
        self.cube2.setScale(1, 1, 1) # 大きさ
        self.cube2.setPos(0, 0, 0) # 位置
        self.cube2.setHpr(0, 0, 0) # 向き

        # 衝突検出オブジェクトcol2を3Dオブジェクトcube2に追加する
        c = CollisionNode('col2') # 名前
        c.addSolid(CollisionBox(0, 0.5, 0.5, 0.5)) # 形状
        cube2_c = self.cube2.attachNewNode(c) #追加

        # 右キーが入力されたらup_key関数を呼び出す
        self.accept( "arrow_up", self.up_key )

        # rollTask関数をタスクマネージャーに追加する
        self.taskMgr.add(self.rollTask, "rollTask")

        # 衝突ハンドラーにcol1とcol2を追加する
        self.cTrav = CollisionTraverser()
        self.cHandler = CollisionHandlerQueue()
        self.cTrav.addCollider(cube1_c, self.cHandler)
        self.cTrav.addCollider(cube2_c, self.cHandler)
        self.cTrav.showCollisions(render)

    # up_key関数
    def up_key(self):
        # cube1をy軸方向に1動かす
        self.cube1.setY( self.cube1.getY() + 1 )

    # rollTask関数
    def rollTask(self, task):
        velocity = 30 # 速さ
        dt = globalClock.getDt() # フレーム経過時間
        angle = velocity * dt # フレーム更新ごとに回転する角度の大きさ
        self.cube2.setH(self.cube2, angle) # cube2の向き

        # 衝突判定
        # 検出された衝突の数だけ繰り返す
        for i in range(self.cHandler.getNumEntries()):
            # 衝突検出オブジェクトがcol2ならhideCube関数を呼び出す
            entry = self.cHandler.getEntry(i)
            name = entry.getIntoNode().getName()
            if name == "col2":
                self.hideCube()

        # 次のフレームで再度rollTask関数を実行する
        return task.cont

    # hideCube関数
    def hideCube(self):
        # cube2を非表示にする
        self.cube2.hide()
        # rollTask関数の実行を停止する
        self.taskMgr.remove('rollTask')

game = MyGame()
game.run()