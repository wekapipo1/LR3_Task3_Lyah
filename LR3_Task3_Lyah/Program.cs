using System;

class Hotel
{
    private int room; //всього місць
    private int occupiedRoom; //зайнято
    private int freeRoom; //вільно
    public Hotel(int room) //конструктор
    {
        this.room = room;
        this.occupiedRoom = 0;
        this.freeRoom = room;
    }
    public void Print() //виведення на екран
    {
        Console.WriteLine($"Загальна кiлькiсть кiмнат: {room}");
        Console.WriteLine($"Зайнято кiмнат: {occupiedRoom}");
        Console.WriteLine($"Вiльних кiмнат: {freeRoom}");
    }
    public bool PersonSett() //поселення одної людини в готель
    {
        if (freeRoom > 0)
        {
            occupiedRoom++;
            freeRoom--;
            return true;
        }
        return false;
    }
    public bool PersonEvic() //виселення одної людини з готелю
    {
        if (occupiedRoom > 0)
        {
            occupiedRoom--;
            freeRoom++;
            return true;
        }
        return false;
    }
    public int GetOccupiedRoom()
    {
        return occupiedRoom;
    }
}

class Cruise : Hotel
{
    private int stops; //зупинки судна
    public Cruise(int room, int stops) : base(room) //конструктор
    {
        this.stops = stops;
    }
    public int Stops //властивість для читання і запису
    {
        get { return stops; }
        set { stops = value; }
    }
    public new void Print() //виведення на екран
    {
        base.Print();
        Console.WriteLine($"Кiлькiсть зупинок: {stops}");
    }
    public new int GetOccupiedRoom()
    {
        return base.GetOccupiedRoom();
    }
}
class Program
{
    static void Main()
    {
        //готель
        Hotel hotel = new Hotel(5);
        Console.WriteLine("Готель:");
        hotel.Print();
        Random random = new Random();
        int peopleArriving = random.Next(1, 6);
        for (int i = 0; i < peopleArriving; i++)
        {
            bool settled = hotel.PersonSett();
            if (settled)
            {
                Console.WriteLine("Оселився один гiсть.");
            }
            else
            {
                Console.WriteLine("Немає вiльних кiмнат для нових гостей.");
                break;
            }
        }
        hotel.Print();
        int peopleLeaving = random.Next(0, hotel.GetOccupiedRoom() + 1);
        for (int i = 0; i < peopleLeaving; i++)
        {
            bool evicted = hotel.PersonEvic();
            if (evicted)
            {
                Console.WriteLine("Один гiсть виселений.");
            }
            else
            {
                Console.WriteLine("Готель порожнiй. Немає гостей для виселення.");
                break;
            }
        }
        hotel.Print();

        // Круїз
        Cruise cruise = new Cruise(7, 2);
        Console.WriteLine("\nКруїз:");
        cruise.Print();
        int peopleBoarding = random.Next(1, 8);
        for (int i = 0; i < peopleBoarding; i++)
        {
            bool settled = cruise.PersonSett();
            if (settled)
            {
                Console.WriteLine("Одна людина прийнята на борт.");
            }
            else
            {
                Console.WriteLine("На борту не залишилося мiсць для нових пасажирiв.");
                break;
            }
        }
        cruise.Print();
        for (int i = 0; i < cruise.Stops; i++)
        {
            int peopleLeavingCruise = random.Next(0, cruise.GetOccupiedRoom() + 1);

            for (int j = 0; j < peopleLeavingCruise; j++)
            {
                bool evicted = cruise.PersonEvic();
                if (evicted)
                {
                    Console.WriteLine("Одна людина висадилася на зупинцi.");
                }
                else
                {
                    Console.WriteLine("На зупинцi нiхто не залишив судно. Всi пасажири вже висадилися.");
                    break;
                }
            }
            cruise.Stops--;
        }
        cruise.Print();
    }
}
