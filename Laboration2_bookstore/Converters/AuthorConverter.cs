using Laboration2_bookstore.Model;
using System.Globalization;
using System.Windows.Data;

public class AuthorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var bookAuthors = value as ICollection<BookAuthor>;
        return bookAuthors != null
            ? string.Join(", ", bookAuthors.Select(ba => $"{ba.Author.FirstName} {ba.Author.LastName}"))
            : string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}