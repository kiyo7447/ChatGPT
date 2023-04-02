import shutil

def copy_file(src, dest):
    try:
        shutil.copy2(src, dest)
        print(f'ファイルがコピーされました: {src} -> {dest}')
    except FileNotFoundError as e:
        print(f'ファイルが見つかりません: {e.filename}')
    except IOError as e:
        print(f'入出力エラーが発生しました: {e}')

# 使用例
source_file = 'source.txt'
destination_file = 'destination.txt'

copy_file(source_file, destination_file)
