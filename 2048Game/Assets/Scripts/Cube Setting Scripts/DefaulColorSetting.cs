using UnityEngine;

public class DefaultColorStrategy : ColorStrategy
{
    public override Color GetColor(int num)
    {
        switch (num)
        {
            case 2: return new Color(1f, 1f, 0f);
            case 4: return new Color(1f, 0.5f, 0f);
            case 8: return new Color(1f, 0f, 0f);
            case 16: return new Color(0f, 1f, 0f);
            case 32: return new Color(0f, 1f, 1f);
            case 64: return new Color(0f, 0f, 1f);
            case 128: return new Color(0.5f, 0f, 1f);
            case 256: return new Color(1f, 0f, 1f);
            case 512: return new Color(1f, 0.7f, 0.7f);
            case 1024: return new Color(0.7f, 1f, 0.7f);
            case 2048: return new Color(0.7f, 0.7f, 1f);
            default: return Color.white;
        }
    }
}

