using UnityEngine;

public class Card
{
    CardView cardView;
    public string StringValue { get; set; }
    public Suit CardSuit { get; set; }
    public string Owner { get; set; }
    public Color CardColor { get; set; }

    public bool isOnScreen = false;
 
    public class Suit
    {
        public string StringSuit;
        //TODO: implement same as Color
        public Values Value { get; set; }
        public GameObject Object { get; set; }

        public enum Values
        {
            Heart, Spades, Diamond, Club
        }
        public Suit(Values suit)
        {
            Value = suit;
            StringSuit = suit.ToString();
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
    }


    //Номинал
    public class Denomination
    {
        public Values Value { get; set; }
        public GameObject Object { get; set; }
        //public static const string Zero = "0";
        public enum Values
        {
            Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, ACE
        }

        public Denomination(Values denomination)
        {
            Value = denomination;
        }

        public int ToInt()
        {
            switch (Values)
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
                case Values.Ten:
                    return 10;
                case Values.Jack:
                    return 11;
                case Values.Queen:
                    return 12;
                case Values.King:
                    return 13;
                case Values.ACE:
                    return 14;
            }
            throw new System.Exception("Denomination doesn't exist!");
        }

        public Denomination(int denomination)
        {
            switch (denomination)
            {
                case 0:
                    Value = Values.Zero;
                case 1:
                    Value = Values.One;
                case 2:
                    Value = Values.Two;
                case 3:
                    Value = Values.Three;
                case 4:
                    Value = Values.Four;
                case 5:
                    Value = Values.Five;
                case 6:
                    Value = Values.Six;
                case 7:
                    Value = Values.Seven;
                case 8:
                    Value = Values.Eight;
                case 9:
                    Value = Values.Nine;
                case 10:
                    Value = Values.Ten;
                case 11:
                    Value = Values.Jack;
                case 12:
                    Value = Values.Queen;
                case 13:
                    Value = Values.King;
                case 14:
                    Value = Values.ACE;
            }
        }
        //Функция возращает разность номиналов двух карт (если DenominationsComparison > 0, то первая карта больше,чем  вторая, если DenominationsComparison = 0, то карты по наминалом равны)
        public int DenominationsComparison(Denomination denominationFirstCard, Denomination denominationSecondCard)
        {
            int ValueFirst = denominationFirstCard.ToInt();
            int ValueSecond = denominationSecondCard.ToInt();
            return ValueFirst - ValueSecond;
        }
    }

    //implement constructors from CardColor / Suit

    public Card(string value, Suit suit)
    {
        StringValue = value;
        CardSuit = suit;
    }

    public Card(string value, Color color)
    {
        StringValue = value;
        CardColor = color;
    }

    public Card(Card card)
    {
        StringValue = card.StringValue;
        CardColor = card.CardColor;
        CardSuit = card.CardSuit;
    }
    public void CreateCard(Vector3 position, Quaternion rotation)
    {
        cardView = new CardView();
        cardView.Render(StringValue, CardSuit.StringSuit, position, rotation);
    }
    public void ReplaceCard(Vector3 position, Quaternion rotation)
    {
        cardView.Replace(position, rotation);
    }
    public void DestroyCard()
    {
        
    }
    public class CardView
    {
        GameObject cardObject;
        public void Render(string value, string suit, Vector3 position, Quaternion rotation, GameObject parent = null)
        {
            //implement
            cardObject = (GameObject)GameObject.Instantiate(Resources.Load("FPC/PlayingCards_" + value + suit));
            cardObject.transform.position = position;
            cardObject.transform.localScale = new Vector3(10, 10, 4);
            cardObject.transform.rotation = rotation;
            if (parent != null)
            {
                cardObject.transform.SetParent(parent.transform);
            }
        }
        public void Replace(Vector3 position, Quaternion rotation)
        {
            cardObject.transform.position = position;
            cardObject.transform.rotation = rotation;
        }
    }
}
