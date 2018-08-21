using UnityEngine;
using UnityEditor;

public class UnoCard : Card
{
    Type mType;
    Color mColor;

    public UnoCard(Type type, Color color) : base()
    {
        
    }

    public new void CreateCard(Vector3 position, Quaternion rotation)
    {
        mCardView = new CardView();
        mCardView.Render("", position, rotation);
    }

    public class Type
    {
        public Values Value { get; set; }
        public GameObject Object { get; set; }

        public enum Values
        {
            Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, ChangeDirection, SkipTurn, TakeTwo, ChangeColor, TakeFour
        }

        public Type(Values type)
        {
            Value = type;
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
                case Values.ChangeDirection:
                    return 10;
                case Values.SkipTurn:
                    return 11;
                case Values.TakeTwo:
                    return 12;
                case Values.ChangeColor:
                    return 13;
                case Values.TakeFour:
                    return 14;
            }
            throw new System.Exception("Type doesn't exist!");
        }

        public Type(int type)
        {
            switch (type)
            {
                case 0:
                    Value = Values.Zero;
                    break;
                case 1:
                    Value = Values.One;
                    break;
                case 2:
                    Value = Values.Two;
                    break;
                case 3:
                    Value = Values.Three;
                    break;
                case 4:
                    Value = Values.Four;
                    break;
                case 5:
                    Value = Values.Five;
                    break;
                case 6:
                    Value = Values.Six;
                    break;
                case 7:
                    Value = Values.Seven;
                    break;
                case 8:
                    Value = Values.Eight;
                    break;
                case 9:
                    Value = Values.Nine;
                    break;
                case 10:
                    Value = Values.ChangeDirection;
                    break;
                case 11:
                    Value = Values.SkipTurn;
                    break;
                case 12:
                    Value = Values.TakeTwo;
                    break;
                case 13:
                    Value = Values.ChangeColor;
                    break;
                case 14:
                    Value = Values.TakeFour;
                    break;
            }
        }
    }
}