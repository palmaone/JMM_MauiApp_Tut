﻿using CommunityToolkit.Mvvm.ComponentModel;


namespace JMM_MauiApp_Tut.ViewModel;

public partial class BaseViewModel : ObservableObject
{

    public BaseViewModel() { }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;

    [ObservableProperty]
    private string title;

    public bool IsNotBusy => !IsBusy;
}

