using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

public class Book
{
    // Kitap sınıfının nitelikleri
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int NumberOfCopies { get; set; }
    public int BorrowedCopies { get; set; }

    // Kitap sınıfının yapıcı metodu
    public Book(string title, string author, string isbn, int numberOfCopies)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        NumberOfCopies = numberOfCopies;
        BorrowedCopies = 0; // Başlangıçta ödünç alınan kopya yok
    }

    // Kitabı ödünç alma
    public void BorrowIt()
    {
        if (NumberOfCopies > BorrowedCopies)
        {
            BorrowedCopies++;
            Console.WriteLine($"\"{Title}\" adlı kitabı ödünç aldınız.");
        }
        else
        {
            Console.WriteLine($"Üzgünüz, \"{Title}\" adlı kitap şu anda tükenmiş durumda.");
        }
    }

    // Kitabı iade et
    public void ReturnIt()
    {
        if (BorrowedCopies > 0)
        {
            BorrowedCopies--;
            Console.WriteLine($"\"{Title}\" adlı kitabı iade ettiniz.");
        }
        else
        {
            Console.WriteLine("Ödünç alınmış kitap bulunmamaktadır.");
        }
    }
}

public class LibraryManagementSystem
{
    private List<Book> books = new List<Book>();

    // Kütüphaneye yeni bir kitap ekleme.
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"{book.Title} kütüphaneye eklendi.");
        //Console.WriteLine($"{kitap.Yazar} kutuphaneye eklendi.");
    }

    // kütüphanedeki kitapların listesi.
    public void ListAllBooks()
    {
        Console.WriteLine("Kütüphanedeki Tüm Kitaplar:");
        foreach (var book in books)
        {
            Console.WriteLine(book.Title);
        }
    }

    // kitabı başlığına ve yazarına göre arama
    public void SearchBook(string searchWord)
    {
        Console.WriteLine($"Arama Sonuçları \"{searchWord}\" ile:");
        foreach (var book in books)
        {
            if (book.Title.Contains(searchWord) || book.Author.Contains(searchWord))
            {
                Console.WriteLine($"{book.Title} - {book.Author}");
            }
        }
    }

    // Bir kitabı ödünç al.
    public void BorrowABook(string bookName)
    {
        var book = books.Find(k => k.Title == bookName);
        if (book != null)
        {
            book.BorrowIt();
        }
        else
        {
            Console.WriteLine("Bu kitap kütüphanede mevcut değil.");
        }
    }

    // Kitabı iade et.
    public void ReturnBook(string bookName)
    {
        var book = books.Find(k => k.Title == bookName);
        if (book != null)
        {
            book.ReturnIt();
        }
        else
        {
            Console.WriteLine("Bu kitap kütüphanede mevcut değil.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        LibraryManagementSystem LMS = new LibraryManagementSystem();

        // kitap örnekleri
        Book book1 = new Book("Harry Potter ve Felsefe Taşı", "J.K. Rowling", "9789750800759", 5);
        Book book2 = new Book("Satranç", "Stefan Zweig", "9789753638018", 3);
        Book book3 = new Book("Romeo and Juliet", "William Shakespeare", "9780671722852", 2);

        // kitaplar kütüphaneye ekleme
        LMS.AddBook(book1);
        LMS.AddBook(book2);
        LMS.AddBook(book3);

        // Kullanıcının menü seçenekleri
        Console.WriteLine("Kütüphane Yönetim Sistemine Hoş Geldiniz!");
        Console.WriteLine("1. Yeni Kitap Ekle");
        Console.WriteLine("2. Tüm Kitapları Listele");
        Console.WriteLine("3. Kitap Ara");
        Console.WriteLine("4. Kitap Ödünç Al");
        Console.WriteLine("5. Kitap İade Et");
        Console.WriteLine("6. Çıkış");

        // Kullanıcının seçim yapacağı yer.
        bool continued = true;
        while (continued)
        {
            Console.Write("Seçiminizi yapınız: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Eklemek istediğiniz kitabın adını girin: ");
                    string newBookName = Console.ReadLine();
                    Console.Write("Yazarını girin: ");
                    string newBookAuthor = Console.ReadLine();
                    Console.Write("ISBN numarasını girin: ");
                    string newBookISBN = Console.ReadLine();
                    Console.Write("Kopya sayısını girin: ");
                    int newBookCopyNumber = Convert.ToInt32(Console.ReadLine());
                    Book newBook = new Book(newBookName, newBookAuthor, newBookISBN, newBookCopyNumber);
                    LMS.AddBook(newBook);
                    break;
                case 2:
                    LMS.ListAllBooks();
                    break;
                case 3:
                    Console.Write("Aramak istediğiniz kelimeyi girin: ");
                    string searchWord = Console.ReadLine();
                    LMS.SearchBook(searchWord);
                    break;
                case 4:
                    Console.Write("Ödünç almak istediğiniz kitabın adını girin: ");
                    string borrowABook = Console.ReadLine();
                    LMS.BorrowABook(borrowABook);
                    break;
                case 5:
                    Console.Write("İade etmek istediğiniz kitabın adını girin: ");
                    string bookReturn = Console.ReadLine();
                    LMS.ReturnBook(bookReturn);
                    break;
                case 6:
                    continued = false;
                    Console.WriteLine("Çıkış yapılıyor...");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
                    
            }
           
        }
    }
}