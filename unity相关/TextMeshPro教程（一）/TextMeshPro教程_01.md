## TextMeshPro教程_01
https://www.youtube.com/watch?v=gVialGm65Yw&list=PLg0yr4zozmZX0dJZ-XNa4v0i_kAVx2sfY  

### 一 . Quickstart to TextMeshPro Basics - and how to level up
#### 1. 怎样import字体  
（1）导入字体  
（2）对字体右键-->Create-->Text Mesh Pro-->Font Asset.  
（3）然后把它拽过来。  
![picture 0](images/fd97b7ab3511de91aacd0eec22d10ad61dd5523bc2a0977d2a1045abe0cc0024.png)  

#### 2 . 脚本可以这样写  
```C#
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    [SerializeField] private TMP_Text textbox;
    [SerializeField] private string textToDisplay;

    public void SetTextboxText() {
        textbox.text = textToDisplay;
        textbox.color = Color.white;
        textbox.fontSize = 20;
    }
}
```

#### 3 . The Text Mesh Pro Default Settings 
You can find Text Mesh Pro's settings under :   
Edit -->  Project Settings --> Text Mesh Pro    
![picture 8](images/3d4dad6a31f39b2b00a69ea07d68e8c25a964fcdb0ded74e7cd2c233b9113e0c.png)  


#### 4 . Setting parts of your text bold or recolor 
For example, you mignt want to display some parts of your text in bold - but clicking this button sets your whole text to bold instead.  
![picture 1](images/59c05b08d07134bb4a1d65b08593d0c04a2c9c6923fce961a685982708279ff7.png)  
To get your desired result, you need to know about tags.  
Tags are small things you add to your string to mark certain parts in a way Text mesh Pro can understand.  
![picture 2](images/ecea45e1046b6588f9400b890001c8ea0a99506208850d8a0401a6505727e29a.png)  
例子：  
![picture 3](images/5830802bfbf8b8c57454e07d6eaa84d721ae82f06d07c054b4e682a1384721df.png)   
![picture 4](images/2dc0e1c0e6fccfd14e04780b9e6e5c5a12f7d955f70e0b11ab2fba4de880d69e.png)  
These tags are part of the so called "rich text" capabilities and there are dozens of styles you can use. 
![picture 5](images/2eaab3aa4bf363dd861a8aa460da7ab44e5ddce5b598cdea6d8fe41d8648bea5.png)  
cheet sheet:  
[cheet sheet链接](./cheetSheet.pdf)

TMP的doc里也有关于rich text tags的内容：  
https://docs.unity3d.com/Packages/com.unity.textmeshpro@3.2/manual/RichTextSupportedTags.html  

#### 5 . 字体动画
If you enjoy cool text effects like shivering or jumping, maybe the paid asset called Text Animator, created by Febucci, is someting you might enjoy.  
![picture 6](images/9861897725d275e1bdeef5764d53450b7484b1e345b7e5aa9dab7d807cd8c4f0.png)  
在这个视频有教：  
![picture 7](images/f8bdd21b00ae06d82fdd69eccedd10ae42b4a58e5c4a22abb4945d0d99160c63.png)  

### 二 . TextMeshPro Text Styles make working with Texts in Unity so much easier!
#### 1 . 
All of these Text Styles can be found in Text Mesh Pro's Style folder,  
![picture 9](images/dbddb50188edb7a81d53e882d4b3534177066005d6dbd3c4b6069bd985a69b1d.png)  
in the aptly named "Default Style Sheet"  

![picture 11](images/a56f832e5bd65950765222db12591d6447fd3f669e2c2a3669f7d692ebda2ecf.png)  


![picture 10](images/02a216c97238ebdbdb9d740af5e82df2fa35786ad3ead4fb1d18401cb3209950.png)  

If you have ever worked with CSS before, you will probably understand what's going on here at first glance.  

#### 2 .   
改变字体大小：  
![picture 12](images/7cc74a51283dd4019c24b7f212eebe47baba85783833d36326abb20bab929479.png)  
![picture 13](images/9f050f6a840c7ac76c23d3bd71d9e90ec89762d8890cc4d33178ad5c812143ac.png)  
BTW "em" refers to the typographic size of roughly one uppercase latter M in your chosen font.    
Thus, 1em means the size of the font will stay the same as set, while a size of 2em doubles it.  
![picture 14](images/8b2859b85e9fb349e87fbecbeee8a2eff1a5fc05d1662a3dea39d001bade61de.png)  

在styles里的字体要放在这个文件夹下面：  
Edit -->  Project Settings --> Text Mesh Pro  
![picture 15](images/c490a23597943fc5608481e8bbc732d90fa9aeb8e19dc5d84dba03d3d2bda84d.png)  

![picture 16](images/813ca937751399705df79157f9dbc2e636dcf4a332d4e487b765384b0222342e.png)  
还可以把星星*删了  

#### 3 . 
通过这个按钮可以删去自己不想要的style ：  
![picture 17](images/401829d4cf3c77545aae3d10525fcf75f9907bc261b9c8fb26936af1caf4dd1d.png)  

使用Style可以改一个而变全部。 
![picture 19](images/d8783a1d298318a76b1e038ede2a4a1c659ccca512ee467f707ce3b47b725d4c.png)  
![picture 20](images/9c9792bb285e07919a28ab392293ded010d84b8ba275ef60b000e3e2a0377b2d.png)  

#### 4 . `<style = "Bold">`
新建一个Bold  
![picture 21](images/6c9b1776090e03c5e7331b11b7b7744bc2053a66675c1988a57f1ab6a915edf8.png)  
![picture 22](images/8726c250858b6ce1fbb45b9b4cc7a72b0507bc5de6a8266059182186350c1c15.png)  

You can use the style tag inside of stylesheets, too, so you can even further tweak how the results should look like!    
![picture 23](images/b5401d0648c95c305665cf88506f48840d3ed82c7450325ac61dc17899cc5b22.png)  

### 三 . How to correctly use font weight and font styles in Unity TextMeshPro   
font family:  
![picture 37](images/02587fff3e4e8f5c0883803fde2680005ff4b834cfe61f5bcbabcd1de3fdbb41.png)  

#### 1 . 问题
![picture 24](images/c4eb076a017f1850e4fa35d766a389381aae941a986638e7112eb30972a1a1ad.png) 
These different styles are important, because if your font doesn't have a dedicated Bold weight, for example, your system will try to be helpful and make one for you. The results can be quite hideous, tho. Also, this happens all the time while working with TextMeshPro, for example.  

用这个是因为可能出现下面的问题：  
![picture 26](images/ef7f2d2abf24ca15dddef609782a1e51e1276d8e0a2dd393820dae902969744b.png)  

I am setting the font in my text field to bold via the button, so it becomes clear when the switch form faux to true happens. You can try it with italic, too.   
点击这个字体就可以看到这个界面：  
![picture 27](images/1632960900a76ca50f9c3871352e4af8cbf6e26a10d6db72b9c8eb49bc9e3177.png)  

#### 2 . 解决办法  
When I started out, I created a Font Asset for every style and dropped it in by hand into every text field and saving them as prefabs.  
![picture 29](images/b172a40cf678f74db985be9c8f4fd9ec6828f1f4e0b1df0f105638b31af32d76.png)  

![picture 30](images/c240ef2ad70a969b754448ae928e96d87b5147c0db9bc47a8144eb9ee3661e1e.png)  

主要是调整不同效果的意大利形和非意大利形的区分。  
从100到900的尺寸分别对应不同的名称。  
比如100就是Thin。  
200是Extra-Light。  

可以通过这里来访问font weight。  
![picture 36](images/6cea66f7deebaa5f1bd00ae7c52b0e0aefcd03c2c22bc438817594c27de15b34.png)  

也可以通过这里：  
CSS语言是这样子使用font-weight。      
![picture 35](images/319d151556572e7f737988bf25806cd0caf5316ed4fc788cea8a092b86944919.png)  
也可以把这些加在tag里面。  

### 四 . Generate TextMesh Pro Style Tags with a click - let's build a tool!

Amazing as they are, if you are not used to writing tags, they can be a bit daunting to get correct and looking good.  
Let's build a tiny tool that will automate this process for us.   
At the end of this tutorial, we will have build this here: a script you can throw on a Gameobject that has a TMP Text component attached and it will generate the tags based on your choices.  
You'll just have to copy-paste them, since there's currently no way to automate that particular part.  
The neat thing is, you only need ths script rarely - thus I'm fine with it. Living its life as a monobehaviour instead of building a dedicated etitor tool.  
不经常用的功能可以做成monobehaviour的script而不是编辑器工具。  

Set your style up once, copy, paste and remove the component afterwards.  

#### 1. 
新建脚本 TMPStyleSheetCreatorPROTOTYPE.cs  

#### 2.  
As you can see, when you created a font asset in TMP, this part gets added.  
![picture 31](images/87fa0a7a91cbd3da6f087ac4a7932cc2d10283a169e1791607abdd2ff7b29464.png)  
But if we want to use it as a font name for our font-tag, we need to get rid of it, since it doesn't work if we keep it.  
![picture 32](images/d671e80b9201ed4906676054361873ec9586667181e237d29e84cde901591a9f.png)  
Thus, we will replace it with emptyness.  

代码：  
```C#
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TMPro;
using UnityEngine;

public class TMPStyleSheetCreatorPROTOTYPE : MonoBehaviour
{
    public TMP_Text Textbox;
    public string OpeningTags;
    public string ClosingTags;

    public TextWeight textWeight;

    [ContextMenu("Read Values from TMP")]
    public void ReadValuesFromTMP()
    {
        StringBuilder openSB = new StringBuilder();
        StringBuilder closeSB = new StringBuilder();

        if ((Textbox.fontStyle & FontStyles.Bold) != 0)
        {
            //First, have it check if I am using a font style and if that style is Bold. 
            openSB.Append("<b>");
            closeSB.Append("</b>");
        }

        if ((Textbox.fontStyle & FontStyles.Italic) != 0)
        {
            openSB.Append("<i>");
            closeSB.Append("</i>");
        }
        if ((Textbox.fontStyle & FontStyles.UpperCase) != 0)
        {
            openSB.Append("<uppercase>");
            closeSB.Append("</uppercase>");
        }
        if ((Textbox.fontStyle & FontStyles.LowerCase) != 0)
        {
            openSB.Append("<lowercase>");
            closeSB.Append("</lowercase>");
        }

        string fontAsset = Textbox.font.ToString();
        fontAsset = fontAsset.Replace("(TMPro.TMP_FontAsset)", string.Empty);

        openSB.Append($"<font=\"{fontAsset}\">");
        closeSB.Append("</font>");

        float textSize = Textbox.fontSize;
        openSB.Append($"<size={textSize}pt>");
        closeSB.Append("</size>");

        Color textColor = Textbox.color;
        string textColorRGB = ColorUtility.ToHtmlStringRGB(textColor);
        openSB.Append($"<color=#{textColorRGB}>");
        closeSB.Append("</color>");
        //Color on the other hand is less intuitive.
        //First, we need to read the value, then convert it to an RGB color that works with TMP's tags.
        //finally, add it to our string builders like this.  

        float characterSpacing = Textbox.characterSpacing;
        characterSpacing /= 100;
        string cSpacing = characterSpacing.ToString("N3", CultureInfo.InvariantCulture);

        if (characterSpacing != 0)
        {
            openSB.Append($"<cspace={cSpacing}em>");
            closeSB.Append("</cspace>");
        }

        float lineSpacing = Textbox.lineSpacing;
        lineSpacing /= 100;
        string lSpacing = lineSpacing.ToString("N3", CultureInfo.InvariantCulture);

        if (lineSpacing != 0)
        {
            openSB.Append($"<line-height={lSpacing}em>");
            closeSB.Append("</line-height>");
        }
        //The author is on a German system, so when I had the code devide the spacing by 100 (which we need,
        //because of the way TMP uses these values), I get a comma value.  
        //Trouble is: TMP doesn't like comma values in its tags. 
        //That's why I need to add this part here: CultureInfo .InvariantCulture turns the comma into a dot,
        //while N3 tells the string to only have three decimal values.  
        //without this line : 0,50000001
        //with this line: 0.500  

        if (textWeight == TextWeight.Black)
        {
            openSB.Append($"<font-weight={"900"}>");
            closeSB.Append("</font-weight>");
        }
        if (textWeight == TextWeight.Thin)
        {
            openSB.Append($"<font-weight={"100"}>");
            closeSB.Append("</font-weight>");
        }

        OpeningTags = openSB.ToString();
        ClosingTags = closeSB.ToString();

        }

        public enum TextWeight {
            Regular,
            Thin,
            Black
        }
    
}

```
这里记得拽过来：  
![picture 38](images/e521ff964effa56e8130152d6fc36c9ac0a969c27971d2d0a7239185eb9b3f84.png)  

使用：  
对脚本点击右键：  
![picture 33](images/f0afddd4ab5da480a8dbdb38eb395302e3028c0c1586039ef73acab74360e8f9.png)  
这里可以调整font weight  
![picture 34](images/a0b33cd48d9911f9fd855e3c97c46e94f0f46a6b014c52f3abb90d8386d931ef.png)  

### 五 . Sprites inside your text boxes! How to use sprites in Unity Text Mesh Pro
导入这张图片：  
![picture 39](images/8b6a530516aa22dc227c075b69e1c2ffe48821f641e6f231457f63b38feab5ef.png)  

![picture 40](images/489d40e658c7e9b4e9dc07dae6a639bb9a0d63b283e1e879e2bb42e072471759.png)  
![picture 41](images/f3a9195d7d561ff2492b7edc7d8c21bcb55e52a812c7d2224d1d42e1caea5214.png)  

我们要reset your pivot points.  
原来的样子：  
![picture 42](images/d1f0b06d0c1e569e695eaf3c3ee2d9761acfb512e7d7eef4608e7bfdb9720edf.png)  

if you keep your pivot point in the center of the graphic, it will actually be set to this position.  
![picture 43](images/7fbcfc13cae7603f16c9a635080c484c472f47ff9643ffc3515d08a5b0b1e9e0.png)  
So, you'll need to figure out where your Pivot needs to be set to. Every sprite you have will be treated like a letter. Thus, your pivot's x value should be the leftmost side of your sprite(or rightmost, if your writing system works like that)

and it's y value should correspond to where your text's base line is.   

You'll need to reset every sprites Pivot point, so if you have many of different shapes, this might take a moment.  
![picture 44](images/8cac0f1ae520dc8df04d9203b5793e67e614457be10c32b07fba873ff702c163.png)  

#### 1 . 
右键创建Sprite Asset。  
![picture 45](images/764956c854eeab33c8414680c9c6d58ea2a3348177a4d2e3f34c9a8c267e2996.png)  

Project setting的text mesh pro那里：    
![picture 47](images/2d2b940c701edf8a8a15ec7c2bb15422f4e7247cf37bb02db92cebd12e4b58f5.png)  

![picture 48](images/29aab9c7d13cc3be2de0db7f4b8b6805b61954dbe582032ffa82ac112882983e.png)  

这里可以改名字：  
![picture 50](images/1a75c42c20149560ef4824d53628638fa712302d2cfe7d705241f8280d25b31d.png)  

#### 2 . 
```
I'll need you to find me some Camomile <sprite name="Camomile"> , a few hands full of Poppy <sprite name="Poppy"> flowers and a few strands of Agapanthus <sprite name="Agapanthus">  , please.
```

注意`<sprite name="Camomile">`里面不能有空格，不然没有效果。`<sprite name="Camomile">`前后需要有空格。  
![picture 51](images/1a1b9df78651815d3fa51b74eb1fab5073d8c1eb6e1513e61d4c5b8b2255974e.png)  

可以看出Poppy flower的图标有点太高了。  

选中这个，调整这里：  
![picture 52](images/79cd130a3148d3758a01119d20eb427a140ac78276718070e10c25d2348c11ed.png)  

BX moves the sprite on its X axis, BY on Y and AD gives it a little bit more spacing to the right of it.  

可以改这些参数：  
![picture 53](images/3ea9cb6cebf54e58ab19529c06fa29fbe34ce79ec7b378b2f64f817d2d2572c2.png)  

#### 3 . 
可以用上style，这样就不用每次都写一大串了。  
![picture 54](images/649333fb35a1a0ec379b157a53e93377eb1e5a749fd4da2df7abd0d5f6f73f91.png)  

![picture 55](images/a1e3d6650225cd4fc73d159972c7058cb8aa3765bf6016e6b6b88b2ae0031816.png)  

### 六 . Let's automate writing Style Tags into your strings for TextMesh Pro!

We will build a small system to automatically tag our texts for us - for example inside a dialogue or tooltip system.  

这样可以把text display出来。

![picture 56](images/c35303e07e2b79d712bbc42d05716914bf5c13b5c5ed614940e2c1998f983c37.png)  
---
上面这段代码不用加在工程里，只是个样例。

#### 1 . 
Dialogue.cs脚本：  
```C#
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private List<string> dialogueLines;
    [SerializeField] private TMP_Text textBox;

    private int _lineOfDialogue;

    private void Start()
    {
        textBox.text = dialogueLines[_lineOfDialogue];
    }

    public void NextLine() {
        _lineOfDialogue++;

        if (_lineOfDialogue < dialogueLines.Count)
            textBox.text = dialogueLines[_lineOfDialogue];
        else {
            _lineOfDialogue = 0;
            textBox.text = dialogueLines[_lineOfDialogue];
        }
    }
}
```
KeywordsToTag.cs脚本：  
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keywords", menuName = "Keywords", order = 0)]
public class KeywordsToTag : ScriptableObject
{
    public List<string> Keywords; 
}
```

#### 2 . 
![picture 57](images/d9fee213b103ea04e257ec0afbb6662096dd6bcb0c9cb5021b48168e5d65ac51.png)  
把keywords创建出来。  
![picture 58](images/bb74cedec5f52076214f004e283a4fbbc18aae0df828e6d97813b7bf8d962161.png)  

#### 3 . 
写AutoTag.cs脚本  
```C#
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoTagSystem : MonoBehaviour
{
    [SerializeField] private TMP_StyleSheet styleSheet;
    [SerializeField] private KeywordsToTag keywordsToTag;

    public string SetAutoTags(string textboxtext) {
        foreach (var keyword in keywordsToTag.Keywords) {
            if (styleSheet.GetStyle(keyword) == null)
                Debug.Log($"Text style needed for keyword {keyword}");

            if (textboxtext.Contains(keyword)) {
                return textboxtext.Replace($"{keyword}", $"<style=\"{keyword}\">{keyword}</style>");
            }

            string lowerKeyword = keyword.ToLower(); //小写也能识别
            if (textboxtext.Contains(lowerKeyword))
            {
                return textboxtext.Replace($"{lowerKeyword}", $"<style=\"{keyword}\">{keyword}</style>");
            }
        }
        return textboxtext;
    }
}
```
新建空物体，把这个脚本放上去:   
![picture 59](images/a524e6cae9c5f0263f74182bc9bfc1e50a344d0de22cf080c15c4b47afbe9442.png)  

给它加上Tag：  
![picture 60](images/03f5e7f3a8b181ed892422986d14cfafdd26cf47d73c144923794020e2e5ab57.png)  

修改Dialogue.cs脚本：  
```C#
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private List<string> dialogueLines;
    [SerializeField] private TMP_Text textBox;

    private AutoTagSystem _autoTagSystem;
    private int _lineOfDialogue;

    private void Awake()
    {
        _autoTagSystem = GameObject.FindWithTag("AutoTagSystem").GetComponent<AutoTagSystem>();
    }

    private void Start()
    {
        textBox.text = _autoTagSystem.SetAutoTags(dialogueLines[_lineOfDialogue]);
    }

    public void NextLine() {
        _lineOfDialogue++;

        if (_lineOfDialogue < dialogueLines.Count)
            textBox.text = _autoTagSystem.SetAutoTags(dialogueLines[_lineOfDialogue]);
        else {
            _lineOfDialogue = 0;
            textBox.text = _autoTagSystem.SetAutoTags(dialogueLines[_lineOfDialogue]);
        }
    }
}
```
#### 4 . 
![picture 62](images/aff74c3ba30dfab6539477861d393ea8a4ec357865ff4c76feab708647a25021.png)  

怎么解决plural的问题

![picture 61](images/4a2d0d3f695363d818405e19466715f56829e82ef690bdadc3f8c7ee48ff8aa9.png)  
