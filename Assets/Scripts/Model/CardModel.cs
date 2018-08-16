using UnityEngine;

public class Card
{

    public string Value { get; set; }
    public Suit CardSuit { get; set; }
    public string Owner { get; set; }
    public Color CardColor { get; set; }


    public class Suit
    {
        //TODO: implement same as Color
        public Values Value { get; set; }
        public GameObject Object { get; set; }

        public enum Values
        {
            Hearts, Spades, Diamonds, Clubs
        }
        public Suit(Values suit)
        {
            Value = suit;
        }



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

        public int toInt()
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
    }



    //implement constructors from CardColor / Suit

    public Card(string value, Suit suit)
    {
        Value = value;
        CardSuit = suit;
    }

    public Card(string value, Color color)
    {
        Value = value;
        CardColor = color;
    }

    public Card(Card card)
    {
        Value = card.Value;
        CardColor = card.CardColor;
        CardSuit = card.CardSuit;
    }


    public void Render(Vector3 position, Quaternion rotation)
    {
        //implement
    }

}
