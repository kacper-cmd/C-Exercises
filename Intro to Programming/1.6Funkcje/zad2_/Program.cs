var text = "Lorem Ipsum is simply dummy\ntext of the printing and typesetting";

Console.WriteLine(string.Concat(SplitText(text)));

static String[] SplitText(String text)
{
    return text.Split(new char[] { ' ', '\n' });
}

