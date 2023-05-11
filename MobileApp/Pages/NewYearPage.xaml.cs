using DSLCS.Shared.Models;
using System;

namespace DSLCS.App.Pages;

public partial class NewYearPage : ContentPage
{
    private bool isSpined = false;

    private List<NewYearSong> newYearSongs = new () 
    {
        new ()
        {
            Song = "Коледни желания",
            Author = "Теди Александрова",
            Wish = @"""Подаръци за тебе,тебе,тебе ще има""",
            URL = "https://www.youtube.com/watch?v=5H5bwR1Ly-g",
            Thumbnail = "https://img.youtube.com/vi/5H5bwR1Ly-g/sddefault.jpg"
        },
        new ()
        {
            Song = "Коледни желания",
            Author = "Теди Александрова",
            Wish = @"""Пари, коли, жени, а от всичко по-много. Желая ти ги двойно, тройно, даже стократно""",
            URL = "https://www.youtube.com/watch?v=5H5bwR1Ly-g",
            Thumbnail = "https://img.youtube.com/vi/5H5bwR1Ly-g/sddefault.jpg"
        },
        new ()
        {
            Song = "От София до Банско",
            Author = "Теди Александрова",
            Wish = @"""От София до Банско ще гърми шампанско""",
            URL = "https://www.youtube.com/watch?v=ZftOgZqKagA",
            Thumbnail = "https://img.youtube.com/vi/ZftOgZqKagA/sddefault.jpg"
        },
        new ()
        {
            Song = "Тръгвай си",
            Author = "Емилия и Денис Теофиков",
            Wish = @"""Живот със скъпи коли и разкош""",
            URL = "https://www.youtube.com/watch?v=OUzl0UA9e7Y",
            Thumbnail = "https://img.youtube.com/vi/OUzl0UA9e7Y/sddefault.jpg"
        },
        new ()
        {
            Song = "Единствено",
            Author = "Емилия и Денис Теофиков",
            Wish = @"""Мис Америка ти си""",
            URL = "https://www.youtube.com/watch?v=0O5pkAPzroo",
            Thumbnail = "https://img.youtube.com/vi/0O5pkAPzroo/sddefault.jpg"
        },
        new ()
        {
            Song = "Как да изтрезнея",
            Author = "Емилия и Тони Стораро",
            Wish = @"""Ще похарчиш всички пари""",
            URL = "https://www.youtube.com/watch?v=V6deoIPmJuY",
            Thumbnail = "https://img.youtube.com/vi/V6deoIPmJuY/sddefault.jpg"
        },
        new ()
        {
            Song = "Как да изтрезнея",
            Author = "Емилия и Тони Стораро",
            Wish = @"""Казината ги разори""",
            URL = "https://www.youtube.com/watch?v=V6deoIPmJuY",
            Thumbnail = "https://img.youtube.com/vi/V6deoIPmJuY/sddefault.jpg"
        },
        new ()
        {
            Song = "Обичай ме",
            Author = "Емилия и Борис Дали",
            Wish = @"""Все по-силно на любов прилича""",
            URL = "https://www.youtube.com/watch?v=JlTejHuQm1g",
            Thumbnail = "https://img.youtube.com/vi/JlTejHuQm1g/sddefault.jpg"
        },
        new ()
        {
            Song = "Обичай ме",
            Author = "Емилия и Борис Дали",
            Wish = @"""Стига вече болка и предателства И връзки, дето свършват в приятелства""",
            URL = "https://www.youtube.com/watch?v=JlTejHuQm1g",
            Thumbnail = "https://img.youtube.com/vi/JlTejHuQm1g/sddefault.jpg"
        },
        new ()
        {
            Song = "Две Сърца",
            Author = "Деси Слава",
            Wish = @"""Две души в едно да се слеят, две сърца в едно да живеят.""",
            URL = "https://www.youtube.com/watch?v=_fOz-tA-cK4",
            Thumbnail = "https://img.youtube.com/vi/_fOz-tA-cK4/sddefault.jpg"
        },
        new ()
        {
            Song = "Честит Рожден Ден",
            Author = "Галена",
            Wish = @"""Колкото си хубав и си млад, толкова да си богат.""",
            URL = "https://www.youtube.com/watch?v=WlHoH9swZsM",
            Thumbnail = "https://img.youtube.com/vi/WlHoH9swZsM/sddefault.jpg"
        },
        new ()
        {
            Song = "Честит Рожден Ден",
            Author = "Галена",
            Wish = @"""Нека винаги да ти върви.""",
            URL = "https://www.youtube.com/watch?v=WlHoH9swZsM",
            Thumbnail = "https://img.youtube.com/vi/WlHoH9swZsM/sddefault.jpg"
        },
        new ()
        {
            Song = "WELCOME TO BULGARIA",
            Author = "GALENA x DJ DAMYAN x COSTI",
            Wish = @"""Без пари живее като паралия Алелелеле страшна гъзария""",
            URL = "https://www.youtube.com/watch?v=fWOKxS7wjLc",
            Thumbnail = "https://img.youtube.com/vi/fWOKxS7wjLc/sddefault.jpg"
        },
        new ()
        {
            Song = "WELCOME TO BULGARIA",
            Author = "GALENA x DJ DAMYAN x COSTI",
            Wish = @"""Яко веселба, яко дандания""",
            URL = "https://www.youtube.com/watch?v=fWOKxS7wjLc",
            Thumbnail = "https://img.youtube.com/vi/fWOKxS7wjLc/sddefault.jpg"
        },
        new ()
        {
            Song = "Шефката",
            Author = "ТОНИ СТОРАРО feat. ГАЛЕНА",
            Wish = @"""Имам шефка за милиони, най-добрата на Земята!""",
            URL = "https://www.youtube.com/watch?v=yMnjEAduxn8",
            Thumbnail = "https://img.youtube.com/vi/yMnjEAduxn8/sddefault.jpg"
        },
        new ()
        {
            Song = "Пей Сърце",
            Author = "Галена и Цветелина Янева ft. Азис",
            Wish = @"""Пей, сърце, жегата пак дойде""",
            URL = "https://www.youtube.com/watch?v=yMnjEAduxn8",
            Thumbnail = "https://img.youtube.com/vi/yMnjEAduxn8/sddefault.jpg"
        },
        new ()
        {
            Song = "Стара Каравана",
            Author = "Галена",
            Wish = @"""Стара каравана и море на един метър""",
            URL = "https://www.youtube.com/watch?v=VE2sme045MA",
            Thumbnail = "https://img.youtube.com/vi/VE2sme045MA/sddefault.jpg"
        },
        new ()
        {
            Song = "Просто шоу",
            Author = "Галена",
            Wish = @"""Без десет да не повтарям - смятам бара с теб да затварям""",
            URL = "https://www.youtube.com/watch?v=s3GO1tjEXz0",
            Thumbnail = "https://img.youtube.com/vi/s3GO1tjEXz0/sddefault.jpg"
        },
        new ()
        {
            Song = "От Утре",
            Author = "Преслава",
            Wish = @"""Май и Юни се пропих.""",
            URL = "https://www.youtube.com/watch?v=ytsiDacjqFI",
            Thumbnail = "https://img.youtube.com/vi/ytsiDacjqFI/sddefault.jpg"
        },
        new ()
        {
            Song = @"Режим ""Неприлична""",
            Author = "Преслава",
            Wish = @"""Виж ме сега в режим ""неприлична"" ще стана много, много различна!""",
            URL = "https://www.youtube.com/watch?v=RDpyn9xkmxg",
            Thumbnail = "https://img.youtube.com/vi/RDpyn9xkmxg/sddefault.jpg"
        },
        new ()
        {
            Song = "Пръскам хонорари",
            Author = "Борис Дали",
            Wish = @"""Уиски, цигари, пръскам хонорари""",
            URL = "https://www.youtube.com/watch?v=CSeRVojWaMM",
            Thumbnail = "https://img.youtube.com/vi/CSeRVojWaMM/sddefault.jpg"
        },
        new ()
        {
            Song = "Нещо Нетипично",
            Author = "Ивана",
            Wish = @"""Какво ще кажеш да се напием""",
            URL = "https://www.youtube.com/watch?v=O6BQM6dXZ-w",
            Thumbnail = "https://img.youtube.com/vi/O6BQM6dXZ-w/sddefault.jpg"
        },
        new ()
        {
            Song = "Нещо Нетипично",
            Author = "Ивана",
            Wish = @"""Води ме в някоя квартална кръчма и поръчвай""",
            URL = "https://www.youtube.com/watch?v=O6BQM6dXZ-w",
            Thumbnail = "https://img.youtube.com/vi/O6BQM6dXZ-w/sddefault.jpg"
        },
        new ()
        {
            Song = "Гърмиш",
            Author = "Софи Маринова и Рико Бенд",
            Wish = @"""Да събираме отряда, газ, газ, газ, газ, пак на маса ще се сяда, газ, газ, газ, газ, понеделник, вторник, сряда, газ, газ, газ, градуса да е хиляда с нас.""",
            URL = "https://www.youtube.com/watch?v=tshokdMQsvk",
            Thumbnail = "https://img.youtube.com/vi/tshokdMQsvk/sddefault.jpg"
        },
        new ()
        {
            Song = "Еротична Машина",
            Author = "Пепа",
            Wish = @"""Адски секси мъж и половина еротично огнена машина""",
            URL = "https://www.youtube.com/watch?v=RypsV9RDYKc",
            Thumbnail = "https://img.youtube.com/vi/RypsV9RDYKc/sddefault.jpg"
        },
        new ()
        {
            Song = "Чалга пеперудки",
            Author = "Теди Александрова",
            Wish = @"""Айде, Чалга пеперудки""",
            URL = "https://www.youtube.com/watch?v=uzHKG86K1ps",
            Thumbnail = "https://img.youtube.com/vi/uzHKG86K1ps/sddefault.jpg"
        },
        new ()
        {
            Song = "Някой Богат",
            Author = "Борис Дали ft. Емилия",
            Wish = @"""Някой богат, да ти купи целия свят""",
            URL = "https://www.youtube.com/watch?v=BTtL9pu3mNs",
            Thumbnail = "https://img.youtube.com/vi/BTtL9pu3mNs/sddefault.jpg"
        },
        new ()
        {
            Song = "Някой Богат",
            Author = "Борис Дали ft. Емилия",
            Wish = @"""Закуска в Дубай, вечеря в Париж, на корици да блестиш""",
            URL = "https://www.youtube.com/watch?v=BTtL9pu3mNs",
            Thumbnail = "https://img.youtube.com/vi/BTtL9pu3mNs/sddefault.jpg"
        }
    };

    public NewYearPage()
	{
		InitializeComponent();
        BindingContext = this;

        if (Preferences.ContainsKey("2023_Wish"))
        {
            int index = Preferences.Get("2023_Wish", 0);
            
            SongFrame.IsVisible = true;
            Button.IsVisible = false;
            VideoThumbnail.Source = newYearSongs[index].Thumbnail;
            VideoTitle.Text = newYearSongs[index].Song;
            VideoAuthor.Text = newYearSongs[index].Author;
            Wish.Text = newYearSongs[index].Wish;
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
            
            int randIndex = new Random().Next(newYearSongs.Count);
            Preferences.Set("2023_Wish", randIndex);

            SongFrame.IsVisible = true;
            Button.IsVisible = false;
            VideoThumbnail.Source = newYearSongs[randIndex].Thumbnail;
            VideoTitle.Text = newYearSongs[randIndex].Song;
            VideoAuthor.Text = newYearSongs[randIndex].Author;
            Wish.Text = newYearSongs[randIndex].Wish;
        }    
    }

    private async void GoToArtist(object sender, TappedEventArgs e)
    {
        try
        {
            Uri uri = new(newYearSongs[Preferences.Get("2023_Wish", 0)].URL);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    protected async void OnBackButtonTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//main");
    }

    protected async void OnSingerButtonPressed(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//newyearsinger");
    }
}