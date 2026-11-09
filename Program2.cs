
static string EncryptText(string text, int shiftKey)
{
    if (string.IsNullOrEmpty(text)) return text;


    string[] words = text.Split(' ');
    for (int i = 0; i < words.Length; i++)
    {
        if (words[i].Length % 2 == 0)
        {
            char[] charArray = words[i].ToCharArray();
            Array.Reverse(charArray);
            words[i] = new string(charArray);
        }
    }
    string step1Text = string.Join(" ", words);

    StringBuilder result = new StringBuilder();
    int totalLength = step1Text.Length;

    for (int i = 0; i < totalLength; i++)
    {
        char ch = step1Text[i];

        if (char.IsLetter(ch) && ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')))
        {
            bool isUpper = char.IsUpper(ch);
            char offset = isUpper ? 'A' : 'a';

            if (i % 2 == 0)
            {
                ch = (char)((((ch - offset) + shiftKey) % 26 + 26) % 26 + offset);
            }
            else
            {
                ch = (char)((((ch - offset) - shiftKey) % 26 + 26) % 26 + offset);
            }
        }

        char lowerCh = char.ToLower(ch);
        if (lowerCh == 'a' || lowerCh == 'e' || lowerCh == 'i' || lowerCh == 'o' || lowerCh == 'u')
        {
            int asciiValue = (int)ch;
            int newValue = asciiValue - totalLength;
            result.Append("[" + newValue + "]");
        }
        else
        {
            result.Append(ch);
        }
    }

    return result.ToString();
}

static string DecryptText(string encryptedText, int shiftKey)
{
    if (string.IsNullOrEmpty(encryptedText)) return encryptedText;

    int tempLength = 0;
    for (int i = 0; i < encryptedText.Length; i++)
    {
        if (encryptedText[i] == '[')
        {
            int closeBracket = encryptedText.IndexOf(']', i);
            i = closeBracket;
            tempLength++;
        }
        else
        {
            tempLength++;
        }
    }
    int totalLength = tempLength;

    StringBuilder step3Decrypted = new StringBuilder();
    for (int i = 0; i < encryptedText.Length; i++)
    {
        if (encryptedText[i] == '[')
        {
            int closeBracket = encryptedText.IndexOf(']', i);
            string numStr = encryptedText.Substring(i + 1, closeBracket - i - 1);
            int encryptedValue = int.Parse(numStr);

            char originalVowel = (char)(encryptedValue + totalLength);
            step3Decrypted.Append(originalVowel);

            i = closeBracket;
        }
        else
        {
            step3Decrypted.Append(encryptedText[i]);
        }
    }

    string step2Text = step3Decrypted.ToString();

    StringBuilder step1Decrypted = new StringBuilder();
    for (int i = 0; i < step2Text.Length; i++)
    {
        char ch = step2Text[i];

        if (char.IsLetter(ch) && ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')))
        {
            bool isUpper = char.IsUpper(ch);
            char offset = isUpper ? 'A' : 'a';

            if (i % 2 == 0)
            {
                ch = (char)((((ch - offset) - shiftKey) % 26 + 26) % 26 + offset);
            }
            else
            {
                ch = (char)((((ch - offset) + shiftKey) % 26 + 26) % 26 + offset);
            }
        }
        step1Decrypted.Append(ch);
    }

    string decryptedStep1Text = step1Decrypted.ToString();
    string[] words = decryptedStep1Text.Split(' ');
    for (int i = 0; i < words.Length; i++)
    {
        if (words[i].Length % 2 == 0)
        {
            char[] charArray = words[i].ToCharArray();
            Array.Reverse(charArray);
            words[i] = new string(charArray);
        }
    }

    return string.Join(" ", words);
}
    }
}
