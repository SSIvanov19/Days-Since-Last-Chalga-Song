using DSLCS.Shared.Models;

namespace DSLCS.App.Pages;

public partial class NewYearPageSinger : ContentPage
{
    private bool isSpined = false;

    private List<Singer> newYearSingers = new()
    {
        new ()
        {
            Name = "Азис",
            Image = "https://i.id24.bg/i/1099175.jpg"
        },
        new ()
        {
            Name = "Теди Александрова",
            Image = "https://payner.bg/images/uploads/Artist_images/TEDI_ALEKSANDROVA_DECEMBER_2021.jpg"
        },
        new ()
        {
            Name = "Алисия",
            Image = "https://signal.bg/wp-content/uploads/2021/12/Alisiya-1.jpg"
        },
        new ()
        {
            Name = "Анелия",
            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6b/Anelialive.jpg/250px-Anelialive.jpg"
        },
        new ()
        {
            Name = "Галена",
            Image = "https://ezine.bg/files/lib/400x296/galena-3.jpg"
        },
        new ()
        {
            Name = "Галин",
            Image = "https://i.pik.bg/news/985/660_3d587347093c1fbee191f4a567709f3d.jpg"
        },
        new ()
        {
            Name = "Борис Дали",
            Image = "https://signal.bg/wp-content/uploads/2018/02/photo_orig_38783.jpg"
        },
        new ()
        {
            Name = "Деси Слава",
            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/Desi_Slava.jpg/250px-Desi_Slava.jpg"
        },
        new ()
        {
            Name = "Джена",
            Image = "https://signal.bg/wp-content/uploads/2022/11/Djena-3.jpg"
        },
        new ()
        {
            Name = "Емануела",
            Image = "https://secret.bg/wp-content/uploads/2021/03/556-6-880x509.png"
        },
        new ()
        {
            Name = "Емилия",
            Image = "https://signal.bg/wp-content/uploads/2021/07/EMILIA.jpg"
        },
        new ()
        {
            Name = "Ивана",
            Image = "https://signal.bg/wp-content/uploads/2022/12/Ivana-1.jpg"
        },
        new ()
        {
            Name = "Милко Калайджиев",
            Image = "https://cdn.marica.bg/images/marica.bg/762/2-%D0%BC%D0%B8%D0%BB%D0%BA%D0%BE1.jpg"
        },
        new ()
        {
            Name = "Кали",
            Image = "https://static.standartnews.com/storage/thumbnails/inner_article/6816/2542/3066/%D0%BA%D0%B0%D0%BB%D0%B8.jpg"
        },
        new ()
        {
            Name = "Камелия",
            Image = "https://img.novini.bg/uploads/profiles_pictures/0/big/Kameliya-476.jpg"
        },
        new ()
        {
            Name = "Кондьо",
            Image = "https://fentv.bg/wp-content/uploads/2021/02/kondio.jpg"
        },
        new ()
        {
            Name = "Софи Маринова",
            Image = "https://cdn.marica.bg/images/marica.bg/333/640_333771.jpeg"
        },
        new ()
        {
            Name = "Меди",
            Image = "https://4vlast-bg.com/wp-content/uploads/2021/10/%D0%BC%D0%B5%D0%B4%D0%B8.jpg"
        },
        new ()
        {
            Name = "Пепа",
            Image = "https://i.ytimg.com/vi/IIOGw8bkfK8/maxresdefault.jpg"
        },
        new ()
        {
            Name = "Преслава",
            Image = "https://img.novini.bg/uploads/profiles_pictures/0/big/Preslava-474.jpg"
        },
        new ()
        {
            Name = "Радо Шишарката",
            Image = "https://signal.bg/wp-content/uploads/2018/12/%D0%A0%D0%B0%D0%B4%D0%BE-%D0%A8%D0%B8%D1%88%D0%B0%D1%80%D0%BA%D0%B0%D1%82%D0%B0.jpg"
        },
        new ()
        {
            Name = "Сашо Роман",
            Image = "https://i.ytimg.com/vi/8vMNX0SzNe4/maxresdefault.jpg"
        },
        new ()
        {
            Name = "Лидия",
            Image = "https://signal.bg/wp-content/uploads/2021/10/Lidiya.jpg"
        },
        new ()
        {
            Name = "Тони Стораро",
            Image = "https://fentv.bg/wp-content/uploads/2021/01/toni-storaro.jpg"
        },
        new ()
        {
            Name = "Фики Стораро",
            Image = "https://radioultra.bg/wp-content/uploads/2022/06/768x432.jpg"
        },
        new ()
        {
            Name = "Яница",
            Image = "https://trafficnews.bg/news/2022/08/09/pop-folk-pevitsata-yanitsa-stana-maika-676.png"
        },
    };

    public NewYearPageSinger()
    {
        InitializeComponent();
        BindingContext = this;

        if (Preferences.ContainsKey("2023_Singer"))
        {
            int index = Preferences.Get("2023_Singer", 0);

            SongFrame.IsVisible = true;
            Button.IsVisible = false;
            VideoThumbnail.Source = newYearSingers[index].Image;
            VideoTitle.Text = newYearSingers[index].Name;
        }
    }

    protected override bool OnBackButtonPressed()
    {
        Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//main");
        });

        return true;
    }

    protected async void RotateTheWhell(object sender, EventArgs e)
    {
        if (!isSpined)
        {
            isSpined = true;
            var deg = new Random().NextDouble() * (5400 - 3600) + 5400;
            await Wheel.RotateTo(deg, 5000, Easing.SinInOut);

            int randIndex = new Random().Next(newYearSingers.Count);
            Preferences.Set("2023_Singer", randIndex);

            SongFrame.IsVisible = true;
            Button.IsVisible = false;
            VideoThumbnail.Source = newYearSingers[randIndex].Image;
            VideoTitle.Text = newYearSingers[randIndex].Name;
        }
    }

    protected async void OnBackButtonTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//main");
    }

    protected async void OnSongButtonPressed(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//newyear");
    }
}