from direct.showbase.ShowBase import ShowBase

class MyGame(ShowBase):
    # 初期化メソッド
    def __init__(self):
        # 画面を生成する
        ShowBase.__init__(self)

        # 3Dオブジェクトを生成する
        self.cube1 = self.loader.loadModel("models/misc/rgbCube") # パス
        self.cube1.reparentTo(self.render) # 描画
        self.cube1.setScale(1, 1, 1) # 大きさ
        self.cube1.setPos(0, 5, 0) # 位置
        self.cube1.setHpr(45,0,45) # 向き

game = MyGame()
game.run()