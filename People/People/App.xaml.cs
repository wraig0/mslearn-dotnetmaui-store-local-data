﻿namespace People;

public partial class App : Application
{
    public static PersonRepository PersonRepo { get; set; }

    public App(PersonRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

        // TODO: Initialize the PersonRepository property with the PersonRespository singleton object
        PersonRepo = repo;
    }
}
