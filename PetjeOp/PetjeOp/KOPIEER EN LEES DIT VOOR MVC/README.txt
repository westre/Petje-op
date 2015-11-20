(outdated)

We gaan ervan uit dat we MainMenu willen implementeren

1. Maak de map MainMenu
2. Kopieer de klassen JOUWKLASSEController.cs, JOUWKLASSEModel.cs en JOUWKLASSEView.cs naar de map MainMenu
3. Hernoem JOUWKLASSEController.cs, JOUWKLASSEModel.cs en JOUWKLASSEView.cs naar MainMenuController.cs, MainMenuModel.cs en MainMenuView.cs respectievelijk
4. Open bestand MainMenuController.cs en verander alle JOUWKLASSEController naar MainMenuController
5. Herhaal dit voor JOUWKLASSEModel en JOUWKLASSEView
6. Check nadat je dit allemaal hebt gedaan of MainMenuView nog werkt (de designer!) en je geen enkel verwijzing hebt naar JOUWKLASSE
7. Ga naar MasterController
8. Declareer: private MainMenuController MainMenuController { get; set; }
9. Declareer in Controllers enum: MainMenuController
10. Voeg in SetController functie dit toe:

else if (controller == Controllers.MainMenuController)
{
    mainPanel.Controls.Add(MainMenuController.View);
}

11. :D