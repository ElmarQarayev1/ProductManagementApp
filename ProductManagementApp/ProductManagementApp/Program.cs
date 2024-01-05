using static System.Net.Mime.MediaTypeNames;
using System;
using System.Text;

namespace ProductManagementApp;

class Program
{
    static void Main(string[] args)
    {
         
        string[] Product = new string[] { "Apple","Samsung","Honor","Nokia" };
        string secim;
        
        do
        {
               ShowMainMenu();

              secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    showProduct(Product);
                    break;
                case "2":
                    LookProduct(Product);
                    break;
                case "3":
                    AddNewProduct( ref Product);

                    break;
                case "4":
                    changeProductName(Product);
                    break;
                case "5":
                    
                    DeleteChoosenProduct( ref Product);
                    break;
                case "0":
                    Console.WriteLine("Programdan cixildi!");
                    break;

                default:
                    Console.WriteLine("secim yanlisdir!");
                    break;
            }


        } while (secim!="0");
       
    
        Console.ReadLine();
           
    }
    static void ShowMainMenu()
    {
        Console.WriteLine("\n**************Ana Menyu**************");
        Console.WriteLine("1.Butun mehsullara baxmaq");
        Console.WriteLine("2.secilmis mehsula baxmaq");
        Console.WriteLine("3.Yeni mehsul elave etmek");
        Console.WriteLine("4.Mehsul adini deyis");
        Console.WriteLine("5.secilmis mehsulu sil");
        Console.WriteLine("0.Programdan cix");
        Console.Write("secim edin : ");

    }
    static void showProduct(string[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{i} ci mehsul:");
            Console.WriteLine(arr[i]);

        }
    }
    static void LookProduct(string[] arr)
    {
        showProduct(arr);
        Console.Write("axtarmaq isteyiniz  mehsulun indexini daxil edin : ");
        
        try
        {
             int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"sizin axtardiginiz mehsul {arr[index]} -dur");
        }
        catch 
        {
            Console.WriteLine("xeta bas verdi");
        }     
       
    }

    static void AddNewProduct( ref string[] arr)
    {
        Console.WriteLine("\n***********YENI MEHSUL ELAVE ETMEK*************");
        showProduct(arr);
        string newProduct;
        string newProductWithoutSpace;
        do
        { Console.WriteLine(" Diqqet: daxil etdiyiniz adin uzunlugu 2 ile 20 arasinda olmalidir!");
            Console.Write("yeni  mehsulun adini daxil edin: ");
            newProduct = Console.ReadLine();
            newProductWithoutSpace = DeleteSpaceInFirstAndlast(newProduct);
            
        } while (newProductWithoutSpace.Length<2 || newProductWithoutSpace.Length>20);
      
        int count = arr.Length + 1;
        string[] newArr = new string[count];
        for (int i = 0; i <arr.Length; i++)
        {
            newArr[i] = arr[i];

        }
        bool varmi=false;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == newProductWithoutSpace)
            {
                varmi = true;
                break;
            }
        }
        if (varmi)
        {
            Console.WriteLine("Xəta: Bu ad ilə artıq bir məhsul mövcuddur");
        }
        else
        {
            newArr[newArr.Length - 1] = newProductWithoutSpace;
            arr = newArr;
            showProduct(arr);
        }
    }
    static string DeleteSpaceInFirstAndlast(string str)
    {
        string newStr = "";
        int firstIndex = DeleteSpaceInFirst(str);
        int lastIndex = DeleteSpaceInLast(str);
        if (firstIndex == -1 || lastIndex==-1) return newStr;
        for (int i = firstIndex; i <= lastIndex; i++)
        {
            newStr += str[i];

        }
        return newStr;
    }


    static int DeleteSpaceInFirst(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != ' ')
            {
                return i;
            }

        }
        return -1;

    }
    static int DeleteSpaceInLast(string str)
    {
        for (int i = str.Length - 1; i >= 0; i--)
        {
            if (str[i] != ' ')
            {
                return i;
            }

        }
        return -1;

    }
    static  void changeProductName(string[] arr)
    {
        showProduct(arr);
        Console.Write("adini deyiseceyiniz indexi daxil edin: ");
        bool check;
        do
        {
            try
            {
                check = false;
          int index = Convert.ToInt32(Console.ReadLine());
          Console.WriteLine($"bu mehsulun adini deyisdireceksiniz:{arr[index]} ");
          Console.Write("yeni adini daxil edin: ");
          string newName = Console.ReadLine();
          arr[index] = DeleteSpaceInFirstAndlast(newName);

            }
            catch 
            {
                check = true;
              Console.WriteLine("xeta bas verdi!");
              Console.Write("yeniden daxil edin: ");

           }

        } while (check);
                
    }
    static void DeleteChoosenProduct( ref string[] arr)
    {
        showProduct(arr);
        Console.Write("silmek istediyiniz indexi daxil edin: ");
        bool check;
        do
        {
         try
        {
          check = false;
        int index = Convert.ToInt32(Console.ReadLine());
        string[] NewArr = new string[arr.Length - 1];
        int say = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (i!= index)
            {
                NewArr[say++] += arr[i];
            }
        }
            arr = NewArr;
        }
        catch 
        {
                check = true;
            Console.WriteLine("Xeta bas verdi!");
                Console.Write("Yeniden daxil edin:");


        }

        } while (check);
       
     
        showProduct(arr);
    }
    
   
}

