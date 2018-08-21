using UnityEngine;
using UnityEditor;

public class UnoCard : Card
{
    public UnoType mType;
    public Color CardColor;

    public UnoCard(UnoType type, Color color) : base()
    {
        mType = type;
        CardColor = color;
    }

    public override void CreateCard(Vector3 position, Quaternion rotation, GameObject parent = null)
    {
        mCardView = new CardView();
        string value = "UnoCards/unos_" + CardColor.ToString() + mType.ToString();
        mCardView.Render("Uno/Card", position, rotation, new Vector3(5, 5, 0.05f), parent);
        mCardView.cardObject.transform.Find("Front").GetComponent<Renderer>().material.mainTexture
            = (Texture)Object.Instantiate(Resources.Load(value));
        mCardView.cardObject.name = value;
        //mCardView.Render(, position, rotation, parent);
    }
    
    public class Color
    {
        public Values Value { get; set; }
        public GameObject Object { get; set; }

        public enum Values
        {
            Red, Yellow, Green, Blue, Any
        }

        public static Color fromInt(int color)
        {
            return new Color(color);
        }

        public Color(Values color)
        {
            Value = color;
        }

        public Color(int color)
        {
            //TODO: implement different constructors form Value and from int
            switch (color)
            {
                case 0:
                    Value = Values.Red;
                    break;
                case 1:
                    Value = Values.Yellow;
                    break;
                case 2:
                    Value = Values.Green;
                    break;
                case 3:
                    Value = Values.Blue;
                    break;
                default:
                    Value = Values.Any;
                    break;
            }
        }

        public int ToInt()
        {
            //TODO: implement
            switch (Value)
            {
                case Values.Red:
                    return 0;
                case Values.Yellow:
                    return 1;
                case Values.Green:
                    return 2;
                case Values.Blue:
                    return 3;
                case Values.Any:
                    return 4;
            }
            throw new System.Exception("Color doesn't exist!");
        }

        public string ToString()
        {
            //TODO: implement
            switch (Value)
            {
                case Values.Red:
                    return "r";
                case Values.Yellow:
                    return "y";
                case Values.Green:
                    return "g";
                case Values.Blue:
                    return "b";
                case Values.Any:
                    return "a";
            }
            throw new System.Exception("Color doesn't exist!");
        }
    }

    public class UnoType
    {
        public Values Value { get; set; }
        public GameObject Object { get; set; }
        //public static const string Zero = "0";
        public enum Values
        {
            Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, SkipTurn, ChangeDirection, TakeTwo, TakeFour, ChangeColor
        }

        public UnoType(Values denomination)
        {
            Value = denomination;
        }
        
        public UnoType(int type)
        {
            Value = (Values)type;
        }

        public override bool Equals(object o)
        {
            return true;
        }
        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            switch (Value)
            {
                case Values.Zero:
                    return "0";
                case Values.One:
                    return "1";
                case Values.Two:
                    return "2";
                case Values.Three:
                    return "3";
                case Values.Four:
                    return "4";
                case Values.Five:
                    return "5";
                case Values.Six:
                    return "6";
                case Values.Seven:
                    return "7";
                case Values.Eight:
                    return "8";
                case Values.Nine:
                    return "9";
                case Values.SkipTurn:
                    return "st";
                case Values.ChangeDirection:
                    return "cd";
                case Values.TakeTwo:
                    return "t2";
                case Values.TakeFour:
                    return "t4";
                case Values.ChangeColor:
                    return "cc";
                default:
                    return null;
            }
        }

        public int ToInt()
        {
            switch (Value)
            {
                case Values.Zero:
                    return 0;
                case Values.One:
                    return 1;
                case Values.Two:
                    return 2;
                case Values.Three:
                    return 3;
                case Values.Four:
                    return 4;
                case Values.Five:
                    return 5;
                case Values.Six:
                    return 6;
                case Values.Seven:
                    return 7;
                case Values.Eight:
                    return 8;
                case Values.Nine:
                    return 9;
                case Values.SkipTurn:
                    return 10;
                case Values.ChangeDirection:
                    return 11;
                case Values.TakeTwo:
                    return 12;
                case Values.TakeFour:
                    return 13;
                case Values.ChangeColor:
                    return 14;
            }
            throw new System.Exception("Denomination doesn't exist!");
        }

        public static Denomination FromInt(int denomination)
        {
            switch (denomination)
            {
                case 0:
                    return new Denomination(Denomination.Values.Zero);
                case 1:
                    return new Denomination(Denomination.Values.One);
                case 2:
                    return new Denomination(Denomination.Values.Two);
                case 3:
                    return new Denomination(Denomination.Values.Three);
                case 4:
                    return new Denomination(Denomination.Values.Four);
                case 5:
                    return new Denomination(Denomination.Values.Five);
                case 6:
                    return new Denomination(Denomination.Values.Six);
                case 7:
                    return new Denomination(Denomination.Values.Seven);
                case 8:
                    return new Denomination(Denomination.Values.Eight);
                case 9:
                    return new Denomination(Denomination.Values.Nine);
                case 10:
                    return new Denomination(Denomination.Values.Ten);
                case 11:
                    return new Denomination(Denomination.Values.Jack);
                case 12:
                    return new Denomination(Denomination.Values.Queen);
                case 13:
                    return new Denomination(Denomination.Values.King);
                case 14:
                    return new Denomination(Denomination.Values.ACE);
            }
            return null;
        }

        public static bool operator <(UnoType denomination, UnoType denomination2)
        {
            return denomination.ToInt() < denomination2.ToInt();
        }

        public static bool operator >(UnoType denomination, UnoType denomination2)
        {
            return denomination.ToInt() > denomination2.ToInt();
        }

        public static bool operator ==(UnoType denomination, UnoType denomination2)
        {
            return denomination.ToInt() == denomination2.ToInt();
        }

        public static bool operator !=(UnoType denomination, UnoType denomination2)
        {
            return denomination.ToInt() != denomination2.ToInt();
        }
    }
}