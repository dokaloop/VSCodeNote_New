import os
import openai

os.environ['OPENAI_API_KEY'] = 'sk-6016da4740a14de08c591278eb6684c0'
os.environ['OPENAI_BASE_URL'] = 'https://api.deepseek.com/v1'

client = openai.OpenAI()


input_file = 'song_names.txt'
output_file = 'outputSongsName.txt'

# 打开原始TXT文件并读取内容
with open('song_names.txt', 'r', encoding='utf-8') as original_file:
    content = original_file.read()


def ask(question):
    response = client.chat.completions.create(
        model="deepseek-chat",
        messages=[
            {"role": "system", "content": "You are a helpful assistant"},
            {"role": "user", "content": question},
        ],
        stream=False
    )
    return response.choices[0].message.content



processed_content = ask('从下一个"niyaochulidewenziruxia"开始是你要处理的文本，处理文本要求：请将以下由图片识别的文字文本其中是歌名的部分转换成这种格式："歌名:歌手名字\n"输出字符串。有些文本只有歌手名字，文本附近没有歌名的，请选取该歌手三个热门歌曲按照以上格式输出字符串。niyaochulidewenziruxia\n'+content)


# 将处理后的内容写入新的TXT文件
with open('outputSongsName.txt', 'w', encoding='utf-8') as processed_file:
    processed_file.write(processed_content)

# 文件会在with语句块结束时自动关闭