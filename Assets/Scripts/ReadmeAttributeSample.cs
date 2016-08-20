using UnityEngine;

public class ReadmeAttributeSample : MonoBehaviour {

    [Readme("<b>Readme (En)</b>", "Readme attribute allows you to add a description for a script or a variable to Unity inspector.\n\nIt supports Unity RTF tags and allows you to <b>highlight</b> the most crucial part of a description. Foldout arrow allows you to collapse the text so it won't take a lot of space.\n\nYou can only use this attribute <color=#A00000FF>on a serializable variable</color>, the same way you would use Space or Header attributes. Multiple instances of an attribute are allowed.")]
    [Readme("<b>Readme (Ru)</b>", "Атрибут Readme добавляет описание для скрипта или переменной в инспектор Unity.\n\nПоддержка тэгов RTF редактора Unity позволяет <b>обратить внимание</b> пользователей на особо важные части описания, при этом текст описания можно свернуть, чтобы он не занимал много места.\n\nАтрибут можно использовать <color=#A00000FF>только на сериализуемых переменных</color>, как и атрибуты Unity вроде Space и Header. Допускается несколько атрибутов для одной переменной.")]

    public int answer = 42;
}
