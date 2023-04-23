namespace MatchingApp;

using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
public partial class ChatPage : ContentPage
{
    private HubConnection _hubConnection;
    public ObservableCollection<Message> Messages { get; } = new ObservableCollection<Message>();

    public ChatPage()
    {
        InitializeComponent();
        MessagesListView.ItemsSource = Messages;


        // MessageEntry��TextChanged�C�x���g�Ƀn���h����ǉ�
        MessageEntry.TextChanged += MessageEntry_TextChanged;
    }

    // MessageEntry_TextChanged���\�b�h��ǉ�
    private void MessageEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        SendButton.IsEnabled = !string.IsNullOrEmpty(e.NewTextValue);
    }


    [Obsolete]

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        _hubConnection = new HubConnectionBuilder()
            .WithUrl("https://matcingapp.azurewebsites.net/chathub")
            .Build();


        // ���[�U����Preferences����ǂݍ��݁AUsernameEntry�ɐݒ肵�܂��B
        var savedUsername = Preferences.Get("Username", string.Empty);
        UsernameEntry.Text = savedUsername;

        _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            var receivedMessage = new Message
            {
                Username = user,
                MessageContent = message
            };
            Device.BeginInvokeOnMainThread(() =>
            {
                Messages.Add(receivedMessage);
                MessagesListView.ScrollTo(receivedMessage, ScrollToPosition.End, true);
            });
        });

        _hubConnection.On<int>("UpdateConnectedUsersCount", (count) =>
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ConnectedUsersLabel.Text = $"�l���F{count}�l";
            });
        });


        await _hubConnection.StartAsync();
    }

    private async void SendButton_Clicked(object sender, System.EventArgs e)
    {
        var username = UsernameEntry.Text;
        var message = MessageEntry.Text;

        // ���[�U����Preferences�ɕۑ����܂��B
        Preferences.Set("Username", username);

        //���b�Z�[�W�����͂���Ă��Ȃ��ꍇ�͉������Ȃ��B
        if (string.IsNullOrEmpty(message))
        {
            return;
        }


        await _hubConnection.SendAsync("SendMessage", username, message);
        MessageEntry.Text = string.Empty;
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();

        if (_hubConnection != null)
        {
            await _hubConnection.DisposeAsync();
            _hubConnection = null;
        }
    }
}

public class Message : INotifyPropertyChanged
{
    private string _username;
    private string _messageContent;


    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }

    public string MessageContent
    {
        get => _messageContent;
        set
        {
            _messageContent = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

