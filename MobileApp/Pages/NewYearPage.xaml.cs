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
            Song = "������� �������",
            Author = "���� ������������",
            Wish = @"""�������� �� ����,����,���� �� ���""",
            URL = "https://www.youtube.com/watch?v=5H5bwR1Ly-g",
            Thumbnail = "https://img.youtube.com/vi/5H5bwR1Ly-g/sddefault.jpg"
        },
        new ()
        {
            Song = "������� �������",
            Author = "���� ������������",
            Wish = @"""����, ����, ����, � �� ������ ��-�����. ����� �� �� ������, ������, ���� ���������""",
            URL = "https://www.youtube.com/watch?v=5H5bwR1Ly-g",
            Thumbnail = "https://img.youtube.com/vi/5H5bwR1Ly-g/sddefault.jpg"
        },
        new ()
        {
            Song = "�� ����� �� ������",
            Author = "���� ������������",
            Wish = @"""�� ����� �� ������ �� ����� ���������""",
            URL = "https://www.youtube.com/watch?v=ZftOgZqKagA",
            Thumbnail = "https://img.youtube.com/vi/ZftOgZqKagA/sddefault.jpg"
        },
        new ()
        {
            Song = "������� ��",
            Author = "������ � ����� ��������",
            Wish = @"""����� ��� ����� ���� � ������""",
            URL = "https://www.youtube.com/watch?v=OUzl0UA9e7Y",
            Thumbnail = "https://img.youtube.com/vi/OUzl0UA9e7Y/sddefault.jpg"
        },
        new ()
        {
            Song = "����������",
            Author = "������ � ����� ��������",
            Wish = @"""��� ������� �� ��""",
            URL = "https://www.youtube.com/watch?v=0O5pkAPzroo",
            Thumbnail = "https://img.youtube.com/vi/0O5pkAPzroo/sddefault.jpg"
        },
        new ()
        {
            Song = "��� �� ���������",
            Author = "������ � ���� �������",
            Wish = @"""�� �������� ������ ����""",
            URL = "https://www.youtube.com/watch?v=V6deoIPmJuY",
            Thumbnail = "https://img.youtube.com/vi/V6deoIPmJuY/sddefault.jpg"
        },
        new ()
        {
            Song = "��� �� ���������",
            Author = "������ � ���� �������",
            Wish = @"""�������� �� ������""",
            URL = "https://www.youtube.com/watch?v=V6deoIPmJuY",
            Thumbnail = "https://img.youtube.com/vi/V6deoIPmJuY/sddefault.jpg"
        },
        new ()
        {
            Song = "������ ��",
            Author = "������ � ����� ����",
            Wish = @"""��� ��-����� �� ����� �������""",
            URL = "https://www.youtube.com/watch?v=JlTejHuQm1g",
            Thumbnail = "https://img.youtube.com/vi/JlTejHuQm1g/sddefault.jpg"
        },
        new ()
        {
            Song = "������ ��",
            Author = "������ � ����� ����",
            Wish = @"""����� ���� ����� � ������������ � ������, ���� �������� � �����������""",
            URL = "https://www.youtube.com/watch?v=JlTejHuQm1g",
            Thumbnail = "https://img.youtube.com/vi/JlTejHuQm1g/sddefault.jpg"
        },
        new ()
        {
            Song = "��� �����",
            Author = "���� �����",
            Wish = @"""��� ���� � ���� �� �� �����, ��� ����� � ���� �� ������.""",
            URL = "https://www.youtube.com/watch?v=_fOz-tA-cK4",
            Thumbnail = "https://img.youtube.com/vi/_fOz-tA-cK4/sddefault.jpg"
        },
        new ()
        {
            Song = "������ ������ ���",
            Author = "������",
            Wish = @"""������� �� ����� � �� ����, ������� �� �� �����.""",
            URL = "https://www.youtube.com/watch?v=WlHoH9swZsM",
            Thumbnail = "https://img.youtube.com/vi/WlHoH9swZsM/sddefault.jpg"
        },
        new ()
        {
            Song = "������ ������ ���",
            Author = "������",
            Wish = @"""���� ������ �� �� �����.""",
            URL = "https://www.youtube.com/watch?v=WlHoH9swZsM",
            Thumbnail = "https://img.youtube.com/vi/WlHoH9swZsM/sddefault.jpg"
        },
        new ()
        {
            Song = "WELCOME TO BULGARIA",
            Author = "GALENA x DJ DAMYAN x COSTI",
            Wish = @"""��� ���� ����� ���� ������� ��������� ������� �������""",
            URL = "https://www.youtube.com/watch?v=fWOKxS7wjLc",
            Thumbnail = "https://img.youtube.com/vi/fWOKxS7wjLc/sddefault.jpg"
        },
        new ()
        {
            Song = "WELCOME TO BULGARIA",
            Author = "GALENA x DJ DAMYAN x COSTI",
            Wish = @"""��� �������, ��� ��������""",
            URL = "https://www.youtube.com/watch?v=fWOKxS7wjLc",
            Thumbnail = "https://img.youtube.com/vi/fWOKxS7wjLc/sddefault.jpg"
        },
        new ()
        {
            Song = "�������",
            Author = "���� ������� feat. ������",
            Wish = @"""���� ����� �� �������, ���-������� �� ������!""",
            URL = "https://www.youtube.com/watch?v=yMnjEAduxn8",
            Thumbnail = "https://img.youtube.com/vi/yMnjEAduxn8/sddefault.jpg"
        },
        new ()
        {
            Song = "��� �����",
            Author = "������ � ��������� ����� ft. ����",
            Wish = @"""���, �����, ������ ��� �����""",
            URL = "https://www.youtube.com/watch?v=yMnjEAduxn8",
            Thumbnail = "https://img.youtube.com/vi/yMnjEAduxn8/sddefault.jpg"
        },
        new ()
        {
            Song = "����� ��������",
            Author = "������",
            Wish = @"""����� �������� � ���� �� ���� �����""",
            URL = "https://www.youtube.com/watch?v=VE2sme045MA",
            Thumbnail = "https://img.youtube.com/vi/VE2sme045MA/sddefault.jpg"
        },
        new ()
        {
            Song = "������ ���",
            Author = "������",
            Wish = @"""��� ����� �� �� �������� - ������ ���� � ��� �� ��������""",
            URL = "https://www.youtube.com/watch?v=s3GO1tjEXz0",
            Thumbnail = "https://img.youtube.com/vi/s3GO1tjEXz0/sddefault.jpg"
        },
        new ()
        {
            Song = "�� ����",
            Author = "��������",
            Wish = @"""��� � ��� �� ������.""",
            URL = "https://www.youtube.com/watch?v=ytsiDacjqFI",
            Thumbnail = "https://img.youtube.com/vi/ytsiDacjqFI/sddefault.jpg"
        },
        new ()
        {
            Song = @"����� ""����������""",
            Author = "��������",
            Wish = @"""��� �� ���� � ����� ""����������"" �� ����� �����, ����� ��������!""",
            URL = "https://www.youtube.com/watch?v=RDpyn9xkmxg",
            Thumbnail = "https://img.youtube.com/vi/RDpyn9xkmxg/sddefault.jpg"
        },
        new ()
        {
            Song = "������� ��������",
            Author = "����� ����",
            Wish = @"""�����, ������, ������� ��������""",
            URL = "https://www.youtube.com/watch?v=CSeRVojWaMM",
            Thumbnail = "https://img.youtube.com/vi/CSeRVojWaMM/sddefault.jpg"
        },
        new ()
        {
            Song = "���� ���������",
            Author = "�����",
            Wish = @"""����� �� ����� �� �� ������""",
            URL = "https://www.youtube.com/watch?v=O6BQM6dXZ-w",
            Thumbnail = "https://img.youtube.com/vi/O6BQM6dXZ-w/sddefault.jpg"
        },
        new ()
        {
            Song = "���� ���������",
            Author = "�����",
            Wish = @"""���� �� � ����� ��������� ������ � ��������""",
            URL = "https://www.youtube.com/watch?v=O6BQM6dXZ-w",
            Thumbnail = "https://img.youtube.com/vi/O6BQM6dXZ-w/sddefault.jpg"
        },
        new ()
        {
            Song = "������",
            Author = "���� �������� � ���� ����",
            Wish = @"""�� �������� ������, ���, ���, ���, ���, ��� �� ���� �� �� ����, ���, ���, ���, ���, ����������, �������, �����, ���, ���, ���, ������� �� � ������ � ���.""",
            URL = "https://www.youtube.com/watch?v=tshokdMQsvk",
            Thumbnail = "https://img.youtube.com/vi/tshokdMQsvk/sddefault.jpg"
        },
        new ()
        {
            Song = "�������� ������",
            Author = "����",
            Wish = @"""����� ����� ��� � �������� �������� ������ ������""",
            URL = "https://www.youtube.com/watch?v=RypsV9RDYKc",
            Thumbnail = "https://img.youtube.com/vi/RypsV9RDYKc/sddefault.jpg"
        },
        new ()
        {
            Song = "����� ���������",
            Author = "���� ������������",
            Wish = @"""����, ����� ���������""",
            URL = "https://www.youtube.com/watch?v=uzHKG86K1ps",
            Thumbnail = "https://img.youtube.com/vi/uzHKG86K1ps/sddefault.jpg"
        },
        new ()
        {
            Song = "����� �����",
            Author = "����� ���� ft. ������",
            Wish = @"""����� �����, �� �� ���� ����� ����""",
            URL = "https://www.youtube.com/watch?v=BTtL9pu3mNs",
            Thumbnail = "https://img.youtube.com/vi/BTtL9pu3mNs/sddefault.jpg"
        },
        new ()
        {
            Song = "����� �����",
            Author = "����� ���� ft. ������",
            Wish = @"""������� � �����, ������ � �����, �� ������ �� �������""",
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