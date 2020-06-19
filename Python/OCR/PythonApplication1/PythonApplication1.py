import os
from pathlib import Path
from pdf2image import convert_from_path

from PIL import Image
import pyocr
import pyocr.builders

import re

# poppler/binを環境変数PATHに追加する
poppler_dir = Path(__file__).parent.absolute() / "poppler/bin"
# class pathlib.Path(*pathsegments)

# __file__
# PurePath.parent
# p = PurePosixPath('/a/b/c/d')
# p.parent
# PurePosixPath('/a/b/c')

os.environ["PATH"] += os.pathsep + str(poppler_dir)

# PDFファイルのパス
pdf_path = Path("./pdf_file/20200407085927.pdf")

# PDF -> Image に変換（150dpi）
pages = convert_from_path(str(pdf_path), 150)

# 画像ファイルを１ページずつ保存
image_dir = Path("./image_file")
for i, page in enumerate(pages):
    file_name = pdf_path.stem + "_{:02d}".format(i + 1) + ".jpeg"
    image_path = image_dir / file_name
    # JPEGで保存
    page.save(str(image_path), "JPEG")

# 1.インストール済みのTesseractのパスを通す
path_tesseract = "C:\Program Files\Tesseract-OCR"
if path_tesseract not in os.environ["PATH"].split(os.pathsep):

# os.environ[]
# os.path.split(path)
# os.pathsep

    os.environ["PATH"] += os.pathsep + path_tesseract

# 2.OCRエンジンの取得
tools = pyocr.get_available_tools()
tool = tools[0]

# 3.原稿画像の読み込み
img_org = Image.open(image_path)

# 4.ＯＣＲ実行
builder = pyocr.builders.TextBuilder()

result = tool.image_to_string(img_org, lang="jpn", builder=builder)

# 5.テキストファイルの整形（空白文字をカンマへ）
tresult = re.sub(r" +", ",", result)



print(result)

output_path = 'C:/Users/USER101/Documents/result.txt'
f = open(output_path, 'w', encoding='utf-8')
f.write(tresult)
f.close()

with open(output_path, mode='rt', encoding='utf-8') as f:
    for line in f:
        print(line)