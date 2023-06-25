from direct.showbase.ShowBase import ShowBase

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

        # cube2オブジェクトを生成する
        self.cube2 = self.loader.loadModel("models/misc/rgbCube") # パス
        self.cube2.reparentTo(self.render) # 描画
        self.cube2.setScale(1, 1, 1) # 大きさ
        self.cube2.setPos(0, 0, 0) # 位置
        self.cube2.setHpr(0, 0, 0) # 向き

        # 右キーが入力されたらup_key関数を呼び出す
        self.accept( "arrow_up", self.up_key )

        # rollTask関数をタスクマネージャーに追加する
        self.taskMgr.add(self.rollTask, "rollTask")

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
        
        # 次のフレームで再度rollTask関数を実行する
        return task.cont

game = MyGame()
game.run()