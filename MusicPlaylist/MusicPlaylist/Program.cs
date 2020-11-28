using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;


namespace ConsoleApp4
{
    class Program
    {
        static int minimum;
        static int maximum;
        static void Main(string[] args)
        {
            var playlist = new Dictionary<int, string>(){
                {0, "Za ljubav ja dao bi sve"},
                {1, "Ako su to samo bile lazi"},
                {2, "Olivera"},
                {3, "Jutro donosi kraj"},
                {4, "Zena drugog sistema"},
                {5, "Ringispil"},
                {6, "Namcor"},
                {7, "Sin jedinac"},
                {8, "Kuca pored mora"},
                {9, "Zagrli me" },
            };

            (minimum, maximum) = FindMinMax(playlist);
            if (minimum != 0)
            {
                Console.WriteLine("Pjesme se u playlisti spremaju pod rednim brojevima počevši od broja 0, a vi nemate pjesmu spremljenu pod brojem 0.");
                return;
            }

            bool goodSequence = CheckingNumbers(playlist, minimum, maximum);
            if (goodSequence == false)
            {
                Console.WriteLine("Redoslijed brojeva nije dobar, to jest fali nam neki broj!");
                return;
            }

            goodSequence = CheckingSongNames(playlist);
            if (goodSequence == false)
            {
                Console.WriteLine("Isti naslov pjesme se pojavljuje više puta!");
                return;
            }


            bool loopContinue = true;
            while (loopContinue)
            {
                int number = DisplayMenu();
                switch (number)
                {
                    case 1:
                        if (playlist.Count == 0)
                        {
                            Console.WriteLine("Playlista je prazna :/");
                            break;
                        }
                        PrintingPlaylist(playlist);
                        break;
                    case 2:
                        if (playlist.Count == 0)
                        {
                            Console.WriteLine("Playlista je prazna tako da nema vaše pjesme:/");
                            break;
                        }
                        Console.WriteLine("Upisivanjem broja dobit cete naslov pjesme pod tim brojem!");

                        int numberSong;

                        bool goodNumberSong = int.TryParse(Console.ReadLine(), out numberSong);

                        if (goodNumberSong == false)
                        {
                            Console.WriteLine("Niste upisali broj!");
                        }
                        else
                        {
                            PrintingSongName(playlist, numberSong);
                        }
                        break;
                    case 3:
                        if (playlist.Count == 0)
                        {
                            Console.WriteLine("Playlista je prazna tako da nema vaše pjesme :/");
                            break;
                        }
                        Console.WriteLine("Upišite naslov pjesme te ćete dobiti broj pod kojim je spremljena!");
                        string songName = Console.ReadLine();
                        PrintingSongNumber(playlist, songName);
                        break;
                    case 4:

                        Console.WriteLine("Upišite naslov pjesme koju želite dodati!");
                        songName = Console.ReadLine();
                        AddingNewSong(playlist, songName, maximum);

                        break;
                    case 5:
                        if (playlist.Count == 0)
                        {
                            Console.WriteLine("Playlista je prazna tako da nema pjesme koju želite izbrisati :/");
                            break;
                        }
                        Console.WriteLine("Upisite redni broj pjesme koju želite izbrisati");
                        numberSong = int.Parse(Console.ReadLine());
                        DialogResult ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ans == DialogResult.Yes)
                        {
                            DeletingSongNumber(playlist, numberSong);
                        }
                        else
                        {
                            Console.Write("U redu, nastavite sa sljedećom radnjom.");
                        }
                        break;

                    case 6:
                        if (playlist.Count == 0)
                        {
                            Console.WriteLine("Playlista je prazna tako da nema pjesme koju želite izbrisati :/");
                            break;
                        }
                        Console.WriteLine("Upišite naslov pjesme koju želite izbrisati!");
                        songName = Console.ReadLine();
                        ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ans == DialogResult.Yes)
                        {
                            DeletingSongName(playlist, songName);
                        }
                        else
                        {
                            Console.Write("U redu, nastavite sa sljedećom radnjom.");
                        }
                        break;
                    case 7:
                        if (playlist.Count == 0)
                        {
                            Console.WriteLine("Playlista je već izbrisana :D");
                            break;
                        }
                        Console.WriteLine("Sad ste u postupku brisanja cijele playliste!");
                        ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ans == DialogResult.Yes)
                        {
                            ClearDictionary(playlist);
                            Console.WriteLine("Cijela playlista je izbrisana.");

                        }
                        else
                        {
                            Console.Write("U redu, nastavite sa sljedećom radnjom.");
                        }
                        break;
                    case 8:
                        if (playlist.Count == 0)
                        {
                            Console.WriteLine("Playlista je prazna tako da nema pjesme kojoj želite promijeniti naziv :/");
                            break;
                        }
                        Console.WriteLine("Upišite broj pjesme kojoj želite promijeniti naziv: ");
                        numberSong = int.Parse(Console.ReadLine());
                        Console.WriteLine("Napišite kako želite da Vam se pjesma zove: ");
                        songName = Console.ReadLine();
                        ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ans == DialogResult.Yes)
                        {
                            RenameSongName(playlist, numberSong, songName);
                        }
                        else
                        {
                            Console.Write("U redu, nastavite sa sljedećom radnjom.");
                        }
                        break;
                    case 9:
                        if (playlist.Count == 0)
                        {
                            Console.WriteLine("Playlista je prazna tako da nema pjesme koju želite premjestiti :/");
                            break;
                        }
                        Console.WriteLine("Upišite broj pjesme koju želite premjestiti: ");
                        int firstNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Upišite broj na koju tu pjesmu želite premjestiti: ");
                        int secondNumber = int.Parse(Console.ReadLine());
                        ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ans == DialogResult.Yes)
                        {
                            ChangingNumber(playlist, firstNumber, secondNumber);

                        }
                        else
                        {
                            Console.Write("U redu, nastavite sa sljedećom radnjom.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("U procesu ste izlaženja iz aplikacije!");
                        ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ans == DialogResult.Yes)
                        {
                            Console.WriteLine("Izlaz iz aplikacije");
                            loopContinue = false;
                        }
                        break;



                    default:
                        Console.WriteLine("Neispravan unos broja");
                        break;
                }
            }






        }
        static int DisplayMenu()
        {
            Console.WriteLine("\n----IZBORNIK----");
            Console.WriteLine("Upišite odgovarajući broj za željenu akciju!");
            Console.WriteLine("1 - Ispis cijele liste");
            Console.WriteLine("2 - Ispis imena pjesme unosom pripadajućeg rednog broja");
            Console.WriteLine("3 - Ispis rednog broja pjesme unosom pripadajućeg imena");
            Console.WriteLine("4 - Unos nove pjesme");
            Console.WriteLine("5 - Brisanje pjesme po rednom broju");
            Console.WriteLine("6 - Brisanje pjesme po imenu");
            Console.WriteLine("7 - Brisanje cijele liste");
            Console.WriteLine("8 - Uređivanje imena pjesme");
            Console.WriteLine("9 - Uređivanje rednog broja pjesme, odnosno premještanje pjesme na novi redni broj u listi");
            Console.WriteLine("0 - Izlaz iz aplikacije");
            Console.WriteLine("\n\n");
            int x = int.Parse(Console.ReadLine());
            return x;

        }
        static (int min, int max) FindMinMax(Dictionary<int, string> myPlaylist)
        {
            int min = -1;
            foreach (var item in myPlaylist)
            {
                min = item.Key;
                break;
            }
            int max = -1;
            foreach (var item in myPlaylist)
            {
                if (item.Key < min)
                    min = item.Key;
                if (item.Key > max)
                    max = item.Key;
            }
            return (min, max);
        }

        static bool CheckingNumbers(Dictionary<int, string> myPlaylist, int min, int max)
        {
            int number = min;
            int counterMissingNumber = 0;
            int counterThroughDict = 0;
            while (counterThroughDict != myPlaylist.Count - 1)
            {
                counterMissingNumber = 0;
                foreach (var item in myPlaylist)
                {
                    if (number == item.Key)
                        counterMissingNumber++;
                }
                if (counterMissingNumber != 1)
                {
                    return false;
                }
                number++;
                counterThroughDict++;
            }
            return true;
        }

        static bool CheckingSongNames(Dictionary<int, string> myPlaylist)
        {
            int counter;
            foreach (var itemFirst in myPlaylist)
            {
                counter = 0;
                foreach (var itemSecond in myPlaylist)
                {
                    if (itemFirst.Value == itemSecond.Value)
                    {
                        counter++;
                    }
                }
                if (counter != 1)
                    return false;
            }
            return true;
        }
        static void PrintingPlaylist(Dictionary<int, string> myPlaylist)
        {
            foreach (var item in myPlaylist)
            {
                Console.WriteLine("Pjesma broj " + item.Key + " te naslov pjesme " + item.Value + ".");
            }

        }

        static void PrintingSongName(Dictionary<int, string> myPlaylist, int numberOfSong)
        {
            foreach (var item in myPlaylist)
            {
                if (numberOfSong == item.Key)
                {
                    Console.WriteLine("Pjesma pod rednim brojem " + item.Key + " je " + item.Value + ".");
                    return;
                }

            }

            Console.WriteLine("Ne postoji pjesma spremljena pod brojem " + numberOfSong + ".");
            DialogResult ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                Console.WriteLine("Upisivanjem broja dobit cete naslov pjesme pod tim brojem!");
                int anotherSongNumber = int.Parse(Console.ReadLine());
                PrintingSongName(myPlaylist, anotherSongNumber);

            }
            else
            {
                Console.WriteLine("U redu, nastavite sa sljedećom radnjom koju ćete odabrati u izborniku!");
            }


        }

        static void PrintingSongNumber(Dictionary<int, string> myPlaylist, string songName)
        {
            foreach (var item in myPlaylist)
            {
                if (songName == item.Value)
                {
                    Console.WriteLine("Pjesma s naslovom " + songName + " je pod brojm " + item.Key + " spremljena.");
                    return;
                }
            }

            Console.WriteLine("Ne postoji pjesma s naslovom " + songName + ".");
            DialogResult ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                Console.WriteLine("Upišite naslov pjesme te ćete dobiti broj pod kojim je spremljena!");
                string anotherSongName = Console.ReadLine();
                PrintingSongNumber(myPlaylist, anotherSongName);

            }
            else
            {
                Console.WriteLine("U redu, nastavite sa sljedećom radnjom koju ćete odabrati u izborniku!");
            }


        }
        static void AddingNewSong(Dictionary<int, string> myPlaylist, string songName, int max)
        {
            bool existingSong = false;
            foreach (var item in myPlaylist)
            {
                if (item.Value == songName)
                {
                    Console.WriteLine("Pjesma s ovim naslovom je već unešena pa je ne možete ponovo unijeti.");
                    existingSong = true;
                    break;
                }
            }

            if (existingSong == true)
            {
                DialogResult ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    Console.WriteLine("Upišite naslov pjesme koju želite dodati!");
                    string anotherSongName = Console.ReadLine();
                    AddingNewSong(myPlaylist, anotherSongName, max);

                }
                else
                {
                    Console.WriteLine("U redu, nastavite sa sljedećom radnjom koju ćete odabrati u izborniku!");
                }
            }
            else
            {
                DialogResult ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    myPlaylist.Add(max + 1, songName);
                    Console.WriteLine("Pjesma je dodana");
                    (minimum, maximum) = FindMinMax(myPlaylist);

                }
                else
                {
                    Console.WriteLine("U redu, nastavite sa sljedećom radnjom koju ćete odabrati u izborniku!");
                }

            }
        }
        static void DeletingSongNumber(Dictionary<int, string> myPlaylist, int number)
        {
            int j;

            if (minimum > number || maximum < number)
            {
                Console.WriteLine("Broj nije u odgovarajućem intervalu.");

                DialogResult ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    Console.WriteLine("Upisite redni broj pjesme koju želite izbrisati");
                    int numberSong = int.Parse(Console.ReadLine());
                    DeletingSongNumber(myPlaylist, numberSong);

                }
                else
                {
                    Console.WriteLine("U redu, nastavite sa sljedećom radnjom koju ćete odabrati u izborniku!");
                }
            }
            else
            {
                myPlaylist.Remove(number);
                //(minimum, maximum) = FindMinMax(myPlaylist);
                string songName = "";
                for (int i = 0; i < maximum; i++)
                {
                    j = i;
                    if (j >= number)
                    {
                        songName = myPlaylist[j + 1];
                        myPlaylist.Remove(j + 1);
                        myPlaylist.Add(number, songName);
                        number++;

                    }
                    //Console.WriteLine(i + " i " +myPlaylist[i]);

                }
                Console.WriteLine("Pjesma je izbrisana!");
                (minimum, maximum) = FindMinMax(myPlaylist);
            }
        }
        static void DeletingSongName(Dictionary<int, string> myPlaylist, string name)
        {

            int j;
            int number = -1;
            foreach (var item in myPlaylist)
            {
                if (item.Value == name)
                {
                    number = item.Key;
                    break;
                }
            }
            if (number == -1)
            {
                Console.WriteLine("Ne postoji pjesma imena " + name + ".");
                DialogResult ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    Console.WriteLine("Upišite naslov pjesme koju želite izbrisati!");
                    string anotherSongName = Console.ReadLine();
                    DeletingSongName(myPlaylist, anotherSongName);

                }
                else
                {
                    Console.WriteLine("U redu, nastavite sa sljedećom radnjom koju ćete odabrati u izborniku!");
                }

            }
            else
            {
                myPlaylist.Remove(number);
                string songName = "";
                for (int i = 0; i <= 8; i++)
                {
                    j = i;
                    if (j >= number)
                    {
                        songName = myPlaylist[j + 1];
                        myPlaylist.Remove(j + 1);
                        myPlaylist.Add(number, songName);
                        number++;

                    }

                }
                Console.WriteLine("Pjesma je izbrisana!");
                (minimum, maximum) = FindMinMax(myPlaylist);
            }
        }

        static void ClearDictionary(Dictionary<int, string> myPlaylist)
        {

            myPlaylist.Clear();
            (minimum, maximum) = FindMinMax(myPlaylist);

        }

        static void RenameSongName(Dictionary<int, string> myPlaylist, int number, string name)
        {

            bool existingSongName = false;
            foreach (var item in myPlaylist)
            {
                if (name == item.Value)
                {
                    existingSongName = true;
                }
            }
            if (number < minimum || maximum < number || existingSongName == true)
            {
                Console.WriteLine("Broj nije u odgovarajućem intervalu i/ili već postoji pjesma s istim naslovom.");

                DialogResult ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    Console.WriteLine("Upišite broj pjesme kojoj želite promijeniti naziv: ");
                    int numberSong = int.Parse(Console.ReadLine());
                    Console.WriteLine("Napišite kako želite da Vam se pjesma zove: ");
                    string songName = Console.ReadLine();
                    RenameSongName(myPlaylist, numberSong, songName);

                }
                else
                {
                    Console.WriteLine("U redu, nastavite sa sljedećom radnjom koju ćete odabrati u izborniku!");
                }
            }

            else
            {
                myPlaylist[number] = name;
                Console.WriteLine("Promijenjeno je ime pjesme!");
            }
        }


        static void ChangingNumber(Dictionary<int, string> myPlaylist, int numberFirst, int numberSecond)
        {

            if (numberFirst < minimum || numberSecond < minimum || numberFirst > maximum || numberSecond > maximum)
            {
                Console.WriteLine("loš");
                Console.WriteLine("Broj(evi) ni(je/su) u odgovarajućem intervalu.");
                DialogResult ans = MessageBox.Show("Do you want to continue it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == DialogResult.Yes)
                {
                    Console.WriteLine("Upišite broj pjesme koju želite premjestiti: ");
                    int firstNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Upišite broj na koju tu pjesmu želite premjestiti: ");
                    int secondNumber = int.Parse(Console.ReadLine());

                    ChangingNumber(myPlaylist, firstNumber, secondNumber);

                }
                else
                {
                    Console.WriteLine("U redu, nastavite sa sljedećom radnjom koju ćete odabrati u izborniku!");
                }
            }
            else
            {
                if (numberFirst < numberSecond)
                {
                    string name = myPlaylist[numberFirst];
                    for (int i = numberFirst; i < numberSecond; i++)
                    {
                        myPlaylist[i] = myPlaylist[i + 1];
                    }
                    myPlaylist[numberSecond] = name;
                }
                if (numberFirst > numberSecond)
                {
                    string name = myPlaylist[numberFirst];
                    for (int i = numberFirst; i >= numberSecond + 1; i--)
                    {
                        myPlaylist[i] = myPlaylist[i - 1];
                    }
                    myPlaylist[numberSecond] = name;
                }
                Console.WriteLine("Pjesma je premještena!");
            }
        }
    }
}

