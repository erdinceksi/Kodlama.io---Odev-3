using System;
using System.Collections.Generic;
using System.Text;

namespace ClassMetotDemo
{
    class MusteriManager
    {
        List<Musteri> musteris = new List<Musteri>();

        public void Start()
        {
            bool exit = false;
            String Id, Name, Surname, Option;

            while (!exit)
            {
                Console.WriteLine("Musteri Takip Sistemi");
                Console.WriteLine("---------------------");
                Console.WriteLine("1. Musteri Ekle");
                Console.WriteLine("2. Musteri Sil");
                Console.WriteLine("3. Musteri Listele");
                Console.WriteLine("4. Cikis\n");
                Console.Write("Secenek Giriniz: ");
                Option = Console.ReadLine();
                Console.WriteLine("\n");

                switch (Option)
                {
                    case "1":
                        Console.Write("Musteri Id Giriniz: ");
                        Id = Console.ReadLine();
                        if (Id == "")
                        {
                            Console.WriteLine("\nLutfen gecerli bir deger giriniz.\n");
                            break;
                        }
                        else
                        {
                            int pos = -1;
                            for (int i = 0; i < musteris.Count; i++)
                            {
                                if (musteris[i].Id == Id)
                                {
                                    pos = i;
                                    break;
                                }
                            }

                            if (pos != -1)
                            {
                                Console.WriteLine("\nBu Id'ye ait musteri zaten var.\n");
                                break;
                            }
                            else
                            {
                                Console.Write("Musteri Adi Giriniz: ");
                                Name = Console.ReadLine();
                                if (Name == "")
                                {
                                    Console.WriteLine("\nLutfen gecerli bir deger giriniz.\n");
                                    break;
                                }
                                Console.Write("Musteri Soyadi Giriniz: ");
                                Surname = Console.ReadLine();
                                if (Surname == "")
                                {
                                    Console.WriteLine("\nLutfen gecerli bir deger giriniz.\n");
                                    break;
                                }
                                MusteriEkle(Id, Name, Surname);
                            }
                        }   
                        break;
                    case "2":
                        if (musteris.Count == 0)
                        {
                            Console.WriteLine("Musteri yok.\n");
                            break;
                        }
                        else
                        {
                            Console.Write("Musteri Id Giriniz: ");
                            Id = Console.ReadLine();
                            if (Id == "")
                            {
                                Console.WriteLine("\nLutfen gecerli bir deger giriniz.\n");
                                break;
                            }
                            MusteriSil(Id);
                        }
                        break;
                    case "3":
                        MusteriListele();
                        break;
                    case "4":
                        Console.Write("Cikis yapiliyor...\n");
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public void MusteriEkle(String Id, String Name, String Surname)
        {
            Musteri musteri = new Musteri();
            musteri.Id = Id;
            musteri.Name = Name;
            musteri.Surname = Surname;

            try
            {
                musteris.Add(musteri);
                Console.WriteLine("\nMusteri Eklendi.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Musteri Eklenemedi, ", e);
            }
            
        }

        public void MusteriSil(String Id)
        {
            int pos = -1;
            for (int i = 0; i < musteris.Count; i++)
            {
                if (musteris[i].Id == Id)
                {
                    pos = i;
                    break;
                }
            }

            if (pos != -1)
            {
                try
                {
                    musteris.RemoveAt(pos);
                    Console.WriteLine("\nMusteri Silindi.\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Musteri Silinemedi, ", e);
                }

            }
            else
            {
                Console.WriteLine("\nMusteri Bulunamadi.\n");
            }
        }

        public void MusteriListele()
        {
            if (musteris.Count > 0)
            {
                Console.WriteLine("Musteriler Listeleniyor...\n");

                foreach (var musteri in musteris)
                {
                    Console.WriteLine("Musteri Id: " + musteri.Id);
                    Console.WriteLine("Musteri Adi: " + musteri.Name);
                    Console.WriteLine("Musteri Soyadi: " + musteri.Surname + "\n");
                }
            }
            else
            {
                Console.WriteLine("Musteri yok.\n");
            }

        }


    }
}
